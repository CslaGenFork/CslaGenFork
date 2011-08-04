using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public class BusinessRuleTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;
        private Type _instance;
        private List<Type> _types;
        private BusinessRule _rule;

        public BusinessRuleTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.SelectedValueChanged += ValueChanged;
            _lstProperties.Width = 300;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
            if (_editorService != null)
            {
                if (context.Instance != null)
                {
                    // CR modifying to accomodate PropertyBag
                    Type instanceType = null;
                    object objinfo = null;
                    TypeHelper.GetBusinessRuleTypeContextInstanceObject(context, ref objinfo, ref instanceType);
                    _rule = (BusinessRule) objinfo;
                    _instance = objinfo.GetType();

                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");

                    // Get Assembly File Path
                    var assemblyFileInfo = _instance.GetProperty("AssemblyFile");
                    //string assemblyFilePath = (string) assemblyFileInfo.GetValue(context.Instance, null);
                    var assemblyFilePath = (string) assemblyFileInfo.GetValue(objinfo, null);
                    Type baseBusinessRule = null;

                    // If Assembly path is available, use assembly to load a drop down with available types.
                    if (!string.IsNullOrEmpty(assemblyFilePath))
                    {
                        var assembly = Assembly.LoadFrom(assemblyFilePath);
                        var alltypes = assembly.GetExportedTypes();
                        if (alltypes.Length > 0)
                            _types = new List<Type>();

                        foreach (var type in alltypes)
                        {
                            // check here for Csla.Rules.BusinessRule inheritance
                            if (type.GetInterface("Csla.Rules.IBusinessRule") != null)
                            {
                                // exclude abstract classes
                                if (!type.IsAbstract)
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
                                else
                                {
                                    if (type.BaseType != null)
                                    {
                                        if (type.BaseType.Name == "BusinessRule")
                                            baseBusinessRule = type.BaseType;
                                    }
                                }
                            }
                        }

                        _lstProperties.Sorted = true;
                    }

                    if (_lstProperties.Items.Contains(_rule.Type))
                        _lstProperties.SelectedItem = _rule.Type;
                    else
                        _lstProperties.SelectedItem = "(None)";

                    _editorService.DropDownControl(_lstProperties);
                    FillSubsidiaryGrids(baseBusinessRule, _rule, _lstProperties.SelectedItem.ToString());

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

        private void FillSubsidiaryGrids(Type baseBusinessRule, BusinessRule rule, string stringType)
        {
            Type usedType = null;

            foreach (var type in _types)
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
                if (stringType == listableType)
                    usedType = type;
            }

            if (usedType == null)
                return;

            _rule.BaseRules = new List<string>();
            _rule.RuleProperties = new BusinessRulePropertyCollection();
            _rule.Constructors = new BusinessRuleConstructorCollection();

            foreach (var prop in baseBusinessRule.GetProperties(BindingFlags.Instance | BindingFlags.Public).
                Where(p => p.CanRead && p.CanWrite))
            {
                _rule.BaseRules.Add(prop.Name);
            }

            foreach (var prop in usedType.GetProperties(BindingFlags.Instance | BindingFlags.Public).
                Where(p => p.CanRead && p.CanWrite))
            {
                /*if(prop.PropertyType.IsGenericParameter)
                {
                    var a = "IsGenericParameter";
                }
                if(prop.PropertyType.IsGenericTypeDefinition)
                {
                    var c = "IsGenericTypeDefinition";
                }
                if (prop.PropertyType.Name.IndexOf('`') > 0)
                {
                    var d = "IsGenericTypeDefinition";
                }*/

                if (!_rule.BaseRules.Contains(prop.Name))
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
                        else if (targetType == typeof (Int16))
                            ruleInfo.Value = (Int16) 0;
                        else if (targetType == typeof (Int32))
                            ruleInfo.Value = (Int32) 0;
                        else if (targetType == typeof (Int64))
                            ruleInfo.Value = (Int64) 0;
                    }
                    else
                    {
                        ruleInfo.Value = " ";
                        ruleInfo.Value = string.Empty;
                    }

                    _rule.RuleProperties.Add(ruleInfo);
                }
            }

            var ctor = usedType.GetConstructors();
            var ctorCounter = 0;
            foreach (var info in ctor)
            {
                ctorCounter++;
                var ctorInfo = new BusinessRuleConstructor();
                ctorInfo.Name = "Constructor #" + ctorCounter;
                if (ctorCounter == 1)
                {
                    ctorInfo.IsActive = true;
                    ctorInfo.Name += "(Default)";
                }

                var ctorParams = info.GetParameters();
                foreach (var param in ctorParams)
                {
                    var ctorParamInfo = new BusinessRuleConstructorParameter();
                    ctorParamInfo.Name = param.Name;
                    ctorParamInfo.Type = param.ParameterType.Name;
                    ctorParamInfo.IsGenericType = param.ParameterType.IsGenericParameter;
                    ctorParamInfo.IsGenericParameter = param.ParameterType.IsGenericType;

                    if (ctorParamInfo.IsGenericParameter)
                    {
                        ctorParamInfo.Type = param.ParameterType.Name.Substring(0, param.ParameterType.Name.LastIndexOf('`'));
                        foreach (var argument in param.ParameterType.GetGenericArguments())
                        {
                            ctorParamInfo.Type += "<" + argument.Name + ">";
                        }
                    }

                    if (ctorParamInfo.Type == "IPropertyInfo")
                        ctorParamInfo.Value = rule.Parent;
                    else
                    {
                        Type targetType = GetDataType(ctorParamInfo.Type);
                        if (targetType != null)
                        {
                            if (targetType.IsEnum)
                                ctorParamInfo.Value = ConvertStringToEnum(targetType, "");
                            else if (targetType == typeof (Int16))
                                ctorParamInfo.Value = (Int16) 0;
                            else if (targetType == typeof (Int32))
                                ctorParamInfo.Value = (Int32) 0;
                            else if (targetType == typeof (Int64))
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

                _rule.Constructors.Add(ctorInfo);
            }
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
    }
}
