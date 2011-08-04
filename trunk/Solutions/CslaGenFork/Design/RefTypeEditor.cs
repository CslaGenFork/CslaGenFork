using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.CodeGen;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class RefTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;
        private Type _instance;
        private List<Type> _types;

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
                    //string assemblyFilePath = (string) assemblyFileInfo.GetValue(context.Instance, null);
                    var assemblyFilePath = (string)assemblyFileInfo.GetValue(objinfo, null);

                    // If Assembly path is available, use assembly to load a drop down with available types.
                    if (!string.IsNullOrEmpty(assemblyFilePath))
                    {
                        /*var currentCslaObject = (CslaObjectInfo) GeneratorController.Current.MainForm.ProjectPanel.ListObjects.SelectedItem;
                        var baseType = currentCslaObject.ObjectType;*/

                        var assembly = Assembly.LoadFrom(assemblyFilePath);
                        var alltypes = assembly.GetExportedTypes();
                        if (alltypes.Length > 0)
                            _types = new List<Type>();

                        foreach (var type in alltypes)
                        {
                            // exclude abstract classes
                            if (!type.IsAbstract && !type.IsInterface)
                            {
                                _types.Add(type);

                                var listableType = type.ToString();
                                if (type.IsGenericType)
                                {
                                    listableType = listableType.Substring(0, listableType.LastIndexOf('`'));
                                    foreach (var argument in type.GetGenericArguments())
                                    {
                                        listableType += "<" + argument.Name + ">";
                                    }
                                }
                                listableType = listableType.Replace("><", ",");
                                _lstProperties.Items.Add(listableType);
                            }
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
