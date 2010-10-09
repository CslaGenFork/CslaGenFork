using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class ItemTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService;
        private ListBox lstProperties;
        //private Type instance;

        public ItemTypeEditor()
        {
            lstProperties = new ListBox();
            lstProperties.DoubleClick += lstProperties_DoubleClick;
            lstProperties.SelectionMode = SelectionMode.One;
        }

        private void lstProperties_DoubleClick(object sender, EventArgs e)
        {
            editorService.CloseDropDown();
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                editorService = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
                if (editorService != null)
                {
                    if (context.Instance != null)
                    {
                        // CR modifying to accomodate PropertyBag
                        Type instanceType = null;
                        object objinfo = null;
                        TypeHelper.GetContextInstanceObject(context, ref objinfo, ref instanceType);
                        CslaObjectInfo obj = (CslaObjectInfo) objinfo;
                        lstProperties.Items.Clear();
                        lstProperties.Items.Add("(None)");
                        foreach (CslaObjectInfo o in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            if (o.ObjectName != obj.ObjectName)
                            {
                                //if (IsItemType(obj.ObjectType, o.ObjectType))
                                if (RelationRulesEngine.IsChildAllowed(obj.ObjectType, o.ObjectType))
                                    lstProperties.Items.Add(o.ObjectName);
                            }
                        }
                        lstProperties.Sorted = true;

                        if (lstProperties.Items.Contains(obj.ItemType))
                            lstProperties.SelectedItem = obj.ItemType;
                        else
                            lstProperties.SelectedItem = "(None)";

                        editorService.DropDownControl(lstProperties);
                        if (lstProperties.SelectedIndex < 0 || lstProperties.SelectedItem.ToString() == "(None)")
                            return string.Empty;

                        return lstProperties.SelectedItem.ToString();
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