using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for RefTypeEditor (list of .NET types).
    /// Used to get/set an assembly type (TypeInfo.Type).
    /// </summary>
    public class RefTypeEditor : UITypeEditor, IDisposable
    {
        public class BaseProperty
        {
            public Type Type { get; set; }
            public string TypeName { get; set; }

            public BaseProperty(Type type, string typeName)
            {
                Type = type;
                TypeName = typeName;
            }
        }

        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;
        private Type _instance;
        private List<BaseProperty> _baseTypes;
        private List<string> _sizeSortedNamespaces;

        public RefTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.SelectedValueChanged += ValueChanged;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
            if (_editorService != null)
            {
                if (context.Instance != null)
                {
                    // CR modifying to accomodate PropertyBag
                    Type instanceType = null;
                    object objinfo = null;
                    ContextHelper.GetTypeInfoContextInstanceObject(context, ref objinfo, ref instanceType);
                    var obj = (TypeInfo) objinfo;
                    _instance = objinfo.GetType();

                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");

                    var currentCslaObject = GeneratorController.Current.CurrentCslaObject;
                    _sizeSortedNamespaces = currentCslaObject.Namespaces.ToList();
                    _sizeSortedNamespaces.Add(currentCslaObject.ObjectNamespace);
                    _sizeSortedNamespaces.Add("Csla");
                    _sizeSortedNamespaces = BusinessRuleTypeEditor.GetSizeSorted(_sizeSortedNamespaces);

                    // Get Assembly File Path
                    var assemblyFileInfo = _instance.GetProperty("AssemblyFile");
                    var assemblyFilePath = (string) assemblyFileInfo.GetValue(objinfo, null);

                    // If Assembly path is available, use assembly to load a drop down with available types.
                    if (!string.IsNullOrEmpty(assemblyFilePath))
                    {
                        var assembly = Assembly.LoadFrom(assemblyFilePath);
                        var alltypes = assembly.GetExportedTypes();
                        if (alltypes.Length > 0)
                            _baseTypes = new List<BaseProperty>();

                        var isCustomCriteria = !(obj.IsInheritedType || obj.IsInheritedTypeWinForms);
                        var numberOfGenericArguments = 1;
                        if (!isCustomCriteria)
                            numberOfGenericArguments = currentCslaObject.NumberOfGenericArguments();

                        foreach (var type in alltypes)
                        {
                            if (type.GetInterface("Csla.Core.IBusinessObject") != null ||
                                type.GetInterface("Csla.Core.IObservableBindingList") != null ||
                                type.GetInterface("Csla.Core.IExtendedBindingList") != null)
                            {
                                // exclude interface classes
                                if (!type.IsInterface)
                                {
                                    var listableType = string.Empty;

                                    if (!GeneratorController.Current.CurrentUnit.Params.EnforceGenericInheritance &&
                                        !isCustomCriteria)
                                        listableType = type.ToString();

                                    if (type.IsGenericType)
                                    {
                                        if (type.GetGenericArguments().Length == numberOfGenericArguments)
                                        {
                                            listableType = type.ToString();
                                            listableType = listableType.Substring(0, listableType.LastIndexOf('`'));
                                            foreach (var argument in type.GetGenericArguments())
                                            {
                                                listableType += "<" + argument.Name + ">";
                                            }
                                            listableType = listableType.Replace("><", ",");
                                        }
                                        else
                                        {
                                            listableType = string.Empty;
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(listableType))
                                    {
                                        listableType = BusinessRuleTypeEditor.StripKnownNamespaces(
                                            _sizeSortedNamespaces,
                                            listableType);
                                        _lstProperties.Items.Add(listableType);
                                        _baseTypes.Add(new BaseProperty(type, listableType));
                                    }
                                }
                            }
                        }

                        _lstProperties.Sorted = true;
                    }

                    var entry = BusinessRuleTypeEditor.StripKnownNamespaces(_sizeSortedNamespaces, obj.Type);
                    if (_lstProperties.Items.Contains(entry))
                        _lstProperties.SelectedItem = entry;
                    else
                        _lstProperties.SelectedItem = "(None)";

                    _editorService.DropDownControl(_lstProperties);

                    if (_lstProperties.SelectedIndex < 0 || _lstProperties.SelectedItem.ToString() == "(None)")
                    {
                        FillPropertyGrid(obj, _lstProperties.SelectedItem.ToString());
                        return string.Empty;
                    }

                    FillPropertyGrid(obj, _lstProperties.SelectedItem.ToString());

                    return _lstProperties.SelectedItem.ToString();
                }
            }

            return value;
        }

        private void FillPropertyGrid(TypeInfo typeInfo, string stringType)
        {
            Type usedType = null;

            if (stringType != "(None)")
            {
                foreach (var baseType in _baseTypes)
                {
                    if (baseType.TypeName ==
                        BusinessRuleTypeEditor.StripKnownNamespaces(_sizeSortedNamespaces, stringType))
                        usedType = baseType.Type;
                }
            }

            if (usedType == null)
                typeInfo.IsGenericType = false;
            else
                typeInfo.IsGenericType = usedType.IsGenericType;
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