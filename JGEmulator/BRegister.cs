using JGEmulator;

public class BRegister
{
    private byte _value;
    private  ALU _alu;
    private  Computer _computer;

    public byte Value { get; set; }
    public BusState State { get; set; }

    public BRegister(Computer computer)
    {
        _computer = computer ;
        Value = 0;
        State = BusState.None;
    }

    public void ReadFromBus()
    {
        if (State == BusState.Reading)
        {
            //_alu = _computer.ALUInstance;
            Console.WriteLine($"        B - Reading value from the bus.");
            Value = _computer.BusInstance.Read();
            _computer.ALUInstance.Execute(); // Call the ALU execute method

        }
    }
}
