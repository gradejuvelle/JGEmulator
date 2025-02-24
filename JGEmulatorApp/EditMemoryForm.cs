using System;
using System.Windows.Forms;
using JGEmulator;

namespace JGEmulatorApp
{
    public partial class EditMemoryForm : Form
    {
        private Memory _memory;
        private Computer _computer;
        private byte[] _displaybytes;

        public EditMemoryForm(Memory memory, Computer computer)
        {
            InitializeComponent();
            _memory = memory;
            _computer = computer;
            LoadMemory();
        }

        private void LoadMemory()
        {
            byte[] memory = _memory.GetMemory();
            dataGridViewMemory.Rows.Clear(); // Clear existing rows
            for (int i = 0; i < memory.Length; i++)
            {
                string binaryValue = Convert.ToString(memory[i], 2).PadLeft(8, '0');
                dataGridViewMemory.Rows.Add(i, binaryValue);
            }
            Invalidate();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _displaybytes = new byte[16];
            for (int i = 0; i < 16; i++)
            {
                var cellValue = dataGridViewMemory.Rows[i].Cells[1].Value;
                if (cellValue != null && cellValue.ToString().Length == 8)
                {
                    _displaybytes[i] = Convert.ToByte(cellValue.ToString(), 2);
                }
            }
            _computer.MemoryInstance.UpdateMemory(_displaybytes);
            _computer.Reset();
            LoadMemory();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewMemory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1) // Only validate the Value column
            {
                string newValue = e.FormattedValue.ToString();
                if (newValue.Length != 8 || !IsBinaryString(newValue))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter exactly 8 binary digits (0 or 1).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsBinaryString(string value)
        {
            foreach (char c in value)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        //private void dataGridViewMemory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    // Disable the Run button when editing starts
        //    ((AppForm)this.Owner).buttonRun.Enabled = false;
        //}

        //private void dataGridViewMemory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Re-enable the Run button after editing ends
        //    ((AppForm)this.Owner).buttonRun.Enabled = true;
        //}
    }
}
