﻿using System;
using System.Security.Cryptography.X509Certificates;

namespace JGEmulator
{
    public class Memory
    {
        private  byte[] _memory; // Change to byte array to hold 8-bit words
        private readonly byte[] _resetmemory;
        private BusState _state; // Add BusState property
        private byte _selectedAddress; // Add SelectedAddress property
        private Computer _thiscomputer;
        private byte SelectedValue;


        public byte GetSelectedValue()
        {
            return SelectedValue;
        }

        public void SetSelectedValue()
        {
            SelectedValue = _memory[_selectedAddress];
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, SelectedValue.ToString(), "MEM"));
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Memory,_selectedAddress.ToString()+":"+ GetSelectedValue().ToString(), "MEM"));


        }

        public byte[] GetMemory()
        {
            return _memory;
        }


        public BusState GetBusState()
        {
            return _state;
        }

        public void SetBusState(BusState state)
        {
            _state = state;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.BusState, state.ToString(), "MEM"));
        }

        public byte GetSelectedAddress()
        {
            return _selectedAddress;
        }

        public void SetSelectedAddress(byte address)
        {
            _selectedAddress = address;
            string addressBinary = Convert.ToString(_selectedAddress, 2).PadLeft(4, '0');
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Selected address updated to {addressBinary}", "MEM"));
            SetSelectedValue();
        }

        public void WriteToBus(Bus bus)
        {
            if (_state == BusState.Writing) // Use the Memory's state
            {
                string addressBinary = Convert.ToString(_selectedAddress, 2).PadLeft(4, '0');
                string valueBinary = Convert.ToString(_memory[_selectedAddress], 2).PadLeft(8, '0');
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Putting new value on the bus from address {addressBinary}. {valueBinary}", "MEM"));
                bus.Write(_memory[_selectedAddress]);
            }
        }

        public void ReadFromBus(Bus bus)
        {
            if (_state == BusState.Reading) // Use the Memory's state
            {
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Reading from bus.", "MEM"));
                _memory[_selectedAddress] = bus.Read();
                string addressBinary = Convert.ToString(_selectedAddress, 2).PadLeft(4, '0');
                string valueBinary = Convert.ToString(_memory[_selectedAddress], 2).PadLeft(8, '0');
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Value read from bus: {valueBinary}", "MEM"));
            }
        }

        public void Reset()
        {
            SetSelectedAddress(0);
            SetBusState(BusState.None);
            LoadMemory(_thiscomputer.selectedProgram);
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Address reset.", "MEM"));

            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Computer, "Reset", "MEM"));
        }



        public void LoadMemory(string program)
        {
            switch (program)
            {
                case "Empty":
                    _memory[0] = 0b00000000; // LDA 6
                    _memory[1] = 0b00000000; // HLT
                    _memory[2] = 0b00000000; //  0 in binary
                    _memory[3] = 0b00000000; //  0 in binary
                    _memory[4] = 0b00000000; //  0 in binary
                    _memory[5] = 0b00000000; //  0 in binary
                    _memory[6] = 0b00000000; // 0 in binary
                    _memory[7] = 0b00000000; // 0 in binary
                    _memory[8] = 0b00000000; // 0 in binary
                    _memory[9] = 0b00000000; // 0 in binary
                    _memory[10] = 0b00000000; // 0 in binary
                    _memory[11] = 0b00000000; // 0 in binary
                    _memory[12] = 0b00000000; // 0 in binary
                    _memory[13] = 0b00000000; // 0 in binary
                    _memory[14] = 0b00000000; // 0 in binary
                    _memory[15] = 0b00000000; // 0 in binary
                    
                    break;
                case "Multiply":
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
                    break;
                case "Fibonacci":
                    _memory[0] = 0b01010000; // ldi 0
                    _memory[1] = 0b01001101; // sta 13
                    _memory[2] = 0b11100000; // out
                    _memory[3] = 0b01010001; // ldi 1 
                    _memory[4] = 0b01001110; // sta 14
                    _memory[5] = 0b11100000; // out
                    _memory[6] = 0b00101101; // add 13
                    _memory[7] = 0b01110000; // jc 0
                    _memory[8] = 0b01001111; // sta 15
                    _memory[9] = 0b00011110; // lda 14
                    _memory[10] = 0b01001101; // sta 13
                    _memory[11] = 0b00011111; // lda 15
                    _memory[12] = 0b01100100; // jmp 4
                    _memory[13] = 0b00000000; // 0
                    _memory[14] = 0b00000000; // 0
                    _memory[15] = 0b00000000; // 0
                    break;
                case "Countdown":
                    _memory[0] = 0b00011111; // lda 15
                    _memory[1] = 0b11100000; // out
                    _memory[2] = 0b00111110; // sub 14
                    _memory[3] = 0b11100000; // out
                    _memory[4] = 0b10000000; // jz
                    _memory[5] = 0b01100001; // jmp 2
                    _memory[6] = 0b11110000; // hlt
                    _memory[7] = 0b00000000; // 0
                    _memory[8] = 0b00000000; // 0
                    _memory[9] = 0b00000000; // 0
                    _memory[10] = 0b00000000; // 0
                    _memory[11] = 0b00000000; // 0
                    _memory[12] = 0b00000000; // 0
                    _memory[13] = 0b00000000; // 0
                    _memory[14] = 0b00000001; // 0
                    _memory[15] = 0b000001010; // 0
                    break;

            }
            //        for (int i = 0; i < _memory.Length; i++)
            //{
            //    _memory[i] = _resetmemory[i];
            //}
        }

        public void UpdateMemory(byte[] data)
        {
            if (data.Length != _memory.Length)
            {
                throw new ArgumentException("Data length must match memory length.");
            }

            for (int i = 0; i < data.Length; i++)
            {
                _memory[i] = data[i];
            }
        }

        public Memory(Computer thiscomputer)
        {
            _thiscomputer = thiscomputer;
            _memory = new byte[16];
            LoadMemory("Multiply");
            _resetmemory = new byte[16];
            _resetmemory = _memory;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Memory initialized.", "MEM"));
        }
    }
}



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

//ADD Test 128 + 1
//_memory[0] = 0b00010110; // lda 6
//_memory[1] = 0b00100101; // add 5
//_memory[2] = 0b11100000; // out
//_memory[3] = 0b11110000; // hlt
//_memory[4] = 0b00000000; // 
//_memory[5] = 0b00000001; // 1 in binary
//_memory[6] = 0b10000000; // 128 in binary

//SUB Test 128-5
//_memory[0] = 0b00010110; // lda 6
//_memory[1] = 0b00110101; // sub 5
//_memory[2] = 0b11100000; // out
//_memory[3] = 0b11110000; // hlt 
//_memory[4] = 0b00000000; // 
//_memory[5] = 0b00000101; // 5 in binary
//_memory[6] = 0b10000000; // 128 in binary

////JMP Test
//_memory[0] = 0b00010110; // lda 6
//_memory[1] = 0b00100101; // add 5
//_memory[2] = 0b01100001; // jmp 1
//_memory[3] = 0b00000000; // 
//_memory[4] = 0b00000000; // 
//_memory[5] = 0b00000001; // 
//_memory[6] = 0b00000000; // 128 in binary

//JC Test (Multiply)
//_memory[0] = 0b00011110; // lda 14
//_memory[1] = 0b00111100; // sub 12
//_memory[2] = 0b01110110; // jc 6
//_memory[3] = 0b00011101; // lda 13 
//_memory[4] = 0b11100000; // out
//_memory[5] = 0b11110000; // hlt
//_memory[6] = 0b01001110; // sta 14
//_memory[7] = 0b00011101; // lda 13
//_memory[8] = 0b00101111; // add 15
//_memory[9] = 0b01001101; // sta 13
//_memory[10] = 0b01100000; // jmp 0
//_memory[11] = 0b00000000; // 0
//_memory[12] = 0b00000001; // 1
//_memory[13] = 0b00000000; // 0
//_memory[14] = 0b00000011; // 3
//_memory[15] = 0b00000101; // 5

// JC Test (fibonacci)
//_memory[0] = 0b01010000; // ldi 0
//_memory[1] = 0b01001101; // sta 13
//_memory[2] = 0b11100000; // out
//_memory[3] = 0b01010001; // ldi 1 
//_memory[4] = 0b01001110; // sta 14
//_memory[5] = 0b11100000; // out
//_memory[6] = 0b00101101; // add 13
//_memory[7] = 0b01110000; // jc 0
//_memory[8] = 0b01001111; // sta 15
//_memory[9] = 0b00011110; // lda 14
//_memory[10] = 0b01001101; // sta 13
//_memory[11] = 0b00011111; // lda 15
//_memory[12] = 0b01100100; // jmp 4
//_memory[13] = 0b00000000; // 0
//_memory[14] = 0b00000000; // 0
//_memory[15] = 0b00000000; // 0

//_memory[0] = 0b00010110; // LDA 6
//_memory[1] = 0b01000100; // STA 5
//_memory[2] = 0b11100011; // LDI 3
//_memory[3] = 0b11100000; // OUT
//_memory[4] = 0b11110000; // HLT
//_memory[5] = 0b00000000; // 2 in binary
//_memory[6] = 0b00000010; // 2 in binary






