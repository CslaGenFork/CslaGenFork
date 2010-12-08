using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class RefTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;
        private Type _instance;

        public RefTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.SelectedValueChanged += ValueChanged;
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
                    TypeHelper.GetInheritedTypeContextInstanceObject(context, ref objinfo, ref instanceType);
                    var obj = (TypeInfo)objinfo;
                    _instance = objinfo.GetType();

                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");

                    // Get Assembly File Path
                    var assemblyFileInfo = _instance.GetProperty("AssemblyFile");
                    //string assemblyFilePath = (string) assemblyFileInfo.GetValue(context.Instance,null);
                    //string assemblyFilePath = (string) assemblyFileInfo.GetValue(context.Instance, null);
                    var assemblyFilePath = (string)assemblyFileInfo.GetValue(objinfo, null);

                    // If Assembly path is available, use assembly to load a drop down with available types.
                    if (!string.IsNullOrEmpty(assemblyFilePath))
                    {
                        var assembly = Assembly.LoadFrom(assemblyFilePath);
                        var types = assembly.GetExportedTypes();
                        for (int i = 0; i < types.Length; i++)
                        {
                            _lstProperties.Items.Add(types[i].ToString());
                        }
                        _lstProperties.Sorted = true;
                    }

                    if (_lstProperties.Items.Contains(obj.Type))
                        _lstProperties.SelectedItem = obj.Type;
                    else
                        _lstProperties.SelectedItem = "(None)";

                    _editorService.DropDownControl(_lstProperties);
                    if (_lstProperties.SelectedIndex < 0 || _lstProperties.SelectedItem.ToString() == "(None)")
                        return string.Empty;

                    return _lstProperties.SelectedItem.ToString();
                }

            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            if (_editorService != null)
            {
                _editorService.CloseDropDown();
            }
        }
    }
}