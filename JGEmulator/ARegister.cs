using System;

namespace JGEmulator
{
    public class ARegister
    {
        private byte _value;
        private BusState State;
        private Computer _thiscomputer;

        public ARegister(Computer computer)
        {
            _thiscomputer = computer;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "A Register initialized.", "ARG"));
        }
        public BusState GetBusState()
        {
            return State;
        }

        public void SetBusState(BusState state)
        {
            State = state;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.BusState, State.ToString(), "ARG"));
        }
        public byte GetValue()
        {
            return _value;
        }

        public void SetValue(byte value)
        {
            _value = value;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, value.ToString(), "ARG"));
        }



        public void WriteToBus(Bus bus)
        {
            if (State == BusState.Writing)
            {
                bus.Write(_value);
            }
        }

        public void ReadFromBus(Bus bus)
        {
            if (State == BusState.Reading)
            {
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Reading value from the bus.", "ARG"));
                SetValue(bus.Read());
            }
        }

        public void Reset()
        {
            SetValue(0);
            State = BusState.None;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "A Register reset.", "ARG"));
        }
    }
}









