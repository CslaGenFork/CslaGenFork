<%
useInlineQuery = false;
if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.Always)
    useInlineQuery = true;
else if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.SpecifyByObject)
{
    foreach (string item in Info.GenerateInlineQueries)
    {
        if (item == "Read")
        {
            useInlineQuery = true;
            break;
        }
    }
}
if (!Info.UseCustomLoading)
{
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
        ''' Loads a <see cref="<%= Info.ObjectName %>"/> object from the database<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        ''' </summary>
        <%
            if (c.Properties.Count > 0)
            {
        %><%= strGetComment %>
        <%
            }
            if (c.GetOptions.RunLocal)
            {
                %><Csla.RunLocal()>
        <%
            }
            if (c.Properties.Count > 1)
            {
                lastCriteria = "crit";
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, c.Name + " crit"));
        %>Protected Sub <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(crit As <%= c.Name %>)<%
            }
            else if (c.Properties.Count > 0)
            {
                lastCriteria = ReceiveSingleCriteriaTypeless(c, "crit");
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ReceiveSingleCriteria(c, "crit")));
        %>Protected Sub <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)<%
            }
            else
            {
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ""));
        %>Protected Sub <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch()<%
            }
        %>
            <%
            if (Info.IsEditableSwitchable())
            {
                %>
            If crit.IsChild Then
                MarkAsChild()
            End If
            <%
            }
            %>
            <%= GetConnection(Info, true) %>
                <%= GetCommand(Info, c.GetOptions.ProcedureName, useInlineQuery, lastCriteria) %>
                    <%
            if (Info.CommandTimeout != string.Empty)
            {
                %>cmd.CommandTimeout = <%= Info.CommandTimeout %>
                    <%
            }
            %>cmd.CommandType = CommandType.<%= useInlineQuery ? "Text" : "StoredProcedure" %>
                    <%
            foreach (CriteriaProperty p in c.Properties)
            {
                if (c.Properties.Count > 1)
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>
                    <%
                }
                else
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>
                    <%
                }
            }
            if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
            {
                %>cn.Open()
                    <%
            }
            string hookArgs = string.Empty;
            if (c.Properties.Count > 1)
            {
                hookArgs = ", crit";
            }
            else if (c.Properties.Count > 0)
            {
                hookArgs = ", " + HookSingleCriteria(c, "crit");
            }
            %>Dim args As New DataPortalHookArgs(cmd<%= hookArgs %>)
                    OnFetchPre(args)
                    Fetch(cmd)
                    OnFetchPost(args)
                End Using
            End Using
            <%
            if (SelfLoadsChildren(Info))
            {
                %>
            FetchChildren()
        <%
            }
            if (Info.CheckRulesOnFetch && !Info.EditOnDemand && !TypeHelper.IsCollectionType(Info.ObjectType))
            {
                %>
            ' check all object rules and property rules
            BusinessRules.CheckRules()
            <%
            }
            %>
        End Sub
        <%
        }
    }
    if (Info.HasGetCriteria)
    {
        if (!Info.DataSetLoadingScheme)
        {
            %>

        Private Sub Fetch(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                If dr.Read() Then
                    Fetch(dr)
                    <%
                if (ParentLoadsChildren(Info))
                {
                    %>
                    FetchChildren(dr)
                    <%
                }
                %>
                End If
            End Using
        End Sub
        <%
        }
        else
        {
            %>

        Private Sub Fetch(cmd As SqlCommand)
            Dim ds As New DataSet()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds)
            End Using
            CreateRelations(ds)
            Fetch(ds.Tables(0).Rows(0))
            <%
            if (ParentLoadsChildren(Info))
            {
                %>
            FetchChildren(ds.Tables(0).Rows(0))
            <%
            }
            %>
        End Sub
<!-- #include file="CreateRelations.asp" -->
        <%
        }
    }
    %>
<!-- #include file="InternalDataPortalFetch.asp" -->
<%
}
%>
