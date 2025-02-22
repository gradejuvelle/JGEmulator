using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace JGEmulatorApp
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public class ControlSignalDisplayControl : Control
    {
        private Image greenLight;
        private Image grayLight;

        private bool _hlt;
        private bool _mi;
        private bool _ri;
        private bool _ro;
        private bool _io;
        private bool _ii;
        private bool _ai;
        private bool _ao;
        private bool _eo;
        private bool _su;
        private bool _bi;
        private bool _oi;
        private bool _ce;
        private bool _co;
        private bool _j;
        private bool _fi;

        public ControlSignalDisplayControl()
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
        [Description("HLT signal")]
        public bool HLT
        {
            get => _hlt;
            set
            {
                if (_hlt != value)
                {
                    _hlt = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("MI signal")]
        public bool MI
        {
            get => _mi;
            set
            {
                if (_mi != value)
                {
                    _mi = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("RI signal")]
        public bool RI
        {
            get => _ri;
            set
            {
                if (_ri != value)
                {
                    _ri = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("RO signal")]
        public bool RO
        {
            get => _ro;
            set
            {
                if (_ro != value)
                {
                    _ro = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("IO signal")]
        public bool IO
        {
            get => _io;
            set
            {
                if (_io != value)
                {
                    _io = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("II signal")]
        public bool II
        {
            get => _ii;
            set
            {
                if (_ii != value)
                {
                    _ii = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("AI signal")]
        public bool AI
        {
            get => _ai;
            set
            {
                if (_ai != value)
                {
                    _ai = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("AO signal")]
        public bool AO
        {
            get => _ao;
            set
            {
                if (_ao != value)
                {
                    _ao = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("EO signal")]
        public bool EO
        {
            get => _eo;
            set
            {
                if (_eo != value)
                {
                    _eo = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("SU signal")]
        public bool SU
        {
            get => _su;
            set
            {
                if (_su != value)
                {
                    _su = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("BI signal")]
        public bool BI
        {
            get => _bi;
            set
            {
                if (_bi != value)
                {
                    _bi = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("OI signal")]
        public bool OI
        {
            get => _oi;
            set
            {
                if (_oi != value)
                {
                    _oi = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("CE signal")]
        public bool CE
        {
            get => _ce;
            set
            {
                if (_ce != value)
                {
                    _ce = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("CO signal")]
        public bool CO
        {
            get => _co;
            set
            {
                if (_co != value)
                {
                    _co = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("J signal")]
        public bool J
        {
            get => _j;
            set
            {
                if (_j != value)
                {
                    _j = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("FI signal")]
        public bool FI
        {
            get => _fi;
            set
            {
                if (_fi != value)
                {
                    _fi = value;
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
            int lightDiameter = Math.Min(Width / 16, Height / 2);
            int spacing = lightDiameter / 4;
            int x = spacing;
            int y = (Height - lightDiameter) / 2 - 20; // Adjusted to leave space for labels

            bool[] signals = { HLT, MI, RI, RO, IO, II, AI, AO, EO, SU, BI, OI, CE, CO, J, FI };
            string[] labels = { "HLT", "MI", "RI", "RO", "IO", "II", "AI", "AO", "EO", "SU", "BI", "OI", "CE", "CO", "J", "FI" };

            for (int i = 0; i < 16; i++)
            {
                bool isOn = signals[i];
                Image lightImage = isOn ? greenLight : grayLight;

                // Draw the light image
                g.DrawImage(lightImage, x, y, lightDiameter, lightDiameter);

                // Draw the label
                g.DrawString(labels[i], Font, Brushes.Black, x, y + lightDiameter + 5);

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
