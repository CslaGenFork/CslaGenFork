<%
if (!Info.UseCustomLoading && !Info.DataSetLoadingScheme)
{
    string fetchString = string.Empty;
    string methodFetchString = string.Empty;
    if (IsNotRootType(Info) && !useChildFactory)
        methodFetchString = "Child_";
    if (Info.ObjectType == CslaObjectType.DynamicEditableRoot && !useChildFactory)
        methodFetchString = "DataPortal_";

    %>

        /// <summary>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void <%= methodFetchString %>Fetch(SafeDataReader dr)
        {
            // Value properties
            <%
        foreach (ValueProperty prop in Info.GetAllValueProperties())
        {
            if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly)
            {
                try
                {
                    %><%= GetReaderAssignmentStatement(Info, prop) %>;
            <%
                }
                catch (Exception ex)
                {
                    Errors.Append(ex.Message + Environment.NewLine);
                }
            }
        }

        bool isRoot = IsRootType(Info);
        bool isRootLoader = (ancestorLoaderLevel == 0 && !ancestorIsCollection) || (ancestorLoaderLevel == 1 && ancestorIsCollection);

        // parent loading field
        if (useFieldForParentLoading)
        {
            foreach(Property prop in Info.ParentProperties)
            {
                %><%= FormatCamel(GetFKColumn(Info, (isItem ? grandParentInfo : parentInfo), prop)) %> = dr.<%= GetReaderMethod(prop.PropertyType) %>("<%= GetFKColumn(Info, (isItem ? grandParentInfo : parentInfo), prop) %>");
            <%
            }
        }
        if (plainConvertProperties.Count > 0)
        {
            %>ConvertPropertiesOnRead();
            <%
        }
            %>var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        <%
        if (ancestorLoaderLevel > 0 && !useChildFactory)
        {
            foreach (ChildProperty childProp in Info.GetCollectionChildProperties())
            {
                CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                if (_child != null)
                {
                    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                    {
                        string internalCreateString = string.Empty;
                        if (IsEditableType(_child.ObjectType))
                        {
                            if (useChildFactory)
                                internalCreateString = FormatPascal(childProp.TypeName) + ".New" + FormatPascal(childProp.TypeName);
                            else
                                internalCreateString = "DataPortal.CreateChild<" + FormatPascal(childProp.TypeName) + ">";
                        }
                        else
                            internalCreateString = "new " + childProp.TypeName;

                        if ((childProp.DeclarationMode == PropertyDeclaration.Managed ||
                            childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion))
                        {
                            if (useBypassPropertyChecks && false) // disable this for now
                            {
                                %>
                <%= FormatPascal(childProp.Name) %> = <%= internalCreateString %>();
            <%
                            }
                            else
                            {
                                %>
            LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= internalCreateString %>());
        <%
                            }
                        }
                        else
                        {
                            %>
            <%= bpcSpacer %><%= GetFieldLoaderStatement(childProp, internalCreateString + "()") %>;
        <%
                        }
                    }
                }
            }
        }
        if (!useChildFactory && Info.CheckRulesOnFetch && (!isRoot || Info.ObjectType == CslaObjectType.DynamicEditableRoot))
        {
            %>
            // check all object rules and property rules
            BusinessRules.CheckRules();
        <%
        }
        %>
        }
        <%
        if (ParentLoadsChildren(Info))
        {
            if (isRootLoader)
            {
                %>

        /// <summary>
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        <%= isRoot ? "private" : "internal" %> void FetchChildren(SafeDataReader dr)
        {
            <%
                if (useBypassPropertyChecks)
                {
                    %>
            using (BypassPropertyChecks)
            {
            <%
                }
                foreach (ChildProperty childProp in Info.GetAllChildProperties())
                {
                    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                    {
                        CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                        if (_child != null)
                        {
                            %>
            <%= bpcSpacer %>dr.NextResult();
<%
                            if (useChildFactory)
                                fetchString = FormatPascal(childProp.TypeName) + ".Get" + FormatPascal(childProp.TypeName);
                            else
                                fetchString = "DataPortal.FetchChild<" + FormatPascal(childProp.TypeName) + ">";

                            if (IsCollectionType(_child.ObjectType))
                            {
                                if (ancestorLoaderLevel == 1 && ancestorIsCollection)
                                {
                                    CslaObjectInfo child = FindChildInfo(Info, childProp.TypeName);
                                    if (child != null)
                                    {
                                        ChildProperty ancestorChildProperty = new ChildProperty();
                                        CslaObjectInfo _parent = child.FindParent(child);
                                        if (_parent != null)
                                        {
                                            %>
            <%= bpcSpacer %>var <%= FormatCamel(childProp.TypeName) %> = <%= fetchString %>(dr);
<%
                                            if (child.ObjectType == CslaObjectType.ReadOnlyCollection)
                                            {
                                                %>
            <%= bpcSpacer %><%= FormatCamel(childProp.TypeName) %>.LoadItems(ParentList);
<%
                                            }
                                            else
                                            {
                                                %>
            <%= bpcSpacer %><%= FormatCamel(childProp.TypeName) %>.LoadItems((<%= FormatPascal(_parent.ParentType) %>)Parent);
<%
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if ((childProp.DeclarationMode == PropertyDeclaration.Managed ||
                                        childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion))
                                    {
                                        if (useBypassPropertyChecks)
                                        {
                                            %>
                <%= FormatPascal(childProp.Name) %> = <%= fetchString %>(dr);
            <%
                                        }
                                        else
                                        {
                                            %>
            LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= fetchString %>(dr));
        <%
                                        }
                                    }
                                    else
                                    {
                                        %>
            <%= bpcSpacer %><%= GetFieldLoaderStatement(childProp, fetchString + "(dr)") %>;
        <%
                                    }
                                }
                            }
                            else if (ancestorLoaderLevel == 1 && ancestorIsCollection)
                            {
                                string findByParams = string.Empty;
                                bool firstFind = true;
                                foreach (Property prop in _child.ParentProperties)
                                {
                                    if (firstFind)
                                        firstFind = false;
                                    else
                                        findByParams += ", ";

                                    findByParams += "child." + FormatCamel(GetFKColumn(_child, Info, prop));
                                }
                                CslaObjectInfo child = FindChildInfo(Info, childProp.TypeName);
                                if (child != null)
                                {
                                    %>
            <%= bpcSpacer %>while (dr.Read())
            <%= bpcSpacer %>{
                <%= bpcSpacer %>var child = <%= fetchString %>(dr);
<%
                                    if (child.ObjectType == CslaObjectType.ReadOnlyObject)
                                    {
                                        %>
                <%= bpcSpacer %>var obj = ParentList.Find<%= FormatPascal(Info.ObjectName) %>ByParentProperties(<%= findByParams %>);
<%
                                    }
                                    else
                                    {
                                        %>
                <%= bpcSpacer %>var obj = ((<%= Info.ParentType %>)Parent).Find<%= FormatPascal(Info.ObjectName) %>ByParentProperties(<%= findByParams %>);
<%
                                    }
                                    if (child.ObjectType == CslaObjectType.ReadOnlyObject && child.AddParentReference)
                                    {
                                        %>
                <%= bpcSpacer %>child.ParentList = obj;
<%
                                    }
                                    if (childProp.DeclarationMode == PropertyDeclaration.Managed ||
                                        childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                                    {
                                        if (useBypassPropertyChecks)
                                        {
                                            %>
                    obj.<%= FormatPascal(childProp.Name) %> = child;
            <%
                                        }
                                        else
                                        {
                                            %>
                obj.LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, child);
            <%
                                        }
                                    }
                                    else
                                    {
                                        %>
                obj.<%= GetFieldLoaderStatement(childProp, "child") %>;
            <%
                                    }
                                }
                                %>
            <%= bpcSpacer %>}
<%
                            }
                            else
                            {
                                %>
            <%= bpcSpacer %>if (dr.Read())
<%
                                CslaObjectInfo child = FindChildInfo(Info, childProp.TypeName);
                                if (child != null)
                                {
                                    if (child.ObjectType == CslaObjectType.ReadOnlyObject && child.AddParentReference)
                                    {
                                        %>
            <%= bpcSpacer %>{
                <%= bpcSpacer %>var child = <%= fetchString %>(dr);
                <%= bpcSpacer %>child.Parent = this;
<%
                                        if (childProp.DeclarationMode == PropertyDeclaration.Managed ||
                                            childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                                        {
                                            if (useBypassPropertyChecks)
                                            {
                                                %>
                    <%= FormatPascal(childProp.Name) %> = child;
            <%
                                            }
                                            else
                                            {
                                                %>
                LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, child);
            <%
                                            }
                                        }
                                        else
                                        {
                                            %>
                <%= GetFieldLoaderStatement(childProp, "child") %>;
            <%
                                        }
                                        %>
            <%= bpcSpacer %>}
            <%
                                    }
                                    else
                                    {
                                        if (childProp.DeclarationMode == PropertyDeclaration.Managed ||
                                            childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                                        {
                                            if (useBypassPropertyChecks)
                                            {
                                                %>
                    <%= FormatPascal(childProp.Name) %> = <%= fetchString %>(dr);
            <%
                                            }
                                            else
                                            {
                                                %>
                LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= fetchString %>(dr));
            <%
                                            }
                                        }
                                        else
                                        {
                                            %>
                <%= GetFieldLoaderStatement(childProp, fetchString + "(dr)") %>;
            <%
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (ChildProperty childProp in GetParentLoadAllGrandChildPropertiesInHierarchy(Info, true))
                {
                    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                    {
                        bool childAncestorIsCollection = false;
                        int childAncestorLoaderLevel = 0;
                        CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                        if (_child != null)
                        {
                            if (useChildFactory)
                                fetchString = FormatPascal(childProp.TypeName) + ".Get" + FormatPascal(childProp.TypeName);
                            else
                                fetchString = "DataPortal.FetchChild<" + FormatPascal(childProp.TypeName) + ">";

                            childAncestorLoaderLevel = AncestorLoaderLevel(_child, out childAncestorIsCollection);
                            ChildProperty ancestorChildProperty = new ChildProperty();
                            CslaObjectInfo _parent = _child.FindParent(_child);
                            if (childAncestorLoaderLevel < 4 && _parent != null)
                            {
                                CslaObjectInfo _ancestor = _child.FindParent(_parent);
                                if (_ancestor != null)
                                    GetChildPropertyByTypeName(_ancestor, _parent.ParentType, ref ancestorChildProperty);
                            }
                            %>
            <%= bpcSpacer %>dr.NextResult();
            <%
                            if (IsCollectionType(_child.ObjectType))
                            {
                                %>
            <%= bpcSpacer %>var <%= FormatCamel(childProp.TypeName) %> = <%= fetchString %>(dr);
            <%= bpcSpacer %><%= FormatCamel(childProp.TypeName) %>.LoadItems(<%= childAncestorLoaderLevel < 4 ? FormatPascal(ancestorChildProperty.Name) : FormatCamel(_parent.ParentType) %>);
<%
                            }
                            else
                            {
                                string findByParams = string.Empty;
                                bool firstFind = true;
                                foreach (Property prop in _child.ParentProperties)
                                {
                                    if (firstFind)
                                        firstFind = false;
                                    else
                                        findByParams += ", ";

                                    findByParams += "child." + FormatCamel(GetFKColumn(_child, _parent, prop));
                                }
                                string findByObject = string.Empty;
                                if (childAncestorLoaderLevel < 4)
                                    findByObject = FormatPascal(ancestorChildProperty.Name);
                                else
                                    findByObject = FormatCamel(_parent.ParentType);

                                %>
            <%= bpcSpacer %>while (dr.Read())
            <%= bpcSpacer %>{
                <%= bpcSpacer %>var child = <%= fetchString %>(dr);
                <%= bpcSpacer %>var obj = <%= findByObject %>.Find<%= FormatPascal(_parent.ObjectName) %>ByParentProperties(<%= findByParams %>);
<%
                                    if (_child.ObjectType == CslaObjectType.ReadOnlyObject && _child.AddParentReference)
                                    {
                                        %>
                <%= bpcSpacer %>child.Parent = obj;
<%
                                    }
                                    %>
                <%= bpcSpacer %>obj.LoadChild(child);
            <%= bpcSpacer %>}
        <%
                            }
                        }
                    }
                }

                if (useBypassPropertyChecks)
                {
                    %>
            }
            <%
                }
                %>
        }
        <%
            }
            else // !isRootLoader
            {
                foreach (ChildProperty childProp in Info.GetNonCollectionChildProperties())
                {
                    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                    {
                        CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                        if (_child != null)
                        {
                        %>

        /// <summary>
        /// Loads child <see cref="<%= FormatPascal(childProp.TypeName) %>"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(<%= FormatPascal(childProp.TypeName) %> child)
        {
<%
                            if (useBypassPropertyChecks)
                            {
                                %>
            using (BypassPropertyChecks)
            {
                <%= FormatPascal(childProp.Name) %> = child;
            }
            <%
                            }
                            else
                            {
                                %>
            LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, child);
            <%
                            }
                            %>
        }
        <%
                        }
                    }
                }
            }
        }

        if (SelfLoadsChildren(Info))
        {
            %>

        /// <summary>
        /// Loads child objects.
        /// </summary>
        <%= isRoot ? "private" : "internal" %> void FetchChildren()
        {
            <%
            if (useBypassPropertyChecks)
            {
                %>
            using (BypassPropertyChecks)
            {
            <%
            }
            foreach (ChildProperty childProp in Info.GetMyChildProperties())
            {
                if (childProp.LoadingScheme == LoadingScheme.SelfLoad && !childProp.LazyLoad)
                {
                    CslaObjectInfo childInfo = FindChildInfo(Info, childProp.TypeName);
                    if (childInfo != null)
                    {
                        string invokeParam = string.Empty;
                        bool first1 = true;
                        //if (isParentRootCollection)
                        if (isItem)
                        {
                            foreach (Property prop in childProp.ParentLoadProperties)
                            {
                                if (first1)
                                    first1 = false;
                                else
                                    invokeParam += ", ";

                                invokeParam += FormatPascal(prop.Name);
                            }
                        }
                        else
                        {
                            foreach (Parameter parm in childProp.LoadParameters)
                            {
                                if (first1)
                                    first1 = false;
                                else
                                    invokeParam += ", ";

                                invokeParam += FormatPascal(parm.Property.Name);
                            }
                        }
                        if (useChildFactory)
                            fetchString = FormatPascal(childProp.TypeName) + ".Get" + FormatPascal(childProp.TypeName);
                        else
                            fetchString = "DataPortal.FetchChild<" + FormatPascal(childProp.TypeName) + ">";

                        if (childProp.DeclarationMode == PropertyDeclaration.Managed)
                        {
                            if (useBypassPropertyChecks)
                            {
                                %>
                <%= FormatPascal(childProp.Name) %> = <%= fetchString %>(<%= invokeParam %>);
                <%
                            }
                            else
                            {
                                %>
            <%= bpcSpacer %>LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= fetchString %>(<%= invokeParam %>));
            <%
                            }
                        }
                        else if (childProp.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                            childProp.DeclarationMode == PropertyDeclaration.AutoProperty)
                        {
                            %>
            <%= bpcSpacer %><%= GetFieldLoaderStatement(childProp, fetchString +"(" + invokeParam + ")") %>;
            <%
                        }
                    }
                }
            }
            if (useBypassPropertyChecks)
            {
                %>
            }
            <%
            }
            %>
        }
        <%
    }
}
%>
