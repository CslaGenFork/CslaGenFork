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

                strGetComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
            }
            if (c.Properties.Count > 1)
                strGetComment = "/// <param name=\"crit\">The fetch criteria.</param>";
            %>

        /// <summary>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> object from the database<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
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
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, c.Name + " crit"));
        %>protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit)<%
            }
            else if (c.Properties.Count > 0)
            {
                lastCriteria = ReceiveSingleCriteriaTypeless(c, "crit");
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ReceiveSingleCriteria(c, "crit")));
        %>protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)<%
            }
            else
            {
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ""));
        %>protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch()<%
            }
        %>
        {
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                %>
            if (crit.IsChild)
                MarkAsChild();
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
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= GetDbType(p) %>;
                    <%
                }
                else
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= GetDbType(p) %>;
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
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            <%
            if (SelfLoadsChildren(Info))
            {
                %>
            FetchChildren();
        <%
            }
            if (Info.CheckRulesOnFetch)
            {
                %>
            // check all object rules and property rules
            BusinessRules.CheckRules();
            <%
            }
            %>
        }
        <%
        }
    }
    if (Info.HasGetCriteria)
    {
        if (!Info.DataSetLoadingScheme)
        {
            %>

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                    <%
                if (ParentLoadsChildren(Info))
                {
                    %>
                    FetchChildren(dr);
                    <%
                }
                %>
                }
            }
        }
        <%
        }
        else
        {
            %>

        private void Fetch(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(ds);
            }
            CreateRelations(ds);
            Fetch(ds.Tables[0].Rows[0]);
            <%
            if (ParentLoadsChildren(Info))
            {
                %>
            FetchChildren(ds.Tables[0].Rows[0]);
            <%
            }
            %>
        }
<!-- #include file="CreateRelations.asp" -->
        <%
        }
    }
    %>
<!-- #include file="InternalDataPortalFetch.asp" -->
<%
}
%>
