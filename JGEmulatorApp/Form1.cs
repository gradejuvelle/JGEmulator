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
            Computer = new JGEmulator.Computer(200, this);
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
                            lblBUSValue.Text = "BUS Register: " + message.Message;
                            lblBUSValueBinary.Text = binaryValue;
                            break;
                        case "ALU":
                            lblALUValue.Text = "ALU Register: " + message.Message;
                            lblALUValueBinary.Text = binaryValue;
                            break;
                        case "PC":
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
                    }
                    break;
                case UIMessageType.BusState:
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
    }
}
