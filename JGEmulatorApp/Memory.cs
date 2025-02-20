using System;

namespace JGEmulator
{
    public class Memory
    {
        private readonly byte[] _memory; // Change to byte array to hold 8-bit words
        public BusState State { get; set; } // Add BusState property
        public byte SelectedAddress { get; set; } // Add SelectedAddress property
        private readonly Computer _computer;

        public Memory(Computer computer)
        {
            _computer = computer;
            _memory = new byte[16]; // 16 8-bit words
            State = BusState.None;
            SelectedAddress = 0;

            // Initialize the first two words
            _memory[0] = 0b00011110; // lda 14
            _memory[1] = 0b00111100; // sub 12
            _memory[2] = 0b01110110; // jc 6
            _memory[3] = 0b00011101; // lda 13 
            _memory[4] = 0b11100000; // out
            _memory[5] = 0b11110000; // hlt
            _memory[6] = 0b01001110; // sta 14
            _memory[7] = 0b00011101; // lda 13
            _memory[8] = 0b00101111; // add 15
            _memory[9] = 0b01001101; // sta 13
            _memory[10] = 0b01100000; // jmp 0
            _memory[11] = 0b00000000; // 0
            _memory[12] = 0b00000001; // 1
            _memory[13] = 0b00000000; // 0
            _memory[14] = 0b00000011; // 3
            _memory[15] = 0b00000101; // 5

            _computer.DisplayMessage("MEM - Memory initialized with initial values for testing.");
        }

        public void WriteToBus(Bus bus)
        {
            if (State == BusState.Writing) // Use the Memory's state
            {
                string addressBinary = Convert.ToString(SelectedAddress, 2).PadLeft(4, '0');
                string valueBinary = Convert.ToString(_memory[SelectedAddress], 2).PadLeft(8, '0');
                _computer.DisplayMessage($"        MEM - Putting new value on the bus from address {addressBinary}. {valueBinary}");
                bus.Write(_memory[SelectedAddress]);
            }
        }

        public void ReadFromBus(Bus bus)
        {
            if (State == BusState.Reading) // Use the Memory's state
            {
                _computer.DisplayMessage("        MEM - Reading from bus.");
                _memory[SelectedAddress] = bus.Read();
                string addressBinary = Convert.ToString(SelectedAddress, 2).PadLeft(4, '0');
                string valueBinary = Convert.ToString(_memory[SelectedAddress], 2).PadLeft(8, '0');
                _computer.DisplayMessage($"        MEM - Value read from bus: {valueBinary}");
            }
        }

        public void SetSelectedAddress(byte address)
        {
            SelectedAddress = address;
            string addressBinary = Convert.ToString(SelectedAddress, 2).PadLeft(4, '0');
            _computer.DisplayMessage($"            MEM - Selected address updated to {addressBinary}");
            _computer.OnRegisterValueChanged("MAR", SelectedAddress);
        }
    }
}
