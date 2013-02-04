<%
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

                TypeCodeEx propType = p.PropertyType;

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
        %>protected void DataPortal_Fetch(<%= c.Name %> crit)<%
            }
            else if (c.Properties.Count > 0)
            {
        %>protected void DataPortal_Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)<%
            }
            else
            {
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
                <%= GetCommand(Info, c.GetOptions.ProcedureName) %>
                {
                    <%
            if (Info.CommandTimeout != string.Empty)
            {
                %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
            }
            %>cmd.CommandType = CommandType.StoredProcedure;
                    <%
            foreach (CriteriaProperty p in c.Properties)
            {
                if (c.Properties.Count > 1)
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
                    <%
                }
                else
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
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
