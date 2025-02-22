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
            byteDisplayControlMEM = new ByteDisplayControl();
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
            lblARGBusState = new Label();
            lblMARBusState = new Label();
            lblBRGBusState = new Label();
            lblINSBusState = new Label();
            lblOUTBusState = new Label();
            lblALUBusState = new Label();
            lblPRGBusState = new Label();
            lblMEMBusState = new Label();
            lblINCValueBinary = new Label();
            lblINCValue = new Label();
            lblPRGEnable = new Label();
            lblSTTCarry = new Label();
            lblSTTZero = new Label();
            lblALUSubtract = new Label();
            byteDisplayControlBRG = new ByteDisplayControl();
            byteDisplayControlARG = new ByteDisplayControl();
            byteDisplayControlINS = new ByteDisplayControl();
            byteDisplayControlALU = new ByteDisplayControl();
            byteDisplayControlOUT = new ByteDisplayControl();
            byteDisplayControlBUS = new ByteDisplayControl();
            fourBitByteDisplayControlPRG = new FourBitByteDisplayControl();
            fourBitByteDisplayControlMAR = new FourBitByteDisplayControl();
            threeBitByteDisplayControlINC = new ThreeBitByteDisplayControl();
            controlSignalDisplayControlCON = new ControlSignalDisplayControl();
            SuspendLayout();
            // 
            // byteDisplayControlMEM
            // 
            byteDisplayControlMEM.Location = new Point(88, 275);
            byteDisplayControlMEM.Name = "byteDisplayControlMEM";
            byteDisplayControlMEM.Size = new Size(349, 34);
            byteDisplayControlMEM.TabIndex = 34;
            byteDisplayControlMEM.Value = 0;
            // 
            // lblARGValue
            // 
            lblARGValue.AutoSize = true;
            lblARGValue.Font = new Font("Segoe UI", 14F);
            lblARGValue.Location = new Point(1079, 275);
            lblARGValue.Name = "lblARGValue";
            lblARGValue.Size = new Size(115, 25);
            lblARGValue.TabIndex = 0;
            lblARGValue.Text = "A Register: 0";
            // 
            // lblARGValueBinary
            // 
            lblARGValueBinary.AutoSize = true;
            lblARGValueBinary.Font = new Font("Segoe UI", 14F);
            lblARGValueBinary.Location = new Point(1079, 305);
            lblARGValueBinary.Name = "lblARGValueBinary";
            lblARGValueBinary.Size = new Size(92, 25);
            lblARGValueBinary.TabIndex = 1;
            lblARGValueBinary.Text = "00000000";
            // 
            // lblBRGValue
            // 
            lblBRGValue.AutoSize = true;
            lblBRGValue.Font = new Font("Segoe UI", 14F);
            lblBRGValue.Location = new Point(1079, 657);
            lblBRGValue.Name = "lblBRGValue";
            lblBRGValue.Size = new Size(114, 25);
            lblBRGValue.TabIndex = 3;
            lblBRGValue.Text = "B Register: 0";
            // 
            // lblBRGValueBinary
            // 
            lblBRGValueBinary.AutoSize = true;
            lblBRGValueBinary.Font = new Font("Segoe UI", 14F);
            lblBRGValueBinary.Location = new Point(1079, 687);
            lblBRGValueBinary.Name = "lblBRGValueBinary";
            lblBRGValueBinary.Size = new Size(92, 25);
            lblBRGValueBinary.TabIndex = 4;
            lblBRGValueBinary.Text = "00000000";
            // 
            // lblINSValue
            // 
            lblINSValue.AutoSize = true;
            lblINSValue.Font = new Font("Segoe UI", 14F);
            lblINSValue.Location = new Point(88, 537);
            lblINSValue.Name = "lblINSValue";
            lblINSValue.Size = new Size(193, 25);
            lblINSValue.TabIndex = 6;
            lblINSValue.Text = "Instruction Register: 0";
            // 
            // lblINSValueBinary
            // 
            lblINSValueBinary.AutoSize = true;
            lblINSValueBinary.Font = new Font("Segoe UI", 14F);
            lblINSValueBinary.Location = new Point(88, 567);
            lblINSValueBinary.Name = "lblINSValueBinary";
            lblINSValueBinary.Size = new Size(92, 25);
            lblINSValueBinary.TabIndex = 7;
            lblINSValueBinary.Text = "00000000";
            // 
            // lblOUTValue
            // 
            lblOUTValue.AutoSize = true;
            lblOUTValue.Font = new Font("Segoe UI", 14F);
            lblOUTValue.Location = new Point(1079, 802);
            lblOUTValue.Name = "lblOUTValue";
            lblOUTValue.Size = new Size(162, 25);
            lblOUTValue.TabIndex = 9;
            lblOUTValue.Text = "Output Register: 0";
            // 
            // lblOUTValueBinary
            // 
            lblOUTValueBinary.AutoSize = true;
            lblOUTValueBinary.Font = new Font("Segoe UI", 14F);
            lblOUTValueBinary.Location = new Point(1079, 832);
            lblOUTValueBinary.Name = "lblOUTValueBinary";
            lblOUTValueBinary.Size = new Size(92, 25);
            lblOUTValueBinary.TabIndex = 10;
            lblOUTValueBinary.Text = "00000000";
            // 
            // lblBUSValue
            // 
            lblBUSValue.AutoSize = true;
            lblBUSValue.Font = new Font("Segoe UI", 14F);
            lblBUSValue.Location = new Point(630, 332);
            lblBUSValue.Name = "lblBUSValue";
            lblBUSValue.Size = new Size(65, 25);
            lblBUSValue.TabIndex = 24;
            lblBUSValue.Text = "BUS: 0";
            // 
            // lblBUSValueBinary
            // 
            lblBUSValueBinary.AutoSize = true;
            lblBUSValueBinary.Font = new Font("Segoe UI", 14F);
            lblBUSValueBinary.Location = new Point(630, 362);
            lblBUSValueBinary.Name = "lblBUSValueBinary";
            lblBUSValueBinary.Size = new Size(92, 25);
            lblBUSValueBinary.TabIndex = 25;
            lblBUSValueBinary.Text = "00000000";
            // 
            // lblALUValue
            // 
            lblALUValue.AutoSize = true;
            lblALUValue.Font = new Font("Segoe UI", 14F);
            lblALUValue.Location = new Point(1079, 420);
            lblALUValue.Name = "lblALUValue";
            lblALUValue.Size = new Size(137, 25);
            lblALUValue.TabIndex = 12;
            lblALUValue.Text = "ALU Register: 0";
            // 
            // lblALUValueBinary
            // 
            lblALUValueBinary.AutoSize = true;
            lblALUValueBinary.Font = new Font("Segoe UI", 14F);
            lblALUValueBinary.Location = new Point(1079, 450);
            lblALUValueBinary.Name = "lblALUValueBinary";
            lblALUValueBinary.Size = new Size(92, 25);
            lblALUValueBinary.TabIndex = 13;
            lblALUValueBinary.Text = "00000000";
            // 
            // lblPRGValue
            // 
            lblPRGValue.AutoSize = true;
            lblPRGValue.Font = new Font("Segoe UI", 14F);
            lblPRGValue.Location = new Point(1079, 125);
            lblPRGValue.Name = "lblPRGValue";
            lblPRGValue.Size = new Size(177, 25);
            lblPRGValue.TabIndex = 15;
            lblPRGValue.Text = "Program Counter: 0";
            // 
            // lblPRGValueBinary
            // 
            lblPRGValueBinary.AutoSize = true;
            lblPRGValueBinary.Font = new Font("Segoe UI", 14F);
            lblPRGValueBinary.Location = new Point(1079, 155);
            lblPRGValueBinary.Name = "lblPRGValueBinary";
            lblPRGValueBinary.Size = new Size(92, 25);
            lblPRGValueBinary.TabIndex = 16;
            lblPRGValueBinary.Text = "00000000";
            // 
            // lblMARValue
            // 
            lblMARValue.AutoSize = true;
            lblMARValue.Font = new Font("Segoe UI", 14F);
            lblMARValue.Location = new Point(88, 125);
            lblMARValue.Name = "lblMARValue";
            lblMARValue.Size = new Size(245, 25);
            lblMARValue.TabIndex = 18;
            lblMARValue.Text = "Memory Address Register: 0";
            // 
            // lblMARValueBinary
            // 
            lblMARValueBinary.AutoSize = true;
            lblMARValueBinary.Font = new Font("Segoe UI", 14F);
            lblMARValueBinary.Location = new Point(88, 155);
            lblMARValueBinary.Name = "lblMARValueBinary";
            lblMARValueBinary.Size = new Size(92, 25);
            lblMARValueBinary.TabIndex = 19;
            lblMARValueBinary.Text = "00000000";
            // 
            // lblMEMValue
            // 
            lblMEMValue.AutoSize = true;
            lblMEMValue.Font = new Font("Segoe UI", 14F);
            lblMEMValue.Location = new Point(88, 312);
            lblMEMValue.Name = "lblMEMValue";
            lblMEMValue.Size = new Size(101, 25);
            lblMEMValue.TabIndex = 21;
            lblMEMValue.Text = "Memory: 0";
            // 
            // lblMEMValueBinary
            // 
            lblMEMValueBinary.AutoSize = true;
            lblMEMValueBinary.Font = new Font("Segoe UI", 14F);
            lblMEMValueBinary.Location = new Point(88, 342);
            lblMEMValueBinary.Name = "lblMEMValueBinary";
            lblMEMValueBinary.Size = new Size(92, 25);
            lblMEMValueBinary.TabIndex = 22;
            lblMEMValueBinary.Text = "00000000";
            // 
            // buttonRun
            // 
            buttonRun.Font = new Font("Segoe UI", 14F);
            buttonRun.Location = new Point(550, 500);
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
            buttonStep.Location = new Point(700, 500);
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
            lblARGBusState.Location = new Point(1079, 335);
            lblARGBusState.Name = "lblARGBusState";
            lblARGBusState.Size = new Size(143, 25);
            lblARGBusState.TabIndex = 2;
            lblARGBusState.Text = "Bus State: None";
            // 
            // lblMARBusState
            // 
            lblMARBusState.AutoSize = true;
            lblMARBusState.Font = new Font("Segoe UI", 14F);
            lblMARBusState.Location = new Point(88, 185);
            lblMARBusState.Name = "lblMARBusState";
            lblMARBusState.Size = new Size(143, 25);
            lblMARBusState.TabIndex = 20;
            lblMARBusState.Text = "Bus State: None";
            // 
            // lblBRGBusState
            // 
            lblBRGBusState.AutoSize = true;
            lblBRGBusState.Font = new Font("Segoe UI", 14F);
            lblBRGBusState.Location = new Point(1079, 717);
            lblBRGBusState.Name = "lblBRGBusState";
            lblBRGBusState.Size = new Size(143, 25);
            lblBRGBusState.TabIndex = 5;
            lblBRGBusState.Text = "Bus State: None";
            // 
            // lblINSBusState
            // 
            lblINSBusState.AutoSize = true;
            lblINSBusState.Font = new Font("Segoe UI", 14F);
            lblINSBusState.Location = new Point(88, 597);
            lblINSBusState.Name = "lblINSBusState";
            lblINSBusState.Size = new Size(143, 25);
            lblINSBusState.TabIndex = 8;
            lblINSBusState.Text = "Bus State: None";
            // 
            // lblOUTBusState
            // 
            lblOUTBusState.AutoSize = true;
            lblOUTBusState.Font = new Font("Segoe UI", 14F);
            lblOUTBusState.Location = new Point(1079, 862);
            lblOUTBusState.Name = "lblOUTBusState";
            lblOUTBusState.Size = new Size(143, 25);
            lblOUTBusState.TabIndex = 11;
            lblOUTBusState.Text = "Bus State: None";
            // 
            // lblALUBusState
            // 
            lblALUBusState.AutoSize = true;
            lblALUBusState.Font = new Font("Segoe UI", 14F);
            lblALUBusState.Location = new Point(1079, 480);
            lblALUBusState.Name = "lblALUBusState";
            lblALUBusState.Size = new Size(143, 25);
            lblALUBusState.TabIndex = 14;
            lblALUBusState.Text = "Bus State: None";
            // 
            // lblPRGBusState
            // 
            lblPRGBusState.AutoSize = true;
            lblPRGBusState.Font = new Font("Segoe UI", 14F);
            lblPRGBusState.Location = new Point(1079, 185);
            lblPRGBusState.Name = "lblPRGBusState";
            lblPRGBusState.Size = new Size(143, 25);
            lblPRGBusState.TabIndex = 17;
            lblPRGBusState.Text = "Bus State: None";
            // 
            // lblMEMBusState
            // 
            lblMEMBusState.AutoSize = true;
            lblMEMBusState.Font = new Font("Segoe UI", 14F);
            lblMEMBusState.Location = new Point(88, 372);
            lblMEMBusState.Name = "lblMEMBusState";
            lblMEMBusState.Size = new Size(143, 25);
            lblMEMBusState.TabIndex = 23;
            lblMEMBusState.Text = "Bus State: None";
            // 
            // lblINCValueBinary
            // 
            lblINCValueBinary.AutoSize = true;
            lblINCValueBinary.Font = new Font("Segoe UI", 14F);
            lblINCValueBinary.Location = new Point(88, 717);
            lblINCValueBinary.Name = "lblINCValueBinary";
            lblINCValueBinary.Size = new Size(92, 25);
            lblINCValueBinary.TabIndex = 29;
            lblINCValueBinary.Text = "00000000";
            // 
            // lblINCValue
            // 
            lblINCValue.AutoSize = true;
            lblINCValue.Font = new Font("Segoe UI", 14F);
            lblINCValue.Location = new Point(88, 687);
            lblINCValue.Name = "lblINCValue";
            lblINCValue.Size = new Size(194, 25);
            lblINCValue.TabIndex = 28;
            lblINCValue.Text = "Instruction Counter: 0";
            // 
            // lblPRGEnable
            // 
            lblPRGEnable.AutoSize = true;
            lblPRGEnable.Font = new Font("Segoe UI", 14F);
            lblPRGEnable.Location = new Point(1079, 210);
            lblPRGEnable.Name = "lblPRGEnable";
            lblPRGEnable.Size = new Size(119, 25);
            lblPRGEnable.TabIndex = 30;
            lblPRGEnable.Text = "Enable: False";
            // 
            // lblSTTCarry
            // 
            lblSTTCarry.AutoSize = true;
            lblSTTCarry.Font = new Font("Segoe UI", 14F);
            lblSTTCarry.Location = new Point(1079, 508);
            lblSTTCarry.Name = "lblSTTCarry";
            lblSTTCarry.Size = new Size(105, 25);
            lblSTTCarry.TabIndex = 31;
            lblSTTCarry.Text = "Carry: false";
            // 
            // lblSTTZero
            // 
            lblSTTZero.AutoSize = true;
            lblSTTZero.Font = new Font("Segoe UI", 14F);
            lblSTTZero.Location = new Point(1079, 537);
            lblSTTZero.Name = "lblSTTZero";
            lblSTTZero.Size = new Size(99, 25);
            lblSTTZero.TabIndex = 32;
            lblSTTZero.Text = "Zero: false";
            // 
            // lblALUSubtract
            // 
            lblALUSubtract.AutoSize = true;
            lblALUSubtract.Font = new Font("Segoe UI", 14F);
            lblALUSubtract.Location = new Point(1079, 562);
            lblALUSubtract.Name = "lblALUSubtract";
            lblALUSubtract.Size = new Size(124, 25);
            lblALUSubtract.TabIndex = 33;
            lblALUSubtract.Text = "Subract: false";
            // 
            // byteDisplayControlBRG
            // 
            byteDisplayControlBRG.Location = new Point(907, 620);
            byteDisplayControlBRG.Name = "byteDisplayControlBRG";
            byteDisplayControlBRG.Size = new Size(349, 34);
            byteDisplayControlBRG.TabIndex = 35;
            byteDisplayControlBRG.Text = "byteDisplayControl1";
            byteDisplayControlBRG.Value = 0;
            // 
            // byteDisplayControlARG
            // 
            byteDisplayControlARG.Location = new Point(907, 238);
            byteDisplayControlARG.Name = "byteDisplayControlARG";
            byteDisplayControlARG.Size = new Size(349, 34);
            byteDisplayControlARG.TabIndex = 36;
            byteDisplayControlARG.Value = 0;
            // 
            // byteDisplayControlINS
            // 
            byteDisplayControlINS.Location = new Point(88, 506);
            byteDisplayControlINS.Name = "byteDisplayControlINS";
            byteDisplayControlINS.Size = new Size(349, 34);
            byteDisplayControlINS.TabIndex = 37;
            byteDisplayControlINS.Value = 0;
            // 
            // byteDisplayControlALU
            // 
            byteDisplayControlALU.Location = new Point(907, 383);
            byteDisplayControlALU.Name = "byteDisplayControlALU";
            byteDisplayControlALU.Size = new Size(349, 34);
            byteDisplayControlALU.TabIndex = 38;
            byteDisplayControlALU.Value = 0;
            // 
            // byteDisplayControlOUT
            // 
            byteDisplayControlOUT.Location = new Point(907, 765);
            byteDisplayControlOUT.Name = "byteDisplayControlOUT";
            byteDisplayControlOUT.Size = new Size(349, 34);
            byteDisplayControlOUT.TabIndex = 39;
            byteDisplayControlOUT.Value = 0;
            // 
            // byteDisplayControlBUS
            // 
            byteDisplayControlBUS.Location = new Point(521, 275);
            byteDisplayControlBUS.Name = "byteDisplayControlBUS";
            byteDisplayControlBUS.Size = new Size(349, 34);
            byteDisplayControlBUS.TabIndex = 40;
            byteDisplayControlBUS.Value = 0;
            // 
            // fourBitByteDisplayControlPRG
            // 
            fourBitByteDisplayControlPRG.Location = new Point(1065, 88);
            fourBitByteDisplayControlPRG.Name = "fourBitByteDisplayControlPRG";
            fourBitByteDisplayControlPRG.Size = new Size(176, 34);
            fourBitByteDisplayControlPRG.TabIndex = 41;
            fourBitByteDisplayControlPRG.Text = "fourBitByteDisplayControlPRG";
            fourBitByteDisplayControlPRG.Value = 0;
            // 
            // fourBitByteDisplayControlMAR
            // 
            fourBitByteDisplayControlMAR.Location = new Point(88, 88);
            fourBitByteDisplayControlMAR.Name = "fourBitByteDisplayControlMAR";
            fourBitByteDisplayControlMAR.Size = new Size(176, 34);
            fourBitByteDisplayControlMAR.TabIndex = 42;
            fourBitByteDisplayControlMAR.Text = "fourBitByteDisplayControlMAR";
            fourBitByteDisplayControlMAR.Value = 0;
            // 
            // threeBitByteDisplayControlINC
            // 
            threeBitByteDisplayControlINC.Location = new Point(88, 650);
            threeBitByteDisplayControlINC.Name = "threeBitByteDisplayControlINC";
            threeBitByteDisplayControlINC.Size = new Size(198, 34);
            threeBitByteDisplayControlINC.TabIndex = 43;
            threeBitByteDisplayControlINC.Text = "threeBitByteDisplayControl1";
            threeBitByteDisplayControlINC.Value = 0;
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
            controlSignalDisplayControlCON.Location = new Point(88, 832);
            controlSignalDisplayControlCON.MI = false;
            controlSignalDisplayControlCON.Name = "controlSignalDisplayControlCON";
            controlSignalDisplayControlCON.OI = false;
            controlSignalDisplayControlCON.RI = false;
            controlSignalDisplayControlCON.RO = false;
            controlSignalDisplayControlCON.Size = new Size(791, 74);
            controlSignalDisplayControlCON.SU = false;
            controlSignalDisplayControlCON.TabIndex = 44;
            controlSignalDisplayControlCON.Text = "controlSignalDisplayControl1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1434, 950);
            Controls.Add(controlSignalDisplayControlCON);
            Controls.Add(threeBitByteDisplayControlINC);
            Controls.Add(fourBitByteDisplayControlMAR);
            Controls.Add(fourBitByteDisplayControlPRG);
            Controls.Add(byteDisplayControlBUS);
            Controls.Add(byteDisplayControlOUT);
            Controls.Add(byteDisplayControlALU);
            Controls.Add(byteDisplayControlINS);
            Controls.Add(byteDisplayControlARG);
            Controls.Add(byteDisplayControlBRG);
            Controls.Add(lblALUSubtract);
            Controls.Add(lblSTTZero);
            Controls.Add(lblSTTCarry);
            Controls.Add(lblPRGEnable);
            Controls.Add(lblINCValueBinary);
            Controls.Add(lblINCValue);
            Controls.Add(buttonStep);
            Controls.Add(buttonRun);
            Controls.Add(lblBUSValueBinary);
            Controls.Add(lblBUSValue);
            Controls.Add(lblMEMBusState);
            Controls.Add(lblMEMValueBinary);
            Controls.Add(lblMEMValue);
            Controls.Add(lblMARBusState);
            Controls.Add(lblMARValueBinary);
            Controls.Add(lblMARValue);
            Controls.Add(lblPRGBusState);
            Controls.Add(lblPRGValueBinary);
            Controls.Add(lblPRGValue);
            Controls.Add(lblALUBusState);
            Controls.Add(lblALUValueBinary);
            Controls.Add(lblALUValue);
            Controls.Add(lblOUTBusState);
            Controls.Add(lblOUTValueBinary);
            Controls.Add(lblOUTValue);
            Controls.Add(lblINSBusState);
            Controls.Add(lblINSValueBinary);
            Controls.Add(lblINSValue);
            Controls.Add(lblBRGBusState);
            Controls.Add(lblBRGValueBinary);
            Controls.Add(lblBRGValue);
            Controls.Add(lblARGBusState);
            Controls.Add(lblARGValueBinary);
            Controls.Add(lblARGValue);
            Controls.Add(byteDisplayControlMEM);
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
        private Label lblARGBusState;
        private Label lblMARBusState;
        private Label lblBRGBusState;
        private Label lblINSBusState;
        private Label lblOUTBusState;
        private Label lblALUBusState;
        private Label lblPRGBusState;
        private Label lblMEMBusState;
        private Label lblINCValueBinary;
        private Label lblINCValue;
        private Label lblALUSubtract;
        private Label label2;
        private Label label3;
        private Label lblPRGEnable;
        private Label lblSTTCarry;
        private Label lblSTTZero;
        private ByteDisplayControl byteDisplayControlMEM;
        private ByteDisplayControl byteDisplayControlBRG;
        private ByteDisplayControl byteDisplayControlARG;
        private ByteDisplayControl byteDisplayControlINS;
        private ByteDisplayControl byteDisplayControlALU;
        private ByteDisplayControl byteDisplayControlOUT;
        private ByteDisplayControl byteDisplayControlBUS;
        private FourBitByteDisplayControl fourBitByteDisplayControlPRG;
        private FourBitByteDisplayControl fourBitByteDisplayControlMAR;
        private ThreeBitByteDisplayControl threeBitByteDisplayControlINC;
        private ControlSignalDisplayControl controlSignalDisplayControlCON;
    }
}
