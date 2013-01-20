<%
if (usesDTO)
{
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
                    if (ancestorLoaderLevel == 0 && ancestorIsCollection)
                    {
                        CslaObjectInfo child = FindChildInfo(universalInfo, childProp.TypeName);
                        if (child != null)
                        {
                            ChildProperty ancestorChildProperty = new ChildProperty();
                            CslaObjectInfo _parent = child.FindParent(child);
                            if (_parent != null)
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
                    }
                    else if (!ancestorIsCollection)
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
                else if (ancestorLoaderLevel == 0 && ancestorIsCollection)
                {
                    CslaObjectInfo child = FindChildInfo(universalInfo, childProp.TypeName);
                    if (child != null)
                    {
                        %>
        /// <summary>
        /// Gets the <%= childProp.FriendlyName != String.Empty ? childProp.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(childProp.Name) %>.
        /// </summary>
        /// <value>A list of <see cref="<%= FormatPascal(_child.ObjectName) %>Dto"/>.</value>
        List<<%= FormatPascal(_child.ObjectName) %>Dto> <%= FormatPascal(_child.ObjectName) %> { get; }

<%
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
        /// <summary>
        /// Gets the <%= childProp.FriendlyName != String.Empty ? childProp.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(childProp.Name) %>.
        /// </summary>
        /// <value>A list of <see cref="<%= FormatPascal(_child.ItemType) %>Dto"/>.</value>
        List<<%= FormatPascal(_child.ItemType) %>Dto> <%= FormatPascal(childProp.TypeName) %> { get; }

<%
                }
                else
                {
                    %>
        /// <summary>
        /// Gets the <%= childProp.FriendlyName != String.Empty ? childProp.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(childProp.Name) %>.
        /// </summary>
        /// <value>A list of <see cref="<%= FormatPascal(_child.ObjectName) %>Dto"/>.</value>
        List<<%= FormatPascal(_child.ObjectName) %>Dto> <%= FormatPascal(_child.ObjectName) %> { get; }

<%
                }
            }
        }
    }
}
%>
