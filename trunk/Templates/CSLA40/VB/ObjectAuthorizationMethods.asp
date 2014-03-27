<%
bool generateAuthRegion2 = false;
CslaObjectInfo authzInfo2 = Info;
string resultRuleObj = string.Empty;
isObjectAutz = true;

if (IsCollectionType(Info.ObjectType))
{
    authzInfo2 = FindChildInfo(Info, Info.ItemType);
    if (authzInfo2 == null)
    {
        Errors.Append("Collection " + Info.ObjectName + " missing Item Type." + Environment.NewLine);
        return;
    }
}
if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
    CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel)
{
    if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
        authzInfo2.AuthzProvider != AuthorizationProvider.Custom)
    {
        if (!String.IsNullOrWhiteSpace(authzInfo2.NewRoles) ||
            !String.IsNullOrWhiteSpace(authzInfo2.GetRoles) ||
            !String.IsNullOrWhiteSpace(authzInfo2.UpdateRoles) ||
            !String.IsNullOrWhiteSpace(authzInfo2.DeleteRoles))
        {
            generateAuthRegion2 = true;
        }
    }
    else if (authzInfo2.NewAuthzRuleType.Constructors.Count > 0 ||
             authzInfo2.GetAuthzRuleType.Constructors.Count > 0 ||
             authzInfo2.UpdateAuthzRuleType.Constructors.Count > 0 ||
             authzInfo2.DeleteAuthzRuleType.Constructors.Count > 0)
    {
        generateAuthRegion2 = true;
    }
}
if (generateAuthRegion2)
{
    AuthorizationRule authzRule;
    string resultRule = string.Empty;
    string resultConstructor = string.Empty;
    string resultProperties = string.Empty;

    if (IsReadOnlyType(authzInfo2.ObjectType) && CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider)
    {
        authzInfo2.NewRoles = String.Empty;
        authzInfo2.UpdateRoles = String.Empty;
        authzInfo2.DeleteRoles = String.Empty;
    }
    if (!genOptional)
    {
        Response.Write(Environment.NewLine);
    }
    genOptional = true;
    %>
        #Region " Object Authorization "
        <%
    string statement = string.Empty;
    if (UseNoSilverlight())
    {
        statement = "Protected Shared Sub AddObjectAuthorizationRules()";
    }
    string statementSilverlight = string.Empty;
    if (UseSilverlight())
    {
        statementSilverlight = "<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>" + "\r\n" + new string(' ', 8);
        statementSilverlight += "Public Shared Sub AddObjectAuthorizationRules()";
    }
    %>

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        <%
    if (UseBoth())
    {
        %>
#If SILVERLIGHT Then
        <%= statementSilverlight %>
#Else
        <%= statement %>
#End If
        <%
    }
    else if (UseSilverlight())
    {
        %>
        <%= statementSilverlight %>
        <%
    }
    else
    {
        %>
        <%= statement %>
        <%
    }
    %>
            <%
    if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
        authzInfo2.AuthzProvider != AuthorizationProvider.Custom)
    {
        if (!String.IsNullOrWhiteSpace(authzInfo2.NewRoles))
        {
            if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
                authzInfo2.AuthzProvider == AuthorizationProvider.IsInRole)
            {
                resultRuleObj = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsInRole(AuthorizationActions.CreateObject" + ReturnRoleList(authzInfo2.NewRoles) +"))";
            %>
            <%= resultRuleObj %>
<%
            }
            else
            {
                resultRuleObj = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsNotInRole(AuthorizationActions.CreateObject" + ReturnRoleList(authzInfo2.NewRoles) + "))";
            %>
            <%= resultRuleObj %>
<%
            }
        }
        if (!String.IsNullOrWhiteSpace(authzInfo2.GetRoles))
        {
            if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
                authzInfo2.AuthzProvider == AuthorizationProvider.IsInRole)
            {
                resultRuleObj = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsInRole(AuthorizationActions.GetObject" + ReturnRoleList(authzInfo2.GetRoles) +"))";
            %>
            <%= resultRuleObj %>
<%
            }
            else
            {
                resultRuleObj = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsNotInRole(AuthorizationActions.GetObject" + ReturnRoleList(authzInfo2.GetRoles) + "))";
            %>
            <%= resultRuleObj %>
<%
            }
        }
        if (!String.IsNullOrWhiteSpace(authzInfo2.UpdateRoles))
        {
            if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
                authzInfo2.AuthzProvider == AuthorizationProvider.IsInRole)
            {
                resultRuleObj = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsInRole(AuthorizationActions.EditObject" + ReturnRoleList(authzInfo2.UpdateRoles) +"))";
            %>
            <%= resultRuleObj %>
<%
            }
            else
            {
                resultRuleObj = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsNotInRole(AuthorizationActions.EditObject" + ReturnRoleList(authzInfo2.UpdateRoles) + "))";
            %>
            <%= resultRuleObj %>
<%
            }
        }
        if (!String.IsNullOrWhiteSpace(authzInfo2.DeleteRoles))
        {
            if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
                authzInfo2.AuthzProvider == AuthorizationProvider.IsInRole)
            {
                resultRuleObj = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsInRole(AuthorizationActions.DeleteObject" + ReturnRoleList(authzInfo2.DeleteRoles) +"))";
            %>
            <%= resultRuleObj %>
<%
            }
            else
            {
                resultRuleObj = "BusinessRules.AddRule(GetType(" + Info.ObjectName + "), New IsNotInRole(AuthorizationActions.DeleteObject" + ReturnRoleList(authzInfo2.DeleteRoles) + "))";
            %>
            <%= resultRuleObj %>
<%
            }
        }
    }
    else if (!CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider &&
        authzInfo2.AuthzProvider == AuthorizationProvider.Custom)
    {
        if (authzInfo2.NewAuthzRuleType.Constructors.Count > 0 ||
            authzInfo2.GetAuthzRuleType.Constructors.Count > 0||
            authzInfo2.UpdateAuthzRuleType.Constructors.Count > 0||
            authzInfo2.DeleteAuthzRuleType.Constructors.Count > 0)
        {
            if (!string.IsNullOrWhiteSpace(authzInfo2.NewAuthzRuleType.Type))
            {
                authzRule = authzInfo2.NewAuthzRuleType;
%>
            <!-- #include file="AuthorizationRules.asp" -->
<%
                //BuildAuthzRule(Info, authzRule);
            }
            if (!string.IsNullOrWhiteSpace(authzInfo2.GetAuthzRuleType.Type))
            {
                authzRule = authzInfo2.GetAuthzRuleType;
%>
            <!-- #include file="AuthorizationRules.asp" -->
<%
            }
            if (!string.IsNullOrWhiteSpace(authzInfo2.UpdateAuthzRuleType.Type))
            {
                authzRule = authzInfo2.UpdateAuthzRuleType;
%>
            <!-- #include file="AuthorizationRules.asp" -->
<%
            }
            if (!string.IsNullOrWhiteSpace(authzInfo2.DeleteAuthzRuleType.Type))
            {
                authzRule = authzInfo2.DeleteAuthzRuleType;
%>
            <!-- #include file="AuthorizationRules.asp" -->
<%
            }
        }
    }
    %>

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        <%
    if (authzInfo2.ObjectType != CslaObjectType.ReadOnlyCollection &&
        authzInfo2.ObjectType != CslaObjectType.ReadOnlyObject &&
        authzInfo2.ObjectType != CslaObjectType.NameValueList)
    {
        %>
        ''' <summary>
        ''' Checks if the current user can create a new <%= Info.ObjectName %> object.
        ''' </summary>
        ''' <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanAddObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, GetType(<%= Info.ObjectName %>))
        End Function

        <%
    }
        %>
        ''' <summary>
        ''' Checks if the current user can retrieve <%= Info.ObjectName %>'s properties.
        ''' </summary>
        ''' <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(<%= Info.ObjectName %>))
        End Function
        <%
    if (authzInfo2.ObjectType != CslaObjectType.ReadOnlyCollection &&
        authzInfo2.ObjectType != CslaObjectType.ReadOnlyObject &&
        authzInfo2.ObjectType != CslaObjectType.NameValueList)
    {
        %>

        ''' <summary>
        ''' Checks if the current user can change <%= Info.ObjectName %>'s properties.
        ''' </summary>
        ''' <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanEditObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, GetType(<%= Info.ObjectName %>))
        End Function

        ''' <summary>
        ''' Checks if the current user can delete a <%= Info.ObjectName %> object.
        ''' </summary>
        ''' <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanDeleteObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, GetType(<%= Info.ObjectName %>))
        End Function
        <%
    }
    %>

        #End Region

<%
}
%>
