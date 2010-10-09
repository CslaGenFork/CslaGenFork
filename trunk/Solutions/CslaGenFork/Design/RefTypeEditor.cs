using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Collections;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class RefTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;
        private ListBox lstRefType = null;
        private Type instance;

        public RefTypeEditor()
        {
            lstRefType = new ListBox();
            lstRefType.SelectedValueChanged += new EventHandler(Value_Changed);
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
                        TypeHelper.GetInheritedTypeContextInstanceObject(context, ref objinfo, ref instanceType);
                        TypeInfo obj = (TypeInfo)objinfo;
                        instance = objinfo.GetType();

                        lstRefType.Items.Clear();
                        lstRefType.Items.Add("(None)");

                        // Get Assembly File Path
                        PropertyInfo assemblyFileInfo = instance.GetProperty("AssemblyFile");
                        //string assemblyFilePath = (string) assemblyFileInfo.GetValue(context.Instance,null);
                        //string assemblyFilePath = (string) assemblyFileInfo.GetValue(context.Instance, null);
                        string assemblyFilePath = (string) assemblyFileInfo.GetValue(objinfo, null);

                        // If Assembly path is available, use assembly to load a drop down with available types.
                        if (assemblyFilePath != null && assemblyFilePath != String.Empty)
                        {
                            Assembly assembly = Assembly.LoadFrom(assemblyFilePath);
                            Type[] types = assembly.GetExportedTypes();
                            for (int i = 0; i < types.Length ; i++)
                            {
                                lstRefType.Items.Add(types[i].ToString());
                            }
                            lstRefType.Sorted = true;
                        }

                        if (lstRefType.Items.Contains(obj.Type))
                            lstRefType.SelectedItem = obj.Type;
                        else
                            lstRefType.SelectedItem = "(None)";

                        editorService.DropDownControl(lstRefType);

                        if (lstRefType.SelectedIndex < 0 || lstRefType.SelectedItem.ToString() == "(None)")
                            return string.Empty;

                        //return lstRefType.SelectedItem;
                        return lstRefType.SelectedItem.ToString();
                    }

                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        private void Value_Changed(object sender, EventArgs e)
        {
            if (editorService != null)
            {
                editorService.CloseDropDown();
            }
        }
    }
}
