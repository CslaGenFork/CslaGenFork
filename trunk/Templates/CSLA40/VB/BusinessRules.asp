<%
bool generateRuleRegion = false;
bool generateAuthRegion = false;
bool generateObjectRuleRegion = false;
isObjectAutz = false;

HaveBusinessRulesCollection allRulesProperties = Info.AllRulableProperties();

foreach (IHaveBusinessRules rulableProperty in allRulesProperties)
{
    if (Info.IsNotUnitOfWork() &&
        Info.IsNotNameValueList() &&
        !TypeHelper.IsCollectionType(Info.ObjectType) &&
        rulableProperty.BusinessRules.Count > 0)
    {
        generateRuleRegion = true;
    }
    if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
        CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.ObjectLevel)
    {
        if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
            rulableProperty.AuthzProvider != AuthorizationProvider.Custom)
        {
            if (!String.IsNullOrWhiteSpace(rulableProperty.ReadRoles) ||
                !String.IsNullOrWhiteSpace(rulableProperty.WriteRoles))
            {
                generateAuthRegion = true;
            }
        }
        else if (rulableProperty.ReadAuthzRuleType.Constructors.Count > 0 ||
                 rulableProperty.WriteAuthzRuleType.Constructors.Count > 0)
        {
            generateAuthRegion = true;
        }
    }
    if (generateRuleRegion && generateAuthRegion)
        break;
}
if (Info.IsNotUnitOfWork() &&
    Info.IsNotNameValueList() &&
    !TypeHelper.IsCollectionType(Info.ObjectType))
{
    if (Info.BusinessRules.Count > 0)
        generateObjectRuleRegion = true;
}

if (generateRuleRegion || generateAuthRegion || generateObjectRuleRegion)
{
    if (!genOptional)
    {
        Response.Write(Environment.NewLine);
    }
    genOptional = true;
    %>
        #Region " Business Rules and Property Authorization "

        ''' <summary>
        ''' Override this method in your business class to be notified when you need to set up shared business rules.
        ''' </summary>
        ''' <remarks>
        ''' This method is automatically called by CSLA.NET when your object should associate
        ''' per-type validation rules with its properties.
        ''' </remarks>
        Protected Overrides Sub AddBusinessRules()
            MyBase.AddBusinessRules()
            <%
    string resultRule = string.Empty;
    string resultConstructor = string.Empty;
    string resultProperties = string.Empty;

    // Object Business Rules
    if (generateObjectRuleRegion)
    {
        Response.WriteLine(Environment.NewLine + new string(' ', 12) + "// Object Business Rules");
        bool primaryOnCtor = false;

        foreach (BusinessRule rule in Info.BusinessRules)
        {
            string backupRuleType = rule.Type;
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

            // RuleProperties
            isFirst = true;
            foreach (BusinessRuleProperty property in rule.RuleProperties)
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

            // BaseRuleProperties
            if (rule.BaseRuleProperties.Count > 0)
            {
                PropertyInfo[] ruleProps = typeof (BusinessRule).GetProperties();
                foreach (PropertyInfo property in ruleProps)
                {
                    if (rule.BaseRuleProperties.Contains(property.Name))
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

            resultRule = "BusinessRules.AddRule(New " + backupRuleType + "(" + resultConstructor + ")" + resultProperties + ")";
            %>
            <%= resultRule %>
<%
        }
    }

    // Property Business Rules
    if (generateRuleRegion)
    {
        Response.WriteLine(Environment.NewLine + new string(' ', 12) + "// Property Business Rules" + Environment.NewLine);
        bool primaryOnCtor = false;
        foreach (IHaveBusinessRules rulableProperty in allRulesProperties)
        {
            resultRule = string.Empty;
            if (rulableProperty.BusinessRules.Count > 0)
                Response.WriteLine(new string(' ', 12) + "// " + rulableProperty.Name);

            foreach (BusinessRule rule in rulableProperty.BusinessRules)
            {
                string backupRuleType = rule.Type;
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
                            if (parameter.Type == "IPropertyInfo")
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
                    if (property.Type == "IPropertyInfo")
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
                if (rule.BaseRuleProperties.Count > 0)
                {
                    PropertyInfo[] ruleProps = typeof (BusinessRule).GetProperties();
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
                }

                if (resultProperties != string.Empty)
                    resultProperties = " { " + resultProperties + " }";

                resultRule = "BusinessRules.AddRule(New " + backupRuleType + "(" + resultConstructor + ")" + resultProperties + ")";
            %>
            <%= resultRule %>
<%
            }
        }
    }

    // Property Authorization Rules
    if (generateAuthRegion)
    {
        Response.WriteLine(Environment.NewLine + new string(' ', 12) + "// Authorization Rules" + Environment.NewLine);
        AuthorizationRule authzRule;
        foreach (IHaveBusinessRules rulableProperty in allRulesProperties)
        {
            if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
                rulableProperty.AuthzProvider != AuthorizationProvider.Custom)
            {
                if (!String.IsNullOrWhiteSpace(rulableProperty.ReadRoles) ||
                    !String.IsNullOrWhiteSpace(rulableProperty.WriteRoles))
                {
                    Response.WriteLine(new string(' ', 12) + "// " + rulableProperty.Name);
                }
                if (!String.IsNullOrWhiteSpace(rulableProperty.ReadRoles))
                {
                    if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
                        rulableProperty.AuthzProvider == AuthorizationProvider.IsInRole)
                    {
                        resultRule = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsInRole(AuthorizationActions.ReadProperty, " + rulableProperty.Name + "Property" + ReturnRoleList(rulableProperty.ReadRoles) +"))";
            %>
            <%= resultRule %>
<%
                    }
                    else
                    {
                        resultRule = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsNotInRole(AuthorizationActions.ReadProperty, " + rulableProperty.Name + "Property" + ReturnRoleList(rulableProperty.ReadRoles) + "))";
            %>
            <%= resultRule %>
<%
                    }
                }
                if (!String.IsNullOrWhiteSpace(rulableProperty.WriteRoles))
                {
                    if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
                        rulableProperty.AuthzProvider == AuthorizationProvider.IsInRole)
                    {
                        resultRule = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsInRole(AuthorizationActions.WriteProperty, " + rulableProperty.Name + "Property" + ReturnRoleList(rulableProperty.WriteRoles) +"))";
            %>
            <%= resultRule %>
<%
                    }
                    else
                    {
                        resultRule = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsNotInRole(AuthorizationActions.WriteProperty, " + rulableProperty.Name + "Property" + ReturnRoleList(rulableProperty.WriteRoles) + "))";
            %>
            <%= resultRule %>
<%
                    }
                }
            }
            else if (!CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider &&
                rulableProperty.AuthzProvider == AuthorizationProvider.Custom)
            {
                if (rulableProperty.ReadAuthzRuleType.Constructors.Count > 0 ||
                    rulableProperty.WriteAuthzRuleType.Constructors.Count > 0)
                {
                    Response.WriteLine(new string(' ', 12) + "// " + rulableProperty.Name);
                    if (!string.IsNullOrWhiteSpace(rulableProperty.ReadAuthzRuleType.Type))
                    {
                        authzRule = rulableProperty.ReadAuthzRuleType;
%>
            <!-- #include file="AuthorizationRules.asp" -->
<%
                        //BuildAuthzRule(Info, authzRule);
                    }
                    if (!string.IsNullOrWhiteSpace(rulableProperty.WriteAuthzRuleType.Type))
                    {
                        authzRule = rulableProperty.WriteAuthzRuleType;
%>
            <!-- #include file="AuthorizationRules.asp" -->
<%
                    }
                }
            }
        }
    }
    %>

            AddBusinessRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom shared business rules.
        ''' </summary>
        Partial Private Sub AddBusinessRulesExtend()
        End Sub

        #End Region

<%
}
%>
