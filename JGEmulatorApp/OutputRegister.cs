namespace JGEmulator;

public class OutputRegister
{
    private byte _value;
    private readonly Computer _computer;

    public byte Value
    {
        get => _value;
        set
        {
            _value = value;
            _computer.OnRegisterValueChanged("OutputRegister", _value);
        }
    }

    public BusState State { get; set; }

    public OutputRegister(Computer computer)
    {
        _computer = computer;
        Value = 0;
        State = BusState.None;
        _computer.DisplayMessage("OR - Output Register Initialized.");
    }

    public void ReadFromBus()
    {
        if (State == BusState.Reading)
        {
            Value = _computer.BusInstance.Read();
            _computer.DisplayMessage($"     OR - Register Read value from bus: {Value}");
        }
    }
}
