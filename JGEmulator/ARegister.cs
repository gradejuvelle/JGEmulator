using System;

namespace JGEmulator
{
    
    public class ARegister
    {
        public byte Value { get; set; }

        public BusState State { get; set; }
        private Computer _thiscomputer;
        public ARegister(Computer computer)
        {
            _thiscomputer = computer;
            Value = 0;
            State = BusState.None;
            _thiscomputer.DisplayMessage($"A - A Register initialized.");
        }

        public void WriteToBus(Bus bus)
        {
            if (State == BusState.Writing)
            {
                bus.Write(Value);
            }
        }

        public void ReadFromBus(Bus bus)
        {
            if (State == BusState.Reading)
            {
                _thiscomputer.DisplayMessage($"        A - Reading value frpm the bus.");
                Value = bus.Read();
            }
        }
        public void Reset()
        {
            Value = 0;
            State = BusState.None;
            _thiscomputer.DisplayMessage($"    A - Register reset.");
        }   
    }
}

