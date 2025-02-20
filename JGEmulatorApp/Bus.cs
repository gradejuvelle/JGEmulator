using JGEmulator;

public class Bus
{
    public int Value { get; set; }
    public byte Data { get; set; }
    private Computer _computer;

    public Bus(Computer computer)
    {
        _computer = computer;
        _computer.DisplayMessage("BUS - Bus initialized.");
        Value = 0;
        Data = 0;
    }

    public void Write(int value)
    {
        Data = (byte)value;
        OnValueChanged();
        string dataBinary = Convert.ToString(Data, 2).PadLeft(8, '0');
        _computer.DisplayMessage($"            BUS - New value on bus. {dataBinary}");
    }

    public byte Read()
    {
        string dataBinary = Convert.ToString(Data, 2).PadLeft(8, '0');
        _computer.DisplayMessage($"            BUS - Value read from bus. {dataBinary}");
        return Data;
    }

    public void WriteFromIR(Bus bus, byte instructionRegisterValue)
    {
        // Combine the left four bits as 0 and the right four bits from the instruction register value
        string valueBinary = Convert.ToString(instructionRegisterValue, 2).PadLeft(8, '0');
        // Write the combined 8 bits to the bus
        bus.Write(instructionRegisterValue);
    }

    private void OnValueChanged()
    {
        // Handle value change logic here
    }
}
