<%
if (!Info.UseCustomLoading && !Info.DataSetLoadingScheme)
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

                if (usesDalCriteria)
                {
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

                        strGetCritParams += p.Name;
                        strGetInvokeParams += "crit." + FormatPascal(p.Name);
                        strGetComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
                    }

                    if (c.Properties.Count > 1)
                    {
                        strGetCritParams = "new " + c.Name + "(" + strGetCritParams + ")";
                    }
                    else if (c.Properties.Count > 0)
                    {
                        strGetCritParams = SendSingleCriteria(c, strGetCritParams);
                    }
                }
                else
                {
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
            using (var dalManager = DalFactory<%= GetConnectionName(CurrentUnit) %>.GetManager())
            {
                var dal = dalManager.GetProvider<I<%= Info.ObjectName %>Dal>();
                var data = dal.Fetch(<%= strGetInvokeParams %>);
                LoadCollection(data);
            }
            OnFetchPost(args);
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
            %>

        private void LoadCollection(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
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
    }
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
%>
