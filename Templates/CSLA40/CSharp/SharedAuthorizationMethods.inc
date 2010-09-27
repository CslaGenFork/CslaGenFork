
        #region Authorization

        <%
if ((Info.GetRoles.Trim() != String.Empty) ||
    (Info.DeleteRoles.Trim() != String.Empty) ||
    (Info.NewRoles.Trim() != String.Empty) ||
    (Info.UpdateRoles.Trim() != String.Empty))
{
    %>
        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            <%
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
    %>
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
        /// Checks if the current user can delete a <%= Info.ObjectName %> object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return Csla.Rules.BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(<%= Info.ObjectName %>));
        }

        /// <summary>
        /// Checks if the current user can create a new <%= Info.ObjectName %> object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return Csla.Rules.BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(<%= Info.ObjectName %>));
        }

        /// <summary>
        /// Checks if the current user can change <%= Info.ObjectName %>'s properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return Csla.Rules.BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(<%= Info.ObjectName %>));
        }
        <%
}
%>

        #endregion
