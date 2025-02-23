using System;

namespace JGEmulator
{
    public class InstructionCounter
    {
        private byte _value;
        private Computer _thiscomputer;

        public InstructionCounter(Computer thiscomputer)
        {
            _thiscomputer = thiscomputer;
            _value = 0;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Instruction Counter initialized.", "INC"));
        }

        public byte Value
        {
            get { return (byte)(_value & 0x07); } // 3-bit value
        }

        public void Increment()
        {
            _value++;
            if ((_value & 0x07) == 0x05) // Reset to 000 after 6 pulses (binary 100)
            {
                _value = 0;
            }
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Instruction Counter incremented to {Convert.ToString(Value, 2).PadLeft(3, '0')}", "INC"));
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, _value.ToString(), "INC"));

        }

        public void Reset()
        {
            _value = 0;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Instruction Counter reset.", "INC"));
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, _value.ToString(), "INC"));
        }
    }
}





