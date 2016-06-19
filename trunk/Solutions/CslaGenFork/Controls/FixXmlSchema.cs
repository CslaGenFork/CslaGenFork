using System;
using System.Reflection;
using System.Windows.Forms;

namespace CslaGenerator.Controls
{
    public partial class FixXmlSchema : Form
    {
        #region Fields and Properties

        public string FilePath { get; set; }
        public int OfendingLine { get; set; }
        public int OfendingPosition { get; set; }
        public string OfendedType { get; set; }
        public string OriginalItem { get; set; }
        public string ReplacementItem { get; private set; }

        #endregion

        public FixXmlSchema()
        {
            InitializeComponent();
        }

        private void FixXmlSchema_Load(object sender, EventArgs e)
        {
            ProcessException();
            var executingAssembly = Assembly.GetExecutingAssembly();

            foreach (Type type in executingAssembly.GetTypes())
            {
                if (type.IsEnum && type.Name == OfendedType)
                {
                    foreach (var name in Enum.GetNames(type))
                    {
                        listBox1.Items.Add(name);
                    }
                    break;
                }
            }
        }

        private void fixButton_Click(object sender, EventArgs e)
        {
            ReplacementItem = listBox1.SelectedItem as string;
            if (!string.IsNullOrEmpty(ReplacementItem))
                Close();
            else
                MessageBox.Show(@"You must select one item in the list.",
                    @"Select replacement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void ProcessException()
        {
            label1.Text = @"Processing file:" + Environment.NewLine + FilePath;

            label2.Text = string.Format("There is an error in XML document: Line {0}, Position {1}.",
                OfendingLine,
                OfendingPosition);

            label3.Text = string.Format("Invalid value for enum '{0}'.", OfendedType);

            label5.Text = string.Format(@"Choose a replacement for '{0}'", OriginalItem);
        }
    }
}