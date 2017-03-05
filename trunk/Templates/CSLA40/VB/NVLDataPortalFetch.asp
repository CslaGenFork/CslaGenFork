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
if (!Info.UseCustomLoading && (UseNoSilverlight() ||
    CurrentUnit.GenerationParams.GenerateSilverlight4))
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
        ''' Loads a <see cref="<%= Info.ObjectName %>"/> collection from the database<%= (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal && c.Properties.Count == 0) ? " or from the cache" : "" %><%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        ''' </summary>
        <%
            if (c.Properties.Count > 0)
            {
        %><%= strGetComment %>
        <%
            }
            if (c.GetOptions.RunLocal)
            {
                %><RunLocal>
        <%
            }
            if (c.Properties.Count > 1)
            {
                lastCriteria = "crit";
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, "crit As " + c.Name));
        %>Protected Overloads Sub DataPortal_Fetch(crit As <%= c.Name %>)<%
            }
            else if (c.Properties.Count > 0)
            {
                lastCriteria = ReceiveSingleCriteriaTypeless(c, "crit");
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ReceiveSingleCriteria(c, "crit")));
        %>Protected Overloads Sub DataPortal_Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)<%
            }
            else
            {
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ""));
        %>Protected Overloads Sub DataPortal_Fetch()<%
            }
        %>
            <%
            if (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal && c.Properties.Count == 0)
            {
                %>
            If IsCached Then
                LoadCachedList()
                Return
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
                    %>cmd.Parameters.<%= AddParameterMethod %>("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>
                    <%
                }
                else
                {
                    %>cmd.Parameters.<%= AddParameterMethod %>("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>
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
                    %>Dim args = New DataPortalHookArgs(cmd<%= hookArgs %>)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
            <%
            if (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal && c.Properties.Count == 0)
            {
                %>
            _list = Me
        <%
            }
            %>
        End Sub
<!-- #include file="SimpleCacheLoadCachedList.asp" -->
        <%
        }
    }
    %>

        Private Sub LoadCollection(cmd As <%= CommandMethod %>)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Using dr = New SafeDataReader(cmd.ExecuteReader())
                While dr.Read()
                    Add(New NameValuePair(
                        <%= String.Format(GetDataReaderStatement(valueProp)) %>,
                        <%= String.Format(GetDataReaderStatement(nameProp)) %>))
                End While
            End Using
            RaiseListChangedEvents = rlce
            IsReadOnly = True
        End Sub
    <%
}
%>
