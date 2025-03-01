using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using JGEmulator;

namespace JGEmulatorApp
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public class MemoryDisplayControl : Control
    {
        private Memory _memory;

        public MemoryDisplayControl()
        {
            this.DoubleBuffered = true;
        }

        [Browsable(false)]
        public Memory Memory
        {
            get => _memory;
            set
            {
                _memory = value;
                Invalidate(); // Redraw the control when the memory is set
            }
        }

        public void SetAddressValue(int address, byte value)
        {
            if (_memory != null && address >= 0 && address < _memory.GetMemory().Length)
            {
                _memory.GetMemory()[address] = value;
                Invalidate(); // Redraw the control when the memory value is changed
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawMemory(e.Graphics);
        }

        private void DrawMemory(Graphics g)
        {
            if (_memory == null)
                return;

            byte[] memory = _memory.GetMemory();
            int lineHeight = 30; // Adjusted to add more spacing between rows
            int y = 0;
            int x = 10; // Add some padding on the left

            using (Font font = new Font("Segoe UI", 14))
            {
                StringFormat format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                };

                for (int i = 0; i < memory.Length; i++)
                {
                    string indexString = i.ToString().PadLeft(2, '0');
                    string binaryString = Convert.ToString(memory[i], 2).PadLeft(8, '0');
                    g.DrawString($"{indexString}: {binaryString}", font, Brushes.Black, new RectangleF(x, y, Width - x, lineHeight), format);
                    y += lineHeight;
                }
            }
        }



        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // Redraw the control when resized
        }
    }
}

