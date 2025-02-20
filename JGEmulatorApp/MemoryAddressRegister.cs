namespace JGEmulator;

public class MemoryAddressRegister
{
    private byte _value;
    private readonly Computer _computer;

    public byte Value
    {
        get => _value;
        set
        {
            _value = value;
            _computer.OnRegisterValueChanged("MAR", _value);
        }
    }

    public BusState State { get; set; }

    public MemoryAddressRegister(Computer computer)
    {
        _computer = computer;
        Value = 0;
        State = BusState.None;
        _computer.DisplayMessage("MAR - Memory Address Register Initialized.");
    }

    public void WriteToBus(Bus bus)
    {
        if (State == BusState.Writing)
        {
            bus.Write(Value);
            _computer.DisplayMessage($"     MAR - Wrote value to bus: {Value}");
        }
    }

    public void ReadFromBus(Bus bus, Memory memory)
    {
        if (State == BusState.Reading)
        {
            Value = bus.Read();
            memory.SetSelectedAddress(Value);
            _computer.DisplayMessage($"     MAR - Read value from bus: {Value}");
        }
    }
}
