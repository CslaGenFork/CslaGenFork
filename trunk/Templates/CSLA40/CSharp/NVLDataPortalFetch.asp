<%
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

                strGetComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
            }
            if (c.Properties.Count > 1)
                strGetComment = "/// <param name=\"crit\">The fetch criteria.</param>";
            %>

        /// <summary>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> collection from the database<%= (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal && c.Properties.Count == 0) ? " or from the cache" : "" %><%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
        %><%= strGetComment %>
        <%
            }
            if (c.GetOptions.RunLocal)
            {
                %>[Csla.RunLocal]
        <%
            }
            if (c.Properties.Count > 1)
            {
                lastCriteria = "crit";
                InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, c.Name + " crit"));
        %>protected void DataPortal_Fetch(<%= c.Name %> crit)<%
            }
            else if (c.Properties.Count > 0)
            {
                lastCriteria = "crit";
                InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ReceiveSingleCriteria(c, "crit")));
        %>protected void DataPortal_Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)<%
            }
            else
            {
                InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ""));
        %>protected void DataPortal_Fetch()<%
            }
        %>
        {
            <%
            if (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal && c.Properties.Count == 0)
            {
                %>
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            <%
            }
            %>
            <%= GetConnection(Info, true) %>
            {
                <%= GetCommand(Info, c.GetOptions.ProcedureName, useInlineQuery, lastCriteria) %>
                {
                    <%
            if (Info.CommandTimeout != string.Empty)
            {
                %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
            }
            %>cmd.CommandType = CommandType.<%= useInlineQuery ? "Text" : "StoredProcedure" %>;
                    <%
            foreach (CriteriaProperty p in c.Properties)
            {
                if (c.Properties.Count > 1)
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %>).DbType = DbType.<%= GetDbType(p) %>;
                    <%
                }
                else
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %>).DbType = DbType.<%= GetDbType(p) %>;
                    <%
                }
            }
            if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
            {
                %>cn.Open();
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
                    %>var args = new DataPortalHookArgs(cmd<%= hookArgs %>);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            <%
            if (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal && c.Properties.Count == 0)
            {
                %>
            _list = this;
        <%
            }
            %>
        }
<!-- #include file="SimpleCacheLoadCachedList.asp" -->
        <%
        }
    }
    %>

        private void LoadCollection(SqlCommand cmd)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                while (dr.Read())
                {
                    Add(new NameValuePair(
                        <%= String.Format(GetDataReaderStatement(valueProp)) %>,
                        <%= String.Format(GetDataReaderStatement(nameProp)) %>));
                }
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }
    <%
}
%>
