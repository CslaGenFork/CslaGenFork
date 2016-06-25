<%
if (usesDTO && ancestorLoaderLevel == 0)
{
    bool writeSeparatorLine = false;
    CslaObjectInfo currentInfo = Info;
    if (IsCollectionType(currentInfo.ObjectType))
    {
        currentInfo = Info.Parent.CslaObjects.Find(Info.ItemType);
    }
    foreach (ChildProperty childProp in currentInfo.GetAllChildProperties())
    {
        if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
        {
            CslaObjectInfo _child = FindChildInfo(currentInfo, childProp.TypeName);
            if (_child != null)
            {
                if (IsCollectionType(_child.ObjectType))
                {
                    if (ancestorIsCollection)
                    {
                        CslaObjectInfo child = FindChildInfo(currentInfo, childProp.TypeName);
                        if (child != null)
                        {
                            ChildProperty ancestorChildProperty = new ChildProperty();
                            CslaObjectInfo _parent = child.FindMyParent(child);
                            if (_parent != null)
                            {
                                writeSeparatorLine = true;
                                %>
        private List<<%= FormatPascal(_child.ItemType) %>Dto> <%= FormatFieldName(childProp.TypeName) %> = new List<<%= FormatPascal(_child.ItemType) %>Dto>();
        <%
                            }
                        }
                    }
                    else if (!ancestorIsCollection)
                    {
                        writeSeparatorLine = true;
                        %>
        private List<<%= FormatPascal(_child.ItemType) %>Dto> <%= FormatFieldName(childProp.TypeName) %> = new List<<%= FormatPascal(_child.ItemType) %>Dto>();
        <%
                    }
                }
                else if (ancestorIsCollection)
                {
                    CslaObjectInfo child = FindChildInfo(currentInfo, childProp.TypeName);
                    if (child != null)
                    {
                        writeSeparatorLine = true;
                        %>
        private List<<%= FormatPascal(_child.ObjectName) %>Dto> <%= FormatFieldName(_child.ObjectName) %> = new List<<%= FormatPascal(_child.ObjectName) %>Dto>();
        <%
                    }
                }
                else
                {
                    CslaObjectInfo child = FindChildInfo(currentInfo, childProp.TypeName);
                    if (child != null)
                    {
                        writeSeparatorLine = true;
                        %>
        private <%= FormatPascal(childProp.TypeName) %>Dto <%= FormatFieldName(childProp.TypeName) %> = new <%= FormatPascal(childProp.TypeName) %>Dto();
        <%
                    }
                }
            }
        }
    }
    foreach (ChildProperty childProp in GetParentLoadAllGrandChildPropertiesInHierarchy(currentInfo, true))
    {
        if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
        {
            bool childAncestorIsCollection = false;
            int childAncestorLoaderLevel = 0;
            CslaObjectInfo _child = FindChildInfo(currentInfo, childProp.TypeName);
            if (_child != null)
            {
                childAncestorLoaderLevel = AncestorLoaderLevel(_child, out childAncestorIsCollection);
                ChildProperty ancestorChildProperty = new ChildProperty();
                CslaObjectInfo _parent = _child.FindMyParent(_child);
                if (childAncestorLoaderLevel < 4 && _parent != null)
                {
                    CslaObjectInfo _ancestor = _child.FindMyParent(_parent);
                    if (_ancestor != null)
                        GetChildPropertyByTypeName(_ancestor, _parent.ParentType, ref ancestorChildProperty);
                }
                if (IsCollectionType(_child.ObjectType))
                {
                    writeSeparatorLine = true;
                    %>
        private List<<%= FormatPascal(_child.ItemType) %>Dto> <%= FormatFieldName(childProp.TypeName) %> = new List<<%= FormatPascal(_child.ItemType) %>Dto>();
        <%
                }
                else
                {
                    writeSeparatorLine = true;
                    %>
        private List<<%= FormatPascal(_child.ObjectName) %>Dto> <%= FormatFieldName(_child.ObjectName) %> = new List<<%= FormatPascal(_child.ObjectName) %>Dto>();
        <%
                }
            }
        }
    }
    if (writeSeparatorLine)
        Response.Write(Environment.NewLine);
}
%>
