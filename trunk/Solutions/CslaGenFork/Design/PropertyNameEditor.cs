using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class PropertyNameEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;
        private ListBox lstProperties;
        private Type instance;

        public PropertyNameEditor()
        {
            lstProperties = new ListBox();
            lstProperties.DoubleClick += lstProperties_DoubleClick;
            lstProperties.DisplayMember = "key";
            lstProperties.ValueMember = "value";
            lstProperties.SelectedIndexChanged += lstProperties_SelectedIndexChanged;
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
                        TypeHelper.GetContextInstanceObject(context, ref objinfo, ref instanceType);
                        CslaObjectInfo obj = (CslaObjectInfo) objinfo;
                        instance = objinfo.GetType();
                        PropertyInfo valuePropsInfo = instance.GetProperty("ValueProperties");
                        ValuePropertyCollection valueProps = (ValuePropertyCollection)valuePropsInfo.GetValue(objinfo,null);
                        if (valueProps.Count > 0)
                        {
                            lstProperties.Items.Clear();
                            for (int i = 0; i < valueProps.Count; i++)
                            {
                                lstProperties.Items.Add(valueProps[i].Name);
                            }
                            lstProperties.Sorted = true;

                            if (context.PropertyDescriptor.DisplayName == "Value Column")
                                lstProperties.SelectedItem = obj.NameColumn;
                            else if (context.PropertyDescriptor.DisplayName == "Key Column")
                                lstProperties.SelectedItem = obj.ValueColumn;

                            editorService.DropDownControl(lstProperties);
                            if (lstProperties.SelectedItem == null)
                                return string.Empty;

                            return lstProperties.SelectedItem.ToString();
                        }
                    }
                }
            }
            return value;
        }

        private void lstProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editorService != null)
            {
                editorService.CloseDropDown();
            }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}
