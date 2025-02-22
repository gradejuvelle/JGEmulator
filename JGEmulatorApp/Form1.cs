using JGEmulator;
using System.Windows.Forms;

namespace JGEmulatorApp
{
    public partial class Form1 : Form
    {
        private JGEmulator.Computer Computer;
        public Form1()
        {
            InitializeComponent();
            Computer = new JGEmulator.Computer(100, this);
        }

        public void HandleUIMessages(UIMessage message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<UIMessage>(HandleUIMessages), message);
                return;
            }

            switch (message.UIMessageType)
            {
                case UIMessageType.Log:
                    break;
                case UIMessageType.RegisterFlag:
                    switch (message.Source)
                    {
                        case "PRGEnable":
                            lblPRGEnable.Text = "Program Counter Enable: " + message.Message;
                            break;
                        case "STTZero":
                            lblSTTZero.Text = "Zero: " + message.Message;
                            break;
                        case "STTCarry":
                            lblSTTCarry.Text = "Carry: " + message.Message;
                            break;
                        case "ALUSubtract":
                            lblALUSubtract.Text = "Substract: " + message.Message;
                            break;
                    }
                    break;
                case UIMessageType.RegisterValue:
                    string binaryValue = Convert.ToString(int.Parse(message.Message), 2).PadLeft(8, '0');
                    switch (message.Source)
                    {
                        case "ARG":
                            lblARGValue.Text = "A Register: " + message.Message;
                            lblARGValueBinary.Text = binaryValue;
                            break;
                        case "BRG":
                            lblBRGValue.Text = "B Register: " + message.Message;
                            lblBRGValueBinary.Text = binaryValue;
                            break;
                        case "OUT":
                            lblOUTValue.Text = "Output Register: " + message.Message;
                            lblOUTValueBinary.Text = binaryValue;
                            break;
                        case "INS":
                            lblINSValue.Text = "Instruction Register: " + message.Message;
                            lblINSValueBinary.Text = binaryValue;
                            break;
                        case "BUS":
                            lblBUSValue.Text = "BUS: " + message.Message;
                            lblBUSValueBinary.Text = binaryValue;
                            break;
                        case "ALU":
                            lblALUValue.Text = "ALU Register: " + message.Message;
                            lblALUValueBinary.Text = binaryValue;
                            break;
                        case "PRG":
                            lblPRGValue.Text = "Program Counter: " + message.Message;
                            lblPRGValueBinary.Text = binaryValue;
                            break;
                        case "MAR":
                            lblMARValue.Text = "Memory Address Register: " + message.Message;
                            lblMARValueBinary.Text = binaryValue;
                            break;
                        case "MEM":
                            lblMEMValue.Text = "Memory: " + message.Message;
                            lblMEMValueBinary.Text = binaryValue;
                            break;
                        case "INC":
                            lblINCValue.Text = "Instruction Counter: " + message.Message;
                            lblINCValueBinary.Text = binaryValue;
                            break;
                    }
                    break;
                case UIMessageType.BusState:
                    switch (message.Source)
                    {
                        case "ARG":
                            lblARGBusState.Text = "Bus State: " + message.Message;
                            break;
                        case "BRG":
                            lblBRGBusState.Text = "Bus State: " + message.Message;
                            break;
                        case "OUT":
                            lblOUTBusState.Text = "Bus State: " + message.Message;
                            break;
                        case "INS":
                            lblINSBusState.Text = "Bus State: " + message.Message;
                            break;
                        case "ALU":
                            lblALUBusState.Text = "Bus State: " + message.Message;
                            break;
                        case "PC":
                            lblPRGBusState.Text = "Bus State: " + message.Message;
                            break;
                        case "MAR":
                            lblMARBusState.Text = "Bus State: " + message.Message;
                            break;
                        case "MEM":
                            lblMEMBusState.Text = "Bus State: " + message.Message;
                            break;
                        case "INC":
                            //lblINCBusState.Text = "Bus State: " + message.Message;
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Computer.Start();
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            Computer.Step();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
