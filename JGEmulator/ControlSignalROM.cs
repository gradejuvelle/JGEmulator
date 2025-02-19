using System;
using System.Collections.Generic;

namespace JGEmulator
{
    public class ControlSignalRom
    {
        private readonly Dictionary<byte, MicroInstruction> _rom;

        public ControlSignalRom()
        {
            _rom = new Dictionary<byte, MicroInstruction>
            {
                // NOP (opcode 0x0)
                { 0b0000000, new MicroInstruction(co: true, mi: true) }, // Step 0: CO, MI
                { 0b0000001, new MicroInstruction(ro: true, ii: true, ce: true) }, // Step 1: RO, II, CE
                { 0b0000010, new MicroInstruction() }, // Step 2: No signals
                { 0b0000011, new MicroInstruction() }, // Step 3: No signals
                { 0b0000100, new MicroInstruction() }, // Step 4: No signals

                // LDA (opcode 0x1)
                { 0b0001000, new MicroInstruction(co: true, mi: true) }, // Step 0: CO, MI
                { 0b0001001, new MicroInstruction(ro: true, ii: true, ce: true) }, // Step 1: RO, II, CE
                { 0b0001010, new MicroInstruction(io: true, mi: true) }, // Step 2: IO, MI
                { 0b0001011, new MicroInstruction(ro: true, ai: true) }, // Step 3: RO, AI
                { 0b0001100, new MicroInstruction() }, // Step 4: No signals

                // ADD (opcode 0x2)
                { 0b0010000, new MicroInstruction(co: true, mi: true) }, // Step 0: CO, MI
                { 0b0010001, new MicroInstruction(ro: true, ii: true, ce: true) }, // Step 1: RO, II, CE
                { 0b0010010, new MicroInstruction(io: true, mi: true) }, // Step 2: IO, MI
                { 0b0010011, new MicroInstruction(ro: true, bi: true) }, // Step 3: RO, BI
                { 0b0010100, new MicroInstruction(eo: true, ai: true) }, // Step 4: EO, AI

                // SUB (opcode 0x3)
                { 0b0011000, new MicroInstruction(co: true, mi: true) }, // Step 0: CO, MI
                { 0b0011001, new MicroInstruction(ro: true, ii: true, ce: true) }, // Step 1: RO, II, CE
                { 0b0011010, new MicroInstruction(io: true, mi: true) }, // Step 2: IO, MI
                { 0b0011011, new MicroInstruction(ro: true, bi: true) }, // Step 3: RO, BI
                { 0b0011100, new MicroInstruction(eo: true, ai: true, su: true) }, // Step 4: EO, AI, SU

                // STA (opcode 0x4)
                { 0b0100000, new MicroInstruction(co: true, mi: true) }, // Step 0: CO, MI
                { 0b0100001, new MicroInstruction(ro: true, ii: true, ce: true) }, // Step 1: RO, II, CE
                { 0b0100010, new MicroInstruction(io: true, mi: true) }, // Step 2: IO, MI
                { 0b0100011, new MicroInstruction(ao: true, ri: true) }, // Step 3: AO, RI
                { 0b0100100, new MicroInstruction() }, // Step 4: No signals

                // LDI (opcode 0x5)
                { 0b0101000, new MicroInstruction(co: true, mi: true) }, // Step 0: CO, MI
                { 0b0101001, new MicroInstruction(ro: true, ii: true, ce: true) }, // Step 1: RO, II, CE
                { 0b0101010, new MicroInstruction(io: true, ai: true) }, // Step 2: IO, AI
                { 0b0101011, new MicroInstruction() }, // Step 3: No signals
                { 0b0101100, new MicroInstruction() }, // Step 4: No signals

                // JMP (opcode 0x6)
                { 0b0110000, new MicroInstruction(co: true, mi: true) }, // Step 0: CO, MI
                { 0b0110001, new MicroInstruction(ro: true, ii: true, ce: true) }, // Step 1: RO, II, CE
                { 0b0110010, new MicroInstruction(io: true, j: true) }, // Step 2: IO, J
                { 0b0110011, new MicroInstruction() }, // Step 3: No signals
                { 0b0110100, new MicroInstruction() }, // Step 4: No signals

                // OUT (opcode 0xE)
                { 0b1110000, new MicroInstruction(co: true, mi: true) }, // Step 0: CO, MI
                { 0b1110001, new MicroInstruction(ro: true, ii: true, ce: true) }, // Step 1: RO, II, CE
                { 0b1110010, new MicroInstruction(ao: true, oi: true) }, // Step 2: AO, OI
                { 0b1110011, new MicroInstruction() }, // Step 3: No signals
                { 0b1110100, new MicroInstruction() }, // Step 4: No signals

                // HLT (opcode 0xF)
                { 0b1111000, new MicroInstruction(co: true, mi: true) }, // Step 0: CO, MI
                { 0b1111001, new MicroInstruction(ro: true, ii: true, ce: true) }, // Step 1: RO, II, CE
                { 0b1111010, new MicroInstruction(hlt: true) }, // Step 2: HLT
                { 0b1111011, new MicroInstruction() }, // Step 3: No signals
                { 0b1111100, new MicroInstruction() }, // Step 4: No signals

                // Remaining opcodes
                { 0b0111000, new MicroInstruction() }, // Placeholder for other instructions
                { 0b1000000, new MicroInstruction() }, // Placeholder for other instructions
                { 0b1001000, new MicroInstruction() }, // Placeholder for other instructions
                { 0b1010000, new MicroInstruction() }, // Placeholder for other instructions
                { 0b1011000, new MicroInstruction() }, // Placeholder for other instructions
                { 0b1100000, new MicroInstruction() }, // Placeholder for other instructions
                { 0b1101000, new MicroInstruction() } // Placeholder for other instructions
            };
        }

        public MicroInstruction GetMicroInstruction(byte address)
        {
            return _rom.ContainsKey(address) ? _rom[address] : new MicroInstruction();
        }
    }
}


