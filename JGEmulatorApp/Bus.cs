using JGEmulator;

public class Bus
{
    private int Value { get; set; }
    private byte Data { get; set; }

    private Computer _thiscomputer;

    public Bus(Computer computer)
    {
        _thiscomputer = computer;
        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Bus initialized.", "BUS"));
    }

    public void Write(int value)
    {
        Value = value;
        Data = (byte)value;
        string dataBinary = Convert.ToString(Data, 2).PadLeft(8, '0');
        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"New value on bus. {dataBinary}", "BUS"));
        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, Value.ToString(), "BUS"));

    }

    public byte Read()
    {
        string dataBinary = Convert.ToString(Data, 2).PadLeft(8, '0');

        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Value read from bus. {dataBinary}", "BUS"));
        return Data;
    }

    public void WriteFromIR(byte instructionRegisterValue)
    {
        // Combine the left four bits as 0 and the right four bits from the instruction register value
        string valueBinary = Convert.ToString(instructionRegisterValue, 2).PadLeft(8, '0');
        //DisplayMessage($"        BUS - Writing {valueBinary} from IR to bus (8-bit value).");
        // Write the combined 8 bits to the bus
        Write(instructionRegisterValue);
        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"New value on bus. {valueBinary}", "BUS"));
        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.RegisterValue, instructionRegisterValue.ToString(), "BUS"));
    }

    public void Reset()
    {
        Write(0);
        _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Bus reset", "BUS"));
    }
}




