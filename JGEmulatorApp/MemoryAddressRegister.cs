using System;

namespace JGEmulator
{
    public class MemoryAddressRegister
    {
        private byte _value; // 4-bit value, stored in an 8-bit byte
        private BusState _state;
        private Computer _thiscomputer;

        public MemoryAddressRegister(Computer computer)
        {
            _thiscomputer = computer;
            //SetValue(0);
            //_state = BusState.None;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Memory Address Register initialized.", "MAR"));
        }

        public byte GetValue()
        {
            return _value;
        }

        public void SetValue(byte value)
        {
            _value = value;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, value.ToString(), "MAR"));
        }

        public BusState GetBusState()
        {
            return _state;

        }

        public void SetBusState(BusState state)
        {
            _state = state;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.BusState, _state.ToString(), "MAR"));

        }

        public void WriteToBus(Bus bus)
        {
            if (_state == BusState.Writing)
            {
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Putting value on the bus. {_value & 0x0F}", "MAR"));
                // Write only the rightmost 4 bits to the bus and zero out the left 4 bits
                bus.Write(_value & 0x0F); // Ensuring left 4 bits are zeroed out
            }
        }

        public void ReadFromBus(Bus bus, Memory memory)
        {
            if (_state == BusState.Reading)
            {
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Reading from bus.", "MAR"));
                // Read only the rightmost 4 bits from the bus
                byte data = bus.Read();
                SetValue((byte)((_value & 0xF0) | (data & 0x0F)));

                // Update the selected address in the memory using a method
                memory.SetSelectedAddress(_value);
            }
        }

        public void Reset()
        {
            SetValue(0);
            _thiscomputer.MemoryInstance.SetSelectedAddress(0);
            _state = BusState.None;
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Memory Address Register reset.", "MAR"));
        }
    }
}










