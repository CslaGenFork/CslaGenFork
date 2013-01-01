        #region Factory Methods
<%
if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
%>
<!-- #include file="NewObject.asp" -->
<%
if (Info.UseUnitOfWorkType == string.Empty)
{
    %>
<!-- #include file="NewObjectAsync.asp" -->
<%
}
%>
<!-- #include file="GetObject.asp" -->
<!-- #include file="InternalGetObject.asp" -->
<!-- #include file="DeleteObject.asp" -->
<%
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (c.CreateOptions.Factory)
            {
                %>

        /// <summary>
        /// Factory method. Creates a new <see cref="<%= Info.ObjectName %>"/> child object<%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        /// </summary>
<%
                string strNewParams = string.Empty;
                string strNewCritParams = string.Empty;
                CriteriaPropertyCollection newParams = c.Properties;
                for (int i = 0; i < newParams.Count; i++)
                {
                    if (i > 0)
                    {
                        strNewParams += ", ";
                        strNewCritParams += ", ";
                    }
                    strNewParams += string.Concat(GetDataTypeGeneric(newParams[i], newParams[i].PropertyType), " ", FormatCamel(newParams[i].Name));
                    strNewCritParams += FormatCamel(newParams[i].Name);
                }
%>
        /// <returns>A reference to the created <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> New<%= Info.ObjectName %><%= c.CreateOptions.FactorySuffix %>Child(<%= strNewParams %>)
        {
        <%
                if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
                    CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
                    Info.GetRoles.Trim() != String.Empty)
                {
                    %>
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to create a <%= Info.ObjectName %>.");

            <%
                }
                if (Info.ObjectType == CslaObjectType.EditableSwitchable)
                {
                    if (strNewCritParams.Length > 0)
                    {
                        strNewCritParams = "true, " + strNewCritParams;
                    }
                    else
                    {
                        strNewCritParams = "true";
                    }
                }
            %>
            <%= Info.ObjectName %> obj = DataPortal.CreateChild<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strNewCritParams %>));
            obj.MarkAsChild();
            return obj;
        }
<%
            }

            if (c.GetOptions.Factory)
            {
                %>

        /// <summary>
        /// Factory method. Loads a <see cref="<%= Info.ObjectName %>" /> child object <%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        /// </summary>
        <%
                string strGetParams = string.Empty;
                string strGetCritParams = string.Empty;
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    if (i > 0)
                    {
                        strGetParams += ", ";
                        strGetCritParams += ", ";
                    }
                    strGetParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                    strGetCritParams += FormatCamel(c.Properties[i].Name);
                }
        %>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>Child(<%= strGetParams %>)
        {
            <%
            if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
                CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
                Info.GetRoles.Trim() != String.Empty)
            {
                %>
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.");

            <%
            }
            if (strGetCritParams.Trim().Length > 0)
                strGetCritParams = "true, " + strGetCritParams;
            else
                strGetCritParams = "true";
            %>
            return DataPortal.Fetch<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strGetCritParams %>));
        }
    <%
            }
        }
        %>
<!-- #include file="Save.asp" -->

        #endregion
