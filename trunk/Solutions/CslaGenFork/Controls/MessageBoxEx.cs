/************************************************************************************************
 *                                                                                              *
 * Author: Max Kleyzit.                                                                         *
 * Developed for StresStimulus, free Fiddler extension for load testing of web applications     *
 * http://stresstimulus.stimulustechnology.com/                                                 *
 *                                                                                              *
 * Changed by Tiago Freitas Leal, 07 Jun 2016                                                   *
 * Cast DialogResult to MessageBoxResult so MessageBoxResult is the single result point         *
 * (no need to check for results on DialogResult)                                               *
 *                                                                                              *
 * Subject to The Code Project Open License (CPOL) 1.02                                         *
 * http://www.codeproject.com/info/cpol10.aspx                                                  *
 *                                                                                              *
 ***********************************************************************************************/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CslaGenerator.Controls
{
    /// <summary>
    /// A customizable Dialog box with 3 buttons, custom icon, and checkbox.
    /// </summary>
    partial class MessageBoxEx : Form
    {
        #region Constants

        private const int FormYMargin = 10;
        private const int FormXMargin = 16;
        private const int ButtonSpace = 5;
        private const int CheckboxSpace = 15;
        private const int TextYMargin = 30;

        #endregion

        #region Fields

        /// <summary>
        /// The icon to paint.
        /// </summary>
        private readonly Icon _systemIcon;

        /// <summary>
        /// Min set width.
        /// </summary>
        private int _minWidth;

        /// <summary>
        /// Min set height.
        /// </summary>
        private int _minHeight;

        /// <summary>
        /// The min required width of the button and checkbox row. Sum of button widths + checkbox width + margins.
        /// </summary>
        private int _minButtonRowWidth;

        #endregion

        #region Contructors

        /// <summary>
        /// Create a new instance of the dialog box with a message and title.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="title">Dialog Box title.</param>
        public MessageBox(string message, string title)
            : this(message, title, MessageBoxIcon.None)
        {
        }

        /// <summary>
        /// Create a new instance of the dialog box with a message and title and a standard windows messagebox icon.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="title">Dialog Box title.</param>
        /// <param name="icon">Standard system messagebox icon.</param>
        public MessageBox(string message, string title, MessageBoxIcon icon)
            : this(message, title, GetMessageBoxIcon(icon))
        {
        }

        /// <summary>
        /// Create a new instance of the dialog box with a message and title and a custom windows icon.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="title">Dialog Box title.</param>
        /// <param name="icon">Custom icon.</param>
        public MessageBox(string message, string title, Icon icon)
        {
            InitializeComponent();

            messageLabel.Text = message;
            Text = title;

            _systemIcon = icon;

            if (_systemIcon == null)
                messageLabel.Location = new Point(FormXMargin, FormYMargin);
        }

        #endregion

        /// <summary>
        /// Get system icon for MessageBoxIcon.
        /// </summary>
        /// <param name="icon">The MessageBoxIcon value.</param>
        /// <returns>SystemIcon type Icon.</returns>
        private static Icon GetMessageBoxIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Asterisk:
                    return SystemIcons.Asterisk;
                case MessageBoxIcon.Error:
                    return SystemIcons.Error;
                case MessageBoxIcon.Exclamation:
                    return SystemIcons.Exclamation;
                case MessageBoxIcon.Question:
                    return SystemIcons.Question;
                default:
                    return null;
            }
        }

        #region Setup API

        /// <summary>
        /// Sets the min size of the dialog box. If the text or button row needs more size then the dialog box will size to fit the text.
        /// </summary>
        /// <param name="width">Min width value.</param>
        /// <param name="height">Min height value.</param>
        public void SetMinSize(int width, int height)
        {
            _minWidth = width;
            _minHeight = height;
        }

        /// <summary>
        /// Create up to 3 buttons with no DialogResult values.
        /// </summary>
        /// <param name="names">Array of button names. Must of length 1-3.</param>
        public void SetButtons(params string[] names)
        {
            var dialogResults = new DialogResult[names.Length];
            for (var i = 0; i < names.Length; i++)
                dialogResults[i] = DialogResult.None;

            SetButtons(names, dialogResults);
        }

        /// <summary>
        /// Create up to 3 buttons with given DialogResult values.
        /// </summary>
        /// <param name="names">Array of button names. Must of length 1-3.</param>
        /// <param name="results">Array of DialogResult values. Must be same length as names.</param>
        public void SetButtons(string[] names, DialogResult[] results)
        {
            SetButtons(names, results, 1);
        }

        /// <summary>
        /// Create up to 3 buttons with given DialogResult values.
        /// </summary>
        /// <param name="names">Array of button names. Must of length 1-3.</param>
        /// <param name="results">Array of DialogResult values. Must be same length as names.</param>
        /// <param name="defaultButton">Default Button number. Must be 1-3.</param>
        public void SetButtons(string[] names, DialogResult[] results, int defaultButton)
        {
            if (names == null)
                throw new ArgumentNullException(nameof(names), @"Button Text is null");

            int count = names.Length;

            if (count < 1 || count > 3)
                throw new ArgumentException("Invalid number of buttons. Must be between 1 and 3.");

            //---- Set Button 1
            _minButtonRowWidth += SetButtonParams(button1, names[0], defaultButton == 1 ? 1 : 2, results[0]);

            //---- Set Button 2
            if (count > 1)
            {
                _minButtonRowWidth += SetButtonParams(button2, names[1], defaultButton == 2 ? 1 : 3,
                    results[1]) + ButtonSpace;
            }

            //---- Set Button 3
            if (count > 2)
            {
                _minButtonRowWidth += SetButtonParams(button3, names[2], defaultButton == 3 ? 1 : 4,
                    results[2]) + ButtonSpace;
            }
        }

        /// <summary>
        /// Sets button text and returns the width.
        /// </summary>
        /// <param name="button">Button object.</param>
        /// <param name="text">Text of the button.</param>
        /// <param name="tabIndex">TabIndex of the button.</param>
        /// <param name="dialogResult">DialogResult of the button.</param>
        /// <returns>Width of the button.</returns>
        private static int SetButtonParams(Button button, string text, int tabIndex, DialogResult dialogResult)
        {
            button.Text = text;
            button.Visible = true;
            button.DialogResult = dialogResult;
            button.TabIndex = tabIndex;

            return button.Size.Width;
        }

        /// <summary>
        /// Enables the checkbox. By default the checkbox is unchecked.
        /// </summary>
        /// <param name="text">Text of the checkbox.</param>
        public void SetCheckbox(string text)
        {
            SetCheckbox(text, false);
        }

        /// <summary>
        /// Enables the checkbox and the default checked state.
        /// </summary>
        /// <param name="text">Text of the checkbox.</param>
        /// <param name="checkedState">Default checked state of the box.</param>
        public void SetCheckbox(string text, bool checkedState)
        {
            checkBox.Visible = true;
            checkBox.Text = text;
            checkBox.Checked = checkedState;
            _minButtonRowWidth += checkBox.Size.Width + CheckboxSpace;
        }

        #endregion

        #region Sizes and Locations

        private void DialogBox_Load(object sender, EventArgs e)
        {
            if (!button1.Visible)
                SetButtons(new[] {"OK"}, new[] {DialogResult.OK});

            _minButtonRowWidth += 2*FormXMargin; //add margin to the ends

            SetDialogSize();

            SetButtonRowLocations();
        }

        /// <summary>
        /// Auto fits the dialog box to fit the text and the buttons.
        /// </summary>
        private void SetDialogSize()
        {
            var requiredWidth = messageLabel.Location.X + messageLabel.Size.Width + FormXMargin;
            requiredWidth = requiredWidth > _minButtonRowWidth ? requiredWidth : _minButtonRowWidth;

            var requiredHeight = messageLabel.Location.Y + messageLabel.Size.Height -
                                 button2.Location.Y + ClientSize.Height + TextYMargin;

            var minSetWidth = ClientSize.Width > _minWidth ? ClientSize.Width : _minWidth;
            var minSetHeight = ClientSize.Height > _minHeight ? ClientSize.Height : _minHeight;

            var size = new Size();
            size.Width = requiredWidth > minSetWidth ? requiredWidth : minSetWidth;
            size.Height = requiredHeight > minSetHeight ? requiredHeight : minSetHeight;
            ClientSize = size;
        }

        /// <summary>
        /// Sets the buttons and checkboxe location.
        /// </summary>
        private void SetButtonRowLocations()
        {
            var formWidth = ClientRectangle.Width;

            var x = formWidth - FormXMargin;
            var y = button1.Location.Y;

            if (button3.Visible)
            {
                x -= button3.Size.Width;
                button3.Location = new Point(x, y);
                x -= ButtonSpace;
            }

            if (button2.Visible)
            {
                x -= button2.Size.Width;
                button2.Location = new Point(x, y);
                x -= ButtonSpace;
            }

            x -= button1.Size.Width;
            button1.Location = new Point(x, y);

            if (checkBox.Visible)
                checkBox.Location = new Point(FormXMargin, checkBox.Location.Y);
        }

        #endregion

        #region Icon Pain

        /// <summary>
        /// Paint the System Icon in the top left corner.
        /// </summary>
        /// <param name="e">The paint event arguments</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_systemIcon != null)
            {
                var graphics = e.Graphics;
                graphics.DrawIconUnstretched(_systemIcon,
                    new Rectangle(FormXMargin, FormYMargin, _systemIcon.Width, _systemIcon.Height));
            }

            base.OnPaint(e);
        }

        #endregion

        #region Result API

        /// <summary>
        /// If visible checkbox was checked.
        /// </summary>
        public bool CheckboxChecked
        {
            get { return checkBox.Checked; }
        }

        /// <summary>
        /// Gets the button that was pressed.
        /// </summary>
        public MessageBoxResult MessageBoxResult { get; private set; }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                if (button1.DialogResult != DialogResult.None)
                    MessageBoxResult = (MessageBoxResult) button1.DialogResult;
                else
                    MessageBoxResult = MessageBoxResult.Button1;
            }
            else if (sender == button2)
            {
                if (button2.DialogResult != DialogResult.None)
                    MessageBoxResult = (MessageBoxResult) button2.DialogResult;
                else
                    MessageBoxResult = MessageBoxResult.Button2;
            }
            else if (sender == button3)
            {
                if (button3.DialogResult != DialogResult.None)
                    MessageBoxResult = (MessageBoxResult) button3.DialogResult;
                else
                    MessageBoxResult = MessageBoxResult.Button3;
            }

            Close();
        }

        #endregion
    }

    public enum MessageBoxResult
    {
        None = DialogResult.None,
        OK = DialogResult.OK,
        Cancel = DialogResult.Cancel,
        Abort = DialogResult.Abort,
        Retry = DialogResult.Retry,
        Ignore = DialogResult.Ignore,
        Yes = DialogResult.Yes,
        No = DialogResult.No,
        Button1,
        Button2,
        Button3
    }
}