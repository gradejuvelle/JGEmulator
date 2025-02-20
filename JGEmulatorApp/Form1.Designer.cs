namespace JGEmulatorApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label aRegisterLabel;
        private System.Windows.Forms.Label bRegisterLabel;
        private System.Windows.Forms.Label outputRegisterLabel;
        private System.Windows.Forms.Label marLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.aRegisterLabel = new System.Windows.Forms.Label();
            this.bRegisterLabel = new System.Windows.Forms.Label();
            this.outputRegisterLabel = new System.Windows.Forms.Label();
            this.marLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(12, 100);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTextBox.Size = new System.Drawing.Size(776, 344);
            this.messageTextBox.TabIndex = 0;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(12, 450);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(93, 450);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // aRegisterLabel
            // 
            this.aRegisterLabel.AutoSize = true;
            this.aRegisterLabel.Location = new System.Drawing.Point(12, 20);
            this.aRegisterLabel.Name = "aRegisterLabel";
            this.aRegisterLabel.Size = new System.Drawing.Size(70, 15);
            this.aRegisterLabel.TabIndex = 3;
            this.aRegisterLabel.Text = "A Register: 0";
            // 
            // bRegisterLabel
            // 
            this.bRegisterLabel.AutoSize = true;
            this.bRegisterLabel.Location = new System.Drawing.Point(12, 40);
            this.bRegisterLabel.Name = "bRegisterLabel";
            this.bRegisterLabel.Size = new System.Drawing.Size(70, 15);
            this.bRegisterLabel.TabIndex = 4;
            this.bRegisterLabel.Text = "B Register: 0";
            // 
            // outputRegisterLabel
            // 
            this.outputRegisterLabel.AutoSize = true;
            this.outputRegisterLabel.Location = new System.Drawing.Point(12, 60);
            this.outputRegisterLabel.Name = "outputRegisterLabel";
            this.outputRegisterLabel.Size = new System.Drawing.Size(95, 15);
            this.outputRegisterLabel.TabIndex = 5;
            this.outputRegisterLabel.Text = "Output Register: 0";
            // 
            // marLabel
            // 
            this.marLabel.AutoSize = true;
            this.marLabel.Location = new System.Drawing.Point(12, 80);
            this.marLabel.Name = "marLabel";
            this.marLabel.Size = new System.Drawing.Size(37, 15);
            this.marLabel.TabIndex = 6;
            this.marLabel.Text = "MAR: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.marLabel);
            this.Controls.Add(this.outputRegisterLabel);
            this.Controls.Add(this.bRegisterLabel);
            this.Controls.Add(this.aRegisterLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.messageTextBox);
            this.Name = "Form1";
            this.Text = "JGEmulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
