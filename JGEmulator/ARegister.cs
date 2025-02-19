using System;

namespace JGEmulator
{
    public class ARegister
    {
        private byte _value;
        public byte Value { get; set; }

        public BusState State { get; set; }

        public ARegister()
        {
            Value = 0;
            State = BusState.None;
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
                Console.WriteLine($"        A - Reading value frpm the bus.");
                Value = bus.Read();
            }
        }
    }
}

