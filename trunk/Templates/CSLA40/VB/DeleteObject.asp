<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.DeleteOptions.Factory)
        {
            if (!isChild && !c.NestedClass && c.Properties.Count > 1 && Info.ObjectType != CslaObjectType.EditableSwitchable)
            {
                %>

        ''' <summary>
        ''' Factory method. Deletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="crit">The delete criteria.</param>
        Public Shared Sub Delete<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(crit As <%= c.Name %>)
            DataPortal.Delete(Of <%= Info.ObjectName %>)(crit)
        End Sub
        <%
            }
            %>

        ''' <summary>
        ''' Factory method. Deletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        ''' </summary>
<%
            string strDelParams = string.Empty;
            string strDelCritParams = string.Empty;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                %>
        ''' <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the <%= Info.ObjectName %> to delete.</param>
        <%
                if (i > 0)
                {
                    strDelParams += ", ";
                    strDelCritParams += ", ";
                }
                strDelParams += string.Concat(FormatCamel(c.Properties[i].Name), " As ", GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType));
                strDelCritParams += FormatCamel(c.Properties[i].Name);
            }
            %>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Sub Delete<%= Info.ObjectName %><%= c.DeleteOptions.FactorySuffix %>(<%= strDelParams %>)
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                if (!strDelCritParams.Equals(String.Empty))
                {
                    strDelCritParams = ", " + strDelCritParams;
                }
                strDelCritParams = "False" + strDelCritParams;
            }
            if (c.Properties.Count > 1)
            {
                %>DataPortal.Delete(Of <%= Info.ObjectName %>)(New <%= c.Name %>(<%= strDelCritParams %>))<%
            }
            else if (c.Properties.Count > 0)
            {
                %>DataPortal.Delete(Of <%= Info.ObjectName %>)(<%= SendSingleCriteria(c, strDelCritParams) %>)<%
            }
            else
            {
                %>DataPortal.Delete(New <%= c.Name %>(<%= strDelCritParams %>))<%
            }
            %>
        End Sub
<%
            if (isUndeletable == true)
            {
                %>

        ''' <summary>
        ''' Factory method. Undeletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        ''' </summary>
<%
                strDelParams = string.Empty;
                strDelCritParams = string.Empty;
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    %>
        ''' <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the <%= Info.ObjectName %> to undelete.</param>
        <%
                    if (i > 0)
                    {
                        strDelParams += ", ";
                        strDelCritParams += ", ";
                    }
                    strDelParams += string.Concat(FormatCamel(c.Properties[i].Name), " As ", GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType));
                    strDelCritParams += FormatCamel(c.Properties[i].Name);
                }
                %>
        ''' <returns>A reference to the undeleted <see cref="<%= Info.ObjectName %>"/> object.</returns>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Function Undelete<%= Info.ObjectName %><%= c.DeleteOptions.FactorySuffix %>(<%= strDelParams %>) As <%= Info.ObjectName %>
            <%
                if (Info.ObjectType == CslaObjectType.EditableSwitchable)
                {
                    if (!strDelCritParams.Equals(String.Empty))
                    {
                        strDelCritParams = ", " + strDelCritParams;
                    }
                    strDelCritParams = "False" + strDelCritParams;
                }
                if (c.Properties.Count > 1)
                {
                    %>Dim obj = DataPortal.Fetch(Of <%= Info.ObjectName %>)(<%= strDelCritParams %>)<%
                }
                else if (c.Properties.Count > 0)
                {
                    %>Dim obj = DataPortal.Fetch(Of <%= Info.ObjectName %>)(<%= SendSingleCriteria(c, strDelCritParams) %>)<%
                }
            %>
            obj.<%= softDeleteProperty %> = True
            Return obj.Save()
        End Function
<%
            }
        }
    }
}
%>
