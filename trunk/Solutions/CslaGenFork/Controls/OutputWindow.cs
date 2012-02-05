using System;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator.Controls
{
    public partial class OutputWindow : DockContent
    {
        private static OutputWindow _current;

        public OutputWindow()
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Properties.Resources.Output.GetHicon());
            DockAreas = DockAreas.DockBottom |
                        DockAreas.Float;
            _current = this;
        }

        #region Properties

        public static OutputWindow Current
        {
            get { return _current; }
        }

        #endregion

        #region Thread Safe Handlers

        private delegate void EmptyDelegate();

        private delegate void MessageDelegate(string message, int appendLines);

        /// <summary>
        /// Thread safe method for appending text to the output panel.
        /// </summary>
        /// <param name="info">Text to be appended to the output panel.</param>
        public void AddOutputInfo(string info)
        {
            AddOutputInfo(info, 1);
        }

        /// <summary>
        /// Thread safe method for appending text to the output panel.
        /// </summary>
        /// <param name="info">Text to be appended to the output panel.</param>
        /// <param name="appendLines">Number of lines to append after the appended text.</param>
        public void AddOutputInfo(string info, int appendLines)
        {
            Invoke(new MessageDelegate(DoStep), new object[] {info, appendLines});
        }

        /// <summary>
        /// Thread safe method to clear the output panel.
        /// </summary>
        public void ClearOutput()
        {
            Invoke(new EmptyDelegate(textBox.Clear), new object[] {});
        }

        #endregion

        #region Private Methods

        private void DoStep(string message, int appendLines)
        {
            textBox.AppendText(message);
            for (var i = 0; i < appendLines; i++)
                textBox.AppendText(Environment.NewLine);
            //txtOutput.AppendText(new String('=', 70) + Environment.NewLine
            //    + objectName + ":" + Environment.NewLine);
            //if (_generating)
            //    progressBar1.Value++;
            //else
            //    progressBar1.Value = progressBar1.Minimum;
            //_generating = true;
            //btnGenerate.Enabled = true;
        }

        #endregion

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
