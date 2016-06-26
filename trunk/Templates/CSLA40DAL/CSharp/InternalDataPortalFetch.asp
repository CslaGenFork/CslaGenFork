<%
if (!Info.UseCustomLoading && !Info.DataSetLoadingScheme)
{
    string fetchString = string.Empty;
    string methodFetchString = string.Empty;
    if (TypeHelper.IsNotRootType(Info) && !UseChildFactoryHelper)
        methodFetchString = "Child_";
    if (Info.ObjectType == CslaObjectType.DynamicEditableRoot && !UseChildFactoryHelper)
        methodFetchString = "DataPortal_";

    %>

        /// <summary>
        <%
        if (usesDTO)
        {
            %>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> object from the given <see cref="<%= Info.ObjectName + "Dto" %>"/>.
        <%
        }
        else
        {
            %>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> object from the given SafeDataReader.
        <%
        }
        %>
        /// </summary>
        /// <param name="<%= usesDTO ? "data" : "dr" %>">The <%= usesDTO ? (Info.ObjectName + "Dto") : "SafeDataReader" %> to use.</param>
        private void <%= methodFetchString %>Fetch(<%= usesDTO ? (Info.ObjectName + "Dto data") : "SafeDataReader dr" %>)
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

        bool isRoot = TypeHelper.IsRootType(Info);
        bool isRootLoader = (ancestorLoaderLevel == 0 && !ancestorIsCollection) || (ancestorLoaderLevel == 1 && ancestorIsCollection);

        // parent loading field
        if (useFieldForParentLoading)
        {
            %>// parent properties
            <%
            foreach(Property prop in Info.ParentProperties)
            {
                if (usesDTO)
                {
                    %><%= FormatCamel(GetFKColumn(Info, (isItem ? grandParentInfo : parentInfo), prop)) %> = data.Parent_<%= prop.Name %>;
            <%
                }
                else
                {
                    %><%= FormatCamel(GetFKColumn(Info, (isItem ? grandParentInfo : parentInfo), prop)) %> = dr.<%= GetReaderMethod(prop.PropertyType) %>("<%= GetFKColumn(Info, (isItem ? grandParentInfo : parentInfo), prop) %>");
            <%
                }
            }
        }
        // state property
        if (useIsLoadedProperty)
        {
            %>// State property
            LoadProperty(IsLoadedProperty, true);
            <%
        }
            %>var args = new DataPortalHookArgs(<%= usesDTO ? "data" : "dr" %>);
            OnFetchRead(args);
        <%
        if (ancestorLoaderLevel > 0 && !UseChildFactoryHelper)
        {
            foreach (ChildProperty childProp in Info.GetCollectionChildProperties())
            {
                CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                if (_child != null)
                {
                    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                    {
                        string internalCreateString = string.Empty;
                        if (TypeHelper.IsEditableType(_child.ObjectType))
                        {
                            if (UseChildFactoryHelper)
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
        if (!UseChildFactoryHelper && Info.CheckRulesOnFetch && !Info.EditOnDemand && (!isRoot || Info.ObjectType == CslaObjectType.DynamicEditableRoot))
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
        /// Loads child objects from the given <%= (usesDTO ? "DAL provider" : "SafeDataReader") %>.
        /// </summary>
        /// <param name="<%= (usesDTO ? "dal" : "dr") %>">The <%= (usesDTO ? "DAL provider" : "SafeDataReader") %> to use.</param>
        <%
        if (usesDTO)
        {
            %>
        <%= isRoot ? "private" : "internal" %> void FetchChildren(I<%= isRoot ? FormatPascal(Info.ObjectName) : FormatPascal(Info.ParentType) %>Dal dal)
        <%
        }
        else
        {
            %>
        <%= isRoot ? "private" : "internal" %> void FetchChildren(SafeDataReader dr)
        <%
        }
        %>
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
                            if (!usesDTO)
                            {
                                %>
            <%= bpcSpacer %>dr.NextResult();
<%
                            }
                            if (UseChildFactoryHelper)
                                fetchString = FormatPascal(childProp.TypeName) + ".Get" + FormatPascal(childProp.TypeName);
                            else
                                fetchString = "DataPortal.FetchChild<" + FormatPascal(childProp.TypeName) + ">";

                            if (TypeHelper.IsCollectionType(_child.ObjectType))
                            {
                                if (ancestorLoaderLevel == 1 && ancestorIsCollection)
                                {
                                    CslaObjectInfo child = FindChildInfo(Info, childProp.TypeName);
                                    if (child != null)
                                    {
                                        ChildProperty ancestorChildProperty = new ChildProperty();
                                        CslaObjectInfo _parent = child.FindMyParent(child);
                                        if (_parent != null)
                                        {
                                            %>
            <%= bpcSpacer %>var <%= FormatCamel(childProp.TypeName) %> = <%= fetchString %>(<%= (usesDTO ? "dal." + FormatPascal(childProp.TypeName) : "dr") %>);
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
                <%= FormatPascal(childProp.Name) %> = <%= fetchString %>(<%= (usesDTO ? "dal." + FormatPascal(childProp.TypeName) : "dr") %>);
            <%
                                        }
                                        else
                                        {
                                            %>
            LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= fetchString %>(<%= (usesDTO ? "dal." + FormatPascal(childProp.TypeName) : "dr") %>));
        <%
                                        }
                                    }
                                    else
                                    {
                                        %>
            <%= bpcSpacer %><%= GetFieldLoaderStatement(childProp, fetchString + "(" + (usesDTO ? "dal." + FormatPascal(childProp.TypeName) : "dr") + ")") %>;
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
                                if (usesDTO)
                                {
                                    %>
            <%= bpcSpacer %>foreach (var item in dal.<%= FormatPascal(childProp.TypeName) %>)
<%
                                }
                                else
                                {
                                    %>
            <%= bpcSpacer %>while (dr.Read())
<%
                                }
                                %>
            <%= bpcSpacer %>{
                <%= bpcSpacer %>var child = <%= fetchString %>(<%= usesDTO ? "item" : "dr" %>);
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
                                string drSpacer = usesDTO ? string.Empty : new string(' ', 4);
                                if (!usesDTO)
                                {
                                    %>
            <%= bpcSpacer %>if (dr.Read())
<%
                                }
                                CslaObjectInfo child = FindChildInfo(Info, childProp.TypeName);
                                if (child != null)
                                {
                                    if (child.ObjectType == CslaObjectType.ReadOnlyObject && child.AddParentReference)
                                    {
                                        if (!usesDTO)
                                        {
                                            %>
            <%= bpcSpacer %>{
<%
                                        }
                                        %>
            <%= bpcSpacer %><%= drSpacer %>var child = <%= fetchString %>(<%= usesDTO ? "dal." + FormatPascal(childProp.TypeName) : "dr" %>);
            <%= bpcSpacer %><%= drSpacer %>child.Parent = this;
<%
                                        if (childProp.DeclarationMode == PropertyDeclaration.Managed ||
                                            childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                                        {
                                            if (useBypassPropertyChecks)
                                            {
                                                %>
                <%= drSpacer %><%= FormatPascal(childProp.Name) %> = child;
            <%
                                            }
                                            else
                                            {
                                                %>
            <%= drSpacer %>LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, child);
            <%
                                            }
                                        }
                                        else
                                        {
                                            %>
            <%= drSpacer %><%= GetFieldLoaderStatement(childProp, "child") %>;
            <%
                                        }
                                        if (!usesDTO)
                                        {
                                            %>
            <%= bpcSpacer %>}
<%
                                        }
                                    }
                                    else
                                    {
                                        if (childProp.DeclarationMode == PropertyDeclaration.Managed ||
                                            childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                                        {
                                            if (useBypassPropertyChecks)
                                            {
                                                %>
                <%= drSpacer %><%= FormatPascal(childProp.Name) %> = <%= fetchString %>(<%= usesDTO ? "dal." + FormatPascal(childProp.TypeName) : "dr" %>);
            <%
                                            }
                                            else
                                            {
                                                %>
            <%= drSpacer %>LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= fetchString %>(<%= usesDTO ? "dal." + FormatPascal(childProp.TypeName) : "dr" %>));
            <%
                                            }
                                        }
                                        else
                                        {
                                            %>
            <%= drSpacer %><%= GetFieldLoaderStatement(childProp, fetchString + "(" + (usesDTO ? "dal." + FormatPascal(childProp.TypeName) : "dr") + ")") %>;
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
                            if (UseChildFactoryHelper)
                                fetchString = FormatPascal(childProp.TypeName) + ".Get" + FormatPascal(childProp.TypeName);
                            else
                                fetchString = "DataPortal.FetchChild<" + FormatPascal(childProp.TypeName) + ">";

                            childAncestorLoaderLevel = AncestorLoaderLevel(_child, out childAncestorIsCollection);
                            ChildProperty ancestorChildProperty = new ChildProperty();
                            CslaObjectInfo _parent = _child.FindMyParent(_child);
                            if (childAncestorLoaderLevel < 4 && _parent != null)
                            {
                                CslaObjectInfo _ancestor = _child.FindMyParent(_parent);
                                if (_ancestor != null)
                                    GetChildPropertyByTypeName(_ancestor, _parent.ParentType, ref ancestorChildProperty);
                            }
                            if (!usesDTO)
                            {
                                %>
            <%= bpcSpacer %>dr.NextResult();
<%
                            }
                            if (TypeHelper.IsCollectionType(_child.ObjectType))
                            {
                                %>
            <%= bpcSpacer %>var <%= FormatCamel(childProp.TypeName) %> = <%= fetchString %>(<%= usesDTO ? "dal." + FormatPascal(childProp.TypeName) : "dr" %>);
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

                                if (usesDTO)
                                {
                                    %>
            <%= bpcSpacer %>foreach (var item in dal.<%= FormatPascal(childProp.TypeName) %>)
<%
                                }
                                else
                                {
                                    %>
            <%= bpcSpacer %>while (dr.Read())
<%
                                }
                                %>
            <%= bpcSpacer %>{
                <%= bpcSpacer %>var child = <%= fetchString %>(<%= (usesDTO ? "item" : "dr") %>);
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
                        if (UseChildFactoryHelper)
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
