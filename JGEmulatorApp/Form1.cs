using JGEmulator;
using System;
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
            this.memoryDisplayControl1.Memory = Computer.MemoryInstance.GetMemory();
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
                            flagsDisplayControlSTT.ZF = Convert.ToBoolean(message.Message);
                            break;
                        case "STTCarry":
                            flagsDisplayControlSTT.CF = Convert.ToBoolean(message.Message);
                            break;
                        case "ALUSubtract":
                            lblALUSubtract.Text = "Subtract: " + message.Message;
                            break;
                    }
                    break;
                case UIMessageType.RegisterValue:
                    string binaryValue = Convert.ToString(int.Parse(message.Message), 2).PadLeft(8, '0');
                    switch (message.Source)
                    {
                        case "ARG":
                            this.byteDisplayControlARG.Value = Convert.ToByte(message.Message);
                            break;
                        case "BRG":
                            this.byteDisplayControlBRG.Value = Convert.ToByte(message.Message);
                            break;
                        case "OUT":
                            this.byteDisplayControlOUT.Value = Convert.ToByte(message.Message);
                            break;
                        case "INS":
                            this.byteDisplayControlINS.Value = Convert.ToByte(message.Message);
                            break;
                        case "BUS":
                            this.byteDisplayControlBUS.Value = Convert.ToByte(message.Message);
                            break;
                        case "ALU":
                            this.byteDisplayControlALU.Value = Convert.ToByte(message.Message);
                            break;
                        case "PRG":
                            this.fourBitByteDisplayControlPRG.Value = Convert.ToByte(message.Message);
                            break;
                        case "MAR":
                            this.fourBitByteDisplayControlMAR.Value = Convert.ToByte(message.Message);
                            break;
                        case "MEM":
                            this.byteDisplayControlMEM.Value = Convert.ToByte(message.Message);
                            break;
                        case "INC":
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
                case UIMessageType.Memory:
                    var parts = message.Message.Split(':');
                 //   if (parts.Length == 2 && byte.TryParse(parts[0], out byte address) && byte.TryParse(parts[1], out byte value))
                    //{
                        //memoryDisplayControl1.SetAddressValue(Convert.ToByte( parts[0]), Convert.ToByte(parts[1]));
                    //}
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



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblINSBusState_Click(object sender, EventArgs e)
        {

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Computer.Stop();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Computer.Reset();
        }
    }
}

