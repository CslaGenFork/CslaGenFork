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
    // guess isn't used any longer
    public class PropertyEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;
        private ListBox lstProperties;
        private Type instance;

        public PropertyEditor()
        {
            lstProperties = new ListBox();
            lstProperties.DisplayMember = "key";
            lstProperties.ValueMember = "value";
            lstProperties.SelectedIndexChanged += new EventHandler(lstProperties_SelectedIndexChanged);
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
                        instance = objinfo.GetType();
                        PropertyInfo valuePropsInfo = instance.GetProperty("ValueProperties");
                        ValuePropertyCollection valueProps = (ValuePropertyCollection)valuePropsInfo.GetValue(objinfo,null);
                        if (valueProps.Count > 0)
                        {
                            lstProperties.Items.Clear();
                            lstProperties.Items.Add(new DictionaryEntry("None",new ValueProperty()));
                            for (int i = 0; i < valueProps.Count; i++)
                            {
                                lstProperties.Items.Add(new DictionaryEntry(valueProps[i].Name,valueProps[i]));
                            }
                            editorService.DropDownControl(lstProperties);
                            if (lstProperties.SelectedItem != null)
                            {
                                ValueProperty prop = (ValueProperty)((DictionaryEntry)lstProperties.SelectedItem).Value;
                                if (prop != null)
                                {
                                    return prop.Clone();
                                }
                            }
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
