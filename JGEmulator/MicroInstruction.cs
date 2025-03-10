﻿using System.Security.Cryptography.X509Certificates;

namespace JGEmulator
{
    public class MicroInstruction
    {
        public bool MI { get; set; } // Memory Address Input
        public bool RI { get; set; } // Memory Input
        public bool RO { get; set; } // Memory Output
        public bool IO { get; set; } // Instruction Register Output
        public bool II { get; set; } // Instruction Register Input
        public bool CO { get; set; } // Control Output
        public bool CE { get; set; } // Counter Enable
        public bool AI { get; set; } // A Register Input
        public bool AO { get; set; } // A Register Output
        public bool BI { get; set; } // B Register Input
        public bool BO { get; set; } // B Register Output
        public bool SU { get; set; } // Subtract
        public bool EO { get; set; } // Enable Output
        public bool J { get; set; }  // Jump
        public bool PC { get; set; } // Program CounterXX
        public bool OI { get; set; } // Output Register Input
        public bool HLT { get; set; } // Halt
        public bool JC { get; set; } // JC
        public bool JZ { get; set; } // JZ
        public bool FI { get; set; } // FI

        public MicroInstruction(
            bool mi = false,
            bool ri = false,
            bool ro = false,
            bool io = false,
            bool ii = false,
            bool co = false,
            bool ce = false,
            bool ai = false,
            bool ao = false,
            bool bi = false,
            bool bo = false,
            bool su = false,
            bool eo = false,
            bool j = false,
            bool pc = false,
            bool oi = false,
            bool jc = false,
            bool jz = false,
            bool hlt = false,
            bool fi=false)
        {
            MI = mi; // Memory Address Input
            RI = ri; // Memory Input
            RO = ro; // Memory Output
            IO = io; // Instruction Register Output
            II = ii; // Instruction Register Input
            CO = co; // Control Output
            CE = ce; // Counter Enable
            AI = ai; // A Register Input
            AO = ao; // A Register Output
            BI = bi; // B Register Input
            BO = bo; // B Register Output
            SU = su; // Subtract
            EO = eo; // Enable Output
            J = j;  // Jump
            PC = pc; // Program Counter
            OI = oi; // Output Register Input
            HLT = hlt; // Halt
            JC = jc; // Jump if Carry
            JZ = jz; // Jump if Zero
            FI = fi; // Flag in
        }
    }
}

