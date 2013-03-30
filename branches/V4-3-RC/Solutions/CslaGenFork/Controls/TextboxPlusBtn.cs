using System;
using System.Windows.Forms;

namespace CslaGenerator.Controls
{
    public partial class TextboxPlusBtn : UserControl
    {
        public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
        public virtual event ButtonClickedEventHandler ButtonClicked;

        public TextboxPlusBtn()
        {
            InitializeComponent();
        }

        internal TextBox TextBox
        {
            get { return textBox; }
        }

        internal Button Button
        {
            get { return button; }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ButtonClicked(sender, e);
        }	

    }
}
