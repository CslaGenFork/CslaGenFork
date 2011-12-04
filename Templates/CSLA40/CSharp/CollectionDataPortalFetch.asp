<%
if (!Info.UseCustomLoading)
{
    bool selfLoad1 = GetSelfLoad(Info);

    bool isChildCollection = (Info.ObjectType == CslaObjectType.EditableChildCollection ||
        (Info.ObjectType == CslaObjectType.ReadOnlyCollection && Info.ParentType != string.Empty)) &&
        !selfLoad1;

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
                string strGetCritParams = string.Empty;
                string strGetInvokeParams = string.Empty;
                string strGetComment = string.Empty;
                bool getIsFirst = true;

                foreach (Property p in c.Properties)
                {
                    if (!getIsFirst)
                    {
                        strGetCritParams += ", ";
                        strGetInvokeParams += ", ";
                        strGetComment += System.Environment.NewLine + new string(' ', 8);
                    }
                    else
                        getIsFirst = false;

                    TypeCodeEx propType = p.PropertyType;

                    strGetCritParams += string.Concat(GetDataTypeGeneric(p, propType), " ", FormatCamel(p.Name));
                    strGetInvokeParams += "crit." + FormatPascal(p.Name);
                    strGetComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
                }
                if (c.Properties.Count > 1)
                    strGetComment = "/// <param name=\"crit\">The fetch criteria.</param>";
                else if (c.Properties.Count == 1)
                    strGetInvokeParams = FormatCamel(c.Properties[0].Name);
                %>

        /// <summary>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> collection from the database<%= (c.Properties.Count == 0 && Info.SimpleCacheOptions == SimpleCacheResults.DataPortal ? " or from the cache" : "") %><%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
                if (c.Properties.Count > 0)
                {
                    %>
        <%= strGetComment %>
        <%
                }
                if (c.GetOptions.RunLocal)
                {
                    %>
        [Csla.RunLocal]
        <%
                }
                if (c.Properties.Count > 1)
                {
                    %>
        protected void <%= isChild ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit)
        {
            <%
                }
                else if (c.Properties.Count > 0)
                {
                    %>
        protected void <%= isChild ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)
        {
            <%
                }
                else
                {
                    %>
        protected void <%= isChild ? "Child_" : "DataPortal_" %>Fetch()
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
                if (SelfLoadsChildren(Info) && IsCollectionType(Info.ObjectType))
                {
                    %>
            foreach (var <%= FormatCamel(childInfo.ObjectName) %> in this)
            {
                <%= FormatCamel(childInfo.ObjectName) %>.FetchChildren();
            }
        <%
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
                <%
                if (ParentLoadsChildren(Info) && IsCollectionType(Info.ObjectType))
                {
                    %>
                foreach (var <%= FormatCamel(childInfo.ObjectName) %> in this)
                {
                    <%= FormatCamel(childInfo.ObjectName) %>.FetchChildren(dr);
                }
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
        private void <%= (isChildCollection && !useChildFactory ? "Child_" : "") %>Fetch(SafeDataReader dr)
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
                <%
        if (useChildFactory)
        {
            %>
                Add(<%= Info.ItemType %>.Get<%= Info.ItemType %>(dr));
            <%
        }
        else
        {
            %>
                Add(DataPortal.Fetch<%= IsNotRootType(childInfo) ? "Child" : "" %><<%= Info.ItemType %>>(dr));
            <%
        }
        %>
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
        private void <%= isChildCollection ? "Child_" : "" %>Fetch(DataRow[] rows)
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
                <%
        if (useChildFactory)
        {
            %>Add(<%= Info.ItemType %>.Get<%= Info.ItemType %>(row));
                <%
        }
        else
        {
            %>Add(DataPortal.Fetch<%= IsNotRootType(childInfo) ? "Child" : "" %><<%= Info.ItemType %>>(row));
                <%
        }
        %>
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
        private void <%= isChildCollection ? "Child_" : "" %>Fetch(DataRowCollection rows)
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
                <%
        if (useChildFactory)
        {
            %>Add(<%= Info.ItemType %>.Get<%= Info.ItemType %>(row));
                <%
        }
        else
        {
            %>Add(DataPortal.Fetch<%= IsNotRootType(childInfo) ? "Child" : "" %><<%= Info.ItemType %>>(row));
                <%
        }
        %>
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
