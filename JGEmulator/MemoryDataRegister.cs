using System;

namespace JGEmulator
{
    public class MemoryDataRegister
    {
        public byte Value { get; set; }
        public BusState State { get; set; }

        public MemoryDataRegister()
        {
            Value = 0;
            State = BusState.None;
            Console.WriteLine("Memory Data Register initialized.");
        }

        public void WriteToBus(Bus bus)
        {
            if (State == BusState.Writing)
            {
                bus.Data = Value;
                Console.WriteLine($"Memory Data Register writing {Value} to bus.");
            }
        }

        public void ReadFromBus(Bus bus)
        {
            if (State == BusState.Reading)
            {
                Value = bus.Data;
                Console.WriteLine($"Memory Data Register reading {Value} from bus.");
            }
        }
    }
}
