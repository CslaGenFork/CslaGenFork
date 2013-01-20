<%
if (usesDTO)
{
    bool isFirstField = Info.ObjectType != CslaObjectType.EditableRootCollection;
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
                                if (isFirstField) { Response.Write(Environment.NewLine); isFirstField = false; }
                                %>
        private List<<%= FormatPascal(_child.ItemType) %>Dto> <%= FormatFieldName(childProp.TypeName) %> = new List<<%= FormatPascal(_child.ItemType) %>Dto>();
        <%
                            }
                        }
                    }
                    else if (!ancestorIsCollection)
                    {
                        if (isFirstField) { Response.Write(Environment.NewLine); isFirstField = false; }
                        %>
        private List<<%= FormatPascal(_child.ItemType) %>Dto> <%= FormatFieldName(childProp.TypeName) %> = new List<<%= FormatPascal(_child.ItemType) %>Dto>();
        <%
                    }
                }
                else if (ancestorLoaderLevel == 0 && ancestorIsCollection)
                {
                    CslaObjectInfo child = FindChildInfo(universalInfo, childProp.TypeName);
                    if (child != null)
                    {
                        if (isFirstField) { Response.Write(Environment.NewLine); isFirstField = false; }
                        %>
        private List<<%= FormatPascal(_child.ObjectName) %>Dto> <%= FormatFieldName(_child.ObjectName) %> = new List<<%= FormatPascal(_child.ObjectName) %>Dto>();
        <%
                    }
                }
                else
                {
                    CslaObjectInfo child = FindChildInfo(universalInfo, childProp.TypeName);
                    if (child != null)
                    {
                        if (isFirstField) { Response.Write(Environment.NewLine); isFirstField = false; }
                        %>
        private <%= FormatPascal(childProp.TypeName) %>Dto <%= FormatFieldName(childProp.TypeName) %> = new <%= FormatPascal(childProp.TypeName) %>Dto();
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
                    if (isFirstField) { Response.Write(Environment.NewLine); isFirstField = false; }
                    %>
        private List<<%= FormatPascal(_child.ItemType) %>Dto> <%= FormatFieldName(childProp.TypeName) %> = new List<<%= FormatPascal(_child.ItemType) %>Dto>();
        <%
                }
                else
                {
                    if (isFirstField) { Response.Write(Environment.NewLine); isFirstField = false; }
                    %>
        private List<<%= FormatPascal(_child.ObjectName) %>Dto> <%= FormatFieldName(_child.ObjectName) %> = new List<<%= FormatPascal(_child.ObjectName) %>Dto>();
        <%
                }
            }
        }
    }
    Response.Write(Environment.NewLine);
}
%>
