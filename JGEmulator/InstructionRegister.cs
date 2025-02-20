﻿using System;

namespace JGEmulator
{
    public class InstructionRegister
    {
        public byte Value { get; set; } // 8-bit value
        private Computer _thiscomputer;
        public BusState State { get; set; }

        public InstructionRegister(Computer thiscomputer)
        {
            _thiscomputer = thiscomputer;
            Value = 0;
            State = BusState.None;
            _thiscomputer.DisplayMessage("IR - Instruction Register initialized.");
            _thiscomputer = thiscomputer;
        }

        public void WriteToBus(Bus bus)
        {
            if (State == BusState.Writing)
            {
                _thiscomputer.DisplayMessage($"        IR - Writing to bus.");
                // Use the Bus.WriteFromIR method to write the combined value to the bus
                bus.WriteFromIR(bus, Value);
            }
        }

        public void ReadFromBus(Bus bus)
        {
            if (State == BusState.Reading)
            {
                _thiscomputer.DisplayMessage($"        IR - Reading from bus.");
                // Read the full 8 bits from the bus
                Value = bus.Read();

                // Decode the value and display a console message with the instruction
                byte opcode = (byte)(Value >> 4); // Get the left 4 bits
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
                _thiscomputer.DisplayMessage($"      !!IR - {instruction}");
            }
        }
        public void Reset()
        {
            Value = 0;
            State = BusState.None;
            _thiscomputer.DisplayMessage($"    IR - Register reset.");
        }
    }
}




