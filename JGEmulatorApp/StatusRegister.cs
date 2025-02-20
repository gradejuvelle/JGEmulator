using System;

namespace JGEmulator
{
    public class StatusRegister
    {
        public bool ZeroFlag { get; set; }
        public bool CarryFlag { get; set; }
        private readonly Computer _computer;

        public StatusRegister(Computer computer)
        {
            _computer = computer;
            ZeroFlag = false;
            CarryFlag = false;
            _computer.DisplayMessage("SR - Status Register initialized.");
        }

        public void SetZeroFlag()
        {
            ZeroFlag = true;
            _computer.DisplayMessage("            Zero flag set.");
        }

        public void ClearZeroFlag()
        {
            ZeroFlag = false;
            _computer.DisplayMessage("            Zero flag cleared.");
        }

        public void SetCarryFlag()
        {
            CarryFlag = true;
            _computer.DisplayMessage("!!            Carry flag set.");
        }

        public void ClearCarryFlag()
        {
            CarryFlag = false;
            _computer.DisplayMessage("!!            Carry flag cleared.");
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
