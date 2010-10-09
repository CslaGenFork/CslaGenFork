using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for ObjectEditorForm.
    /// </summary>
    public partial class ObjectEditorForm : Form
    {
        private object _object;

        public ObjectEditorForm()
        {
            InitializeComponent();
        }

        public object ObjectToEdit
        {
            get { return _object; }
            set
            {
                _object = value;
                if (_object.GetType() == typeof (Criteria))
                {
                    Text = "Criteria Editor";
                    pgEditor.SelectedObject = _object;
                    //pgEditor.SelectedObject = new CriteriaPropertyBag(((Criteria) _object).Properties[0]);
                }
                else
                {
                    Text = "InheritedType Editor";
                    //pgEditor.SelectedObject = _object;
                    pgEditor.SelectedObject = new InheritedTypePropertyBag((TypeInfo) _object);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
