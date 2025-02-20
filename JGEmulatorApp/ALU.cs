using System;

namespace JGEmulator
{
    public class ALU
    {
        public bool Subtract { get; set; }
        public StatusRegister StatusRegister { get; set; }
        public byte Value { get; set; } // ALU's own value
        private Computer _computer;
        private bool carry;
        private bool zero;

        public BusState State { get; set; }
        public ALU(Computer _thiscomputer)
        {
            _computer = _thiscomputer;
            Subtract = false; // Default to addition
            StatusRegister = _thiscomputer.StatusRegister;
            Value = 0; // Initialize ALU value to 0
            _computer.DisplayMessage("ALU initialized with Subtract = false.");
        }
        public void WriteToBus()
        {
            if (State == BusState.Writing)
            {
                _computer.BusInstance.Write(Value);
            }
        }
        public void Execute()
        {
            int result;

            if (Subtract)
            {
                // Subtract B from ALU value
                result = _computer.ARegister.Value - _computer.BRegister.Value;
                carry = _computer.BRegister.Value <= _computer.ARegister.Value;
                zero = _computer.ARegister.Value == _computer.BRegister.Value;
                result &= 0xFF; // Ensure result fits into 8 bits
                if (carry)
                {
                    StatusRegister.SetCarryFlag();
                }
                else
                {
                    StatusRegister.ClearCarryFlag();
                }
                if (zero)
                {
                    StatusRegister.SetZeroFlag();
                }
                else
                {
                    StatusRegister.ClearZeroFlag();
                }
                _computer.DisplayMessage($"        ALU - Executed subtraction: {result}");
            }
            else
            {
                // Add ALU value and B
                result = _computer.ARegister.Value + _computer.BRegister.Value;
                carry = _computer.ARegister.Value + _computer.BRegister.Value > 255;
                zero = _computer.ARegister.Value + _computer.BRegister.Value == 255;
                result &= 0xFF; // Ensure result fits into 8 bits
                if (carry)
                {
                    StatusRegister.SetCarryFlag();
                }
                else
                {
                    StatusRegister.ClearCarryFlag();
                }
                if (zero)
                {
                    StatusRegister.SetZeroFlag();
                }
                else
                {
                    StatusRegister.ClearZeroFlag();
                }
                //StatusRegister.UpdateZeroFlag(Value);
                //StatusRegister.UpdateCarryFlag(carry);
                _computer.DisplayMessage($"        ALU - Executed addition: {result}");
            }

            // Update ALU value with the result
            Value = (byte)result;

            // Update status flags based on the result

        }

        internal void EnableSubtract(bool _state)
        {
            Subtract = _state;
            if (_state == true)
            {
                Execute();
            }
        }
    }
}

