using JGEmulator;

public class Computer
{
    public event Action<string, byte> RegisterValueChanged;

    public Clock ClockInstance { get; set; }
    public Bus BusInstance { get; set; }
    public ARegister ARegister { get; set; }
    public BRegister BRegister { get; set; }
    public ProgramCounter PC { get; set; }
    public InstructionRegister IR { get; set; }
    public OutputRegister OR { get; set; }
    public MemoryAddressRegister MAR { get; set; }
    public Memory MemoryInstance { get; set; }
    public StatusRegister StatusRegister { get; set; }
    public ALU ALUInstance { get; set; }
    public ControlUnit ControlUnitInstance { get; set; }
    private TextBox _messageTextBox;
    private Label _aRegisterLabel;
    private Label _bRegisterLabel;
    private Label _outputRegisterLabel;
    private Label _marLabel;

    public Computer(int clockSpeed, TextBox messageTextBox, Label aRegisterLabel, Label bRegisterLabel, Label outputRegisterLabel, Label marLabel)
    {
        _messageTextBox = messageTextBox;
        _aRegisterLabel = aRegisterLabel;
        _bRegisterLabel = bRegisterLabel;
        _outputRegisterLabel = outputRegisterLabel;
        _marLabel = marLabel;
        ClockInstance = new Clock(clockSpeed, this);
        ClockInstance.OnTick += HandleTick;
        ClockInstance.OnTock += HandleTock;
        BusInstance = new Bus(this);
        StatusRegister = new StatusRegister(this);
        BRegister = new BRegister(this); // Initialize BRegister first
        ARegister = new ARegister(this) { Value = 0 };
        ALUInstance = new ALU(this); // Pass Computer to ALU
        PC = new ProgramCounter(this) { Value = 0 };
        IR = new InstructionRegister(this) { Value = 0 };
        OR = new OutputRegister(this) { Value = 0 };
        MAR = new MemoryAddressRegister(this) { Value = 0 };
        MemoryInstance = new Memory(this);
        ControlUnitInstance = new ControlUnit(this);
        DisplayMessage("CO - Computer created and instances assigned.");
    }

    public void DisplayMessage(string message)
    {
        if (_messageTextBox.InvokeRequired)
        {
            _messageTextBox.Invoke(new Action(() => _messageTextBox.AppendText(message + Environment.NewLine)));
        }
        else
        {
            _messageTextBox.AppendText(message + Environment.NewLine);
        }
    }

    public void OnRegisterValueChanged(string registerName, byte value)
    {
        if (registerName == "ARegister")
        {
            if (_aRegisterLabel.InvokeRequired)
            {
                _aRegisterLabel.Invoke(new Action(() => _aRegisterLabel.Text = $"A Register: {value}"));
            }
            else
            {
                _aRegisterLabel.Text = $"A Register: {value}";
            }
        }
        else if (registerName == "BRegister")
        {
            if (_bRegisterLabel.InvokeRequired)
            {
                _bRegisterLabel.Invoke(new Action(() => _bRegisterLabel.Text = $"B Register: {value}"));
            }
            else
            {
                _bRegisterLabel.Text = $"B Register: {value}";
            }
        }
        else if (registerName == "OutputRegister")
        {
            if (_outputRegisterLabel.InvokeRequired)
            {
                _outputRegisterLabel.Invoke(new Action(() => _outputRegisterLabel.Text = $"Output Register: {value}"));
            }
            else
            {
                _outputRegisterLabel.Text = $"Output Register: {value}";
            }
        }
        else if (registerName == "MAR")
        {
            if (_marLabel.InvokeRequired)
            {
                _marLabel.Invoke(new Action(() => _marLabel.Text = $"MAR: {value}"));
            }
            else
            {
                _marLabel.Text = $"MAR: {value}";
            }
        }
        // Add more cases here for other registers if needed
    }

    public void Reset()
    {
        ARegister.Value = 0;
        BRegister.Value = 0;
        PC.Value = 0;
        IR.Value = 0;
        OR.Value = 0;
        MAR.Value = 0;
        DisplayMessage($"[{Utils.GetTimestamp()}] Origin: CO, Message: Registers set to zero.");

        ControlUnitInstance.ProcessControlSignalsTick();
        DisplayMessage($"[{Utils.GetTimestamp()}] Origin: CO, Message: Reset executed.");
    }

    public void UpdateRegisters()
    {
        ARegister.WriteToBus(BusInstance);
        ARegister.ReadFromBus(BusInstance);
        BRegister.ReadFromBus();
        PC.WriteToBus(BusInstance);
        PC.ReadFromBus(BusInstance);
        IR.WriteToBus(BusInstance);
        IR.ReadFromBus(BusInstance);
        OR.ReadFromBus(); // Ensure OutputRegister reads from the bus
        MAR.WriteToBus(BusInstance);
        MAR.ReadFromBus(BusInstance, MemoryInstance); // Pass MemoryInstance to update SelectedAddress
        MemoryInstance.WriteToBus(BusInstance);
        MemoryInstance.ReadFromBus(BusInstance);
    }

    private void HandleTick()
    {
        ControlUnitInstance.ProcessControlSignalsTick();
    }

    private void HandleTock()
    {
        ControlUnitInstance.ProcessControlSignalsTock();
    }
}
