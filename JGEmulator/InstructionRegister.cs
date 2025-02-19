using System;

namespace JGEmulator
{
    public class InstructionRegister
    {
        public byte Value { get; set; } // 8-bit value

        public BusState State { get; set; }

        public InstructionRegister()
        {
            Value = 0;
            State = BusState.None;
            Console.WriteLine("IR - Instruction Register initialized.");
        }

        public void WriteToBus(Bus bus)
        {
            if (State == BusState.Writing)
            {
                Console.WriteLine($"        IR - Writing to bus.");
                // Use the Bus.WriteFromIR method to write the combined value to the bus
                bus.WriteFromIR(bus, Value);
            }
        }

        public void ReadFromBus(Bus bus)
        {
            if (State == BusState.Reading)
            {
                Console.WriteLine($"        IR - Reading from bus.");
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
                    0xE => "OUT started",
                    0xF => "HLT started",
                    _ => "Unknown instruction"
                };
                Console.WriteLine($"    !!IR - {instruction}");
            }
        }
    }
}




