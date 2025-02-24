namespace JGEmulatorApp
{
    partial class EditMemoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewMemory;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        private System.Windows.Forms.DataGridViewTextBoxColumn AddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;


        private void InitializeComponent()
        {
            dataGridViewMemory = new DataGridView();
            AddressColumn = new DataGridViewTextBoxColumn();
            ValueColumn = new DataGridViewTextBoxColumn();
            buttonSave = new Button();
            buttonCancel = new Button();
            comboBoxPrograms = new ComboBox();
            buttonLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMemory).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMemory
            // 
            dataGridViewMemory.AllowUserToAddRows = false;
            dataGridViewMemory.AllowUserToDeleteRows = false;
            dataGridViewMemory.BackgroundColor = SystemColors.Control;
            dataGridViewMemory.BorderStyle = BorderStyle.None;
            dataGridViewMemory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMemory.Columns.AddRange(new DataGridViewColumn[] { AddressColumn, ValueColumn });
            dataGridViewMemory.Font = new Font("Segoe UI", 14F);
            dataGridViewMemory.Location = new Point(12, 12);
            dataGridViewMemory.Name = "dataGridViewMemory";
            dataGridViewMemory.Size = new Size(314, 448);
            dataGridViewMemory.TabIndex = 0;
            dataGridViewMemory.CellValidating += dataGridViewMemory_CellValidating;
            // 
            // AddressColumn
            // 
            AddressColumn.HeaderText = "Address";
            AddressColumn.Name = "AddressColumn";
            AddressColumn.ReadOnly = true;
            AddressColumn.Width = 80;
            // 
            // ValueColumn
            // 
            ValueColumn.HeaderText = "Value";
            ValueColumn.Name = "ValueColumn";
            ValueColumn.Width = 180;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 14F);
            buttonSave.Location = new Point(78, 533);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 40);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Run";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 14F);
            buttonCancel.Location = new Point(184, 533);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 40);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // comboBoxPrograms
            // 
            comboBoxPrograms.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPrograms.Font = new Font("Segoe UI", 14F);
            comboBoxPrograms.Items.AddRange(new object[] { "Empty", "Multiply", "Fibonacci" });
            comboBoxPrograms.Location = new Point(28, 471);
            comboBoxPrograms.Name = "comboBoxPrograms";
            comboBoxPrograms.Size = new Size(150, 33);
            comboBoxPrograms.TabIndex = 3;
            comboBoxPrograms.SelectedIndexChanged += comboBoxPrograms_SelectedIndexChanged;
            // 
            // buttonLoad
            // 
            buttonLoad.Enabled = false;
            buttonLoad.Font = new Font("Segoe UI", 14F);
            buttonLoad.Location = new Point(184, 466);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(120, 40);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load Editor";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // EditMemoryForm
            // 
            ClientSize = new Size(330, 585);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(dataGridViewMemory);
            Controls.Add(comboBoxPrograms);
            Controls.Add(buttonLoad);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "EditMemoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Memory";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMemory).EndInit();
            ResumeLayout(false);
        }

        private ComboBox comboBoxPrograms;
        private Button buttonLoad;

        private void comboBoxPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonLoad.Enabled = comboBoxPrograms.SelectedItem.ToString() != "Custom";
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string selectedProgram = comboBoxPrograms.SelectedItem.ToString();
            _memory.LoadMemory(selectedProgram);
            LoadMemory();
        }

        private Label label1;
    }
}

