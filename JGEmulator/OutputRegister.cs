using System;

namespace JGEmulator
{
    public class OutputRegister
    {
        public byte Value { get; set; }
        public BusState State { get; set; }
        private Computer _computer;
        public OutputRegister(Computer computer)
        {
            _computer = computer;
            Value = 0;
            State = BusState.None;
            Console.WriteLine("OUT - Output Register initialized.");
        }

        public void ReadFromBus()
        {
            if (State == BusState.Reading)
            {
                Console.WriteLine($"        OUT - Reading from bus.");
                Value = _computer.BusInstance.Read(); // Use the Bus.Read method
                string valueBinary = Convert.ToString(Value, 2).PadLeft(8, '0');
                Console.WriteLine($"OUT - " + Value);

            }
        }
    }
}



