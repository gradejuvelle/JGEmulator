using System;

namespace JGEmulator
{
    public class StatusRegister
    {
        private bool ZeroFlag { get; set; }
        private bool CarryFlag { get; set; }
        private Computer _thiscomputer;

        public StatusRegister(Computer thiscomputer)
        {
            _thiscomputer = thiscomputer;
            ZeroFlag = false;
            CarryFlag = false;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Status Register initialized.", "STT"));
        }

        public void SetZeroFlag()
        {
            ZeroFlag = true;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Zero flag set.", "STT"));
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterFlag, "true", "STTZero"));
        }

        public void ClearZeroFlag()
        {
            ZeroFlag = false;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Zero flag cleared.", "STT"));
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterFlag, "false", "STTZero"));
        }

        public void SetCarryFlag()
        {
            CarryFlag = true;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Carry flag set.", "STT"));
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterFlag, "true", "STTCarry"));
        }

        public void ClearCarryFlag()
        {
            CarryFlag = false;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Carry flag cleared.", "STT"));
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterFlag, "false", "STTCarry"));
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
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Status Register reset.", "STT"));
        }
    }
}

