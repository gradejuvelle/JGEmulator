using System;

namespace JGEmulator
{
    public class Memory
    {
        private readonly byte[] _memory; // Change to byte array to hold 8-bit words
        public BusState State { get; set; } // Add BusState property
        public byte SelectedAddress { get; set; } // Add SelectedAddress property

        public Memory()
        {
            _memory = new byte[16]; // 16 8-bit words
            State = BusState.None;
            SelectedAddress = 0;

            // Initialize the first two words

            //LDA Test
            //_memory[0] = 0b00010110; // LDA 6
            //_memory[1] = 0b11110000; // HLT
            //_memory[2] = 0b00000000; // 
            //_memory[3] = 0b00000000; // 
            //_memory[4] = 0b00000000; // 
            //_memory[5] = 0b00000000; // 
            //_memory[6] = 0b10000000; // 128 in binary

            //sta test
            //_memory[0] = 0b00010110; // lda 6
            //_memory[1] = 0b01000101; // sta 5
            //_memory[2] = 0b11110000; // hlt
            //_memory[3] = 0b00000000; // 
            //_memory[4] = 0b00000000; // 
            //_memory[5] = 0b00000000; // 
            //_memory[6] = 0b10000000; // 128 in binary

            //ADD Test
            //_memory[0] = 0b00010110; // lda 6
            //_memory[1] = 0b00100101; // add 5
            //_memory[2] = 0b11110000; // hlt
            //_memory[3] = 0b00000000; // 
            //_memory[4] = 0b00000000; // 
            //_memory[5] = 0b00000001; // 
            //_memory[6] = 0b10000000; // 128 in binary

            //SUB Test
            //_memory[0] = 0b00010110; // lda 6
            //_memory[1] = 0b00110101; // sub 5
            //_memory[2] = 0b11110000; // hlt
            //_memory[3] = 0b00000000; // 
            //_memory[4] = 0b00000000; // 
            //_memory[5] = 0b10000001; // 
            //_memory[6] = 0b10000000; // 128 in binary

            //JMP Test
            _memory[0] = 0b00010110; // lda 6
            _memory[1] = 0b00100101; // add 5
            _memory[2] = 0b01100001; // jmp 1
            _memory[3] = 0b00000000; // 
            _memory[4] = 0b00000000; // 
            _memory[5] = 0b00000001; // 
            _memory[6] = 0b00000000; // 128 in binary

            //_memory[0] = 0b00010110; // LDA 6
            //_memory[1] = 0b01000100; // STA 5
            //_memory[2] = 0b11100011; // LDI 3
            //_memory[3] = 0b11100000; // OUT
            //_memory[4] = 0b11110000; // HLT
            //_memory[5] = 0b00000000; // 2 in binary
            //_memory[6] = 0b00000010; // 2 in binary

            Console.WriteLine("MEM - Memory initialized with initial values for testing.");
        }

        public void WriteToBus(Bus bus)
        {
            if (State == BusState.Writing) // Use the Memory's state
            {
                string addressBinary = Convert.ToString(SelectedAddress, 2).PadLeft(4, '0');
                string valueBinary = Convert.ToString(_memory[SelectedAddress], 2).PadLeft(8, '0');
                Console.WriteLine($"        MEM - Putting new value on the bus from address {addressBinary}. {valueBinary}");
                bus.Write(_memory[SelectedAddress]);
            }
        }

        public void ReadFromBus(Bus bus)
        {
            if (State == BusState.Reading) // Use the Memory's state
            {
                Console.WriteLine($"        MEM - Reading from bus.");
                _memory[SelectedAddress] = bus.Read();
                string addressBinary = Convert.ToString(SelectedAddress, 2).PadLeft(4, '0');
                string valueBinary = Convert.ToString(_memory[SelectedAddress], 2).PadLeft(8, '0');

            }
        }

        public void SetSelectedAddress(byte address)
        {
            SelectedAddress = address;
            string addressBinary = Convert.ToString(SelectedAddress, 2).PadLeft(4, '0');
            Console.WriteLine($"            MEM - Selected address updated to {addressBinary}");
        }
    }
}

