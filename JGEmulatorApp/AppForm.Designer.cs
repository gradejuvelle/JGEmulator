namespace JGEmulatorApp
{
    partial class AppForm
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
            byteDisplayControlMEM = new ByteDisplayControl();
            buttonRun = new Button();
            buttonStep = new Button();
            lblARGBusState = new Label();
            lblMARBusState = new Label();
            lblBRGBusState = new Label();
            lblINSBusState = new Label();
            lblOUTBusState = new Label();
            lblALUBusState = new Label();
            lblPRGBusState = new Label();
            lblMEMBusState = new Label();
            lblPRGEnable = new Label();
            lblALUSubtract = new Label();
            byteDisplayControlBRG = new ByteDisplayControl();
            byteDisplayControlARG = new ByteDisplayControl();
            byteDisplayControlALU = new ByteDisplayControl();
            byteDisplayControlOUT = new ByteDisplayControl();
            byteDisplayControlBUS = new ByteDisplayControl();
            fourBitByteDisplayControlPRG = new FourBitByteDisplayControl();
            fourBitByteDisplayControlMAR = new FourBitByteDisplayControl();
            threeBitByteDisplayControlINC = new ThreeBitByteDisplayControl();
            controlSignalDisplayControlCON = new ControlSignalDisplayControl();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            flagsDisplayControlSTT = new FlagsDisplayControl();
            buttonReset = new Button();
            buttonStop = new Button();
            instructionRegisterDisplayControlINS = new InstructionRegisterDisplayControl();
            memoryDisplayControl01 = new MemoryDisplayControl();
            label13 = new Label();
            buttonEditMemory = new Button();
            txtClockSpeed = new TextBox();
            label14 = new Label();
            label15 = new Label();
            SuspendLayout();
            // 
            // byteDisplayControlMEM
            // 
            byteDisplayControlMEM.Location = new Point(68, 439);
            byteDisplayControlMEM.Name = "byteDisplayControlMEM";
            byteDisplayControlMEM.Size = new Size(389, 30);
            byteDisplayControlMEM.TabIndex = 34;
            byteDisplayControlMEM.Value = 0;
            // 
            // buttonRun
            // 
            buttonRun.Font = new Font("Segoe UI", 14F);
            buttonRun.Location = new Point(186, 30);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(100, 40);
            buttonRun.TabIndex = 26;
            buttonRun.Text = "Run";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // buttonStep
            // 
            buttonStep.Font = new Font("Segoe UI", 14F);
            buttonStep.Location = new Point(420, 30);
            buttonStep.Name = "buttonStep";
            buttonStep.Size = new Size(100, 40);
            buttonStep.TabIndex = 27;
            buttonStep.Text = "Step";
            buttonStep.UseVisualStyleBackColor = true;
            buttonStep.Click += buttonStep_Click;
            // 
            // lblARGBusState
            // 
            lblARGBusState.AutoSize = true;
            lblARGBusState.Font = new Font("Segoe UI", 14F);
            lblARGBusState.ForeColor = Color.ForestGreen;
            lblARGBusState.Location = new Point(846, 375);
            lblARGBusState.Name = "lblARGBusState";
            lblARGBusState.Size = new Size(143, 25);
            lblARGBusState.TabIndex = 2;
            lblARGBusState.Text = "Bus State: None";
            // 
            // lblMARBusState
            // 
            lblMARBusState.AutoSize = true;
            lblMARBusState.Font = new Font("Segoe UI", 14F);
            lblMARBusState.ForeColor = Color.ForestGreen;
            lblMARBusState.Location = new Point(68, 377);
            lblMARBusState.Name = "lblMARBusState";
            lblMARBusState.Size = new Size(143, 25);
            lblMARBusState.TabIndex = 20;
            lblMARBusState.Text = "Bus State: None";
            // 
            // lblBRGBusState
            // 
            lblBRGBusState.AutoSize = true;
            lblBRGBusState.Font = new Font("Segoe UI", 14F);
            lblBRGBusState.ForeColor = Color.ForestGreen;
            lblBRGBusState.Location = new Point(846, 624);
            lblBRGBusState.Name = "lblBRGBusState";
            lblBRGBusState.Size = new Size(143, 25);
            lblBRGBusState.TabIndex = 5;
            lblBRGBusState.Text = "Bus State: None";
            lblBRGBusState.Click += lblBRGBusState_Click;
            // 
            // lblINSBusState
            // 
            lblINSBusState.AutoSize = true;
            lblINSBusState.Font = new Font("Segoe UI", 14F);
            lblINSBusState.ForeColor = Color.ForestGreen;
            lblINSBusState.Location = new Point(68, 624);
            lblINSBusState.Name = "lblINSBusState";
            lblINSBusState.Size = new Size(143, 25);
            lblINSBusState.TabIndex = 8;
            lblINSBusState.Text = "Bus State: None";
            // 
            // lblOUTBusState
            // 
            lblOUTBusState.AutoSize = true;
            lblOUTBusState.Font = new Font("Segoe UI", 14F);
            lblOUTBusState.ForeColor = Color.ForestGreen;
            lblOUTBusState.Location = new Point(846, 759);
            lblOUTBusState.Name = "lblOUTBusState";
            lblOUTBusState.Size = new Size(143, 25);
            lblOUTBusState.TabIndex = 11;
            lblOUTBusState.Text = "Bus State: None";
            // 
            // lblALUBusState
            // 
            lblALUBusState.AutoSize = true;
            lblALUBusState.Font = new Font("Segoe UI", 14F);
            lblALUBusState.ForeColor = Color.ForestGreen;
            lblALUBusState.Location = new Point(846, 500);
            lblALUBusState.Name = "lblALUBusState";
            lblALUBusState.Size = new Size(143, 25);
            lblALUBusState.TabIndex = 14;
            lblALUBusState.Text = "Bus State: None";
            // 
            // lblPRGBusState
            // 
            lblPRGBusState.AutoSize = true;
            lblPRGBusState.Font = new Font("Segoe UI", 14F);
            lblPRGBusState.ForeColor = Color.ForestGreen;
            lblPRGBusState.Location = new Point(839, 229);
            lblPRGBusState.Name = "lblPRGBusState";
            lblPRGBusState.Size = new Size(143, 25);
            lblPRGBusState.TabIndex = 17;
            lblPRGBusState.Text = "Bus State: None";
            // 
            // lblMEMBusState
            // 
            lblMEMBusState.AutoSize = true;
            lblMEMBusState.Font = new Font("Segoe UI", 14F);
            lblMEMBusState.ForeColor = Color.ForestGreen;
            lblMEMBusState.Location = new Point(68, 472);
            lblMEMBusState.Name = "lblMEMBusState";
            lblMEMBusState.Size = new Size(143, 25);
            lblMEMBusState.TabIndex = 23;
            lblMEMBusState.Text = "Bus State: None";
            // 
            // lblPRGEnable
            // 
            lblPRGEnable.AutoSize = true;
            lblPRGEnable.Font = new Font("Segoe UI", 14F);
            lblPRGEnable.ForeColor = Color.ForestGreen;
            lblPRGEnable.Location = new Point(843, 229);
            lblPRGEnable.Name = "lblPRGEnable";
            lblPRGEnable.Size = new Size(119, 25);
            lblPRGEnable.TabIndex = 30;
            lblPRGEnable.Text = "Enable: False";
            // 
            // lblALUSubtract
            // 
            lblALUSubtract.AutoSize = true;
            lblALUSubtract.Font = new Font("Segoe UI", 14F);
            lblALUSubtract.ForeColor = Color.ForestGreen;
            lblALUSubtract.Location = new Point(1014, 500);
            lblALUSubtract.Name = "lblALUSubtract";
            lblALUSubtract.Size = new Size(124, 25);
            lblALUSubtract.TabIndex = 33;
            lblALUSubtract.Text = "Subtract: false";
            // 
            // byteDisplayControlBRG
            // 
            byteDisplayControlBRG.Location = new Point(843, 591);
            byteDisplayControlBRG.Name = "byteDisplayControlBRG";
            byteDisplayControlBRG.Size = new Size(389, 30);
            byteDisplayControlBRG.TabIndex = 35;
            byteDisplayControlBRG.Text = "byteDisplayControl1";
            byteDisplayControlBRG.Value = 0;
            // 
            // byteDisplayControlARG
            // 
            byteDisplayControlARG.Location = new Point(843, 342);
            byteDisplayControlARG.Name = "byteDisplayControlARG";
            byteDisplayControlARG.Size = new Size(389, 30);
            byteDisplayControlARG.TabIndex = 36;
            byteDisplayControlARG.Value = 0;
            // 
            // byteDisplayControlALU
            // 
            byteDisplayControlALU.Location = new Point(843, 467);
            byteDisplayControlALU.Name = "byteDisplayControlALU";
            byteDisplayControlALU.Size = new Size(389, 30);
            byteDisplayControlALU.TabIndex = 38;
            byteDisplayControlALU.Value = 0;
            // 
            // byteDisplayControlOUT
            // 
            byteDisplayControlOUT.Location = new Point(839, 726);
            byteDisplayControlOUT.Name = "byteDisplayControlOUT";
            byteDisplayControlOUT.Size = new Size(389, 30);
            byteDisplayControlOUT.TabIndex = 39;
            byteDisplayControlOUT.Value = 0;
            // 
            // byteDisplayControlBUS
            // 
            byteDisplayControlBUS.Location = new Point(452, 197);
            byteDisplayControlBUS.Name = "byteDisplayControlBUS";
            byteDisplayControlBUS.Size = new Size(389, 34);
            byteDisplayControlBUS.TabIndex = 40;
            byteDisplayControlBUS.Value = 0;
            // 
            // fourBitByteDisplayControlPRG
            // 
            fourBitByteDisplayControlPRG.Location = new Point(843, 196);
            fourBitByteDisplayControlPRG.Name = "fourBitByteDisplayControlPRG";
            fourBitByteDisplayControlPRG.Size = new Size(331, 30);
            fourBitByteDisplayControlPRG.TabIndex = 41;
            fourBitByteDisplayControlPRG.Text = "fourBitByteDisplayControlPRG";
            fourBitByteDisplayControlPRG.Value = 0;
            // 
            // fourBitByteDisplayControlMAR
            // 
            fourBitByteDisplayControlMAR.Location = new Point(68, 344);
            fourBitByteDisplayControlMAR.Name = "fourBitByteDisplayControlMAR";
            fourBitByteDisplayControlMAR.Size = new Size(331, 30);
            fourBitByteDisplayControlMAR.TabIndex = 42;
            fourBitByteDisplayControlMAR.Text = "fourBitByteDisplayControlMAR";
            fourBitByteDisplayControlMAR.Value = 0;
            // 
            // threeBitByteDisplayControlINC
            // 
            threeBitByteDisplayControlINC.Location = new Point(68, 703);
            threeBitByteDisplayControlINC.Name = "threeBitByteDisplayControlINC";
            threeBitByteDisplayControlINC.Size = new Size(198, 30);
            threeBitByteDisplayControlINC.TabIndex = 43;
            threeBitByteDisplayControlINC.Text = "threeBitByteDisplayControl1";
            threeBitByteDisplayControlINC.Value = 0;
            threeBitByteDisplayControlINC.Click += threeBitByteDisplayControlINC_Click;
            // 
            // controlSignalDisplayControlCON
            // 
            controlSignalDisplayControlCON.AI = false;
            controlSignalDisplayControlCON.AO = false;
            controlSignalDisplayControlCON.BI = false;
            controlSignalDisplayControlCON.CE = false;
            controlSignalDisplayControlCON.CO = false;
            controlSignalDisplayControlCON.EO = false;
            controlSignalDisplayControlCON.FI = false;
            controlSignalDisplayControlCON.HLT = false;
            controlSignalDisplayControlCON.II = false;
            controlSignalDisplayControlCON.IO = false;
            controlSignalDisplayControlCON.J = false;
            controlSignalDisplayControlCON.Location = new Point(753, 52);
            controlSignalDisplayControlCON.MI = false;
            controlSignalDisplayControlCON.Name = "controlSignalDisplayControlCON";
            controlSignalDisplayControlCON.OI = false;
            controlSignalDisplayControlCON.RI = false;
            controlSignalDisplayControlCON.RO = false;
            controlSignalDisplayControlCON.Size = new Size(527, 68);
            controlSignalDisplayControlCON.SU = false;
            controlSignalDisplayControlCON.TabIndex = 44;
            controlSignalDisplayControlCON.Text = "controlSignalDisplayControl1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(839, 686);
            label1.Name = "label1";
            label1.Size = new Size(203, 37);
            label1.TabIndex = 45;
            label1.Text = "Output Register";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(68, 303);
            label2.Name = "label2";
            label2.Size = new Size(319, 37);
            label2.TabIndex = 46;
            label2.Text = "Memory Address Register";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(68, 402);
            label3.Name = "label3";
            label3.Size = new Size(116, 37);
            label3.TabIndex = 47;
            label3.Text = "Memory";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F);
            label4.Location = new Point(68, 551);
            label4.Name = "label4";
            label4.Size = new Size(244, 37);
            label4.TabIndex = 48;
            label4.Text = "Instruction Register";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F);
            label5.Location = new Point(68, 663);
            label5.Name = "label5";
            label5.Size = new Size(244, 37);
            label5.TabIndex = 49;
            label5.Text = "Instruction Counter";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F);
            label6.Location = new Point(843, 551);
            label6.Name = "label6";
            label6.Size = new Size(134, 37);
            label6.TabIndex = 50;
            label6.Text = "B Register";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20F);
            label7.Location = new Point(843, 432);
            label7.Name = "label7";
            label7.Size = new Size(65, 37);
            label7.TabIndex = 51;
            label7.Text = "ALU";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 20F);
            label8.Location = new Point(843, 302);
            label8.Name = "label8";
            label8.Size = new Size(136, 37);
            label8.TabIndex = 52;
            label8.Text = "A Register";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 20F);
            label9.Location = new Point(843, 156);
            label9.Name = "label9";
            label9.Size = new Size(221, 37);
            label9.TabIndex = 53;
            label9.Text = "Program Counter";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 20F);
            label10.Location = new Point(545, 156);
            label10.Name = "label10";
            label10.Size = new Size(58, 37);
            label10.TabIndex = 54;
            label10.Text = "Bus";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 20F);
            label11.Location = new Point(923, 12);
            label11.Name = "label11";
            label11.Size = new Size(178, 37);
            label11.TabIndex = 55;
            label11.Text = "Control Word";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 30F);
            label12.Location = new Point(12, 19);
            label12.Name = "label12";
            label12.Size = new Size(157, 54);
            label12.TabIndex = 56;
            label12.Text = "BENIAC";
            // 
            // flagsDisplayControlSTT
            // 
            flagsDisplayControlSTT.CF = false;
            flagsDisplayControlSTT.Location = new Point(1179, 465);
            flagsDisplayControlSTT.Name = "flagsDisplayControlSTT";
            flagsDisplayControlSTT.Size = new Size(101, 82);
            flagsDisplayControlSTT.TabIndex = 57;
            flagsDisplayControlSTT.Text = "flagsDisplayControl1";
            flagsDisplayControlSTT.ZF = false;
            // 
            // buttonReset
            // 
            buttonReset.Font = new Font("Segoe UI", 14F);
            buttonReset.Location = new Point(535, 30);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(100, 40);
            buttonReset.TabIndex = 58;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonStop
            // 
            buttonStop.Font = new Font("Segoe UI", 14F);
            buttonStop.Location = new Point(301, 30);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(100, 40);
            buttonStop.TabIndex = 59;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // instructionRegisterDisplayControlINS
            // 
            instructionRegisterDisplayControlINS.Location = new Point(68, 591);
            instructionRegisterDisplayControlINS.Name = "instructionRegisterDisplayControlINS";
            instructionRegisterDisplayControlINS.Size = new Size(389, 30);
            instructionRegisterDisplayControlINS.TabIndex = 60;
            instructionRegisterDisplayControlINS.Text = "instructionRegisterDisplayControl1";
            instructionRegisterDisplayControlINS.Value = 0;
            // 
            // memoryDisplayControl01
            // 
            memoryDisplayControl01.BackColor = SystemColors.Control;
            memoryDisplayControl01.Location = new Point(524, 342);
            memoryDisplayControl01.Memory = null;
            memoryDisplayControl01.Name = "memoryDisplayControl01";
            memoryDisplayControl01.Size = new Size(158, 420);
            memoryDisplayControl01.TabIndex = 61;
            memoryDisplayControl01.Text = "memoryDisplayControl1";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 20F);
            label13.Location = new Point(480, 302);
            label13.Name = "label13";
            label13.Size = new Size(229, 37);
            label13.TabIndex = 62;
            label13.Text = "Memory Contents";
            // 
            // buttonEditMemory
            // 
            buttonEditMemory.Font = new Font("Segoe UI", 14F);
            buttonEditMemory.Location = new Point(545, 759);
            buttonEditMemory.Name = "buttonEditMemory";
            buttonEditMemory.Size = new Size(100, 40);
            buttonEditMemory.TabIndex = 63;
            buttonEditMemory.Text = "Edit";
            buttonEditMemory.UseVisualStyleBackColor = true;
            buttonEditMemory.Click += buttonEditMemory_Click_1;
            // 
            // txtClockSpeed
            // 
            txtClockSpeed.Font = new Font("Segoe UI", 14F);
            txtClockSpeed.Location = new Point(535, 79);
            txtClockSpeed.Name = "txtClockSpeed";
            txtClockSpeed.Size = new Size(100, 32);
            txtClockSpeed.TabIndex = 64;
            txtClockSpeed.Text = "10";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14F);
            label14.Location = new Point(311, 82);
            label14.Name = "label14";
            label14.Size = new Size(218, 25);
            label14.TabIndex = 65;
            label14.Text = "Clock Speed in Hz (1-25)";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 20F);
            label15.Location = new Point(1179, 432);
            label15.Name = "label15";
            label15.Size = new Size(78, 37);
            label15.TabIndex = 66;
            label15.Text = "Flags";
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 840);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(txtClockSpeed);
            Controls.Add(buttonEditMemory);
            Controls.Add(label13);
            Controls.Add(memoryDisplayControl01);
            Controls.Add(instructionRegisterDisplayControlINS);
            Controls.Add(buttonStop);
            Controls.Add(buttonReset);
            Controls.Add(flagsDisplayControlSTT);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(controlSignalDisplayControlCON);
            Controls.Add(threeBitByteDisplayControlINC);
            Controls.Add(fourBitByteDisplayControlMAR);
            Controls.Add(fourBitByteDisplayControlPRG);
            Controls.Add(byteDisplayControlBUS);
            Controls.Add(byteDisplayControlOUT);
            Controls.Add(byteDisplayControlALU);
            Controls.Add(byteDisplayControlARG);
            Controls.Add(byteDisplayControlBRG);
            Controls.Add(lblALUSubtract);
            Controls.Add(lblPRGEnable);
            Controls.Add(buttonStep);
            Controls.Add(buttonRun);
            Controls.Add(lblMEMBusState);
            Controls.Add(lblMARBusState);
            Controls.Add(lblPRGBusState);
            Controls.Add(lblALUBusState);
            Controls.Add(lblOUTBusState);
            Controls.Add(lblINSBusState);
            Controls.Add(lblBRGBusState);
            Controls.Add(lblARGBusState);
            Controls.Add(byteDisplayControlMEM);
            Name = "AppForm";
            Text = "BENIAC";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Button buttonRun;
        private Button buttonStep;
        private Label lblARGBusState;
        private Label lblMARBusState;
        private Label lblBRGBusState;
        private Label lblINSBusState;
        private Label lblOUTBusState;
        private Label lblALUBusState;
        private Label lblPRGBusState;
        private Label lblMEMBusState;
        private Label lblALUSubtract;
        private Label label2;
        private Label lblPRGEnable;
        private ByteDisplayControl byteDisplayControlMEM;
        private ByteDisplayControl byteDisplayControlBRG;
        private ByteDisplayControl byteDisplayControlARG;
        private ByteDisplayControl byteDisplayControlALU;
        private ByteDisplayControl byteDisplayControlOUT;
        private ByteDisplayControl byteDisplayControlBUS;
        private FourBitByteDisplayControl fourBitByteDisplayControlPRG;
        private FourBitByteDisplayControl fourBitByteDisplayControlMAR;
        private ThreeBitByteDisplayControl threeBitByteDisplayControlINC;
        private ControlSignalDisplayControl controlSignalDisplayControlCON;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private FlagsDisplayControl flagsDisplayControlSTT;
        private Button buttonReset;
        private Button buttonStop;
        private InstructionRegisterDisplayControl instructionRegisterDisplayControlINS;
        private MemoryDisplayControl memoryDisplayControl01;
        private Label label13;
        private Button buttonEditMemory;
        private TextBox txtClockSpeed;
        private Label label14;
        private Label label15;
    }
}
