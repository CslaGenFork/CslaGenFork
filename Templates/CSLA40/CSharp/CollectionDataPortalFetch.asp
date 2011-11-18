<%
if (!Info.UseCustomLoading)
{
    bool selfLoad1 = GetSelfLoad(Info);

    bool isSwitchable = false;
    CslaObjectInfo childInfo = FindChildInfo(Info, Info.ItemType);
    if (childInfo.ObjectType == CslaObjectType.EditableSwitchable)
    {
        isSwitchable = true;
    }

    if (GetCriteriaObjects(Info).Count > 0)
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
        /// Loads a <see cref="<%= Info.ObjectName %>"/> collection from the database<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        protected void <%= isChild ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit)
        {
            <%
                }
                else if (c.Properties.Count > 0)
                {
                    %>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> collection from the database<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        protected void <%= isChild ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)
        {
            <%
                }
                else
                {
                    %>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> collection from the database<%= Info.SimpleCacheOptions == SimpleCacheResults.DataPortal ? " or from the cache" : "" %>.
        /// </summary>
        protected void <%= isChild ? "Child_" : "DataPortal_" %>Fetch()
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
                foreach (Property p in c.Properties)
                {
                    if (c.Properties.Count > 1)
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
                    <%
                    }
                    else
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
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
                if (Info.ObjectType == CslaObjectType.EditableRootCollection)
                {
                    foreach (ChildProperty childProp in childInfo.GetCollectionChildProperties())
                    {
                        if (childProp.LoadingScheme == LoadingScheme.SelfLoad && !childProp.LazyLoad)
                        {
                            string invokeParam = string.Empty;
                            foreach (Parameter param in childProp.LoadParameters)
                            {
                                bool first1 = true;
                                foreach (CriteriaProperty crit in param.Criteria.Properties)
                                {
                                    if (first1)
                                    {
                                        first1 = false;
                                    }
                                    else
                                    {
                                        invokeParam += ", ";
                                    }
                                    invokeParam += FormatPascal(crit.Name);
                                }
                            }
            %>
            foreach (var <%= FormatCamel(childInfo.ObjectName) %> in this)
            {
                <%= FormatCamel(childInfo.ObjectName) %>.FetchChildren(<%= FormatCamel(childInfo.ObjectName) %>.<%= invokeParam %>);
            }
        <%
                        }
                    }
                }
                %>
        }
<!-- #include file="SimpleCacheLoadCachedList.asp" -->
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

<!-- #include file="CreateRelations.asp" -->
<%
            }
        }
    }

    if (!Info.DataSetLoadingScheme)
    {
        %>

        /// <summary>
        /// Loads all <see cref="<%= Info.ObjectName %>"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            <%
        if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
        {
            %>
            IsReadOnly = false;
            <%
        }
        %>
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            <%
        if (!Info.HasGetCriteria && Info.ParentType != string.Empty && !selfLoad1)
        {
            %>
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            <%
        }
        %>
            while (dr.Read())
            {
                <%= Info.ItemType %> obj = <%= Info.ItemType %>.Get<%= Info.ItemType %>(dr<%= useParentReference ? (", this") : "" %>);
                Add(obj);
            }
            <%
        if (!Info.HasGetCriteria && Info.ParentType != string.Empty && !selfLoad1)
        {
            %>
            OnFetchPost(args);
            <%
        }
        %>
            RaiseListChangedEvents = rlce;
            <%
        if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
        {
            %>
            IsReadOnly = true;
            <%
        }
        %>
        }
    <%
    }
    else
    {
        %>

        /// <summary>
        /// Loads all <see cref="<%= Info.ObjectName %>"/> collection items using given DataRow array.
        /// </summary>
        private void Fetch(DataRow[] rows)
        {
            <%
        if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
        {
            %>
            IsReadOnly = false;
            <%
        }
        %>
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (DataRow row in rows)
            {
                <%= Info.ItemType %> obj = <%= Info.ItemType %>.Get<%= Info.ItemType %>(row);
                Add(obj);
            }
            RaiseListChangedEvents = rlce;
            <%
        if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
        {
            %>
            IsReadOnly = true;
            <%
        }
        %>
        }
        <%
        if (Info.HasGetCriteria)
        {
            %>

        /// <summary>
        /// Loads all <see cref="<%= Info.ObjectName %>"/> collection items from given DataTable.
        /// </summary>
        private void Fetch(DataRowCollection rows)
        {
            <%
            if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
            {
                %>
            IsReadOnly = false;
            <%
            }
            %>
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (DataRow row in rows)
            {
                <%= Info.ItemType %> obj = <%= Info.ItemType %>.Get<%= Info.ItemType %>(row);
                Add(obj);
            }
            RaiseListChangedEvents = rlce;
            <%
            if (Info.ObjectType == CslaObjectType.ReadOnlyCollection)
            {
                %>
            IsReadOnly = true;
            <%
            }
            %>
        }
            <%
        }
    }
}
%>
