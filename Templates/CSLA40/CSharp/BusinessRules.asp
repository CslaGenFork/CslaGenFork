<%
bool generateRuleRegion = false;
foreach (ValueProperty valueProperty in Info.AllValueProperties)
{
    if (valueProperty.BusinessRules.Count > 0)
    {
        generateRuleRegion = true;
        break;
    }
}
if (!generateRuleRegion)
{
    foreach (ValueProperty valueProperty in Info.InheritedValueProperties)
    {
        if (valueProperty.BusinessRules.Count > 0)
        {
            generateRuleRegion = true;
            break;
        }
    }
}
if (!generateRuleRegion)
{
    foreach (ChildProperty childProperty in Info.GetAllChildProperties())
    {
        if (childProperty.BusinessRules.Count > 0)
        {
            generateRuleRegion = true;
            break;
        }
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

            ValuePropertyCollection allValueProperties = new ValuePropertyCollection();
            allValueProperties.AddRange(Info.AllValueProperties); // ValueProperties and ConvertValueProperties
            allValueProperties.AddRange(Info.InheritedValueProperties); // InheritedValueProperties
            foreach (ValueProperty valueProperty in allValueProperties)
            {
                if (valueProperty.BusinessRules.Count > 0)
                    Response.Write(new string(' ', 12) + "//" + valueProperty.Name + Environment.NewLine);

                foreach (BusinessRule rule in valueProperty.BusinessRules)
                {
                    string backupRuleType = rule.Type;
                    resultConstructor = string.Empty;
                    resultProperties = string.Empty;
                    primaryOnCtor = false;
                    bool isFirst = true;
                    bool isFirstGeneric = true;
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

                    PropertyInfo[] ruleProps = typeof(BusinessRule).GetProperties();
                    foreach (PropertyInfo property in ruleProps)
                    {
                        if (rule.BaseRules.Contains(property.Name))
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
                                if (stringValue == "")
                                    continue;
                                if (stringValue == "0")
                                    continue;
                                if (stringValue == "RunModes.Default")
                                    continue;
                                if (stringValue == "RuleSeverity.Error")
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

            ChildPropertyCollection allChildProperties = new ChildPropertyCollection();
            // ChildProperties, ChildCollectionProperties, InheritedChildProperties, InheritedChildCollectionProperties
            allChildProperties.AddRange(Info.GetAllChildProperties());
            foreach (ChildProperty childProperty in allChildProperties)
            {
                if (childProperty.BusinessRules.Count > 0)
                    Response.Write(new string(' ', 12) + "//" + childProperty.Name + Environment.NewLine);

                foreach (BusinessRule rule in childProperty.BusinessRules)
                {
                    string backupRuleType = rule.Type;
                    resultConstructor = string.Empty;
                    resultProperties = string.Empty;
                    primaryOnCtor = false;
                    bool isFirst = true;
                    bool isFirstGeneric = true;
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

                    PropertyInfo[] ruleProps = typeof(BusinessRule).GetProperties();
                    foreach (PropertyInfo property in ruleProps)
                    {
                        if (rule.BaseRules.Contains(property.Name))
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
                                if (stringValue == "")
                                    continue;
                                if (stringValue == "0")
                                    continue;
                                if (stringValue == "RunModes.Default")
                                    continue;
                                if (stringValue == "RuleSeverity.Error")
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
