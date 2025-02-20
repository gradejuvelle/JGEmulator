using System;

namespace JGEmulator
{
    public class ARegister
    {
        private Computer _computer;
        private byte _value;

        public byte Value
        {
            get => _value;
            set
            {
                _value = value;
                _computer.OnRegisterValueChanged("ARegister", _value);
            }
        }

        public BusState State { get; set; }

        public ARegister(Computer computer)
        {
            _computer = computer;
            Value = 0;
            State = BusState.None;
            _computer.DisplayMessage("A - A Register initialized.");
        }

        public void WriteToBus(Bus bus)
        {
            if (State == BusState.Writing)
            {
                bus.Write(Value);
                _computer.DisplayMessage($"A - Wrote value to bus: {Value}");
            }
        }

        public void ReadFromBus(Bus bus)
        {
            if (State == BusState.Reading)
            {
                _computer.DisplayMessage("A - Reading value from the bus.");
                Value = bus.Read();
                _computer.DisplayMessage($"A - Read value from bus: {Value}");
            }
        }
    }
}