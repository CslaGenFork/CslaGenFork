<%
if (!Info.UseCustomLoading)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.DataPortal)
        {
        %>

        /// <summary>
        /// Retrieve an existing <see cref="<%=Info.ObjectName%>"/> object from the database, based on given criteria.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
        %>/// <param name="crit">The fetch criteria.</param>
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
        %>protected void <%= (Info.ObjectType == CslaObjectType.EditableChild && CurrentUnit.GenerationParams.UseChildDataPortal) ? "Child_" : "DataPortal_" %>Fetch(SingleCriteria<<%= GetDataTypeGeneric(c.Properties[0], c.Properties[0].PropertyType) %>> crit)<%
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
                    %>
                    cmd.Parameters.AddWithValue("@<%=p.ParameterName%>", <%= GetParameterSet(p,true) %>);
                    <%
                }
                else
                {
                    %>
                    cmd.Parameters.AddWithValue("@<%=p.ParameterName%>", crit.Value);
                    <%
                }
            }
            %>
                    var args = new DataPortalHookArgs(cmd<%= c.Properties.Count > 0 ? ", crit" : "" %>);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
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
                dr.Read();
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
            BusinessRules.CheckRules();
            <%
                if (ActiveObjects)
                {
                    %>
            this.RegisterAndSubscribe();
            <%
                }
            }
            %>
        }
<!-- #include file="CreateRelations.inc" -->
        <%
        }
    }
%>

        <!-- #include file="InternalFetch.inc" -->
    <%
}
%>
