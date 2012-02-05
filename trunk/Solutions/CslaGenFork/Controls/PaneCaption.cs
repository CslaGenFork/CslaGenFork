using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CslaGenerator.Controls
{
    // Custom control that draws the caption for each pane. Contains an active 
    // state and draws the caption different for each state. Caption is drawn
    // with a gradient fill and antialias font.
    public sealed class PaneCaption : UserControl
    {
        private class Consts
        {
            public const int DefaultHeight = 26;
            public const int PosOffset = 4;
        }

        private bool _active;
        private bool _antiAlias;
        private bool _allowActive;
        private string _text = string.Empty;

        private Color _colorActiveText = Color.Black;
        private Color _colorInactiveText = Color.White;

        private Color _colorActiveLow = Color.FromArgb(255, 165, 78);
        private Color _colorActiveHigh = Color.FromArgb(255, 225, 155);
        private Color _colorInactiveLow = Color.FromArgb(3, 55, 145);
        private Color _colorInactiveHigh = Color.FromArgb(90, 135, 215);

        private SolidBrush _brushActiveText;
        private SolidBrush _brushInactiveText;
        private LinearGradientBrush _brushActive;
        private LinearGradientBrush _brushInactive;
        private readonly StringFormat _format = new StringFormat();
        private LinearGradientMode _linearGradientMode;
        private IContainer components;

        [CategoryAttribute("Appearance")]
        [DescriptionAttribute("If should draw the text as antialiased.")]
        [DefaultValueAttribute(true)]
        public bool AntiAlias
        {
            get { return _antiAlias; }

            set
            {
                _antiAlias = value;
                Invalidate();
            }
        }

        [DefaultValueAttribute(typeof (Color), "Black")]
        [DescriptionAttribute("Color of the text when active.")]
        [CategoryAttribute("Appearance")]
        public Color ActiveTextColor
        {
            get { return _colorActiveText; }

            set
            {
                if (value == Color.Empty)
                    value = Color.Black;

                _colorActiveText = value;
                _brushActiveText = new SolidBrush(_colorActiveText);
                Invalidate();
            }
        }

        [CategoryAttribute("Appearance")]
        [DefaultValueAttribute(typeof (Color), "White")]
        [DescriptionAttribute("Color of the text when inactive.")]
        public Color InactiveTextColor
        {
            get { return _colorInactiveText; }

            set
            {
                if (value == Color.Empty)
                    value = Color.White;

                _colorInactiveText = value;
                _brushInactiveText = new SolidBrush(_colorInactiveText);
                Invalidate();
            }
        }

        [DescriptionAttribute("Linear Gradient Mode (direction of fade).")]
        [CategoryAttribute("Appearance")]
        [DefaultValueAttribute(LinearGradientMode.Horizontal)]
        public LinearGradientMode LinearGradient
        {
            get { return _linearGradientMode; }

            set
            {
                if (value != _linearGradientMode)
                {
                    _linearGradientMode = value;
                    Invalidate();
                }
            }
        }

        [DescriptionAttribute("Low color of the active gradient.")]
        [CategoryAttribute("Appearance")]
        [DefaultValueAttribute(typeof (Color), "255, 165, 78")]
        public Color ActiveGradientLowColor
        {
            get { return _colorActiveLow; }

            set
            {
                if (value == Color.Empty)
                    value = Color.FromArgb(255, 165, 78);

                _colorActiveLow = value;
                CreateGradientBrushes(_linearGradientMode);
                Invalidate();
            }
        }

        [CategoryAttribute("Appearance")]
        [DescriptionAttribute("High color of the active gradient.")]
        [DefaultValueAttribute(typeof (Color), "255, 225, 155")]
        public Color ActiveGradientHighColor
        {
            get { return _colorActiveHigh; }

            set
            {
                if (value == Color.Empty)
                    value = Color.FromArgb(255, 225, 155);

                _colorActiveHigh = value;
                CreateGradientBrushes(_linearGradientMode);
                Invalidate();
            }
        }

        [DefaultValueAttribute(typeof (Color), "3, 55, 145")]
        [DescriptionAttribute("Low color of the inactive gradient.")]
        [CategoryAttribute("Appearance")]
        public Color InactiveGradientLowColor
        {
            get { return _colorInactiveLow; }

            set
            {
                if (value == Color.Empty)
                    value = Color.FromArgb(3, 55, 145);

                _colorInactiveLow = value;
                CreateGradientBrushes(_linearGradientMode);
                Invalidate();
            }
        }

        [CategoryAttribute("Appearance")]
        [DescriptionAttribute("High color of the inactive gradient.")]
        [DefaultValueAttribute(typeof (Color), "90, 135, 215")]
        public Color InactiveGradientHighColor
        {
            get { return _colorInactiveHigh; }

            set
            {
                if (value == Color.Empty)
                    value = Color.FromArgb(90, 135, 215);

                _colorInactiveHigh = value;
                CreateGradientBrushes(_linearGradientMode);
                Invalidate();
            }
        }

        // brush used to draw the caption
        private SolidBrush TextBrush
        {
            get
            {
                if (_active && _allowActive)
                    return _brushActiveText;

                return _brushInactiveText;
            }
        }

        // gradient brush for the background
        private LinearGradientBrush BackBrush
        {
            get
            {
                if (_active && _allowActive)
                    return _brushActive;

                return _brushInactive;
            }
        }

        public override string Text
        {
            get { return Caption; }
            set { Caption = value; }
        }

        [DescriptionAttribute("Text displayed in the caption.")]
        [DefaultValueAttribute("")]
        [CategoryAttribute("Appearance")]
        public string Caption
        {
            get { return _text; }

            set
            {
                _text = value;
                Invalidate();
            }
        }

        [DescriptionAttribute("The active state of the caption, draws the caption with different gradient colors.")]
        [DefaultValueAttribute(false)]
        [CategoryAttribute("Appearance")]
        public bool Active
        {
            get { return _active; }

            set
            {
                _active = value;
                Invalidate();
            }
        }

        [DefaultValueAttribute(true)]
        [CategoryAttribute("Appearance")]
        [DescriptionAttribute("True always uses the inactive state colors, false maintains an active and inactive state.")]
        public bool AllowActive
        {
            get { return _allowActive; }

            set
            {
                _allowActive = value;
                Invalidate();
            }
        }

        public PaneCaption()
        {
            InitializeComponent();

            // set double buffer styles
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.DoubleBuffer,
                     true);

            // init the height
            Height = Consts.DefaultHeight;

            // format used when drawing the text
            _format.FormatFlags = StringFormatFlags.NoWrap;
            _format.LineAlignment = StringAlignment.Center;
            _format.Trimming = StringTrimming.EllipsisCharacter;

            // init the font
            Font = new Font("Tahoma", 12.0F, FontStyle.Bold);

            // create gdi objects
            ActiveTextColor = _colorActiveText;
            InactiveTextColor = _colorInactiveText;

            // setting the height above actually does this, but leave
            // in incase change the code (and forget to init the 
            // gradient brushes)
            CreateGradientBrushes(_linearGradientMode);
        }

        // the caption needs to be drawn
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawCaption(e.Graphics);
            base.OnPaint(e);
        }

        // draw the caption
        private void DrawCaption(Graphics g)
        {
            // background
            g.FillRectangle(BackBrush, DisplayRectangle);

            if (_antiAlias)
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // need a rectangle when want to use ellipsis
            var bounds = new RectangleF(Consts.PosOffset, 0, DisplayRectangle.Width - Consts.PosOffset, DisplayRectangle.Height);
            g.DrawString(_text, Font, TextBrush, bounds, _format);
        }

        // clicking on the caption does not give focus,
        // handle the mouse down event and set focus to self
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_allowActive)
                Focus();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            // create the gradient brushes based on the new size
            CreateGradientBrushes(_linearGradientMode);
        }

        private void CreateGradientBrushes(LinearGradientMode lgm)
        {
            // can only create brushes when have a width and height
            if (Width > 0 && Height > 0)
            {
                if (_brushActive != null)
                    _brushActive.Dispose();

                _brushActive = new LinearGradientBrush(DisplayRectangle, _colorActiveHigh, _colorActiveLow, lgm);

                if (_brushInactive != null)
                    _brushInactive.Dispose();

                _brushInactive = new LinearGradientBrush(DisplayRectangle, _colorInactiveHigh, _colorInactiveLow, lgm);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        [DebuggerStepThroughAttribute]
        private void InitializeComponent()
        {
            Name = "PaneCaption";
            Size = new Size(150, 30);
        }
    }
}
