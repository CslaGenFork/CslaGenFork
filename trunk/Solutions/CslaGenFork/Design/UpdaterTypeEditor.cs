using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class UpdaterTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService;
        private ListBox lstProperties;
        //private Type instance;

        public UpdaterTypeEditor()
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
                        var obj = (CslaObjectInfo) objinfo;
                        lstProperties.Items.Clear();
                        lstProperties.Items.Add("(None)");
                        foreach (CslaObjectInfo o in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            if (o.ObjectName != obj.ObjectName)
                            {
                                if (IsUpdaterType(o.ObjectType))
                                    lstProperties.Items.Add(o.ObjectName);
                            }
                        }
                        lstProperties.Sorted = true;

                        if (lstProperties.Items.Contains(obj.UpdaterType))
                            lstProperties.SelectedItem = obj.UpdaterType;
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

        public bool IsUpdaterType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableRoot ||
                cslaType == CslaObjectType.DynamicEditableRootCollection ||
                cslaType == CslaObjectType.EditableSwitchable)
                return true;

            return false;
        }
    }
}