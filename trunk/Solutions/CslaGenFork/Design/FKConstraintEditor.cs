using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using System.Drawing;

namespace CslaGenerator.Design
{
    public class FKConstraintEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;
        private ListBox lstProperties;

        public FKConstraintEditor()
        {
            lstProperties = new ListBox();
            lstProperties.DoubleClick += lstProperties_DoubleClick;
            lstProperties.SelectionMode = SelectionMode.One;
        }

        void lstProperties_DoubleClick(object sender, EventArgs e)
        {
            editorService.CloseDropDown();
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (editorService != null)
                {
                    if (context.Instance != null)
                    {
                        // CR modifying to accomodate PropertyBag
                        Type instanceType = null;
                        object objinfo = null;
                        TypeHelper.GetValuePropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                        ValueProperty obj = (ValueProperty) objinfo;
                        lstProperties.Items.Clear();
                        if (obj.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.Default)
                        {
                            lstProperties.Items.Add("(None)");

                            // Warehouse.FK_Models_Brands - FK=Models.BrandID - PK = Brands.BrandID
                            // GeneralStore.FK_Products_ProdFamilies
                            //      FK=Products.ProdFamilyId
                            //      PK=ProdFamily.ProdFamilyId
                            //
                            foreach (var constraint in GeneratorController.Catalog.ForeignKeyConstraints)
                            {
                                // get constraints with table match for PK or FK
                                if (obj.DbBindColumn.ObjectName == constraint.PKTable.ObjectName ||
                                    obj.DbBindColumn.ObjectName == constraint.ConstraintTable.ObjectName)

                                    // get constraints with table match for Constraint FK
                                    //if (obj.DbBindColumn.ObjectName == constraint.ConstraintTable.ObjectName)
                                {
                                    lstProperties.Items.Add(constraint.ConstraintName);
                                }
                            }
                            lstProperties.Sorted = true;

                            if (lstProperties.Items.Contains(obj.FKConstraint))
                                lstProperties.SelectedItem = obj.FKConstraint;
                            else
                                lstProperties.SelectedItem = "(None)";

                            editorService.DropDownControl(lstProperties);
                            if (lstProperties.SelectedIndex < 0 || lstProperties.SelectedItem.ToString() == "(None)")
                                return string.Empty;

                            return lstProperties.SelectedItem.ToString();
                        }
                        else
                        {
                            lstProperties.Items.Add("(Illegal)");
                            editorService.DropDownControl(lstProperties);
                            return string.Empty;
                        }
                    }

                }
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}
