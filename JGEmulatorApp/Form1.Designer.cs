namespace JGEmulatorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblARGValue = new Label();
            lblARGValueBinary = new Label();
            lblBRGValue = new Label();
            lblBRGValueBinary = new Label();
            lblINSValue = new Label();
            lblINSValueBinary = new Label();
            lblOUTValue = new Label();
            lblOUTValueBinary = new Label();
            lblBUSValue = new Label();
            lblBUSValueBinary = new Label();
            lblALUValue = new Label();
            lblALUValueBinary = new Label();
            lblPRGValue = new Label();
            lblPRGValueBinary = new Label();
            lblMARValue = new Label();
            lblMARValueBinary = new Label();
            lblMEMValue = new Label();
            lblMEMValueBinary = new Label();
            buttonRun = new Button();
            buttonStep = new Button();
            SuspendLayout();
            // 
            // lblARGValue
            // 
            lblARGValue.AutoSize = true;
            lblARGValue.Location = new Point(613, 148);
            lblARGValue.Name = "lblARGValue";
            lblARGValue.Size = new Size(72, 15);
            lblARGValue.TabIndex = 0;
            lblARGValue.Text = "A Register: 0";
            // 
            // lblARGValueBinary
            // 
            lblARGValueBinary.AutoSize = true;
            lblARGValueBinary.Location = new Point(613, 168);
            lblARGValueBinary.Name = "lblARGValueBinary";
            lblARGValueBinary.Size = new Size(72, 15);
            lblARGValueBinary.TabIndex = 1;
            lblARGValueBinary.Text = "00000000";
            // 
            // lblBRGValue
            // 
            lblBRGValue.AutoSize = true;
            lblBRGValue.Location = new Point(613, 210);
            lblBRGValue.Name = "lblBRGValue";
            lblBRGValue.Size = new Size(71, 15);
            lblBRGValue.TabIndex = 2;
            lblBRGValue.Text = "B Register: 0";
            // 
            // lblBRGValueBinary
            // 
            lblBRGValueBinary.AutoSize = true;
            lblBRGValueBinary.Location = new Point(613, 230);
            lblBRGValueBinary.Name = "lblBRGValueBinary";
            lblBRGValueBinary.Size = new Size(72, 15);
            lblBRGValueBinary.TabIndex = 3;
            lblBRGValueBinary.Text = "00000000";
            // 
            // lblINSValue
            // 
            lblINSValue.AutoSize = true;
            lblINSValue.Location = new Point(72, 354);
            lblINSValue.Name = "lblINSValue";
            lblINSValue.Size = new Size(121, 15);
            lblINSValue.TabIndex = 4;
            lblINSValue.Text = "Instruction Register: 0";
            // 
            // lblINSValueBinary
            // 
            lblINSValueBinary.AutoSize = true;
            lblINSValueBinary.Location = new Point(72, 374);
            lblINSValueBinary.Name = "lblINSValueBinary";
            lblINSValueBinary.Size = new Size(72, 15);
            lblINSValueBinary.TabIndex = 5;
            lblINSValueBinary.Text = "00000000";
            // 
            // lblOUTValue
            // 
            lblOUTValue.AutoSize = true;
            lblOUTValue.Location = new Point(613, 354);
            lblOUTValue.Name = "lblOUTValue";
            lblOUTValue.Size = new Size(102, 15);
            lblOUTValue.TabIndex = 6;
            lblOUTValue.Text = "Output Register: 0";
            // 
            // lblOUTValueBinary
            // 
            lblOUTValueBinary.AutoSize = true;
            lblOUTValueBinary.Location = new Point(613, 374);
            lblOUTValueBinary.Name = "lblOUTValueBinary";
            lblOUTValueBinary.Size = new Size(72, 15);
            lblOUTValueBinary.TabIndex = 7;
            lblOUTValueBinary.Text = "00000000";
            // 
            // lblBUSValue
            // 
            lblBUSValue.AutoSize = true;
            lblBUSValue.Location = new Point(372, 180);
            lblBUSValue.Name = "lblBUSValue";
            lblBUSValue.Size = new Size(85, 15);
            lblBUSValue.TabIndex = 8;
            lblBUSValue.Text = "BUS Register: 0";
            // 
            // lblBUSValueBinary
            // 
            lblBUSValueBinary.AutoSize = true;
            lblBUSValueBinary.Location = new Point(372, 200);
            lblBUSValueBinary.Name = "lblBUSValueBinary";
            lblBUSValueBinary.Size = new Size(72, 15);
            lblBUSValueBinary.TabIndex = 9;
            lblBUSValueBinary.Text = "00000000";
            // 
            // lblALUValue
            // 
            lblALUValue.AutoSize = true;
            lblALUValue.Location = new Point(613, 180);
            lblALUValue.Name = "lblALUValue";
            lblALUValue.Size = new Size(86, 15);
            lblALUValue.TabIndex = 10;
            lblALUValue.Text = "ALU Register: 0";
            // 
            // lblALUValueBinary
            // 
            lblALUValueBinary.AutoSize = true;
            lblALUValueBinary.Location = new Point(613, 200);
            lblALUValueBinary.Name = "lblALUValueBinary";
            lblALUValueBinary.Size = new Size(72, 15);
            lblALUValueBinary.TabIndex = 11;
            lblALUValueBinary.Text = "00000000";
            // 
            // lblPRGValue
            // 
            lblPRGValue.AutoSize = true;
            lblPRGValue.Location = new Point(613, 56);
            lblPRGValue.Name = "lblPRGValue";
            lblPRGValue.Size = new Size(111, 15);
            lblPRGValue.TabIndex = 12;
            lblPRGValue.Text = "Program Counter: 0";
            // 
            // lblPRGValueBinary
            // 
            lblPRGValueBinary.AutoSize = true;
            lblPRGValueBinary.Location = new Point(613, 76);
            lblPRGValueBinary.Name = "lblPRGValueBinary";
            lblPRGValueBinary.Size = new Size(72, 15);
            lblPRGValueBinary.TabIndex = 13;
            lblPRGValueBinary.Text = "00000000";
            // 
            // lblMARValue
            // 
            lblMARValue.AutoSize = true;
            lblMARValue.Location = new Point(72, 122);
            lblMARValue.Name = "lblMARValue";
            lblMARValue.Size = new Size(154, 15);
            lblMARValue.TabIndex = 14;
            lblMARValue.Text = "Memory Address Register: 0";
            // 
            // lblMARValueBinary
            // 
            lblMARValueBinary.AutoSize = true;
            lblMARValueBinary.Location = new Point(72, 142);
            lblMARValueBinary.Name = "lblMARValueBinary";
            lblMARValueBinary.Size = new Size(72, 15);
            lblMARValueBinary.TabIndex = 15;
            lblMARValueBinary.Text = "00000000";
            // 
            // lblMEMValue
            // 
            lblMEMValue.AutoSize = true;
            lblMEMValue.Location = new Point(72, 180);
            lblMEMValue.Name = "lblMEMValue";
            lblMEMValue.Size = new Size(64, 15);
            lblMEMValue.TabIndex = 16;
            lblMEMValue.Text = "Memory: 0";
            // 
            // lblMEMValueBinary
            // 
            lblMEMValueBinary.AutoSize = true;
            lblMEMValueBinary.Location = new Point(72, 200);
            lblMEMValueBinary.Name = "lblMEMValueBinary";
            lblMEMValueBinary.Size = new Size(72, 15);
            lblMEMValueBinary.TabIndex = 17;
            lblMEMValueBinary.Text = "00000000";
            // 
            // buttonRun
            // 
            buttonRun.Location = new Point(372, 354);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(75, 23);
            buttonRun.TabIndex = 18;
            buttonRun.Text = "Run";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // buttonStep
            // 
            buttonStep.Location = new Point(372, 384);
            buttonStep.Name = "buttonStep";
            buttonStep.Size = new Size(75, 23);
            buttonStep.TabIndex = 19;
            buttonStep.Text = "Step";
            buttonStep.UseVisualStyleBackColor = true;
            buttonStep.Click += buttonStep_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonStep);
            Controls.Add(buttonRun);
            Controls.Add(lblMEMValueBinary);
            Controls.Add(lblMEMValue);
            Controls.Add(lblMARValueBinary);
            Controls.Add(lblMARValue);
            Controls.Add(lblPRGValueBinary);
            Controls.Add(lblPRGValue);
            Controls.Add(lblALUValueBinary);
            Controls.Add(lblALUValue);
            Controls.Add(lblBUSValueBinary);
            Controls.Add(lblBUSValue);
            Controls.Add(lblOUTValueBinary);
            Controls.Add(lblOUTValue);
            Controls.Add(lblINSValueBinary);
            Controls.Add(lblINSValue);
            Controls.Add(lblBRGValueBinary);
            Controls.Add(lblBRGValue);
            Controls.Add(lblARGValueBinary);
            Controls.Add(lblARGValue);
            Name = "Form1";
            Text = "BENIAC";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblARGValue;
        private Label lblARGValueBinary;
        private Label lblBRGValue;
        private Label lblBRGValueBinary;
        private Label lblINSValue;
        private Label lblINSValueBinary;
        private Label lblOUTValue;
        private Label lblOUTValueBinary;
        private Label lblBUSValue;
        private Label lblBUSValueBinary;
        private Label lblALUValue;
        private Label lblALUValueBinary;
        private Label lblPRGValue;
        private Label lblPRGValueBinary;
        private Label lblMARValue;
        private Label lblMARValueBinary;
        private Label lblMEMValue;
        private Label lblMEMValueBinary;
        private Button buttonRun;
        private Button buttonStep;
    }
}
