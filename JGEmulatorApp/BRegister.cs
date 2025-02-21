using JGEmulator;

public class BRegister
{
    private Computer _thiscomputer;

    private int Value { get; set; }
    private byte Data { get; set; }
    private BusState State { get; set; }
    public BRegister(Computer computer)
    {
        _thiscomputer = computer;
        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "B Register initialized.", "BRG"));
    }
    public BusState GetBusState()
    {
        return State;
    }
    public void SetBusState(BusState state)
    {
        State = state;
        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.BusState, State.ToString(), "BRG"));
    }
    private void SetValue(int value)
    {
        Value = value;
        Data = (byte)value;
        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, Data.ToString(), "BRG"));
    }
    internal byte GetValue()
    {
        return Data;
    }
    public void ReadFromBus()
    {
        if (State == BusState.Reading)
        {
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Reading value from the bus.", "BRG"));
            SetValue( _thiscomputer.BusInstance.Read());
            _thiscomputer.ALUInstance.Execute(); // Call the ALU execute method
        }
    }
 
    public void Reset()
    {
        SetValue(0);
        State = BusState.None;
        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "B Register reset.", "BRG"));
    }


}

