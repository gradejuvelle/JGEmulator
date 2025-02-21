using System;

namespace JGEmulator
{
    public class OutputRegister
    {
        private byte _value;
        private BusState State;
        private Computer _thiscomputer;

        public OutputRegister(Computer computer)
        {
            _thiscomputer = computer;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Output Register initialized.", "OUT"));
        }

        public byte GetValue()
        {
            return _value;
        }

        public void SetValue(byte value)
        {
            _value = value;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, value.ToString(), "OUT"));
        }

        public BusState GetBusState()
        {
            return State;
        }

        public void SetBusState(BusState state)
        {
            State = state;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.BusState, State.ToString(), "OUT"));
        }

        public void ReadFromBus()
        {
            if (State == BusState.Reading)
            {
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Reading value from the bus.", "OUT"));
                SetValue(_thiscomputer.BusInstance.Read());
            }
        }

        public void Reset()
        {
            SetValue(0);
            State = BusState.None;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Output Register reset.", "OUT"));
        }
    }
}










