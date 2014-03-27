<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    int createCriteriaCount = 0;
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.CreateOptions.Factory)
            createCriteriaCount ++;
    }
    if (createCriteriaCount == 0 &&
        (Info.ObjectType == CslaObjectType.EditableRootCollection ||
        Info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
        Info.ObjectType == CslaObjectType.EditableChildCollection))
    {
        %>

        ''' <summary>
        ''' Factory method. Creates a new <see cref="<%= Info.ObjectName %>"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="<%= Info.ObjectName %>"/> collection.</returns>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Function New<%= Info.ObjectName %>() As <%= Info.ObjectName %>
            Return DataPortal.Create<%= isChildNotLazyLoaded ? "Child" : "" %>(Of <%= Info.ObjectName %>)()
        End Function
        <%
    }
    else
    {
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (c.CreateOptions.Factory)
            {
                var runLocal = c.CreateOptions.RunLocal;
                string strNewParams = string.Empty;
                string strNewCritParams = string.Empty;
                string strNewComment = string.Empty;
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    if (i > 0)
                    {
                        strNewParams += ", ";
                        strNewCritParams += ", ";
                    }
                    strNewParams += string.Concat(FormatCamel(c.Properties[i].Name), " As ", GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType));
                    strNewCritParams += FormatCamel(c.Properties[i].Name);
                    strNewComment += "''' <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + FormatProperty(c.Properties[i].Name) + " of the " + Info.ObjectName + " to create.</param>" + System.Environment.NewLine + new string(' ', 8);
                }
                if (!isChild && !c.NestedClass && c.Properties.Count > 1 && Info.ObjectType != CslaObjectType.EditableSwitchable)
                {
                    %>

        ''' <summary>
        ''' Factory method. Creates a new <see cref="<%= Info.ObjectName %>"/> <%= IsCollectionType(Info.ObjectType) ? "collection" : "object" %>, based on given parameters.
        ''' </summary>
        ''' <param name="crit">The create criteria.</param>
        ''' <returns>A reference to the created <see cref="<%= Info.ObjectName %>"/> <%= IsCollectionType(Info.ObjectType) ? "collection" : "object" %>.</returns>
        Public Shared Function New<%= Info.ObjectName %><%= c.CreateOptions.FactorySuffix %>(crit As <%= c.Name %>) As <%= Info.ObjectName %>
            Return DataPortal.Create(Of <%= Info.ObjectName %>)(crit)
        End Function
        <%
                }
                %>

        ''' <summary>
        ''' Factory method. Creates a new <see cref="<%= Info.ObjectName %>"/> <%= IsCollectionType(Info.ObjectType) ? "collection" : "object" %><%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        ''' </summary>
        <%= strNewComment %>''' <returns>A reference to the created <see cref="<%= Info.ObjectName %>"/> <%= IsCollectionType(Info.ObjectType) ? "collection" : "object" %>.</returns>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Function New<%= Info.ObjectName %><%= c.CreateOptions.FactorySuffix %>(<%= strNewParams %>) As <%= Info.ObjectName %>
           <%
                if (Info.ObjectType == CslaObjectType.EditableSwitchable)
                {
                    if (strNewCritParams.Length > 0)
                    {
                        strNewCritParams = "False, " + strNewCritParams;
                    }
                    else
                    {
                        strNewCritParams = "False" ;
                    }
                }
                if (c.Properties.Count > 1)
                {
                    %>
            Return DataPortal.Create<%= (isChildNotLazyLoaded && runLocal) ? "Child" : "" %>(Of <%= Info.ObjectName %>)(New <%= c.Name %>(<%= strNewCritParams %>))
                <%
                }
                else if (c.Properties.Count > 0)
                {
                    %>
            Return DataPortal.Create<%= (isChildNotLazyLoaded && runLocal) ? "Child" : "" %>(Of <%= Info.ObjectName %>)(<%= SendSingleCriteria(c, strNewCritParams) %>)
                    <%
                }
                else
                {
                    %>
            Return DataPortal.Create<%= (isChildNotLazyLoaded && runLocal) ? "Child" : "" %>(Of <%= Info.ObjectName %>)()
                    <%
                }
                %>
        End Function
        <%
            }
        }
    }
}
%>
