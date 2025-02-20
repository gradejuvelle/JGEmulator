using System;

namespace JGEmulator
{
    public class ProgramCounter
    {
        public byte Value { get; set; } // 4-bit value, stored in an 8-bit byte
        public BusState State { get; set; }
        public bool CounterEnable { get; set; } // Counter enable property
        private Computer _thiscomputer;
        public ProgramCounter(Computer computer)
        {
            _thiscomputer = computer;
            Value = 0;
            State = BusState.None;
            CounterEnable = false; // Default to false
            string valueBinary = Convert.ToString(Value, 2).PadLeft(4, '0');
            _thiscomputer.DisplayMessage($"PC - Program Counter initialized. Value: {valueBinary}");
        }

        public void WriteToBus(Bus bus)
        {

                string valueBinary = Convert.ToString(Value & 0x0F, 2).PadLeft(4, '0');
            _thiscomputer.DisplayMessage($"        PC - Putting value on the bus. {valueBinary}");
                // Write only the rightmost 4 bits to the bus and zero out the left 4 bits
                bus.Write(Value & 0x0F); // Ensuring left 4 bits are zeroed out

        }

        public void ReadFromBus(Bus bus)
        {

            _thiscomputer.DisplayMessage($"            PC - Reading from bus.");
                byte data = bus.Read();
                string dataBinary = Convert.ToString(data & 0x0F, 2).PadLeft(4, '0');
                // Read only the rightmost 4 bits from the bus
                Value = (byte)((Value & 0xF0) | (data & 0x0F));

        }

        public void Increment()
        {
            if (CounterEnable)
            {
                Value = (byte)((Value + 1) & 0x0F); // Increment and keep only the rightmost 4 bits
                string valueBinary = Convert.ToString(Value, 2).PadLeft(4, '0');
                _thiscomputer.DisplayMessage($"        PC - Program Counter incremented to {valueBinary}");
            }
        }

        public void EnableCounter()
        {
            CounterEnable = true;
            _thiscomputer.DisplayMessage("    PC - Counter enabled.");
        }

        public void DisableCounter()
        {
            CounterEnable = false;
            _thiscomputer.DisplayMessage("    PC - Counter disabled.");
        }

        public void Reset()
        {
            Value = 0;
            State = BusState.None;
            _thiscomputer.DisplayMessage($"    PC - Register reset.");
        }
    }
}





