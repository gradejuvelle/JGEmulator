using System;

namespace JGEmulator
{
    public class OutputRegister
    {
        public byte Value { get; set; }
        public BusState State { get; set; }
        private Computer _thiscomputer;
        public OutputRegister(Computer computer)
        {
            _thiscomputer = computer;
            Value = 0;
            State = BusState.None;
            _thiscomputer.DisplayMessage("OUT - Output Register initialized.");
        }

        public void ReadFromBus()
        {
            if (State == BusState.Reading)
            {
                _thiscomputer.DisplayMessage($"        OUT - Reading from bus.");
                Value = _thiscomputer.BusInstance.Read(); // Use the Bus.Read method
                string valueBinary = Convert.ToString(Value, 2).PadLeft(8, '0');
                _thiscomputer.DisplayMessage($"OUT - " + Value);

            }
        }
        public void Reset()
        {
            Value = 0;
            State = BusState.None;
            _thiscomputer.DisplayMessage($"    OR - Register reset.");
        }
    }
}



