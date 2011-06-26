using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using CslaGenerator.Util.PropertyBags;

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
                    Text = @"Criteria Editor";
                    // pgEditor.SelectedObject = _object;
                    pgEditor.SelectedObject = new CriteriaBag(((Criteria) _object));
                    pgEditor.PropertySort = PropertySort.Categorized;
                    this.Size = new Size(this.Size.Width, 711);
                    pgEditor.Size = new Size(pgEditor.Size.Width, 619);
                    var cslaObject = (CslaObjectInfo)GeneratorController.Current.MainForm.ProjectPanel.ListObjects.SelectedItem;
                    if ((cslaObject.ObjectType == CslaObjectType.ReadOnlyObject ||
                         cslaObject.ObjectType == CslaObjectType.ReadOnlyCollection ||
                         cslaObject.ObjectType == CslaObjectType.NameValueList ||
                         (cslaObject.ObjectType == CslaObjectType.UnitOfWork)))
                    {
                        this.Size = new Size(this.Size.Width, this.Size.Height - 256);
                        pgEditor.Size = new Size(pgEditor.Size.Width, pgEditor.Size.Height - 256);
                    }
                    if (GeneratorController.Current.CurrentUnit.GenerationParams.TargetFramework != TargetFramework.CSLA40 &&
                        GeneratorController.Current.CurrentUnit.GenerationParams.TargetFramework != TargetFramework.CSLA40DAL)
                    {
                        this.Size = new Size(this.Size.Width, this.Size.Height - 32);
                        pgEditor.Size = new Size(pgEditor.Size.Width, pgEditor.Size.Height - 32);
                    }
                    pgEditor.ExpandAllGridItems();
                }
                else
                {
                    Text = @"InheritedType Editor";
                    //pgEditor.SelectedObject = _object;
                    pgEditor.SelectedObject = new InheritedTypePropertyBag((TypeInfo) _object);
                }
                this.MaximumSize = new Size(this.Size.Width + 100, this.Size.Height);
                this.MinimumSize = new Size(this.Size.Width - 100, this.Size.Height);
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

        public void OnSort(object sender, EventArgs e)
        {
            if (pgEditor.PropertySort == PropertySort.CategorizedAlphabetical)
                pgEditor.PropertySort = PropertySort.Categorized;
        }

    }
}
