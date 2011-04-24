<%
if (!Info.UseCustomLoading)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.DataPortal)
        {
            %>
        /// <summary>
        /// Loads an existing <see cref="<%=Info.ObjectName%>"/> object from the database, based on given criteria.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
        %>/// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        <%
            }
            if (c.Properties.Count > 0 && c.GetOptions.RunLocal)
            {
                Response.Write("\r\n        ");
            }
            if (c.GetOptions.RunLocal)
            {
        %>[Csla.RunLocal]<%
            }
            if (c.Properties.Count > 1)
            {
        %>protected void <%= (Info.ObjectType == CslaObjectType.EditableChild && CurrentUnit.GenerationParams.UseChildDataPortal) ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit)<%
            }
            else if (c.Properties.Count > 0)
            {
        %>protected void <%= (Info.ObjectType == CslaObjectType.EditableChild && CurrentUnit.GenerationParams.UseChildDataPortal) ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)<%
            }
            else
            {
        %>protected void <%= (Info.ObjectType == CslaObjectType.EditableChild && CurrentUnit.GenerationParams.UseChildDataPortal) ? "Child_" : "DataPortal_" %>Fetch()<%
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
            foreach (Property p in c.Properties)
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
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            <%
            if (SelfLoadsChildren(Info))
            {
                string fetchChildrenParam = string.Empty;
                if (c.Properties.Count == 1)
                    fetchChildrenParam = AssignSingleCriteria(c, "crit");
                else
                {
                    bool first1 = true;
                    foreach (Property p in c.Properties)
                    {
                        if (first1) { first1 = false; } else { fetchChildrenParam += ", "; }
                        fetchChildrenParam += "crit." + p.Name;
                    }
                }
                %>}
            FetchChildren(<%= fetchChildrenParam %>);
        }

        <%
            }
            else
            {
        %>}
        }

        <%
            }
        }
    }
    if (Info.HasGetCriteria)
    {
        if (!Info.DataSetLoadingScheme)
        {
            %>private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                    <%
                if (LoadsChildren(Info))
                {
                    %>
                    FetchChildren(dr);
                    <%
                }
                if (Info.ObjectType != CslaObjectType.ReadOnlyObject)
                {
                    %>
                    MarkOld();
                <%
                }
                %>
                }
                <%
                if (Info.CheckRulesOnFetch)
                {
                    %>
                BusinessRules.CheckRules();
                <%
                }
                %>
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
            if (LoadsChildren(Info))
            {
                %>
            FetchChildren(ds.Tables[0].Rows[0]);
            <%
            }
            if (Info.ObjectType != CslaObjectType.ReadOnlyObject)
            {
                %>
            MarkOld();
            <%
                if (Info.CheckRulesOnFetch)
                {
                    %>
            BusinessRules.CheckRules();
            <%
                }
                if (ActiveObjects)
                {
                    %>
            this.RegisterAndSubscribe();
            <%
                }
            }
            %>
        }
<!-- #include file="CreateRelations.asp" -->
        <%
        }
    }
    %>
<%= IfNewSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel) %>
<!-- #include file="InternalFetch.asp" --><%= IfNewSilverlight (Conditional.End, 0, ref silverlightLevel) %>
<%
}
%>
