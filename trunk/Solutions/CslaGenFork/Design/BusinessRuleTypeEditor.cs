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
    /// Summary description for RuleTypeEditor for Rules 4
    /// </summary>
    public class BusinessRuleTypeEditor : UITypeEditor, IDisposable
    {
        public class BaseProperty
        {
            public Type Type { get; set; }
            public Type BaseType { get; set; }
            public string TypeName { get; set; }

            public BaseProperty(Type type, Type baseType, string typeName)
            {
                Type = type;
                BaseType = baseType;
                TypeName = typeName;
            }
        }

        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;
        private Type _instance;
        private List<BaseProperty> _baseTypes;
        private List<string> _sizeSortedNamespaces;

        public BusinessRuleTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.SelectedValueChanged += ValueChanged;
            _lstProperties.Width = 300;
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
                    ContextHelper.GetBusinessRuleTypeContextInstanceObject(context, ref objinfo, ref instanceType);
                    var obj = (BusinessRule) objinfo;
                    _instance = objinfo.GetType();

                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");

                    _sizeSortedNamespaces = new List<string>();
                    var currentCslaObject = (CslaObjectInfo) GeneratorController.Current.GetSelectedItem();
                    _sizeSortedNamespaces = currentCslaObject.Namespaces.ToList();
                    _sizeSortedNamespaces.Add(currentCslaObject.ObjectNamespace);
                    _sizeSortedNamespaces = GetSizeSorted(_sizeSortedNamespaces);

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

                        foreach (var type in alltypes)
                        {
                            // check here for Csla.Rules.IBusinessRule inheritance
                            if (type.GetInterface("Csla.Rules.IBusinessRule") != null)
                            {
                                // exclude abstract classes and exclude Property level rules for Objects and vv.
                                if (!type.IsAbstract && CTorMatchesRuleLevel(obj, type))
                                {
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
                                    listableType = StripKnownNamespaces(_sizeSortedNamespaces, listableType);
                                    _lstProperties.Items.Add(listableType);
                                    _baseTypes.Add(new BaseProperty(type, type.BaseType, listableType));
                                }
                            }
                        }

                        _lstProperties.Sorted = true;
                    }

                    var entry = StripKnownNamespaces(_sizeSortedNamespaces, obj.Type);
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

        public static List<string> GetSizeSorted(List<string> namespaces)
        {
            var result = namespaces.OrderByDescending(o => o.Length).ToList();
            return result;
        }

        public static string StripKnownNamespaces(List<string> sortedNamespaces, string stringType)
        {
            foreach (var ns in sortedNamespaces)
            {
                if (stringType.IndexOf(ns, StringComparison.InvariantCulture) == 0)
                {
                    return stringType.Substring(ns.Length + 1);
                }
            }
            return stringType;
        }

        private void FillPropertyGrid(BusinessRule rule, string stringType)
        {
            Type usedType = null;

            if (stringType != "(None)")
            {
                foreach (var baseType in _baseTypes)
                {
                    if (baseType.TypeName == StripKnownNamespaces(_sizeSortedNamespaces, stringType))
                        usedType = baseType.Type;
                }
            }

            if (usedType == null)
            {
                if (rule.BaseRuleProperties.Count > 0)
                    rule.BaseRuleProperties.RemoveRange(0, rule.BaseRuleProperties.Count);
                if (rule.RuleProperties.Count > 0)
                    rule.RuleProperties.RemoveRange(0, rule.RuleProperties.Count);
                if (rule.Constructors.Count > 0)
                {
                    foreach (BusinessRuleConstructor constructor in rule.Constructors)
                    {
                        if (constructor.ConstructorParameters.Count > 0)
                            constructor.ConstructorParameters.RemoveRange(0, constructor.ConstructorParameters.Count);
                    }
                    rule.Constructors.RemoveRange(0, rule.Constructors.Count);
                }
                return;
            }

            #region Base Rule Properties

            rule.BaseRuleProperties = new List<string>();
            foreach (var baseType in _baseTypes)
            {
                if (baseType.Type != usedType)
                    continue;
                foreach (var prop in baseType.BaseType.GetProperties(BindingFlags.Instance | BindingFlags.Public).
                    Where(p => p.CanRead && p.GetSetMethod() != null))
                {
                    if (!prop.GetSetMethod().IsPublic)
                        continue;

                    rule.BaseRuleProperties.Add(prop.Name);
                }
            }

            // PrimaryProperty always shows in baseType.BaseType.GetProperties()

            #endregion

            #region Business Rule Properties

            rule.RuleProperties = new BusinessRulePropertyCollection();
            var collection = usedType.GetProperties(BindingFlags.Instance | BindingFlags.Public |
                                                    BindingFlags.DeclaredOnly).
                Where(p => p.CanRead && p.GetSetMethod() != null);
            foreach (var prop in collection)
            {
                /*if (prop.PropertyType.IsGenericParameter)
                {
                    var a = "IsGenericParameter";
                }
                if (prop.PropertyType.IsGenericTypeDefinition)
                {
                    var c = "IsGenericTypeDefinition";
                }
                if (prop.PropertyType.Name.IndexOf('`') > 0)
                {
                    var d = "IsGenericTypeDefinition";
                }*/

                if (!prop.GetSetMethod().IsPublic)
                    continue;

                if (!rule.BaseRuleProperties.Contains(prop.Name))
                {
                    var ruleInfo = new BusinessRuleProperty();
                    ruleInfo.Name = prop.Name;
                    ruleInfo.Type = prop.PropertyType.Name;
                    ruleInfo.IsGenericType = prop.PropertyType.IsGenericParameter;
                    ruleInfo.IsGenericParameter = prop.PropertyType.IsGenericType;

                    if (ruleInfo.IsGenericParameter)
                    {
                        ruleInfo.Type = prop.PropertyType.Name.Substring(0, prop.PropertyType.Name.LastIndexOf('`'));
                        foreach (var argument in prop.PropertyType.GetGenericArguments())
                        {
                            ruleInfo.Type += "<" + argument.Name + ">";
                        }
                    }

                    Type targetType = GetDataType(ruleInfo.Type);
                    if (targetType != null)
                    {
                        if (targetType.IsEnum)
                            ruleInfo.Value = ConvertStringToEnum(targetType, "");
                        else if (targetType == typeof(Int16))
                            ruleInfo.Value = (Int16) 0;
                        else if (targetType == typeof(Int32))
                            ruleInfo.Value = (Int32) 0;
                        else if (targetType == typeof(Int64))
                            ruleInfo.Value = (Int64) 0;
                    }
                    else
                    {
                        ruleInfo.Value = " ";
                        ruleInfo.Value = string.Empty;
                    }

                    rule.RuleProperties.Add(ruleInfo);
                }
            }

            #endregion

            #region Contructors

            rule.Constructors = new BusinessRuleConstructorCollection();
            var ctor = usedType.GetConstructors();
            var ctorCounter = 0;
            var isSetActive = false;
            foreach (var info in ctor)
            {
                var primaryPropertyFound = false;
                var ctorInfo = new BusinessRuleConstructor();
                var ctorParams = info.GetParameters();
                foreach (var param in ctorParams)
                {
                    var ctorParamInfo = new BusinessRuleConstructorParameter();
                    ctorParamInfo.Name = param.Name;
                    ctorParamInfo.Type = param.ParameterType.Name;
                    var attributeData = param.GetCustomAttributesData();
                    foreach (var attribute in attributeData)
                    {
                        if (attribute.ToString() == "[System.ParamArrayAttribute()]")
                            ctorParamInfo.IsParams = true;
                    }
                    ctorParamInfo.IsGenericType = param.ParameterType.IsGenericParameter;
                    ctorParamInfo.IsGenericParameter = param.ParameterType.IsGenericType;

                    if (ctorParamInfo.IsGenericParameter)
                    {
                        ctorParamInfo.Type = param.ParameterType.Name.Substring(0,
                            param.ParameterType.Name.LastIndexOf('`'));
                        foreach (var argument in param.ParameterType.GetGenericArguments())
                        {
                            ctorParamInfo.Type += "<" + argument.Name + ">";
                        }
                    }

                    if (ctorParamInfo.Type == "IPropertyInfo" && ctorParamInfo.Name == "primaryProperty")
                    {
                        ctorParamInfo.Value = rule.Parent;
                        primaryPropertyFound = true;
                    }
                    else
                    {
                        Type targetType = GetDataType(ctorParamInfo.Type);
                        if (targetType != null)
                        {
                            if (targetType.IsEnum)
                                ctorParamInfo.Value = ConvertStringToEnum(targetType, "");
                            else if (targetType == typeof(Int16))
                                ctorParamInfo.Value = (Int16) 0;
                            else if (targetType == typeof(Int32))
                                ctorParamInfo.Value = (Int32) 0;
                            else if (targetType == typeof(Int64))
                                ctorParamInfo.Value = (Int64) 0;
                        }
                        else
                        {
                            ctorParamInfo.Value = " ";
                            ctorParamInfo.Value = string.Empty;
                        }
                    }

                    ctorInfo.ConstructorParameters.Add(ctorParamInfo);
                }

                if (rule.IsPropertyRule && !primaryPropertyFound)
                    continue;

                if (!rule.IsPropertyRule && primaryPropertyFound)
                    continue;

                ctorCounter++;
                ctorInfo.Name = "Constructor #" + ctorCounter;

                if (!isSetActive)
                {
                    ctorInfo.IsActive = true;
                    ctorInfo.Name += " (Active)";
                    isSetActive = true;
                }

                rule.Constructors.Add(ctorInfo);
            }

            #endregion
        }

        private bool CTorMatchesRuleLevel(BusinessRule rule, Type candidate)
        {
            var hasObjectCTor = false;
            var hasPropertyCTor = false;
            foreach (var constructor in candidate.GetConstructors())
            {
                var primaryPropertyFound = false;
                foreach (var parameter in constructor.GetParameters())
                {
                    if (parameter.ParameterType.Name == "IPropertyInfo" && parameter.Name == "primaryProperty")
                        primaryPropertyFound = true;
                }
                if (primaryPropertyFound)
                    hasPropertyCTor = true;
                else
                    hasObjectCTor = true;
            }

            if (rule.IsPropertyRule && !hasPropertyCTor)
                return false;

            if (!rule.IsPropertyRule && !hasObjectCTor)
                return false;

            return true;
        }

        private dynamic ConvertStringToEnum(Type targetType, string value)
        {
            if (targetType.Name == "RuleSeverity" && string.IsNullOrWhiteSpace(value))
                value = "Error";

            dynamic val = targetType;
            if (Enum.IsDefined(targetType, value))
                val = Enum.Parse(targetType, value, true);
            else
            {
                Array enumValues = Enum.GetValues(targetType);
                foreach (var enumValue in enumValues)
                {
                    val = enumValue;
                    break;
                }
            }

            return val;
        }

        private static Type GetDataType(string type)
        {
            Type propType = Type.GetType(type);
            if (propType == null)
                propType = Type.GetType("System." + type);
            if (propType == null)
                propType = Type.GetType("CslaGenerator.Metadata." + type);

            return propType;
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