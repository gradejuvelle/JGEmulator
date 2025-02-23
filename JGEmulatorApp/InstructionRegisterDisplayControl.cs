using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace JGEmulatorApp
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public class InstructionRegisterDisplayControl : Control
    {
        private byte _value;
        private Image yellowLight;
        private Image redLight;
        private Image grayLight;
        private Label valueLabel;

        public InstructionRegisterDisplayControl()
        {
            // Load the images from embedded resources
            yellowLight = LoadImageFromResource("JGEmulatorApp.Resources.yellow.png");
            redLight = LoadImageFromResource("JGEmulatorApp.Resources.red.png");
            grayLight = LoadImageFromResource("JGEmulatorApp.Resources.gray.png");

            // Initialize the Label
            valueLabel = new Label
            {
                Font = new Font("Segoe UI", 15),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 0)
            };
            this.Controls.Add(valueLabel);
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
        [Description("The byte value to display.")]
        public byte Value
        {
            get => _value;
            set
            {
                _value = value;
                valueLabel.Text = $"({_value})";
                Invalidate(); // Redraw the control when the value changes
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawLights(e.Graphics);
        }

        private void DrawLights(Graphics g)
        {
            int lightDiameter = 25;
            int spacing = lightDiameter / 4;
            int x = spacing;
            int y = (Height - lightDiameter) / 2;

            for (int i = 0; i < 8; i++)
            {
                bool isOn = (_value & (1 << (7 - i))) != 0;
                Image lightImage = grayLight;

                if (isOn)
                {
                    lightImage = i < 4 ? yellowLight : redLight;
                }

                // Draw the light image
                g.DrawImage(lightImage, x, y, lightDiameter, lightDiameter);

                x += lightDiameter + spacing;
            }

            // Adjust the Label location and size
            valueLabel.Location = new Point(x + spacing, (Height - valueLabel.Height) / 2);
            valueLabel.Size = new Size(65, lightDiameter);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // Redraw the control when resized
        }
    }
}


