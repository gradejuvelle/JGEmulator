﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace JGEmulatorApp
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public class FourBitByteDisplayControl : Control
    {
        private byte _value;
        private Image blueLight;
        private Image grayLight;
        private TextBox textBox;

        public FourBitByteDisplayControl()
        {
            // Load the images from embedded resources
            blueLight = LoadImageFromResource("JGEmulatorApp.Resources.blue.png");
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
        [Description("The byte value to display.")]
        public byte Value
        {
            get => _value;
            set
            {
                _value = value;
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
            int lightDiameter = Math.Min(Width / 4, Height);
            int spacing = lightDiameter / 4;
            int x = spacing;
            int y = (Height - lightDiameter) / 2;

            for (int i = 0; i < 4; i++)
            {
                bool isOn = (_value & (1 << (3 - i))) != 0; // Adjusted to check the correct bit
                Image lightImage = isOn ? blueLight : grayLight;

                // Draw the light image
                g.DrawImage(lightImage, x, y, lightDiameter, lightDiameter);

                x += lightDiameter + spacing;
            }
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // Redraw the control when resized
        }
    }
}
