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
       private byte[] _memory;

        public MemoryDisplayControl()
        {
            this.DoubleBuffered = true;

        }

        [Browsable(false)]
        public byte[] Memory
        {
            get => _memory;
            set
            {
                _memory = value;
                Invalidate(); // Redraw the control when the memory is set
            }
        }

        public void SetAddressValue(byte address, byte value)
        {
     //       if (_memory != null && address >= 0 && address < _memory.GetMemory().Length)
     //       {
               // _memory =.GetMemory()[address] = value;
                Invalidate(); // Redraw the control when the memory value is changed
     //       }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawMemory(e.Graphics);
        }

        private void DrawMemory(Graphics g)
        {
         //   if (_memory == null)
          //      return;

         //   byte[] _memory = .GetMemory();
            int lineHeight = Font.Height + 5;
            int y = 0;

            for (int i = 0; i < _memory.Length; i++)
            {
                string binaryString = Convert.ToString(_memory[i], 2).PadLeft(8, '0');
                g.DrawString(binaryString, Font, Brushes.Black, new PointF(0, y));
                y += lineHeight;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // Redraw the control when resized
        }
    }
}

