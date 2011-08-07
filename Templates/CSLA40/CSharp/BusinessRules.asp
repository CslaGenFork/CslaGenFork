<%
bool generateRuleRegion = false;

HaveBusinessRulesCollection allRulesProperties = new HaveBusinessRulesCollection();
allRulesProperties.AddRange(Info.AllValueProperties); // ValueProperties and ConvertValueProperties
allRulesProperties.AddRange(Info.InheritedValueProperties); // InheritedValueProperties
// ChildProperties, ChildCollectionProperties, InheritedChildProperties, InheritedChildCollectionProperties
allRulesProperties.AddRange(Info.GetAllChildProperties());
            
foreach (IHaveBusinessRules rulableProperty in allRulesProperties)
{
    if (rulableProperty.BusinessRules.Count > 0)
    {
        generateRuleRegion = true;
        break;
    }
}

//TestRules (Info);
//if (false)
if (generateRuleRegion)
{
    if (!genOptional)
    {
        Response.Write(Environment.NewLine);
    }
    genOptional = true;
    %>
        #region Business Rules and Property Authorization

        /// <summary>
        /// Override this method in your business class to be notified when you need to set up shared business rules.
        /// </summary>
        /// <remarks>
        /// This method is automatically called by CSLA.NET when your object should associate
        /// per-type validation rules with its properties.
        /// </remarks>
        protected override void AddBusinessRules()
        {
            <%
            string resultRule = string.Empty;
            string resultConstructor = string.Empty;
            string resultProperties = string.Empty;
            bool primaryOnCtor = false;

            /*HaveBusinessRulesCollection allRulesProperties = new HaveBusinessRulesCollection();
            allRulesProperties.AddRange(Info.AllValueProperties); // ValueProperties and ConvertValueProperties
            allRulesProperties.AddRange(Info.InheritedValueProperties); // InheritedValueProperties
            // ChildProperties, ChildCollectionProperties, InheritedChildProperties, InheritedChildCollectionProperties
            allRulesProperties.AddRange(Info.GetAllChildProperties());*/

            foreach (IHaveBusinessRules rulableProperty in allRulesProperties)
            {
                if (rulableProperty.BusinessRules.Count > 0)
                    Response.Write(new string(' ', 12) + "//" + rulableProperty.Name + Environment.NewLine);

                foreach (BusinessRule rule in rulableProperty.BusinessRules)
                {
                    string backupRuleType = rule.Type;
                    resultConstructor = string.Empty;
                    resultProperties = string.Empty;
                    primaryOnCtor = false;
                    bool isFirst = true;
                    bool isFirstGeneric = true;

                    // Constructors and ConstructorParameters
                    foreach (BusinessRuleConstructor constructor in rule.Constructors)
                    {
                        if (constructor.IsActive)
                        {
                            foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters)
                            {
                                if (isFirst)
                                    isFirst = false;
                                else
                                    resultConstructor += ", ";
                                if (parameter.Name == "primaryProperty")
                                {
                                    resultConstructor += FormatPropertyInfoName(ReturnRawParameterValue(parameter));
                                    primaryOnCtor = true;
                                }
                                else
                                {
                                    if (parameter.IsGenericType)
                                    {
                                        backupRuleType = backupRuleType.Replace(parameter.Type, GetDataType(parameter.GenericType));
                                        if (isFirstGeneric)
                                            isFirstGeneric = false;
                                        else
                                            backupRuleType = backupRuleType.Replace(",", ", ");
                                    }
                                    resultConstructor += ReturnParameterValue(parameter);
                                }
                            }
                        }
                    }

                    // RuleProperties
                    isFirst = true;
                    foreach (BusinessRuleProperty property in rule.RuleProperties)
                    {
                        if (property.Name == "primaryProperty")
                        {
                            if (primaryOnCtor)
                                continue;
                            if (isFirst)
                                isFirst = false;
                            else
                                resultProperties += ", ";
                            resultProperties += property.Name + " = " + FormatPropertyInfoName(ReturnRawPropertyValue(property));
                        }
                        else
                        {
                            string stringValue = ReturnPropertyValue(property);
                            if (stringValue == string.Empty)
                                continue;

                            if (isFirst)
                                isFirst = false;
                            else
                                resultProperties += ", ";
                            resultProperties += property.Name + " = " + stringValue;
                        }
                    }

                    // BaseRuleProperties
                    PropertyInfo[] ruleProps = typeof(BusinessRule).GetProperties();
                    foreach (PropertyInfo property in ruleProps)
                    {
                        if (rule.BaseRuleProperties.Contains(property.Name))
                        {
                            if (property.Name == "PrimaryProperty")
                            {
                                if (primaryOnCtor)
                                    continue;
                                if (isFirst)
                                    isFirst = false;
                                else
                                    resultProperties += ", ";

                                resultProperties += property.Name + " = " + FormatPropertyInfoName(ReturnRawPropertyValue(rule, property));
                            }
                            else
                            {
                                string stringValue = ReturnPropertyValue(rule, property);
                                if (IsBaseRulePropertyDefault(property.Name, stringValue))
                                    continue;

                                if (isFirst)
                                    isFirst = false;
                                else
                                    resultProperties += ", ";
                                resultProperties += property.Name + " = " + stringValue;
                            }
                        }
                    }

                    if (resultProperties != string.Empty)
                        resultProperties = " { " + resultProperties + " }";

                    resultRule = "BusinessRules.AddRule(new " + backupRuleType + "(" + resultConstructor + ")" + resultProperties + ")" + ";";
                    %>
            <%= resultRule %>
            <%
                }
            }
            %>
        }

        #endregion

<%
}
%>
