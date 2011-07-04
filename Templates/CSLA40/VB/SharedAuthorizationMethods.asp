<%
CslaObjectInfo authzInfo2 = Info;
if (IsCollectionType(Info.ObjectType))
{
    authzInfo2 = FindChildInfo(Info, Info.ItemType);
    if (authzInfo2 == null)
    {
        Errors.Append("Collection " + Info.ObjectName + " missing Item Type." + Environment.NewLine);
        return;
    }
}
if (IsReadOnlyType(authzInfo2.ObjectType))
{
    authzInfo2.NewRoles = String.Empty;
    authzInfo2.UpdateRoles = String.Empty;
    authzInfo2.DeleteRoles = String.Empty;
}
if (CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
    CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel &&
    (authzInfo2.NewRoles.Trim() != String.Empty ||
    authzInfo2.GetRoles.Trim() != String.Empty ||
    authzInfo2.UpdateRoles.Trim() != String.Empty ||
    authzInfo2.DeleteRoles.Trim() != String.Empty))
{
    if (!genOptional)
    {
        Response.Write(Environment.NewLine);
    }
    genOptional = true;
    %>
        #region Authorization
        <%
    if (CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.Custom)
    {
        string statement = new string(' ', 8) + "protected static void AddObjectAuthorizationRules()";
        string statementSilverlight = string.Empty;
        if (UseSilverlight())
        {
            statementSilverlight = "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" + "\r\n" + new string(' ', 8);
            statementSilverlight += "public static void AddObjectAuthorizationRules()";
        }
        %>

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        <%
        if (UseSilverlight())
        {
            %>
<%= IfSilverlight (Conditional.Silverlight, 2, ref silverlightLevel, false, true) %><%= statementSilverlight %>
<%= IfSilverlight (Conditional.Else, 0, ref silverlightLevel, false, true) %><%= statement %>
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, false, false) %>
        <%
        }
        else
        {
            %>
<%= statement %>
        <%
        }
        %>
        {
            <%
        if (authzInfo2.NewRoles.Trim() != String.Empty)
        {
            string allowOrDeny = string.Empty;
            string infoNewRoles = authzInfo2.NewRoles;
            if (authzInfo2.NewRoles[0] == '!')
            {
                allowOrDeny = "Not";
                infoNewRoles = infoNewRoles.Substring(1);
            }
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new Is<%= allowOrDeny %>InRole(AuthorizationActions.CreateObject<%
            String[] newRoles = System.Text.RegularExpressions.Regex.Split(infoNewRoles, ";");
            foreach (String role in newRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        if (authzInfo2.GetRoles.Trim() != String.Empty)
        {
            string allowOrDeny = string.Empty;
            string infoGetRoles = authzInfo2.GetRoles;
            if (authzInfo2.GetRoles[0] == '!')
            {
                allowOrDeny = "Not";
                infoGetRoles = infoGetRoles.Substring(1);
            }
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new Is<%= allowOrDeny %>InRole(AuthorizationActions.GetObject<%
            String[] getRoles = System.Text.RegularExpressions.Regex.Split(infoGetRoles, ";");
            foreach (String role in getRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        if (authzInfo2.UpdateRoles.Trim() != String.Empty)
        {
            string allowOrDeny = string.Empty;
            string infoUpdateRoles = authzInfo2.UpdateRoles;
            if (authzInfo2.UpdateRoles[0] == '!')
            {
                allowOrDeny = "Not";
                infoUpdateRoles = infoUpdateRoles.Substring(1);
            }
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new Is<%= allowOrDeny %>InRole(AuthorizationActions.EditObject<%
            String[] updateRoles = System.Text.RegularExpressions.Regex.Split(infoUpdateRoles, ";");
            foreach (String role in updateRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        if (authzInfo2.DeleteRoles.Trim() != String.Empty)
        {
            string allowOrDeny = string.Empty;
            string infoDeleteRoles = authzInfo2.DeleteRoles;
            if (authzInfo2.DeleteRoles[0] == '!')
            {
                allowOrDeny = "Not";
                infoDeleteRoles = infoDeleteRoles.Substring(1);
            }
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new Is<%= allowOrDeny %>InRole(AuthorizationActions.DeleteObject<%
            String[] deleteRoles = System.Text.RegularExpressions.Regex.Split(infoDeleteRoles, ";");
            foreach (String role in deleteRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        %>
        }

        <%
    }
    if (authzInfo2.ObjectType != CslaObjectType.ReadOnlyCollection &&
        authzInfo2.ObjectType != CslaObjectType.ReadOnlyObject &&
        authzInfo2.ObjectType != CslaObjectType.NameValueList)
    {
        %>
        /// <summary>
        /// Checks if the current user can create a new <%= Info.ObjectName %> object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return Csla.Rules.BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(<%= Info.ObjectName %>));
        }

        <%
    }
        %>
        /// <summary>
        /// Checks if the current user can retrieve <%= Info.ObjectName %>'s properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return Csla.Rules.BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(<%= Info.ObjectName %>));
        }
        <%
    if (authzInfo2.ObjectType != CslaObjectType.ReadOnlyCollection &&
        authzInfo2.ObjectType != CslaObjectType.ReadOnlyObject &&
        authzInfo2.ObjectType != CslaObjectType.NameValueList)
    {
        %>

        /// <summary>
        /// Checks if the current user can change <%= Info.ObjectName %>'s properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return Csla.Rules.BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(<%= Info.ObjectName %>));
        }

        /// <summary>
        /// Checks if the current user can delete a <%= Info.ObjectName %> object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return Csla.Rules.BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(<%= Info.ObjectName %>));
        }
        <%
    }
    %>

        #endregion

<%
}
%>
