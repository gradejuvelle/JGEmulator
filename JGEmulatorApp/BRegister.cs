namespace JGEmulator;

public class BRegister
{
    private byte _value;
    private ALU _alu;
    private readonly Computer _computer;

    public byte Value
    {
        get => _value;
        set
        {
            _value = value;
            _computer.OnRegisterValueChanged("BRegister", _value);
        }
    }

    public BusState State { get; set; }

    public BRegister(Computer computer)
    {
        _computer = computer;
        _alu = computer.ALUInstance;
        Value = 0;
        State = BusState.None;
        _computer.DisplayMessage("B - B Register Initialized.");
    }

    public void ReadFromBus()
    {
        if (State == BusState.Reading)
        {
            Value = _computer.BusInstance.Read();
            _alu = _computer.ALUInstance;
            _alu.Execute(); // Call the ALU execute method
            _computer.DisplayMessage($"     B- Register Read value from bus: {Value}");
        }
    }
}
