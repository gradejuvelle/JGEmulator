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
                             flagsDisplayControlSTT.ZF=Convert.ToBoolean( message.Message);
                            //lblSTTZero.Text = "Zero: " + message.Message;
                            break;
                        case "STTCarry":
                            flagsDisplayControlSTT.CF = Convert.ToBoolean(message.Message);
                            //lblSTTCarry.Text = "Carry: " + message.Message;
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
                            //lblARGValue.Text = "A Register: " + message.Message;
                            //lblARGValueBinary.Text = binaryValue;
                            this.byteDisplayControlARG.Value = Convert.ToByte(message.Message);

                            break;
                        case "BRG":
                            //lblBRGValue.Text = "B Register: " + message.Message;
                            //lblBRGValueBinary.Text = binaryValue;
                            this.byteDisplayControlBRG.Value = Convert.ToByte(message.Message);
                            break;
                        case "OUT":
                            //lblOUTValue.Text = "Output Register: " + message.Message;
                            //lblOUTValueBinary.Text = binaryValue;
                            this.byteDisplayControlOUT.Value = Convert.ToByte(message.Message);
                            break;
                        case "INS":
                            //lblINSValue.Text = "Instruction Register: " + message.Message;
                            //lblINSValueBinary.Text = binaryValue;
                            this.byteDisplayControlINS.Value = Convert.ToByte(message.Message);
                            break;
                        case "BUS":
                            //lblBUSValue.Text = "BUS: " + message.Message;
                            ////lblBUSValueBinary.Text = binaryValue;
                            this.byteDisplayControlBUS.Value = Convert.ToByte(message.Message);
                            break;
                        case "ALU":
                            //lblALUValue.Text = "ALU Register: " + message.Message;
                            //lblALUValueBinary.Text = binaryValue;
                            this.byteDisplayControlALU.Value = Convert.ToByte(message.Message);
                            break;
                        case "PRG":
                            //lblPRGValue.Text = "Program Counter: " + message.Message;
                            //lblPRGValueBinary.Text = binaryValue;
                            this.fourBitByteDisplayControlPRG.Value = Convert.ToByte(message.Message);
                            break;
                        case "MAR":
                            //lblMARValue.Text = "Memory Address Register: " + message.Message;
                            //lblMARValueBinary.Text = binaryValue;
                            this.fourBitByteDisplayControlMAR.Value = Convert.ToByte(message.Message);
                            break;
                        case "MEM":
                            //lblMEMValue.Text = "Memory: " + message.Message;
                            //lblMEMValueBinary.Text = binaryValue;
                            this.byteDisplayControlMEM.Value = Convert.ToByte(message.Message);
                            break;
                        case "INC":
                            //lblINCValue.Text = "Instruction Counter: " + message.Message;
                            //lblINCValueBinary.Text = binaryValue;
                            this.threeBitByteDisplayControlINC.Value = Convert.ToByte(message.Message);
                            break;
                    }
                    break;
                case UIMessageType.BusState:
                    switch (message.Source)
                    {
                        case "ARG":
                            lblARGBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    this.controlSignalDisplayControlCON.AO = false;
                                    this.controlSignalDisplayControlCON.AI = false;
                                    break;
                                case "Reading":
                                    this.controlSignalDisplayControlCON.AI = true;
                                    this.controlSignalDisplayControlCON.AO = false;
                                    break;
                                case "Writing":
                                    this.controlSignalDisplayControlCON.AI = false;
                                    this.controlSignalDisplayControlCON.AO = true;

                                    break;
                            }
                            break;
                        case "BRG":
                            lblBRGBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    this.controlSignalDisplayControlCON.BI = false;

                                    break;
                                case "Reading":
                                    this.controlSignalDisplayControlCON.BI = true;
                                    break;
                            }
                            break;
                        case "OUT":
                            lblOUTBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    this.controlSignalDisplayControlCON.OI = false;
                                    break;
                                case "Reading":
                                    this.controlSignalDisplayControlCON.OI = true;
                                    break;
                            }
                            break;
                        case "INS":
                            lblINSBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    this.controlSignalDisplayControlCON.IO = false;
                                    this.controlSignalDisplayControlCON.II = false;
                                    break;
                                case "Reading":
                                    this.controlSignalDisplayControlCON.II = true;
                                    this.controlSignalDisplayControlCON.IO = false;
                                    break;
                                case "Writing":
                                    this.controlSignalDisplayControlCON.II = false;
                                    this.controlSignalDisplayControlCON.IO = true;

                                    break;
                            }
                            break;

                        case "ALU":
                            lblALUBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    this.controlSignalDisplayControlCON.EO = false;
                                    break;
                                case "Writing":
                                    this.controlSignalDisplayControlCON.EO = true;

                                    break;
                            }
                            break;

                        case "PRG":
                            lblPRGBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    this.controlSignalDisplayControlCON.CO = false;
                                    this.controlSignalDisplayControlCON.J = false;
                                    break;
                                case "Reading":
                                    this.controlSignalDisplayControlCON.J = true;
                                    this.controlSignalDisplayControlCON.CO = false;
                                    break;
                                case "Writing":
                                    this.controlSignalDisplayControlCON.J = false;
                                    this.controlSignalDisplayControlCON.CO = true;

                                    break;
                            }
                            break;
                        case "MAR":
                            lblMARBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    this.controlSignalDisplayControlCON.MI = false;
                                    break;
                                case "Reading":
                                    this.controlSignalDisplayControlCON.MI = true;
                                    break;
                            }
                            break;
                        case "MEM":
                            lblMEMBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    this.controlSignalDisplayControlCON.RO = false;
                                    this.controlSignalDisplayControlCON.RI = false;
                                    break;
                                case "Reading":
                                    this.controlSignalDisplayControlCON.RI = true;
                                    this.controlSignalDisplayControlCON.RO = false;
                                    break;
                                case "Writing":
                                    this.controlSignalDisplayControlCON.RI = false;
                                    this.controlSignalDisplayControlCON.RO = true;

                                    break;
                            }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblINSBusState_Click(object sender, EventArgs e)
        {

        }
    }
}
