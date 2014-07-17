using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class FKConstraintEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;

        public FKConstraintEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.SelectionMode = SelectionMode.One;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (_editorService != null)
            {
                if (context.Instance != null)
                {
                    // CR modifying to accomodate PropertyBag
                    Type instanceType = null;
                    object objinfo = null;
                    TypeHelper.GetValuePropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    var obj = (ValueProperty)objinfo;
                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    if (obj.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.Default)
                    {
                        // Warehouse.FK_Models_Brands - FK=Models.BrandID - PK = Brands.BrandID
                        // GeneralStore.FK_Products_ProdFamilies
                        //      FK=Products.ProdFamilyId
                        //      PK=ProdFamily.ProdFamilyId
                        //
                        foreach (var constraint in GeneratorController.Catalog.ForeignKeyConstraints)
                        {
                            /*// get constraints with table match for PK or FK
                            if (obj.DbBindColumn.ObjectName == constraint.PKTable.ObjectName ||
                                obj.DbBindColumn.ObjectName == constraint.ConstraintTable.ObjectName)*/

                            // get constraints with table match for Constraint FK
                            if (obj.DbBindColumn.ObjectName == constraint.ConstraintTable.ObjectName)
                            {
                                _lstProperties.Items.Add(constraint.ConstraintName);
                            }
                        }
                        _lstProperties.Sorted = true;

                        if (_lstProperties.Items.Contains(obj.FKConstraint))
                            _lstProperties.SelectedItem = obj.FKConstraint;
                        else
                            _lstProperties.SelectedItem = "(None)";

                        _editorService.DropDownControl(_lstProperties);
                        if (_lstProperties.SelectedIndex < 0 || _lstProperties.SelectedItem.ToString() == "(None)")
                            return string.Empty;

                        return _lstProperties.SelectedItem.ToString();
                    }

                    _lstProperties.Items.Add("(Illegal)");
                    _editorService.DropDownControl(_lstProperties);
                    return string.Empty;
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        void LstPropertiesDoubleClick(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                if (_lstProperties != null)
                {
                    _lstProperties.Dispose();
                    _lstProperties = null;
                }
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}