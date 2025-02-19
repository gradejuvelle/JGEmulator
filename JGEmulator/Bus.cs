using JGEmulator;

public class Bus
{
    public int Value { get; set; }
    public byte Data { get; set; }


    public Bus()
    {
        Value = 0;
        Data = 0;

    }

    public void Write(int value)
    {
        Data = (byte)value;
        OnValueChanged();
        string dataBinary = Convert.ToString(Data, 2).PadLeft(8, '0');
        Console.WriteLine($"            BUS - New value on bus. {dataBinary}");
    }

    public byte Read()
    {
        string dataBinary = Convert.ToString(Data, 2).PadLeft(8, '0');
        Console.WriteLine($"            BUS - Value read from bus. {dataBinary}");
        return Data;
    }

    public void WriteFromIR(Bus bus, byte instructionRegisterValue)
    {
        // Combine the left four bits as 0 and the right four bits from the instruction register value
        string valueBinary = Convert.ToString(instructionRegisterValue, 2).PadLeft(8, '0');
        //Console.WriteLine($"        BUS - Writing {valueBinary} from IR to bus (8-bit value).");
        // Write the combined 8 bits to the bus
        bus.Write(instructionRegisterValue);
        Console.WriteLine($"            Debug ");
    }

    private void OnValueChanged()
    {
        // Handle value change logic here
    }
}




