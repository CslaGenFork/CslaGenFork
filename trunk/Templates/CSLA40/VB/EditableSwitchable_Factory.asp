        #Region " Factory Methods "
<%
if (UseBoth())
{
    %>

#If Not SILVERLIGHT Then
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
<!-- #include file="InternalGetObject.asp" -->
<!-- #include file="GetObject.asp" -->
<!-- #include file="DeleteObject.asp" -->
<%
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (c.CreateOptions.Factory)
            {
                %>

        ''' <summary>
        ''' Factory method. Creates a new <see cref="<%= Info.ObjectName %>"/> child object<%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        ''' </summary>
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
                    strNewParams += string.Concat(FormatCamel(newParams[i].Name), " As ", GetDataTypeGeneric(newParams[i], newParams[i].PropertyType));
                    strNewCritParams += FormatCamel(newParams[i].Name);
                }
%>
        ''' <returns>A reference to the created <see cref="<%= Info.ObjectName %>"/> object.</returns>
        Friend Shared Function New<%= Info.ObjectName %><%= c.CreateOptions.FactorySuffix %>Child(<%= strNewParams %>) As <%= Info.ObjectName %>
        <%
                if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
                    CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
                    Info.GetRoles.Trim() != String.Empty)
                {
                    %>
            If Not CanAddObject() Then
                Throw New System.Security.SecurityException("User not authorized to create a <%= Info.ObjectName %>.")
            End If

            <%
                }
                if (Info.ObjectType == CslaObjectType.EditableSwitchable)
                {
                    if (strNewCritParams.Length > 0)
                    {
                        strNewCritParams = "True, " + strNewCritParams;
                    }
                    else
                    {
                        strNewCritParams = "True";
                    }
                }
            %>
            Dim obj As <%= Info.ObjectName %> = DataPortal.CreateChild(Of <%= Info.ObjectName %>)(New <%= c.Name %>(<%= strNewCritParams %>))
            obj.MarkAsChild()
            Return obj
        End Function
<%
            }

            if (c.GetOptions.Factory)
            {
                %>

        ''' <summary>
        ''' Factory method. Loads a <see cref="<%= Info.ObjectName %>" /> child object <%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        ''' </summary>
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
                    strGetParams += string.Concat(FormatCamel(c.Properties[i].Name), " As ", GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType));
                    strGetCritParams += FormatCamel(c.Properties[i].Name);
                }
        %>
        Friend Shared Function Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>Child(<%= strGetParams %>) As  <%= Info.ObjectName %>
            <%
            if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
                CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
                Info.GetRoles.Trim() != String.Empty)
            {
                %>
            If Not CanGetObject() Then
                Throw New System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.")
            End If

            <%
            }
            if (strGetCritParams.Trim().Length > 0)
                strGetCritParams = "True, " + strGetCritParams;
            else
                strGetCritParams = "True";
            %>
            Return DataPortal.Fetch(Of <%= Info.ObjectName %>)(New <%= c.Name %>(<%= strGetCritParams %>))
        End Function
    <%
            }
        }
        %>

        #End Region
