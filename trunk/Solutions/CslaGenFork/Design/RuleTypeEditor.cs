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
    /// <summary>
    /// Summary description for RuleTypeEditor for Rules 4
    /// </summary>
    public class RuleTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;
        private Type _instance;

        public RuleTypeEditor()
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
                        //http://msdn.microsoft.com/en-us/library/system.type.findinterfaces(v=vs.80).aspx
                        //TypeFilter myFilter = new TypeFilter(MyInterfaceFilter);

                        var assembly = Assembly.LoadFrom(assemblyFilePath);
                        var types = assembly.GetExportedTypes();
                        foreach (var type in types)
                        {
                            var baseType = type.BaseType.ToString().Split(new char[1] { '`' });
                            if (baseType.Length > 0)
                                _lstProperties.Items.Add(baseType[0] + " - " + type);
                        }
                        /*foreach (var type in types)
                        {
                            var businessRule = type.GetInterface("Csla.Rules.IBusinessRule");
                            var authorizationRule = type.GetInterface("Csla.Rules.IAuthorizationRule");
                            var validationAttribute = type.GetInterface("System.Runtime.InteropServices._Attribute");
                            // check here for Csla.Rules.BusinessRule inheritance
                            // check here for System.ComponentModel.DataAnnotations.ValidationAttribute inheritance
                            if (businessRule != null || authorizationRule != null || validationAttribute != null)
                                _lstProperties.Items.Add(type.ToString());
                        }*/
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

        //http://msdn.microsoft.com/en-us/library/system.type.findinterfaces(v=vs.80).aspx
        /*public static bool MyInterfaceFilter(Type typeObj, Object criteriaObj)
        {
            if (typeObj.ToString() == criteriaObj.ToString())
                return true;

            return false;
        }*/

    }
}