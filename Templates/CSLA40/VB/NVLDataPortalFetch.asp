<%
if (!Info.UseCustomLoading)
{
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.GetOptions.DataPortal)
        {
            %>
        /// <summary>
        <%
            if (c.Properties.Count > 1)
            {
                %>
        /// Load <see cref="<%= Info.ObjectName %>"/> collection from the database<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        protected void DataPortal_Fetch(<%= c.Name %> crit)
        {
            <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
        /// Load <see cref="<%= Info.ObjectName %>"/> collection from the database<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        protected void DataPortal_Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)
        {
            <%
            }
            else
            {
                %>
        /// Load <see cref="<%= Info.ObjectName %>"/> collection from the database<%= Info.SimpleCacheOptions == SimpleCacheResults.DataPortal ? " or from the cache" : "" %>.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            <%
                if (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal)
                {
                    %>
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            <%
                }
            }
            %>
            <%= GetConnection(Info, true) %>
            {
                <%
            if (string.IsNullOrEmpty(c.GetOptions.ProcedureName))
            {
                Errors.Append("Criteria " + c.Name + " missing get procedure name." + Environment.NewLine);
            }
            %>
                <%= GetCommand(Info, c.GetOptions.ProcedureName) %>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    <%
            foreach (CriteriaProperty p in c.Properties)
            {
                if (c.Properties.Count > 1)
                {
                    %>cmd.Parameters.AddWithValue("@<%=p.ParameterName%>", <%= GetParameterSet(p, true) %>);
                    <%
                }
                else
                {
                    %>cmd.Parameters.AddWithValue("@<%=p.ParameterName%>", <%= AssignSingleCriteria(c, "crit") %>);
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
                        <%=String.Format(GetDataReaderStatement(valueProp)) %>,
                        <%=String.Format(GetDataReaderStatement(nameProp)) %>));
                }
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }
    <%
}
%>
