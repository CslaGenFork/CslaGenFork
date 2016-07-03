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
    /// Summary description for CslaObjectInfoEditor (TypeInfo).
    /// Used to get/set a type defined in the project (TypeInfo.ObjectName).
    /// </summary>
    public class CslaObjectInfoEditor : UITypeEditor, IDisposable
    {
        public class BaseProperty
        {
            public CslaObjectInfo Type { get; set; }
            public string TypeName { get; set; }

            public BaseProperty(CslaObjectInfo type, string typeName)
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

        public CslaObjectInfoEditor()
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

                    _sizeSortedNamespaces = new List<string>();

                    var currentCslaObject = GeneratorController.Current.CurrentCslaObject;
                    _sizeSortedNamespaces = currentCslaObject.Namespaces.ToList();
                    _sizeSortedNamespaces.Add(currentCslaObject.ObjectNamespace);
                    _sizeSortedNamespaces = BusinessRuleTypeEditor.GetSizeSorted(_sizeSortedNamespaces);

                    var alltypes = GeneratorController.Current.CurrentUnit.CslaObjects;
                    if (alltypes.Count > 0)
                        _baseTypes = new List<BaseProperty>();

                    var isCustomCriteria = !(obj.IsInheritedType || obj.IsInheritedTypeWinForms);
                    var currentBaseClass = currentCslaObject.CslaBaseClass();

                    foreach (var type in alltypes)
                    {
                        var addToList = false;

                        if (isCustomCriteria)
                        {
                            addToList = type.IsCriteriaClass();
                        }
                        else
                        {
                            if (!GeneratorController.Current.CurrentUnit.Params.EnforceGenericInheritance)
                            {
                                var isMatch = currentCslaObject.IsObjectType() == type.IsObjectType() &&
                                              currentCslaObject.IsCollectionType() == type.IsCollectionType();
                                var isSameBaseClass = isMatch && currentBaseClass == type.CslaBaseClass();

                                var isInheritedNonGeneric = type.IsBaseClass() &&
                                                            !type.IsGenericType;

                                addToList = isSameBaseClass || isInheritedNonGeneric;
                            }

                            var isInheritedMatchingGeneric = type.IsBaseClass() &&
                                                             type.IsGenericType &&
                                                             type.GetGenericArguments().Length ==
                                                             currentCslaObject.NumberOfGenericArguments();

                            var isNotSameObject = !ReferenceEquals(currentCslaObject, type);

                            addToList = (addToList || isInheritedMatchingGeneric) &&
                                        isNotSameObject;
                        }

                        if (addToList)
                        {
                            var listableType = type.GenericName;
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

                    _lstProperties.Sorted = true;

                    if (_lstProperties.Items.Contains(obj.ObjectName))
                        _lstProperties.SelectedItem = obj.ObjectName;
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
            CslaObjectInfo usedType = null;

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