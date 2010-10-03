<%
if ((CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
    CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel) &&
    ((Info.NewRoles.Trim() != String.Empty) ||
    (Info.GetRoles.Trim() != String.Empty) ||
    (Info.UpdateRoles.Trim() != String.Empty) ||
    (Info.DeleteRoles.Trim() != String.Empty) ||
    (Info.DenyNewRoles.Trim() != String.Empty) ||
    (Info.DenyGetRoles.Trim() != String.Empty) ||
    (Info.DenyUpdateRoles.Trim() != String.Empty) ||
    (Info.DenyDeleteRoles.Trim() != String.Empty)))
{
    %>

        #region Authorization
        <%
    if (CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.Custom)
    {
        %>

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            <%
        if (Info.NewRoles.Trim() != String.Empty)
        {
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new IsInRole(AuthorizationActions.CreateObject<%
            String[] newRoles = System.Text.RegularExpressions.Regex.Split(Info.NewRoles, ";");
            foreach(String role in newRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        if (Info.GetRoles.Trim() != String.Empty)
        {
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new IsInRole(AuthorizationActions.GetObject<%
            String[] getRoles = System.Text.RegularExpressions.Regex.Split(Info.GetRoles, ";");
            foreach(String role in getRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        if (Info.UpdateRoles.Trim() != String.Empty)
        {
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new IsInRole(AuthorizationActions.EditObject<%
            String[] updateRoles = System.Text.RegularExpressions.Regex.Split(Info.UpdateRoles, ";");
            foreach(String role in updateRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        if (Info.DeleteRoles.Trim() != String.Empty)
        {
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new IsInRole(AuthorizationActions.DeleteObject<%
            String[] deleteRoles = System.Text.RegularExpressions.Regex.Split(Info.DeleteRoles, ";");
            foreach(String role in deleteRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        if (Info.DenyNewRoles.Trim() != String.Empty)
        {
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new IsNotInRole(AuthorizationActions.CreateObject<%
            String[] denyNewRoles = System.Text.RegularExpressions.Regex.Split(Info.DenyNewRoles, ";");
            foreach(String role in denyNewRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        if (Info.DenyGetRoles.Trim() != String.Empty)
        {
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new IsNotInRole(AuthorizationActions.GetObject<%
            String[] denyGetRoles = System.Text.RegularExpressions.Regex.Split(Info.DenyGetRoles, ";");
            foreach(String role in denyGetRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        if (Info.DenyUpdateRoles.Trim() != String.Empty)
        {
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new IsNotInRole(AuthorizationActions.EditObject<%
            String[] denyUpdateRoles = System.Text.RegularExpressions.Regex.Split(Info.DenyUpdateRoles, ";");
            foreach(String role in denyUpdateRoles)
            {
                %>, "<%= role.Trim() %>"<%
            }
            %>));
            <%
        }
        if (Info.DenyDeleteRoles.Trim() != String.Empty)
        {
            %>
            BusinessRules.AddRule(typeof(<%= Info.ObjectName %>), new IsNotInRole(AuthorizationActions.DeleteObject<%
            String[] denyDeleteRoles = System.Text.RegularExpressions.Regex.Split(Info.DenyDeleteRoles, ";");
            foreach(String role in denyDeleteRoles)
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
    if (Info.ObjectType != CslaObjectType.ReadOnlyCollection &&
        Info.ObjectType != CslaObjectType.ReadOnlyObject &&
        Info.ObjectType != CslaObjectType.NameValueList)
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
    if (Info.ObjectType != CslaObjectType.ReadOnlyCollection &&
        Info.ObjectType != CslaObjectType.ReadOnlyObject &&
        Info.ObjectType != CslaObjectType.NameValueList)
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
