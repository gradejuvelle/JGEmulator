using System;
using System.Windows.Forms;
using JGEmulator;
namespace JGEmulatorApp
{
    public partial class Form1 : Form
    {
        private Computer myComputer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the Computer object
            myComputer = new Computer(1000, messageTextBox, aRegisterLabel,bRegisterLabel, outputRegisterLabel, marLabel); // Default clock speed
            myComputer.RegisterValueChanged += OnRegisterValueChanged;

            // Example usage
            myComputer.StatusRegister.SetZeroFlag();
            myComputer.StatusRegister.SetCarryFlag();
            myComputer.StatusRegister.ClearZeroFlag();
            myComputer.StatusRegister.ClearCarryFlag();
        }

        private void OnRegisterValueChanged(string registerName, byte value)
        {
            if (registerName == "ARegister")
            {
                if (aRegisterLabel.InvokeRequired)
                {
                    aRegisterLabel.Invoke(new Action(() => aRegisterLabel.Text = $"A Register: {value}"));
                }
                else
                {
                    aRegisterLabel.Text = $"A Register: {value}";
                }
            }
            // Add more cases here for other registers if needed
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter clock speed (10-10000):", "Set Clock Speed", "1000");
            if (int.TryParse(input, out int speed) && speed >= 10 && speed <= 10000)
            {
                myComputer.ClockInstance.SetSpeed(speed);
                myComputer.ClockInstance.Start();
                messageTextBox.AppendText($"Clock started with speed: {speed}{Environment.NewLine}");
            }
            else
            {
                MessageBox.Show("Please enter a valid speed between 10 and 10000.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            myComputer.ClockInstance.Stop();
            messageTextBox.AppendText("Clock stopped." + Environment.NewLine);
        }
    }
}
