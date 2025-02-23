using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace JGEmulatorApp
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public class FlagsDisplayControl : Control
    {
        private Image greenLight;
        private Image grayLight;

        private bool _cf;
        private bool _zf;

        public FlagsDisplayControl()
        {
            // Load the images from embedded resources
            greenLight = LoadImageFromResource("JGEmulatorApp.Resources.green.png");
            grayLight = LoadImageFromResource("JGEmulatorApp.Resources.gray.png");
        }

        private Image LoadImageFromResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    return Image.FromStream(stream);
                }
                else
                {
                    throw new Exception($"Resource '{resourceName}' not found.");
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("CF signal")]
        public bool CF
        {
            get => _cf;
            set
            {
                if (_cf != value)
                {
                    _cf = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("ZF signal")]
        public bool ZF
        {
            get => _zf;
            set
            {
                if (_zf != value)
                {
                    _zf = value;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawLights(e.Graphics);
        }

        private void DrawLights(Graphics g)
        {
            const int lightDiameter = 25;
            int spacing = lightDiameter / 4;
            int x = spacing;
            int y = (Height - lightDiameter) / 2 - 20; // Adjusted to leave space for labels

            bool[] signals = { CF, ZF };
            string[] labels = { "CF", "ZF" };

            using (Font labelFont = new Font("Segoe UI", 14))
            {
                for (int i = 0; i < 2; i++)
                {
                    bool isOn = signals[i];
                    Image lightImage = isOn ? greenLight : grayLight;

                    // Draw the light image
                    g.DrawImage(lightImage, x, y, lightDiameter, lightDiameter);

                    // Draw the label
                    SizeF labelSize = g.MeasureString(labels[i], labelFont);
                    float labelX = x + (lightDiameter - labelSize.Width) / 2;
                    g.DrawString(labels[i], labelFont, Brushes.Black, labelX, y + lightDiameter + 5);

                    x += lightDiameter + spacing;
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



