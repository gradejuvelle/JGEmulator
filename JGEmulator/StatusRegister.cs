using System;

namespace JGEmulator
{
    public class StatusRegister
    {
        public bool ZeroFlag { get;  set; }
        public bool CarryFlag { get;  set; }

        public StatusRegister()
        {
            ZeroFlag = false;
            CarryFlag = false;
            Console.WriteLine("SR - Status Register initialized.");
        }

        public void SetZeroFlag()
        {
            ZeroFlag = true;
            Console.WriteLine("            Zero flag set.");
        }

        public void ClearZeroFlag()
        {
            ZeroFlag = false;
            Console.WriteLine("            Zero flag cleared.");
        }

        public void SetCarryFlag()
        {
            CarryFlag = true;
            Console.WriteLine("!!            Carry flag set.");
        }

        public void ClearCarryFlag()
        {
            CarryFlag = false;
            Console.WriteLine("!!            Carry flag cleared.");
        }


        public bool IsZeroFlagSet()
        {
            return ZeroFlag;
        }

        public bool IsCarryFlagSet()
        {
            return CarryFlag;
        }
    }
}

