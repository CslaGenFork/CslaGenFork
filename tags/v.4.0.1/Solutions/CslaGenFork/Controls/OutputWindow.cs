using System;
using System.Drawing;
using System.Windows.Forms;

namespace CslaGenerator.Controls
{
    public partial class OutputWindow : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        static OutputWindow _Current;
     
        public OutputWindow()
        {
            InitializeComponent();
            Icon =Icon.FromHandle(CslaGenerator.Properties.Resources.Output.GetHicon());
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom |
                WeifenLuo.WinFormsUI.Docking.DockAreas.Float;
            _Current = this;

        }


        #region Properties
        
        public static OutputWindow Current
        {
            get
            {
                return _Current;
            }
        }
        
        #endregion

        #region Thread Safe Handlers

        delegate void EmptyDelegate();
        delegate void MessageDelegate(string message, int appendLines);
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
            this.Invoke(new MessageDelegate(DoStep), new object[] { info, appendLines });
        }

        /// <summary>
        /// Thread safe method to clear the output panel.
        /// </summary>
        public void ClearOutput()
        {
            this.Invoke(new EmptyDelegate(textBox1.Clear), new object[] { });
        }

        #endregion

        #region Private Methods
        
        void DoStep(string message, int appendLines)
        {
            textBox1.AppendText(message);
            for (int i=0; i < appendLines; i++)
                textBox1.AppendText(Environment.NewLine);
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
