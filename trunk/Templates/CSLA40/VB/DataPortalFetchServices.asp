<%
if (!Info.UseCustomLoading && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    List<string> fetchPartialMethods = new List<string>();
    List<string> fetchPartialParams = new List<string>();
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.DataPortal)
        {
            string strGetComment = string.Empty;
            bool getIsFirst = true;

            foreach (CriteriaProperty p in c.Properties)
            {
                if (!getIsFirst)
                {
                    strGetComment += System.Environment.NewLine + new string(' ', 8);
                }
                else
                    getIsFirst = false;

                strGetComment += "''' <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
            }
            if (c.Properties.Count > 1)
                strGetComment = "''' <param name=\"crit\">The fetch criteria.</param>";
            %>

        ''' <summary>
        ''' Loads a <see cref="<%= Info.ObjectName %>"/> <%= IsCollectionType(Info.ObjectType) ? "collection" : "object" %><%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        ''' </summary>
        <%
            if (c.Properties.Count > 0)
            {
                fetchPartialParams.Add("''' <param name=\"" + (c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit")) + "\">The fetch criteria.</param>");
        %>
        <%= strGetComment %>
        <%
            }
            else
            {
                fetchPartialParams.Add("");
            }
            %>
        ''' <param name="handler">The asynchronous handler.</param>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        <%
            if (c.Properties.Count > 1)
            {
                fetchPartialMethods.Add("Partial Sub Service_Fetch(crit As " + c.Name + ")");
                %>
        Public Sub <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(crit As <%= c.Name %>, handler As Csla.DataPortalClient.LocalProxy(Of <%= Info.ObjectName %>).CompletedHandler)
        <%
            }
            else if (c.Properties.Count > 0)
            {
                fetchPartialMethods.Add("Partial Sub Service_Fetch(" + ReceiveSingleCriteria(c, "crit") + ")");
                %>
        Public Sub <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>, handler As Csla.DataPortalClient.LocalProxy(Of <%= Info.ObjectName %>).CompletedHandler)
        <%
            }
            else
            {
                fetchPartialMethods.Add("Partial Sub Service_Fetch()");
                %>
        Public Sub <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(handler As Csla.DataPortalClient.LocalProxy(Of <%= Info.ObjectName %>).CompletedHandler)
        <%
            }
        %>
            Try
                <%
            if (c.Properties.Count > 1)
            {
                %>
                Service_Fetch(crit)
                <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
                Service_Fetch(<%= HookSingleCriteria(c, "crit") %>)
                <%
            }
            else
            {
                %>
                Service_Fetch()
                <%
            }
    %>
                handler(Me, Nothing)

            Catch ex As Exception
                handler(Nothing, ex)
            End Try
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                %>
            If crit.IsChild Then
                MarkAsChild()
            End If
            <%
            }
        %>
        End Sub
        <%
        }
    }
    for (int index = 0; index < fetchPartialMethods.Count ; index++)
    {
        string header = fetchPartialParams[index] + (string.IsNullOrEmpty(fetchPartialParams[index]) ? "" : "\r\n        ");
        header += fetchPartialMethods[index];
        MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Fetch" : "DataPortal_Fetch", header));
        %>

        ''' <summary>
        ''' Implements <%= isChildNotLazyLoaded ? "Child_Fetch" : "DataPortal_Fetch" %> for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%= header %>
        End Sub
<%
    }
}
%>
