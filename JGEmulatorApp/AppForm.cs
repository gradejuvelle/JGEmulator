using JGEmulator;
using System;
using System.Windows.Forms;

namespace JGEmulatorApp
{
    public partial class AppForm : Form
    {
        private JGEmulator.Computer Computer;
        private bool halted = false;

        public AppForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi; // Enable DPI scaling
            this.AutoScaleDimensions = new SizeF(96F, 96F); // Set default DPI settings

            Computer = new JGEmulator.Computer(40, this);
            this.memoryDisplayControl01.Memory = Computer.MemoryInstance;
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Make the form non-resizable
            Computer.Reset();
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
                            this.controlSignalDisplayControlCON.CE = Convert.ToBoolean(message.Message);
                            break;
                        case "STTZero":
                            flagsDisplayControlSTT.ZF = Convert.ToBoolean(message.Message);
                            break;
                        case "STTCarry":
                            flagsDisplayControlSTT.CF = Convert.ToBoolean(message.Message);
                            break;
                        case "ALUSubtract":
                            lblALUSubtract.Text = "Subtract: " + message.Message;
                            this.controlSignalDisplayControlCON.SU = Convert.ToBoolean(message.Message);
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
                            //this.byteDisplayControlINS.Value = Convert.ToByte(message.Message);
                            this.instructionRegisterDisplayControlINS.Value = Convert.ToByte(message.Message);
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
                                    lblARGBusState.Visible = false;
                                    this.controlSignalDisplayControlCON.AO = false;
                                    this.controlSignalDisplayControlCON.AI = false;
                                    break;
                                case "Reading":
                                    lblARGBusState.Visible = true;
                                    this.controlSignalDisplayControlCON.AI = true;
                                    this.controlSignalDisplayControlCON.AO = false;
                                    break;
                                case "Writing":
                                    lblARGBusState.Visible = true;
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
                                    lblBRGBusState.Visible = false;
                                    this.controlSignalDisplayControlCON.BI = false;
                                    break;
                                case "Reading":
                                    lblBRGBusState.Visible = true;
                                    this.controlSignalDisplayControlCON.BI = true;
                                    break;
                            }
                            break;
                        case "OUT":
                            lblOUTBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    lblOUTBusState.Visible = false;
                                    this.controlSignalDisplayControlCON.OI = false;
                                    break;
                                case "Reading":
                                    lblOUTBusState.Visible = true;
                                    this.controlSignalDisplayControlCON.OI = true;
                                    break;
                            }
                            break;
                        case "INS":
                            lblINSBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    lblINSBusState.Visible = false;
                                    this.controlSignalDisplayControlCON.IO = false;
                                    this.controlSignalDisplayControlCON.II = false;
                                    break;
                                case "Reading":
                                    lblINSBusState.Visible = true;
                                    this.controlSignalDisplayControlCON.II = true;
                                    this.controlSignalDisplayControlCON.IO = false;
                                    break;
                                case "Writing":
                                    lblINSBusState.Visible = true;
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
                                    lblALUBusState.Visible = false;
                                    break;
                                case "Writing":
                                    lblALUBusState.Visible = true;
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
                                    lblPRGBusState.Visible = false;
                                    break;
                                case "Reading":
                                    this.controlSignalDisplayControlCON.J = true;
                                    this.controlSignalDisplayControlCON.CO = false;
                                    lblPRGBusState.Visible = true;
                                    break;
                                case "Writing":
                                    this.controlSignalDisplayControlCON.J = false;
                                    this.controlSignalDisplayControlCON.CO = true;
                                    lblPRGBusState.Visible = true;
                                    break;
                            }
                            break;
                        case "MAR":
                            lblMARBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    lblMARBusState.Visible = false;
                                    this.controlSignalDisplayControlCON.MI = false;
                                    break;
                                case "Reading":
                                    lblMARBusState.Visible = true;
                                    this.controlSignalDisplayControlCON.MI = true;
                                    break;
                            }
                            break;
                        case "MEM":
                            lblMEMBusState.Text = "Bus State: " + message.Message;
                            switch (message.Message)
                            {
                                case "None":
                                    lblMEMBusState.Visible = false;
                                    this.controlSignalDisplayControlCON.RO = false;
                                    this.controlSignalDisplayControlCON.RI = false;
                                    break;
                                case "Reading":
                                    lblMEMBusState.Visible = true;
                                    this.controlSignalDisplayControlCON.RI = true;
                                    this.controlSignalDisplayControlCON.RO = false;
                                    break;
                                case "Writing":
                                    lblMEMBusState.Visible = true;
                                    this.controlSignalDisplayControlCON.RI = false;
                                    this.controlSignalDisplayControlCON.RO = true;
                                    break;
                            }
                            break;

                        case "STT":
                            switch (message.Message)
                            {
                                case "None":
                                    controlSignalDisplayControlCON.FI = false;
                                    break;
                                case "Reading":
                                    this.controlSignalDisplayControlCON.FI = true;
                                    break;
                            }

                            break;
                    }
                    break;
                case UIMessageType.Memory:
                    var parts = message.Message.Split(':');
                    //   if (parts.Length == 2 && byte.TryParse(parts[0], out byte address) && byte.TryParse(parts[1], out byte value))
                    //{
                    memoryDisplayControl01.SetAddressValue(Convert.ToByte(parts[0]), Convert.ToByte(parts[1]));
                    //}
                    break;
                case UIMessageType.Computer:
                    switch (message.Message)
                    {
                        case "Reset":
                            this.memoryDisplayControl01.Memory = Computer.MemoryInstance;

                            break;
                        case "STOP":
                            this.halted = true;
                            this.buttonStop.Enabled = false;
                            this.buttonReset.Enabled = true;
                            halted = false;
                            this.controlSignalDisplayControlCON.HLT = true;

                            break;
                    }
                    break;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            halted = false;
            buttonStop.Enabled = true;
            buttonRun.Enabled = false;
            buttonStep.Enabled = false;
            buttonReset.Enabled = false;
            buttonEditMemory.Enabled = false;
            txtClockSpeed.Enabled = false;
            Computer.SetSpeed((int)((1.0 / Convert.ToInt32(txtClockSpeed.Text)) * 1000));

            Computer.Start();
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            Computer.Step();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {

            buttonStop.Enabled = false;
            if (!halted)
            {
                buttonRun.Enabled = true;
                buttonStep.Enabled = true;
                buttonReset.Enabled = true;
                buttonEditMemory.Enabled = true;
            }
            txtClockSpeed.Enabled = true;
            buttonReset.Enabled = true;
            Computer.Stop();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Computer.Reset();
            buttonRun.Enabled = true;
            buttonStep.Enabled = true;
            buttonEditMemory.Enabled = true;
            txtClockSpeed.Enabled = true;
            this.controlSignalDisplayControlCON.HLT = false;
        }

        private void buttonEditMemory_Click_1(object sender, EventArgs e)
        {
            EditMemoryForm editMemoryForm = new EditMemoryForm(Computer.MemoryInstance, Computer);
            editMemoryForm.ShowDialog();
        }

        private void txtClockSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtClockSpeed_TextChanged(object sender, EventArgs e)
        {
            // Disable the Run button when editing starts
            //buttonRun.Enabled = false;

            if (int.TryParse(txtClockSpeed.Text, out int clockSpeed))
            {
                if (clockSpeed >= 1 && clockSpeed <= 25)
                {
                    // Re-enable the Run button after a successful change
                    //buttonRun.Enabled = true;
                    Computer.SetSpeed((1/   clockSpeed)*1000);
                }
                else
                {
                    MessageBox.Show("Please enter a value between 1 and 25.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
