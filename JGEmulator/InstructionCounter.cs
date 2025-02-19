using System;

namespace JGEmulator
{
    public class InstructionCounter
    {
        private byte _value;

        public InstructionCounter()
        {
            _value = 0;
            Console.WriteLine("IC - Instruction Counter initialized with value 000.");
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
            Console.WriteLine($"        IC - Instruction Counter incremented to {Convert.ToString(Value, 2).PadLeft(3, '0')}");
        }

        public void Reset()
        {
            _value = 0;
            Console.WriteLine("         IC - Instruction Counter reset to 000.");
        }
    }
}
