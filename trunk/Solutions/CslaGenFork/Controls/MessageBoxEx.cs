/************************************************************************************************
 *                                                                                              *
 * Author: Max Kleyzit.                                                                         *
 * Developed for StresStimulus, free Fiddler extension for load testing of web applications     *
 * http://stresstimulus.stimulustechnology.com/                                                 *
 *                                                                                              *
 * Changed by Tiago Freitas Leal, June 2016                                                     *
 * - Make it look like the standard MessageBox (styles, sizes, auto wrap long lines,            *
 *   minimum and maximum size, etc.)                                                            *
 * - Check API methods are invoked in the correct order.                                        *
 * - Cast DialogResult to MessageBoxResult so MessageBoxResult is the single result point       *
 *   (no need to check for results on DialogResult).                                            *
 *                                                                                              *
 * Subject to The Code Project Open License (CPOL) 1.02                                         *
 * http://www.codeproject.com/info/cpol10.aspx                                                  *
 *                                                                                              *
 ***********************************************************************************************/

using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CslaGenerator.Controls
{
    /// <summary>
    /// A customizable Dialog box with 3 buttons, custom icon, and checkbox.
    /// </summary>
    partial class MessageBoxEx : Form
    {
        #region Constants

        private const int ClientSizeMinimumWidth = 138;
        private const int ClientSizeMinimumHeight = 116;
        private const int MessageLeftMargin = 9;
        private const int MessageIconSpace = 6;
        private const int MessageTopMarginMinimum = 25;
        private const int MessageTopMarginMaximum = 33;
        private const int MessageBottomMarginMinimum = 25;
        private const int MessageBottomMarginMaximum = 33;
        private const int MessageRightMargin = 34;
        private const int MessageMaximumWidth = 431;
        private const int IconLeftMargin = 26;
        private const int IconVerticalMargin = 27;
        private const int ButtonSpace = 9;
        private const int ButtonRowRightMargin = 7;
        private const int ButtonRowLeftMargin = 42;
        private const int CheckBoxSpace = 12;
        private const int CheckBoxLeftMargin = 12;

        #endregion

        #region Fields

        /// <summary>
        /// The icon to paint.
        /// </summary>
        private readonly Icon _systemIcon;

        /// <summary>
        /// The required width of the button and checkbox row. Sum of button widths + checkbox width, margins and spacing.
        /// </summary>
        private int _buttonRowRequiredWidth;

        /// <summary>
        /// Whether the MessageBox was already shown.
        /// </summary>
        private bool _shown;

        private int _bottomMargin;

        #endregion

        #region API Properties

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
        /// <value>
        /// The message box result.
        /// </value>
        public MessageBoxResult MessageBoxResult { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of the dialog box with a message and title.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="title">Dialog Box title.</param>
        public MessageBoxEx(string message, string title)
            : this(message, title, MessageBoxIcon.None)
        {
        }

        /// <summary>
        /// Create a new instance of the dialog box with a message and title and a standard windows messagebox icon.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="title">Dialog Box title.</param>
        /// <param name="icon">Standard system messagebox icon.</param>
        public MessageBoxEx(string message, string title, MessageBoxIcon icon)
            : this(message, title, GetMessageBoxIcon(icon))
        {
        }

        /// <summary>
        /// Create a new instance of the dialog box with a message and title and a custom windows icon.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="title">Dialog Box title.</param>
        /// <param name="icon">Custom icon.</param>
        public MessageBoxEx(string message, string title, Icon icon)
        {
            InitializeComponent();

            messageLabel.Text = message;
            Text = title;
            _systemIcon = icon;
        }

        #endregion

        #region API methods

        /// <summary>
        /// Create up to 3 buttons with no DialogResult values specified.
        /// </summary>
        /// <param name="buttonResults">Array of DialogResult values. Must of length 1 to 3.</param>
        public void SetButtons(DialogResult[] buttonResults)
        {
            var buttonNames = new string[buttonResults.Length];
            for (var i = 0; i < buttonNames.Length; i++)
                buttonNames[i] = buttonResults[i].ToString();

            SetButtons(buttonNames, buttonResults);
        }

        /// <summary>
        /// Create up to 3 buttons with no DialogResult values specified.
        /// </summary>
        /// <param name="buttonResults">Array of DialogResult values. Must of length 1 to 3.</param>
        /// <param name="defaultButton">Default Button number. Must be 1 to 3.</param>
        public void SetButtons(DialogResult[] buttonResults, int defaultButton)
        {
            var buttonNames = new string[buttonResults.Length];
            for (var i = 0; i < buttonNames.Length; i++)
                buttonNames[i] = buttonResults[i].ToString();

            SetButtons(buttonNames, buttonResults, defaultButton);
        }

        /// <summary>
        /// Create up to 3 buttons with no DialogResult values specified.
        /// </summary>
        /// <param name="buttonNames">Array of button names. Must of length 1 to 3.</param>
        public void SetButtons(string[] buttonNames)
        {
            var dialogResults = new DialogResult[buttonNames.Length];
            for (var i = 0; i < buttonNames.Length; i++)
                dialogResults[i] = DialogResult.None;

            SetButtons(buttonNames, dialogResults);
        }

        /// <summary>
        /// Create up to 3 buttons with no DialogResult values specified.
        /// </summary>
        /// <param name="buttonNames">Array of button names. Must of length 1 to 3.</param>
        /// <param name="defaultButton">Default Button number. Must be 1 to 3.</param>
        public void SetButtons(string[] buttonNames, int defaultButton)
        {
            var dialogResults = new DialogResult[buttonNames.Length];
            for (var i = 0; i < buttonNames.Length; i++)
                dialogResults[i] = DialogResult.None;

            SetButtons(buttonNames, dialogResults, defaultButton);
        }

        /// <summary>
        /// Create up to 3 buttons with given buttonNames and DialogResult values.
        /// </summary>
        /// <param name="buttonNames">Array of button names. Must of length 1 to 3.</param>
        /// <param name="buttonResults">Array of DialogResult values. Must of length 1 to 3.</param>
        public void SetButtons(string[] buttonNames, DialogResult[] buttonResults)
        {
            SetButtons(buttonNames, buttonResults, 1);
        }

        /// <summary>
        /// Create up to 3 buttons with given buttonNames, DialogResult values and a default button,.
        /// </summary>
        /// <param name="buttonNames">Array of button names. Must of length 1 to 3.</param>
        /// <param name="buttonResults">Array of DialogResult values. Must of length 1 to 3.</param>
        /// <param name="defaultButton">Default Button number. Must be 1 to 3.</param>
        public void SetButtons(string[] buttonNames, DialogResult[] buttonResults, int defaultButton)
        {
            if (_shown)
                throw new MethodUsedOutOfOrder("SetButtons", "cannot invoke method after showing the MessageBox.");

            if (buttonNames == null)
                throw new ArgumentNullException(@"buttonNames", @"Button names cannot be null");

            var buttonNameCount = buttonNames.Length;
            if (buttonNameCount < 1 || buttonNameCount > 3)
                throw new ArgumentException(@"nvalid number of buttons. Must be between 1 and 3.", "buttonNames");

            if (buttonResults == null)
                throw new ArgumentNullException(@"buttonResults", @"Button results cannot be null");

            var buttonResultCount = buttonResults.Length;
            if (buttonResultCount < 1 || buttonResultCount > 3)
                throw new ArgumentException(@"Invalid number of buttons. Must be between 1 and 3.", "buttonResults");

            if (defaultButton < 1 || defaultButton > 3)
                throw new ArgumentException(@"Invalid button number. Must be between 1 and 3.", "defaultButton");

            // Set Button 1
            _buttonRowRequiredWidth += SetButtonParams(button1, buttonNames[0], defaultButton == 1 ? 1 : 2,
                buttonResults[0]);

            // Set Button 2
            if (buttonResultCount > 1)
            {
                _buttonRowRequiredWidth += SetButtonParams(button2, buttonNames[1], defaultButton == 2 ? 1 : 3,
                    buttonResults[1]) + ButtonSpace;
            }

            // Set Button 3
            if (buttonResultCount > 2)
            {
                _buttonRowRequiredWidth += SetButtonParams(button3, buttonNames[2], defaultButton == 3 ? 1 : 4,
                    buttonResults[2]) + ButtonSpace;
            }
        }

        /// <summary>
        /// Enables the checkbox. By default the checkbox is unchecked.
        /// </summary>
        /// <param name="text">Text of the checkbox.</param>
        public void SetCheckbox(string text)
        {
            if (_shown)
                throw new MethodUsedOutOfOrder("SetCheckbox", "cannot invoke method after showing the MessageBox.");

            SetCheckbox(text, false);
        }

        /// <summary>
        /// Enables the checkbox and the default checked state.
        /// </summary>
        /// <param name="text">Text of the checkbox.</param>
        /// <param name="checkedState">Default checked state of the box.</param>
        public void SetCheckbox(string text, bool checkedState)
        {
            if (_shown)
                throw new MethodUsedOutOfOrder("SetCheckbox", "cannot invoke method after showing the MessageBox.");

            checkBox.Visible = true;
            checkBox.Text = text;
            checkBox.Checked = checkedState;
            _buttonRowRequiredWidth += checkBox.Size.Width + CheckBoxSpace;
        }

        #endregion

        #region OnLoad engine

        /// <summary>
        /// Handles the Load event of the DialogBox control that is triggered by the ShowDialog() call.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DialogBox_Load(object sender, EventArgs e)
        {
            if (_shown)
                throw new MethodUsedOutOfOrder("ShowDialog", "was already invoked.");

            SetMessageBounds();

            if (!button1.Visible)
                SetButtons(new[] {DialogResult.OK.ToString()}, new[] {DialogResult.OK});

            _buttonRowRequiredWidth += ButtonRowRightMargin;

            if (checkBox.Visible)
                _buttonRowRequiredWidth += CheckBoxLeftMargin;
            else
                _buttonRowRequiredWidth += ButtonRowLeftMargin;

            SetDialogSize();

            SetButtonLocations();

            _shown = true;
        }

        #endregion

        #region Dialog

        private void SetDialogSize()
        {
            var requiredWidth = messageLabel.Location.X + messageLabel.Size.Width + MessageRightMargin;
            requiredWidth = requiredWidth > _buttonRowRequiredWidth ? requiredWidth : _buttonRowRequiredWidth;

            var requiredHeight = messageLabel.Location.Y + messageLabel.Size.Height + _bottomMargin +
                                 interactionPanel.Height;

            if (requiredWidth < ClientSizeMinimumWidth)
                requiredWidth = ClientSizeMinimumWidth;

            if (requiredHeight < ClientSizeMinimumHeight)
                requiredHeight = ClientSizeMinimumHeight;

            ClientSize = new Size(requiredWidth, requiredHeight);
        }

        #endregion

        #region Message

        private void SetMessageBounds()
        {
            var widthFactor = messageLabel.Size.Width/MessageMaximumWidth;
            if (widthFactor > 0)
            {
                messageLabel.AutoSize = false;
                messageLabel.Size = new Size(MessageMaximumWidth, 17 + 15*widthFactor);
            }

            if (_systemIcon == null)
            {
                messageLabel.Location = new Point(MessageLeftMargin, MessageTopMarginMinimum);
                _bottomMargin = MessageBottomMarginMinimum;
            }
            else
            {
                var y = _systemIcon.Height + MessageTopMarginMinimum;
                _bottomMargin = MessageBottomMarginMaximum;

                if (y > MessageTopMarginMaximum)
                    y = MessageTopMarginMaximum;

                if (messageLabel.Size.Height > 17)
                {
                    y = MessageBottomMarginMinimum;
                    _bottomMargin = MessageBottomMarginMinimum;
                }

                messageLabel.Location = new Point(IconLeftMargin + _systemIcon.Width + MessageIconSpace, y);
            }
        }

        #endregion

        #region Buttons

        private static int SetButtonParams(Button button, string text, int tabIndex, DialogResult dialogResult)
        {
            button.Text = text;
            button.Visible = true;
            button.DialogResult = dialogResult;
            button.TabIndex = tabIndex;

            return button.Size.Width;
        }

        private void SetButtonLocations()
        {
            var formWidth = ClientRectangle.Width;

            var x = formWidth - ButtonRowRightMargin;
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
                checkBox.Location = new Point(CheckBoxLeftMargin, checkBox.Location.Y);
        }

        #endregion

        #region Icon

        private static Icon GetMessageBoxIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    return SystemIcons.Information;
                case MessageBoxIcon.Error:
                    return SystemIcons.Error;
                case MessageBoxIcon.Warning:
                    return SystemIcons.Warning;
                case MessageBoxIcon.Question:
                    return SystemIcons.Question;
                default:
                    return null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_systemIcon != null)
            {
                var graphics = e.Graphics;
                graphics.DrawIconUnstretched(_systemIcon,
                    new Rectangle(IconLeftMargin, IconVerticalMargin, _systemIcon.Width, _systemIcon.Height));
            }

            base.OnPaint(e);
        }

        #endregion

        #region Results

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

    #region MethodUsedOutOfOrder Exception class

    /// <summary>
    /// Exception a method was invoke out of order.
    /// </summary>
    public class MethodUsedOutOfOrder : Exception
    {
        /// <summary>
        /// Creates an instance of the object.
        /// </summary>
        // ReSharper disable UnusedMember.Local
        private MethodUsedOutOfOrder()
            // ReSharper restore UnusedMember.Local
        {
            // force to use the public constructor
        }

        /// <summary>
        /// Creates an instance of the object.
        /// </summary>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="message">The offending fact.</param>
        public MethodUsedOutOfOrder(string methodName, string message) :
            base(string.Format("{0} {1}", methodName, message))
        {
        }
    }

    #endregion

    #region MessageBoxResult enum

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

    #endregion
}