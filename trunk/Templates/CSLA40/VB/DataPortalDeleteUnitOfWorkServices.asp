<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
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
        ''' <param name="handler">The asynchronous handler.</param>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Overrides Sub DataPortal_DeleteSelf(handler As Csla.DataPortalClient.LocalProxy(Of <%= Info.ObjectName %>).CompletedHandler)
        {
            <%
            if (Info.IsEditableSwitchable())
            {
                strDeleteCritParams = "False, " + strDeleteCritParams;
            }
            if (c.Properties.Count > 1 || (Info.IsEditableSwitchable() && c.Properties.Count == 1))
            {
                %>
            DataPortal_Delete(new <%= c.Name %>(<%= strDeleteCritParams %>), handler)
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            DataPortal_Delete(<%= SendSingleCriteria(c, strDeleteCritParams) %>, handler)
        <%
            }
            else
            {
                %>
            DataPortal_Delete()
        <%
            }
            %>
        }

        ''' <summary>
        ''' Deletes the <see cref="<%= Info.ObjectName %>"/> object immediately.
        ''' </summary>
        ''' <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The delete criteria.</param>
        ''' <param name="handler">The asynchronous handler.</param>
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
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        <%
            deletePartialParams.Add("''' <param name=\"" + (c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit")) + "\">The delete criteria.</param>");
            if (c.Properties.Count > 1)
            {
                deletePartialMethods.Add("Partial Sub Service_Delete(" + "crit As " + c.Name + ")");
                %>
        Public Sub DataPortal_Delete(crit As <%= c.Name %>, handler As Csla.DataPortalClient.LocalProxy(Of <%= Info.ObjectName %>).CompletedHandler)
        <%
            }
            else
            {
                deletePartialMethods.Add("Partial Sub Service_Delete(" + ReceiveSingleCriteria(c, "crit") + ")");
                %>
        Public Sub DataPortal_Delete(<%= ReceiveSingleCriteria(c, "crit") %>, handler As Csla.DataPortalClient.LocalProxy(Of <%= Info.ObjectName %>).CompletedHandler)
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
            %>
            Try
                <%
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
            %>
                handler(Me, Nothing)
            Catch (ex As Exception)
                handler(Nothing, ex)
            End Try
            <%
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
