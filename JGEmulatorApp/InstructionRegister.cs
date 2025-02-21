using System;

namespace JGEmulator
{
    public class InstructionRegister
    {
        private byte _value; // 8-bit value
        private BusState _state;
        private Computer _thiscomputer;

        public InstructionRegister(Computer thiscomputer)
        {
            _thiscomputer = thiscomputer;
            //SetValue(0);
            //_state = BusState.None;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Instruction Register initialized.", "INS"));
        }

        public byte GetValue()
        {
            return _value;
        }

        public void SetValue(byte value)
        {
            _value = value;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, value.ToString(), "INS"));
        }

        public BusState GetBusState()
        {
            return _state;
        }

        public void SetBusState(BusState state)
        {
            _state = state;

            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.BusState, state.ToString(), "INS"));
        }

        public void WriteToBus(Bus bus)
        {
            if (_state == BusState.Writing)
            {
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Writing to bus.", "INS"));
                // Combine the left four bits as 0 and the right four bits from the instruction register value
                byte valueToWrite = (byte)(_value & 0x0F);
                bus.Write(valueToWrite);
            }
        }

        public void ReadFromBus(Bus bus)
        {
            if (_state == BusState.Reading)
            {
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Reading from bus.", "INS"));
                // Read the full 8 bits from the bus
                SetValue(bus.Read());

                // Decode the value and display a console message with the instruction
                byte opcode = (byte)(_value >> 4); // Get the left 4 bits
                string instruction = opcode switch
                {
                    0x0 => "NOP started",
                    1 => "LDA started",
                    0x2 => "ADD started",
                    0x3 => "SUB started",
                    0x4 => "STA started",
                    0x5 => "LDI started",
                    0x6 => "JMP started",
                    0x7 => "JC started",
                    0x8 => "JZ started",
                    0xE => "OUT started",
                    0xF => "HLT started",
                    _ => "Unknown instruction"
                };
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, instruction, "INS"));
            }
        }

        public void Reset()
        {
            SetValue(0);
            SetBusState(BusState.None);
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Instruction Register reset.", "INS"));
        }
    }
}










