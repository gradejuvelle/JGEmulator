using System;

namespace JGEmulator
{
    public class ARegister
    {
        public byte Value { get; set; }

        public BusState State { get; set; }

        public ARegister()
        {
            Value = 0;
            State = BusState.None;
            Console.WriteLine($"A - A Register initialized.");
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

