<%
bool dependentAllowNew3 = false;
if (!IsReadOnlyType(Info.ObjectType) && IsCollectionType(Info.ObjectType))
{
    if (CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
        CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel &&
        Info.GetRoles.Trim() != String.Empty)
    {
        CslaObjectInfo itemInfo3 = FindChildInfo(Info, Info.ItemType);
        if (Info.AllowNew && itemInfo3.NewRoles.Trim() != String.Empty)
            dependentAllowNew3 = true;
    }
}
if (!Info.UseCustomLoading)
{
    if (Info.LazyLoad && Info.CriteriaObjects.Count == 0)
    {
        Errors.Append("Object " + Info.ObjectName + " missing criteria. To \"Lazyload\" a collection, you need a criteria at the collection level." + Environment.NewLine);
        return;
    }
    if (Info.CriteriaObjects.Count > 0)
    {
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.DataPortal)
        {
            %>

        /// <summary>
        <%
            if (c.Properties.Count > 1)
            {
                %>
        /// Load <see cref="<%=Info.ObjectName%>"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        protected void <%= (Info.ObjectType == CslaObjectType.EditableChild && CurrentUnit.GenerationParams.UseChildDataPortal) ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit)
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
        /// Load <see cref="<%=Info.ObjectName%>"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        protected void <%= (Info.ObjectType == CslaObjectType.EditableChild && CurrentUnit.GenerationParams.UseChildDataPortal) ? "Child_" : "DataPortal_" %>Fetch(SingleCriteria<<%= GetDataTypeGeneric(c.Properties[0], c.Properties[0].PropertyType) %>> crit)
        <%
            }
            else
            {
                %>
        /// Load <see cref="<%=Info.ObjectName%>"/> collection from the database.
        /// </summary>
        protected void <%= (Info.ObjectType == CslaObjectType.EditableChild && CurrentUnit.GenerationParams.UseChildDataPortal) ? "Child_" : "DataPortal_" %>Fetch()
        <%
            }
            %>
        {
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
                    %>cmd.Parameters.AddWithValue("@<%=p.ParameterName%>", crit.Value);
                    <%
                }
            }
            if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
            {
                %>cn.Open();
                    <%
            }
            %>var args = new DataPortalHookArgs(cmd<%= c.Properties.Count > 0 ? ", crit" : "" %>);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);<%
            if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
            {
                %>
                    IsReadOnly = true;<%
            }
            %>
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

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }
        <%
        }
        else
        {
            %>

        private void LoadCollection(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(ds);
            }
            CreateRelations(ds);
            Fetch(ds.Tables[0].Rows);
        }

<!-- #include file="CreateRelations.inc" -->
        <%
        }
    }
    }

    bool isSwitchable = false;
    CslaObjectInfo childInfo = FindChildInfo(Info, Info.ItemType);
    if (childInfo.ObjectType == CslaObjectType.EditableSwitchable)
    {
        isSwitchable = true;
    }
    if (!Info.DataSetLoadingScheme)
    {
        %>

        /// <summary>
        /// Load all <see cref="<%=Info.ObjectName%>"/> collection items using given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader.</param>
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            //AllowNew = true;
            <%
        if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
        {
            %>
            IsReadOnly = false;
            <%
        }
        %>
            while (dr.Read())
            {
                <%= Info.ItemType %> obj = <%= Info.ItemType %>.Get<%= Info.ItemType %>(dr);
                Add(obj);
            }
            <%
        if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
        {
            %>
            IsReadOnly = true;
            <%
        }
        if (dependentAllowNew3 || Info.AllowNew.ToString().ToLower() != "true")
        {
            %>
            //AllowNew = <%= dependentAllowNew3 ? itemName2 + ".CanAddObject()" : Info.AllowNew.ToString().ToLower() %>;
            <%
        }
        %>
            RaiseListChangedEvents = true;
        }
    <%
    }
    else
    {
        %>
        /// <summary>
        /// Load all <see cref="<%=Info.ObjectName%>"/> collection items using given DataRow array.
        /// </summary>
        private void Fetch(DataRow[] rows)
        {
            RaiseListChangedEvents = false;
            //AllowNew = true;
            <%
        if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
        {
            %>
            IsReadOnly = false;
            <%
        }
        %>
            foreach (DataRow row in rows)
            {
                <%= Info.ItemType %> obj = <%= Info.ItemType %>.Get<%= Info.ItemType %>(row);
                Add(obj);
            }
            <%
        if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
        {
            %>
            IsReadOnly = true;
            <%
        }
        if (dependentAllowNew3 || Info.AllowNew.ToString().ToLower() != "true")
        {
            %>
            //AllowNew = <%= dependentAllowNew3 ? itemName2 + ".CanAddObject()" : Info.AllowNew.ToString().ToLower() %>;
            <%
        }
        %>
            RaiseListChangedEvents = true;
        }
        <%
        if (Info.HasGetCriteria)
        {
            %>
        /// <summary>
        /// Load all <see cref="<%=Info.ObjectName%>"/> collection items from given DataTable.
        /// </summary>
        private void Fetch(DataRowCollection rows)
        {
            RaiseListChangedEvents = false;<%
        if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
        {
            %>
            IsReadOnly = false;
            <%
        }
        %>
            foreach (DataRow row in rows)
            {
                <%= Info.ItemType %> obj = <%= Info.ItemType %>.Get<%= Info.ItemType %>(row);
                Add(obj);
            }
            <%
        if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
        {
            %>
            IsReadOnly = true;
            <%
        }
        %>
            RaiseListChangedEvents = true;
        }
            <%
        }
    }
}
%>

