using System;

namespace JGEmulator
{
    public class MemoryAddressRegister
    {
        public byte Value { get; set; } // 4-bit value, stored in an 8-bit byte

        public BusState State { get; set; }
        private Computer _thiscomputer;
        public MemoryAddressRegister(Computer computer)
        {
            _thiscomputer = computer;
            Value = 0;
            State = BusState.None;
            _thiscomputer.DisplayMessage("MAR - Memory Address Register initialized.");
        }

        public void WriteToBus(Bus bus)
        {
            if (State == BusState.Writing)
            {
                _thiscomputer.DisplayMessage($"        MAR - Putting value on the bus. {Value & 0x0F}");
                // Write only the rightmost 4 bits to the bus and zero out the left 4 bits
                bus.Write(Value & 0x0F); // Ensuring left 4 bits are zeroed out

            }
        }

        public void ReadFromBus(Bus bus, Memory memory)
        {
            if (State == BusState.Reading)
            {
                _thiscomputer.DisplayMessage($"        MAR - Reading from bus.");
                // Read only the rightmost 4 bits from the bus
                byte data = bus.Read();
                Value = (byte)((Value & 0xF0) | (data & 0x0F));


                // Update the selected address in the memory using a method
                memory.SetSelectedAddress(Value);
            }
        }
        public void Reset()
        {
            Value = 0;
            State = BusState.None;
            _thiscomputer.DisplayMessage($"    MAR - Register reset.");
        }
    }
}


