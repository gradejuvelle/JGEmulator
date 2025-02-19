using System;

namespace JGEmulator
{
    public class OutputRegister
    {
        public byte Value { get; set; }
        public BusState State { get; set; }

        public OutputRegister()
        {
            Value = 0;
            State = BusState.None;
            Console.WriteLine("OUT - Output Register initialized.");
        }

        public void ReadFromBus(Bus bus)
        {
            if (State == BusState.Reading)
            {
                Console.WriteLine($"        OUT - Reading from bus.");
                Value = bus.Read(); // Use the Bus.Read method
                string valueBinary = Convert.ToString(Value, 2).PadLeft(8, '0');

            }
        }
    }
}



