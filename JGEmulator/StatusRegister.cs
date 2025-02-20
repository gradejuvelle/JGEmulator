using System;

namespace JGEmulator
{
    public class StatusRegister
    {
        public bool ZeroFlag { get;  set; }
        public bool CarryFlag { get;  set; }
        private Computer _thiscomputer;
        public StatusRegister(Computer thiscomputer)
        {
            _thiscomputer = thiscomputer;
            ZeroFlag = false;
            CarryFlag = false;
            _thiscomputer.DisplayMessage("STAT - Status Register initialized.");
            _thiscomputer = thiscomputer;
        }

        public void SetZeroFlag()
        {
            ZeroFlag = true;
            _thiscomputer.DisplayMessage("            STAT - Zero flag set.");
        }

        public void ClearZeroFlag()
        {
            ZeroFlag = false;
            _thiscomputer.DisplayMessage("            STAT - Zero flag cleared.");
        }

        public void SetCarryFlag()
        {
            CarryFlag = true;
            _thiscomputer.DisplayMessage("            STAT - Carry flag set.");
        }

        public void ClearCarryFlag()
        {
            CarryFlag = false;
            _thiscomputer.DisplayMessage("             STAT - Carry flag cleared.");
        }


        public bool IsZeroFlagSet()
        {
            return ZeroFlag;
        }

        public bool IsCarryFlagSet()
        {
            return CarryFlag;
        }
        public void Reset()
        {
            ClearCarryFlag();
            ClearZeroFlag();
            _thiscomputer.DisplayMessage($"        STAT - Register reset.");
        }
    }
}

