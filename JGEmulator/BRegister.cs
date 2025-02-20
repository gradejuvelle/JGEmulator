using JGEmulator;

public class BRegister
{

    private  Computer _thiscomputer;

    public byte Value { get; set; }
    public BusState State { get; set; }

    public BRegister(Computer computer)
    {
        _thiscomputer = computer ;
        Value = 0;
        State = BusState.None;
        _thiscomputer.DisplayMessage($"B - B Register initialized.");
    }

    public void ReadFromBus()
    {
        if (State == BusState.Reading)
        {
            //_alu = _computer.ALUInstance;
            _thiscomputer.DisplayMessage($"        B - Reading value from the bus.");
            Value = _thiscomputer.BusInstance.Read();
            _thiscomputer.ALUInstance.Execute(); // Call the ALU execute method

        }
    }
    public void Reset()
    {
        Value = 0;
        State = BusState.None;
        _thiscomputer.DisplayMessage($"    B - Register reset.");
    }
}
