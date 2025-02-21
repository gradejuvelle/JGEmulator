using System;

namespace JGEmulator
{
    public class ProgramCounter
    {
        public byte Value { get; set; } // 4-bit value, stored in an 8-bit byte
        private BusState State { get; set; }
        private bool CounterEnable; // Counter enable property
        private Computer _thiscomputer;

        public ProgramCounter(Computer computer)
        {
            _thiscomputer = computer;
            //SetValue(0);
            //SetBusState( BusState.None);
            //CounterEnable = false; // Default to false
            //string valueBinary = Convert.ToString(Value, 2).PadLeft(4, '0');
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Program Counter initialized.", "PRG"));
        }

        public bool IsCounterEnabled()
        {
            return CounterEnable;
        }
        public void SetCounterEnable(bool enable)
        {
            CounterEnable = enable;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterFlag, enable.ToString(), "PRGEnable"));
        }
        public BusState GetBusState()
        {
            return State;
        }

        public void SetBusState(BusState state)
        {
            State = state;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.BusState, State.ToString(), "PRG"));
        }
        public byte GetValue()
        {
            return Value;
        }

        public void SetValue(byte value)
        {
            Value = value;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, value.ToString(), "PRG"));
        }
        public void WriteToBus(Bus bus)
        {
            string valueBinary = Convert.ToString(Value & 0x0F, 2).PadLeft(4, '0');
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Putting value on the bus. {valueBinary}", "PRG"));
            // Write only the rightmost 4 bits to the bus and zero out the left 4 bits
            bus.Write(Value & 0x0F); // Ensuring left 4 bits are zeroed out
        }

        public void ReadFromBus(Bus bus)
        {
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Reading from bus.", "PRG"));
            byte data = bus.Read();
            string dataBinary = Convert.ToString(data & 0x0F, 2).PadLeft(4, '0');
            // Read only the rightmost 4 bits from the bus
            Value = (byte)((Value & 0xF0) | (data & 0x0F));
        }

        public void Increment()
        {
            if (CounterEnable)
            {
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Incrementing Program Counter.", "PRG"));

                SetValue( (byte)((Value + 1) & 0x0F)); // Increment and keep only the rightmost 4 bits
                string valueBinary = Convert.ToString(Value, 2).PadLeft(4, '0');
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Program Counter incremented to {valueBinary}", "PRG"));
            }
        }

        public void EnableCounter()
        {
            SetCounterEnable(true);
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Counter enabled.", "PRG"));
        }

        public void DisableCounter()
        {
            SetCounterEnable(false);
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Counter disabled.", "PRG"));
        }

        public void Reset()
        {
            SetValue(0);
            SetBusState(BusState.None);
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Program Counter reset.", "PRG"));
        }
    }
}



