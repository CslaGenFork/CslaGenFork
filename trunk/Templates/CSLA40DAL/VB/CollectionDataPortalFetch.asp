<%
if (!Info.UseCustomLoading && !Info.DataSetLoadingScheme)
{
    bool selfLoad1 = IsChildSelfLoaded(Info);

    bool isChildCollection = (Info.IsEditableChildCollection() ||
        (Info.IsReadOnlyCollection() && Info.ParentType != string.Empty)) &&
        !selfLoad1;

    if (Info.CriteriaObjects.Count > 0)
    {
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (c.GetOptions.DataPortal)
            {
                string strGetInvokeParams = string.Empty;
                string strGetComment = string.Empty;
                bool getIsFirst = true;

                if (usesDTO)
                {
                    if (c.Properties.Count == 1)
                        strGetComment = "/// <param name=\"" + FormatCamel(c.Properties[0].Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(c.Properties[0].Name) + ".</param>";
                    if (c.Properties.Count > 1)
                        strGetInvokeParams = SendMultipleCriteria(c, "crit");
                }
                else
                {
                    foreach (CriteriaProperty p in c.Properties)
                    {
                        if (!getIsFirst)
                        {
                            strGetInvokeParams += ", ";
                            strGetComment += System.Environment.NewLine + new string(' ', 8);
                        }
                        else
                            getIsFirst = false;

                        strGetInvokeParams += "crit." + FormatPascal(p.Name);
                        strGetComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
                    }
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
                    %>
        protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit)
        {
            <%
                }
                else if (c.Properties.Count > 0)
                {
                    %>
        protected void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)
        {
            <%
                }
                else
                {
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
                string hookArgs = string.Empty;
                if (c.Properties.Count > 1)
                {
                    hookArgs = "crit";
                }
                else if (c.Properties.Count > 0)
                {
                    hookArgs = HookSingleCriteria(c, "crit");
                }
                %>
            var args = new DataPortalHookArgs(<%= hookArgs %>);
            OnFetchPre(args);
            using (var dalManager = DalFactory<%= GetDalNameDot(CurrentUnit) %>GetManager())
            {
                var dal = dalManager.GetProvider<I<%= Info.ObjectName %>Dal>();
                var data = dal.Fetch(<%= strGetInvokeParams %>);
                <%
                if (usesDTO)
                {
                    %>
                Fetch(data);
                <%
                    if (itemInfo != null)
                    {
                        if (ParentLoadsCollectionChildren(itemInfo))
                        {
                            %>
                LoadCollection(dal);
                <%
                        }
                    }
                }
                else
                {
                    %>
                LoadCollection(data);
                <%
                }
                %>
            }
            OnFetchPost(args);
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
            if (usesDTO)
            {
                if (itemInfo != null)
                {
                    if (ParentLoadsCollectionChildren(itemInfo))
                    {
                        %>

        private void LoadCollection(I<%= Info.ObjectName %>Dal dal)
        {
            if (this.Count > 0)
                this[0].FetchChildren(dal);
        }
        <%
                    }
                }
            }
            else
            {
            %>

        private void LoadCollection(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
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
        }
    }
    %>

        /// <summary>
        /// Loads all <see cref="<%= Info.ObjectName %>"/> collection items from the given <%= usesDTO ? ("list of " + Info.ItemType + "Dto") : "SafeDataReader" %>.
        /// </summary>
        <%
        if (usesDTO)
        {
            %>
        /// <param name="data">The list of <see cref="<%= Info.ItemType %>Dto"/>.</param>
        <%
        }
        else
        {
            %>
        /// <param name="dr">The SafeDataReader to use.</param>
        <%
        }
        %>
        private void <%= (isChildCollection && !UseChildFactoryHelper ? "Child_" : "") %>Fetch(<%= usesDTO ? ("List<" + Info.ItemType + "Dto> data") : "SafeDataReader dr" %>)
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
    if (!Info.HasGetCriteria && Info.ParentType != string.Empty && !selfLoad1)
    {
        %>
            var args = new DataPortalHookArgs(<%= usesDTO ? "data" : "dr" %>);
            OnFetchPre(args);
            <%
    }
    %>
            <%= usesDTO ? "foreach (var dto in data)" : "while (dr.Read())" %>
            {
                <%
    if (UseChildFactoryHelper)
    {
        %>
                Add(<%= Info.ItemType %>.Get<%= Info.ItemType %>(<%= usesDTO ? "dto" : "dr" %>));
            <%
    }
    else
    {
        %>
                Add(DataPortal.Fetch<%= TypeHelper.IsNotRootType(itemInfo) ? "Child" : "" %><<%= Info.ItemType %>>(<%= usesDTO ? "dto" : "dr" %>));
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
        foreach (Property prop in itemInfo.ParentProperties)
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
%>
