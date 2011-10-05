<%
bool validateRuleRegion = false;
bool validateAuthRegion = false;

// Is Property validation needed?
HaveBusinessRulesCollection validateAllRulesProperties = Info.AllRulableProperties();
foreach (IHaveBusinessRules rulableProperty in validateAllRulesProperties)
{
    if (Info.ObjectType != CslaObjectType.UnitOfWork &&
        Info.ObjectType != CslaObjectType.NameValueList &&
        !IsCollectionType(Info.ObjectType) &&
        rulableProperty.BusinessRules.Count > 0)
    {
        validateRuleRegion = true;
    }
    if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
        CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.ObjectLevel)
    {
        if (rulableProperty.AuthzProvider == AuthorizationProvider.Custom)
        {
            if (rulableProperty.ReadAuthzRuleType.Constructors.Count > 0 ||
                rulableProperty.WriteAuthzRuleType.Constructors.Count > 0)
            {
                validateAuthRegion = true;
            }
        }
    }
    if (validateRuleRegion || validateAuthRegion)
        break;
}

// Validate Property Business Rules
if (validateRuleRegion)
{
    foreach (IHaveBusinessRules rulableProperty in validateAllRulesProperties)
    {
        foreach (BusinessRule rule in rulableProperty.BusinessRules)
        {
            foreach (BusinessRuleConstructor constructor in rule.Constructors)
            {
                if (constructor.IsActive)
                {
                    foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters)
                    {
                        if (parameter.IsGenericType && parameter.GenericType == TypeCodeEx.Empty)
                        {
                            Errors.Append(rulableProperty.Name + ": business rule " + rule.Name + ": generic parameter <" + parameter.Type + "> is Empty (undefined)." + Environment.NewLine);
                        }
                        if (string.IsNullOrEmpty(ReturnRawParameterValue(parameter)))
                        {
                            Errors.Append(rulableProperty.Name + ": business rule " + rule.Name + ": parameter " + parameter.Name + " has no value." + Environment.NewLine);
                        }
                    }
                }
            }
        }
    }
}

// Validate Property Authorization Rules
if (validateAuthRegion)
{
    foreach (IHaveBusinessRules rulableProperty in validateAllRulesProperties)
    {
        AuthorizationRuleCollection allAuthzRules = new AuthorizationRuleCollection();
        allAuthzRules.Add(rulableProperty.ReadAuthzRuleType);
        allAuthzRules.Add(rulableProperty.WriteAuthzRuleType);
        foreach (AuthorizationRule rule in allAuthzRules)
        {
            foreach (BusinessRuleConstructor constructor in rule.Constructors)
            {
                if (constructor.IsActive)
                {
                    foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters)
                    {
                        if (parameter.IsGenericType && parameter.GenericType == TypeCodeEx.Empty)
                        {
                            Errors.Append(rulableProperty.Name + ": authorization rule " + rule.Name + ": generic parameter <" + parameter.Type + "> is Empty (undefined)." + Environment.NewLine);
                        }
                        if (string.IsNullOrEmpty(ReturnRawParameterValue(parameter)))
                        {
                            Errors.Append(rulableProperty.Name + ": authorization rule " + rule.Name + ": parameter " + parameter.Name + " has no value." + Environment.NewLine);
                        }
                    }
                }
            }
        }
    }
}

// Validate Object Business Rules
if (Info.ObjectType != CslaObjectType.UnitOfWork &&
    Info.ObjectType != CslaObjectType.NameValueList &&
    !IsCollectionType(Info.ObjectType))
{
    foreach (var rule in Info.BusinessRules)
    {
        foreach (BusinessRuleConstructor constructor in rule.Constructors)
        {
            if (constructor.IsActive)
            {
                foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters)
                {
                    if (parameter.IsGenericType && parameter.GenericType == TypeCodeEx.Empty)
                    {
                        Errors.Append(Info.ObjectName + ": business rule " + rule.Name + ": generic parameter <" + parameter.Type + "> is Empty (undefined)." + Environment.NewLine);
                    }
                    if (string.IsNullOrEmpty(ReturnRawParameterValue(parameter)))
                    {
                        Errors.Append(Info.ObjectName + ": business rule " + rule.Name + ": parameter " + parameter.Name + " has no value." + Environment.NewLine);
                    }
                }
            }
        }
    }
}

// Validate Object Authorization Rules
if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
    CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel)
{
    if (Info.AuthzProvider == AuthorizationProvider.Custom)
    {
        AuthorizationRuleCollection objectAuthzRules = new AuthorizationRuleCollection();
        objectAuthzRules.Add(Info.NewAuthzRuleType);
        objectAuthzRules.Add(Info.GetAuthzRuleType);
        objectAuthzRules.Add(Info.UpdateAuthzRuleType);
        objectAuthzRules.Add(Info.DeleteAuthzRuleType);
        foreach (AuthorizationRule rule in objectAuthzRules)
        {
            foreach (BusinessRuleConstructor constructor in rule.Constructors)
            {
                if (constructor.IsActive)
                {
                    foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters
                        )
                    {
                        if (parameter.IsGenericType && parameter.GenericType == TypeCodeEx.Empty)
                        {
                            Errors.Append(Info.ObjectName + ": authorization rule " + rule.Name + ": generic parameter <" + parameter.Type + "> is Empty (undefined)." + Environment.NewLine);
                        }
                        if (string.IsNullOrEmpty(ReturnRawParameterValue(parameter)))
                        {
                            Errors.Append(Info.ObjectName + ": authorization rule " + rule.Name + ": parameter " + parameter.Name + " has no value." + Environment.NewLine);
                        }
                    }
                }
            }
        }
    }
}
%>