using System;
using System.Drawing;
using System.Reflection;
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
            pgEditor.PropertySort = PropertySort.Categorized;
        }

        public object ObjectToEdit
        {
            get { return _object; }
            set
            {
                _object = value;
                OnSelect(this, new EventArgs());
            }
        }

        public void OnSelect(object sender, EventArgs e)
        {
            if (_object != null)
            {
                if (_object.GetType() == typeof (Criteria))
                {
                    Text = @"Criteria Editor";
                    // pgEditor.SelectedObject = _object;
                    pgEditor.SelectedObject = new CriteriaBag(((Criteria) _object));
                    Size = new Size(Size.Width, 711);
                    pgEditor.Size = new Size(pgEditor.Size.Width, 619);
                    var cslaObject =
                        (CslaObjectInfo) GeneratorController.Current.MainForm.ProjectPanel.ListObjects.SelectedItem;
                    if ((cslaObject.ObjectType == CslaObjectType.ReadOnlyObject ||
                         cslaObject.ObjectType == CslaObjectType.ReadOnlyCollection ||
                         cslaObject.ObjectType == CslaObjectType.NameValueList ||
                         (cslaObject.ObjectType == CslaObjectType.UnitOfWork)))
                    {
                        Size = new Size(Size.Width, Size.Height - 256);
                        pgEditor.Size = new Size(pgEditor.Size.Width, pgEditor.Size.Height - 256);
                    }
                    if (GeneratorController.Current.CurrentUnit.GenerationParams.TargetFramework !=
                        TargetFramework.CSLA40 &&
                        GeneratorController.Current.CurrentUnit.GenerationParams.TargetFramework !=
                        TargetFramework.CSLA40DAL)
                    {
                        Size = new Size(Size.Width, Size.Height - 32);
                        pgEditor.Size = new Size(pgEditor.Size.Width, pgEditor.Size.Height - 32);
                    }
                    pgEditor.ExpandAllGridItems();
                }
                else if (_object.GetType() == typeof (TypeInfo))
                {
                    Text = @"Inherited Type Editor";
                    //pgEditor.SelectedObject = _object;
                    pgEditor.SelectedObject = new InheritedTypePropertyBag((TypeInfo) _object);
                    Size = new Size(Size.Width + 100, Size.Height);
                }
                else if (_object.GetType() == typeof (AuthorizationRule))
                {
                    Text = @"Authorization Type Editor";
                    ((AuthorizationRule) _object).TypeChanged -= OnSelect;
                    ((AuthorizationRule) _object).TypeChanged += OnSelect;
                    if (PropertyCollectionForm.ParentValProp != null)
                    {
                        ((AuthorizationRule) _object).IsPropertyRule = true;
                        ((AuthorizationRule) _object).Parent = PropertyCollectionForm.ParentValProp;
                        ((AuthorizationRule) _object).ActionProperty = ValueProperty.Convert(PropertyCollectionForm.ParentProperty);
                    }
                    else
                    {
                        var cslaObject =
                            (CslaObjectInfo) GeneratorController.Current.MainForm.ProjectPanel.ListObjects.SelectedItem;
                        ((AuthorizationRule) _object).ActionProperty = cslaObject.ActionProperty;
                        ((AuthorizationRule)_object).Parent = string.Empty;
                    }
                    //pgEditor.SelectedObject = _object;
                    pgEditor.SelectedObject = new AuthorizationRuleBag((AuthorizationRule) _object);
                    Size = new Size(468, Size.Height);
                }
                MaximumSize = new Size(Size.Width + 100, Size.Height);
                MinimumSize = new Size(Size.Width - 100, Size.Height);
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

        private void pgEditor_Layout(object sender, LayoutEventArgs e)
        {
            var gridItem = pgEditor.SelectedGridItem;
            while (gridItem.Parent != null)
            {
                gridItem = gridItem.Parent;
            }
            var r = 0;
            GetLongest(gridItem.GridItems, ref r);

            // http://www.dotnetmonster.com/Uwe/Forum.aspx/winform-controls/5624/Using-the-PropertyGrid-Control

            FieldInfo fi = typeof(PropertyGrid).GetField("gridView", BindingFlags.Instance | BindingFlags.NonPublic);
            object propertyGridView = fi.GetValue(pgEditor);

            pgEditor.AutoSize = false;

            MethodInfo mi = propertyGridView.GetType().GetMethod("MoveSplitterTo", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(propertyGridView, new object[] { r+10 });
        }

        private void GetLongest(GridItemCollection col, ref int r)
        {
            foreach (GridItem item in col)
            {
                if(item.GridItemType != GridItemType.Category)
                    r = Math.Max(r, TextRenderer.MeasureText(item.Label, pgEditor.Font).Width);
                if (item.Expanded)
                {
                    GetLongest(item.GridItems, ref r);
                }
            }
        }
    }
}
