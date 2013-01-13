<%
if (usesDTO)
{
    string baseUsing = GetContextObjectNamespace(Info, CurrentUnit, GenerationStep.DalInterface);
    CslaObjectInfo universalInfo = Info;
    if (IsCollectionType(universalInfo.ObjectType))
    {
        universalInfo = Info.Parent.CslaObjects.Find(Info.ItemType);
    }
    foreach (ChildProperty childProp in universalInfo.GetAllChildProperties())
    {
        if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
        {
            CslaObjectInfo _child = FindChildInfo(universalInfo, childProp.TypeName);
            if (_child != null)
            {
                if (IsCollectionType(_child.ObjectType))
                {
                    if (ancestorLoaderLevel == 1 && ancestorIsCollection)
                    {
                        CslaObjectInfo child = FindChildInfo(universalInfo, childProp.TypeName);
                        if (child != null)
                        {
                            ChildProperty ancestorChildProperty = new ChildProperty();
                            CslaObjectInfo _parent = child.FindParent(child);
                            if (_parent != null)
                            {
                                %>
        List<<%= FormatPascal(_child.ItemType) %>Dto> <%= FormatPascal(childProp.TypeName) %> { get; } // (1)
        <%
                            }
                        }
                    }
                    else
                    {
                        %>
        /// <summary>
        /// Gets the <%= childProp.FriendlyName != String.Empty ? childProp.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(childProp.Name) %>.
        /// </summary>
        /// <value>A list of <see cref="<%= FormatPascal(_child.ItemType) %>Dto"/>.</value>
        List<<%= FormatPascal(_child.ItemType) %>Dto> <%= FormatPascal(childProp.TypeName) %> { get; }

<%
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

                        findByParams += "child." + FormatCamel(GetFKColumn(_child, universalInfo, prop));
                    }
                    CslaObjectInfo child = FindChildInfo(universalInfo, childProp.TypeName);
                    if (child != null)
                    {
                        if (childProp.DeclarationMode == PropertyDeclaration.Managed ||
                            childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                        {
                            %>
        obj.LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, child); (3)
        <%
                        }
                        else
                        {
                            %>
        obj.<%= GetFieldLoaderStatement(childProp, "child") %>; (4)
        <%
                        }
                    }
                }
                else
                {
                    CslaObjectInfo child = FindChildInfo(universalInfo, childProp.TypeName);
                    if (child != null)
                    {
                        %>
        /// <summary>
        /// Gets the <%= childProp.FriendlyName != String.Empty ? childProp.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(childProp.Name) %>.
        /// </summary>
        /// <value>A <see cref="<%= FormatPascal(childProp.TypeName) %>Dto"/> object.</value>
        <%= FormatPascal(childProp.TypeName) %>Dto <%= FormatPascal(childProp.TypeName) %> { get; }

<%
                    }
                }
            }
        }
    }
    foreach (ChildProperty childProp in GetParentLoadAllGrandChildPropertiesInHierarchy(universalInfo, true))
    {
        if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
        {
            bool childAncestorIsCollection = false;
            int childAncestorLoaderLevel = 0;
            CslaObjectInfo _child = FindChildInfo(universalInfo, childProp.TypeName);
            if (_child != null)
            {
                childAncestorLoaderLevel = AncestorLoaderLevel(_child, out childAncestorIsCollection);
                ChildProperty ancestorChildProperty = new ChildProperty();
                CslaObjectInfo _parent = _child.FindParent(_child);
                if (childAncestorLoaderLevel < 4 && _parent != null)
                {
                    CslaObjectInfo _ancestor = _child.FindParent(_parent);
                    if (_ancestor != null)
                        GetChildPropertyByTypeName(_ancestor, _parent.ParentType, ref ancestorChildProperty);
                }
                if (IsCollectionType(_child.ObjectType))
                {
                    %>
        <%= FormatCamel(childProp.TypeName) %> = (<%= usesDTO ? "dal." + FormatPascal(childProp.TypeName) : "dr" %>); (6)
        <%= FormatCamel(childProp.TypeName) %>.LoadItems(<%= childAncestorLoaderLevel < 4 ? FormatPascal(ancestorChildProperty.Name) : FormatCamel(_parent.ParentType) %>); (6)
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
        var obj = <%= findByObject %>.Find<%= FormatPascal(_parent.ObjectName) %>ByParentProperties(<%= findByParams %>); (7)
        <%
                }
            }
        }
    }
}
%>
