<%
string backupRuleType = authzRule.Type;
foreach (string ns in Info.Namespaces)
{
    string nameSpace = ns + '.';
    if (backupRuleType.IndexOf(nameSpace) == 0 &&
        backupRuleType.Substring(nameSpace.Length).IndexOf('.') == -1)
    {
        backupRuleType = backupRuleType.Substring(nameSpace.Length);
        break;
    }
}
resultConstructor = string.Empty;
resultProperties = string.Empty;
bool isFirst = true;
bool isFirstGeneric = true;
bool actionOnCtor = false;
bool elementOnCtor = false;

// Constructors and ConstructorParameters
foreach (BusinessRuleConstructor constructor in authzRule.Constructors)
{
    if (constructor.IsActive)
    {
        foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters)
        {
            if (parameter.Type == "IMemberInfo")
            {
                if (isFirst)
                    isFirst = false;
                else
                    resultConstructor += ", ";
                resultConstructor += FormatPropertyInfoName(ReturnRawParameterValue(parameter));
                elementOnCtor = true;
            }
            else if (parameter.Type == "AuthorizationActions")
            {
                if (isFirst)
                    isFirst = false;
                else
                    resultConstructor += ", ";
                resultConstructor += "AuthorizationActions." + ReturnRawParameterValue(parameter);
                actionOnCtor = true;
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

                string stringValue = ReturnParameterValue(parameter);
                if (stringValue == string.Empty)
                    continue;
                if (isFirst)
                    isFirst = false;
                else
                    resultConstructor += ", ";

                resultConstructor += stringValue;
            }
        }
    }
}

// RuleProperties
isFirst = true;
foreach (BusinessRuleProperty property in authzRule.RuleProperties)
{
    if (property.Type == "IMemberInfo")
    {
        if (elementOnCtor)
            continue;
        if (isFirst)
            isFirst = false;
        else
            resultProperties += ", ";
        resultProperties += property.Name + " = " + FormatPropertyInfoName(ReturnRawPropertyValue(property));
    }
    else if (property.Type == "AuthorizationActions")
    {
        if (actionOnCtor)
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
if (authzRule.BaseRuleProperties.Count > 0)
{
    PropertyInfo[] ruleProps = typeof (AuthorizationRule).GetProperties();
    foreach (PropertyInfo property in ruleProps)
    {
        if (authzRule.BaseRuleProperties.Contains(property.Name))
        {
            if (property.Name == "Element")
            {
                if (elementOnCtor)
                    continue;
                if (isFirst)
                    isFirst = false;
                else
                    resultProperties += ", ";
                resultProperties += property.Name + " = " + FormatPropertyInfoName(ReturnRawPropertyValue(authzRule, property));
            }
            else if (property.Name == "Action")
            {
                if (actionOnCtor)
                    continue;
                if (isFirst)
                    isFirst = false;
                else
                    resultProperties += ", ";
                resultProperties += property.Name + " = " + FormatPropertyInfoName(ReturnRawPropertyValue(authzRule, property));
            }
            else
            {
                string stringValue = ReturnPropertyValue(authzRule, property);
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
}

if (resultProperties != string.Empty)
    resultProperties = " { " + resultProperties + " }";

resultRule = "BusinessRules.AddRule(typeof (" + Info.ObjectName + "), new " + backupRuleType + "(" + resultConstructor + ")" + resultProperties + ")" + ";";
            %>
            <%= resultRule %>
            <%
%>
