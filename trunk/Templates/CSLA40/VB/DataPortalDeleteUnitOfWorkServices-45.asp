<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices && UseNoSilverlight())
{
    List<string> deletePartialMethods = new List<string>();
    List<string> deletePartialParams = new List<string>();
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.DeleteOptions.DataPortal)
        {
            %>

        ''' <summary>
        ''' Self deletes the <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%
            string strDeleteCritParams = string.Empty;
            bool firstParam = true;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (firstParam)
                {
                    firstParam = false;
                }
                else
                {
                    strDeleteCritParams += ", ";
                }
                strDeleteCritParams += c.Properties[i].Name;
            }
            %>
        <Csla.RunLocal()>
        Protected Overrides Sub DataPortal_DeleteSelf()
            <%
            if (Info.IsEditableSwitchable())
            {
                strDeleteCritParams = "False, " + strDeleteCritParams;
            }
            if (c.Properties.Count > 1 || (Info.IsEditableSwitchable() && c.Properties.Count == 1))
            {
                %>
            DataPortal_Delete(new <%= c.Name %>(<%= strDeleteCritParams %>), )
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            DataPortal_Delete(<%= SendSingleCriteria(c, strDeleteCritParams) %>, )
        <%
            }
            else
            {
                %>
            DataPortal_Delete()
        <%
            }
            %>
        End Sub

        ''' <summary>
        ''' Deletes the <see cref="<%= Info.ObjectName %>"/> object immediately.
        ''' </summary>
        ''' <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The delete criteria.</param>
        <%
            if (Info.TransactionType == TransactionType.EnterpriseServices)
            {
                %>
        <Transactional(TransactionalTypes.EnterpriseServices)>
        <%
            }
            else if (Info.TransactionType == TransactionType.TransactionScope)
            {
                %>
        <Transactional(TransactionalTypes.TransactionScope)>
        <%
            }
            %>
        <Csla.RunLocal()>
        <%
            deletePartialParams.Add("''' <param name=\"" + (c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit")) + "\">The delete criteria.</param>");
            if (c.Properties.Count > 1)
            {
                deletePartialMethods.Add("Partial Sub Service_Delete(" + "crit As " + c.Name + ")");
                %>
        Protected Sub DataPortal_Delete(crit As <%= c.Name %>)
        <%
            }
            else
            {
                deletePartialMethods.Add("Partial Sub Service_Delete(" + ReceiveSingleCriteria(c, "crit") + ")");
                %>
        Protected Sub DataPortal_Delete(<%= ReceiveSingleCriteria(c, "crit") %>)
        <%
            }
            %>
            <%
            if (Info.GetMyChildReadWriteProperties().Count > 0)
            {
                string ucpSpacer = string.Empty;
                %>
<!-- #include file="UpdateChildProperties.asp" -->
        <%
            }
            if (c.Properties.Count > 1)
            {
                %>
            Service_Delete(crit)
            <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            Service_Delete(<%= HookSingleCriteria(c, "crit") %>)
            <%
            }
            else
            {
                %>
            Service_Delete()
            <%
            }
            if (Info.GetMyChildProperties().Count > 0)
            {
                %>
            '' removes all previous references to children
            <%
            }
            foreach (ChildProperty collectionProperty in Info.GetMyChildProperties())
            {
                %>
            <%= GetFieldLoaderStatement(collectionProperty, "DataPortal.CreateChild(Of " + collectionProperty.TypeName + ")()") %>
            <%
            }
            %>
        End Sub
        <%
        }
    }
    for (int index = 0; index < deletePartialMethods.Count ; index++)
    {
        string header = deletePartialParams[index] + (string.IsNullOrEmpty(deletePartialParams[index]) ? "" : "\r\n        ");
        header += deletePartialMethods[index];
        MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Delete" : "DataPortal_Delete", header));
        %>

        ''' <summary>
        ''' Implements <%= isChildNotLazyLoaded ? "Child_Delete" : "DataPortal_Delete" %> for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%= header %>
        End Sub
<%
    }
}
%>
