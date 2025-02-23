using System;

namespace JGEmulator
{
    public class ALU
    {
        private bool Subtract { get; set; }
        public StatusRegister StatusRegister { get; set; }
        private byte Value { get; set; } // ALU's own value
        private Computer _computer;
        private bool carry;
        private bool zero;
        private BusState State;
        public BusState GetBusState()
        {
            return State;
        }
        public void SetBusState(BusState state)
        {
            State = state;
            _computer.HandleUIMessages(new UIMessage(UIMessageType.BusState, State.ToString(), "ALU"));

        }
        public ALU(Computer _thiscomputer)
        {
            _computer = _thiscomputer;
            //Subtract = false; // Default to addition
            StatusRegister = _thiscomputer.StatusRegister;
            //Value = 0; // Initialize ALU value to 0
            _computer.HandleUIMessages(new UIMessage(UIMessageType.Log, "ALU initialized.", "ALU"));
        }
        public void SetValue(byte result)
        {
            Value = result;
            _computer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, Value.ToString(), "ALU"));

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
                result = _computer.ARegister.GetValue() - _computer.BRegister.GetValue();
                carry = _computer.BRegister.GetValue() <= _computer.ARegister.GetValue();
                zero = _computer.ARegister.GetValue() == _computer.BRegister.GetValue();
                result &= 0xFF; // Ensure result fits into 8 bits
                //if (carry)
                //{
                //    StatusRegister.SetCarryFlag();
                //}
                //else
                //{
                //    StatusRegister.ClearCarryFlag();
                //}
                //if (zero)
                //{
                //    StatusRegister.SetZeroFlag();
                //}
                //else
                //{
                //    StatusRegister.ClearZeroFlag();
                //}
                _computer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Executed subtraction: {result}", "ALU"));
            }
            else
            {
                // Add ALU value and B
                result = _computer.ARegister.GetValue() + _computer.BRegister.GetValue();
                carry = _computer.ARegister.GetValue() + _computer.BRegister.GetValue() > 255;
                zero = _computer.ARegister.GetValue() + _computer.BRegister.GetValue() == 255;
                result &= 0xFF; // Ensure result fits into 8 bits
                if (carry)
                {
                    //StatusRegister.SetCarryFlag();
                }
                else
                {
                    //StatusRegister.ClearCarryFlag();
                }
                if (zero)
                {
                    //StatusRegister.SetZeroFlag();
                }
                else
                {
                    //StatusRegister.ClearZeroFlag();
                }
                _computer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Executed addition: {result}", "ALU"));
            }

            // Update ALU value with the result
            SetValue( (byte)result);

            // Update status flags based on the result
        }

        internal void EnableSubtract(bool _state)
        {
            Subtract = _state;
            _computer.HandleUIMessages(new UIMessage(UIMessageType.RegisterFlag, Subtract.ToString(), "ALUSubtract"));
            if (_state == true)
            {

                Execute();
            }
        }
    }
}


