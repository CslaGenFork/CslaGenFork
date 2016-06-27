<%
useInlineQuery = false;
lastCriteria = "";
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
    string createString = string.Empty;
    bool isChildCollection = (Info.IsEditableChildCollection() ||
        (Info.IsReadOnlyCollection() && Info.ParentType != string.Empty)) &&
        !isChildSelfLoaded;

    if (Info.CriteriaObjects.Count > 0)
    {
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (c.GetOptions.DataPortal)
            {
                string strGetCritParams = string.Empty;
                string strGetInvokeParams = string.Empty;
                string strGetComment = string.Empty;
                bool getIsFirst = true;

                foreach (CriteriaProperty p in c.Properties)
                {
                    if (!getIsFirst)
                    {
                        strGetCritParams += ", ";
                        strGetInvokeParams += ", ";
                        strGetComment += System.Environment.NewLine + new string(' ', 8);
                    }
                    else
                        getIsFirst = false;

                    strGetCritParams += string.Concat(GetDataTypeGeneric(p, p.PropertyType), " ", FormatCamel(p.Name));
                    strGetInvokeParams += "crit." + FormatPascal(p.Name);
                    strGetComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
                }
                if (c.Properties.Count > 1)
                    strGetComment = "/// <param name=\"crit\">The fetch criteria.</param>";
                else if (c.Properties.Count > 0)
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
                    lastCriteria = "crit";
                    if (useInlineQuery)
                        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, c.Name + " crit"));
                    %>
        protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit)
        {
            <%
                }
                else if (c.Properties.Count > 0)
                {
                    lastCriteria = ReceiveSingleCriteriaTypeless(c, "crit");
                    if (useInlineQuery)
                        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ReceiveSingleCriteria(c, "crit")));
                    %>
        protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)
        {
            <%
                }
                else
                {
                    if (useInlineQuery)
                        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ""));
                    %>
        protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch()
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
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>;
                    <%
                    }
                    else
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>;
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
                if (SelfLoadsChildren(Info) && TypeHelper.IsCollectionType(Info.ObjectType))
                {
                    %>
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        <%
                }
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
                if (itemInfo != null)
                {
                    if (ParentLoadsCollectionChildren(itemInfo))
                    {
                        %>
                if (this.Count > 0)
                    this[0].FetchChildren(dr);
                <%
                    }
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
        private void <%= (isChildCollection && !UseChildFactoryHelper ? "Child_" : "") %>Fetch(SafeDataReader dr)
        {
            <%
        if (Info.IsReadOnlyCollection())
        {
            %>
            IsReadOnly = false;
            <%
        }
        %>
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            <%
        if (!Info.HasGetCriteria && Info.ParentType != string.Empty && !isChildSelfLoaded)
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
        if (UseChildFactoryHelper)
        {
            %>
                Add(<%= Info.ItemType %>.Get<%= Info.ItemType %>(dr));
            <%
        }
        else
        {
            %>
                Add(DataPortal.Fetch<%= TypeHelper.IsNotRootType(itemInfo) ? "Child" : "" %><<%= Info.ItemType %>>(dr));
            <%
        }
        %>
            }
            <%
        if (!Info.HasGetCriteria && Info.ParentType != string.Empty && !isChildSelfLoaded)
        {
            %>
            OnFetchPost(args);
            <%
        }
        %>
            RaiseListChangedEvents = rlce;
            <%
        if (Info.IsReadOnlyCollection())
        {
            %>
            IsReadOnly = true;
            <%
        }
        %>
        }
    <%
        if ((ancestorLoaderLevel > 1 && !ancestorIsCollection) || (ancestorLoaderLevel > 1 && ancestorIsCollection))
        {
            ChildProperty childProp = new ChildProperty();
            foreach (ChildProperty child in parentInfo.GetCollectionChildProperties())
            {
                if (child.TypeName == Info.ObjectName)
                {
                    childProp = child;
                    break;
                }
            }
            CslaObjectInfo childInfo = Info.Parent.CslaObjects.Find(childProp.TypeName);

            string findByParams = string.Empty;
            bool parentFirst = true;
            foreach(Property prop in itemInfo.ParentProperties)
            {
                if (parentFirst)
                    parentFirst = false;
                else
                    findByParams += ", ";

                findByParams += "item." + FormatCamel(GetFKColumn(itemInfo, parentInfo, prop));
            }
            string collectionObject = FormatPascal(childProp.Name);
            %>

        /// <summary>
        /// Loads <see cref="<%= FormatPascal(Info.ItemType) %>"/> items on the <%= FormatPascal(childProp.Name) %> collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="<%= FormatPascal(parentInfo.ParentType) %>"/> collection.</param>
        internal void LoadItems(<%= FormatPascal(parentInfo.ParentType) %> collection)
        {
            foreach (var item in this)
            {
                var obj = collection.Find<%= FormatPascal(Info.ParentType) %>ByParentProperties(<%= findByParams %>);
                <%
                if (childInfo.IsReadOnlyCollection())
                {
                    %>
                obj.<%= collectionObject %>.IsReadOnly = false;
                <%
                }
                %>
                var rlce = obj.<%= collectionObject %>.RaiseListChangedEvents;
                obj.<%= collectionObject %>.RaiseListChangedEvents = false;
                obj.<%= collectionObject %>.Add(item);
                obj.<%= collectionObject %>.RaiseListChangedEvents = rlce;
                <%
                if (childInfo.IsReadOnlyCollection())
                {
                    %>
                obj.<%= collectionObject %>.IsReadOnly = true;
                <%
                }
                %>
            }
        }
    <%
        }
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
        if (Info.IsReadOnlyCollection())
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
        if (UseChildFactoryHelper)
        {
            %>Add(<%= Info.ItemType %>.Get<%= Info.ItemType %>(row));
                <%
        }
        else
        {
            %>Add(DataPortal.Fetch<%= TypeHelper.IsNotRootType(itemInfo) ? "Child" : "" %><<%= Info.ItemType %>>(row));
                <%
        }
        %>
            }
            RaiseListChangedEvents = rlce;
            <%
        if (Info.IsReadOnlyCollection())
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
            if (Info.IsReadOnlyCollection())
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
        if (UseChildFactoryHelper)
        {
            %>Add(<%= Info.ItemType %>.Get<%= Info.ItemType %>(row));
                <%
        }
        else
        {
            %>Add(DataPortal.Fetch<%= TypeHelper.IsNotRootType(itemInfo) ? "Child" : "" %><<%= Info.ItemType %>>(row));
                <%
        }
        %>
            }
            RaiseListChangedEvents = rlce;
            <%
            if (Info.IsReadOnlyCollection())
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
