<%
CslaObjectInfo currentInfo = Info;
CslaObjectInfo childParentInfo;
CslaObjectInfo childGrandParentInfo;
if (isCollection)
    currentInfo = itemInfo;
int childAncestorLoaderLevel;
bool childAncestorIsCollection;
bool childIsItem;
bool parentIsCollection;
%>

        private void FetchChildren(SafeDataReader dr)
        {
            <%
foreach (ChildProperty childProp in currentInfo.GetAllChildProperties())
{
    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
    {
        CslaObjectInfo _child = FindChildInfo(currentInfo, childProp.TypeName);
        if (_child != null)
        {
            %>
            dr.NextResult();
<%
            if (IsCollectionType(_child.ObjectType))
            {
                %>
            while (dr.Read())
            {
                <%= FormatFieldName(_child.ObjectName) %>.Add(Fetch<%= _child.ItemType %>(dr));
            }
            <%
            }
            else
            {
                %>
            if (dr.Read())
                Fetch<%= _child.ObjectName %>(dr);
            <%
            }
        }
    }
}

foreach (ChildProperty childProp in GetParentLoadAllGrandChildPropertiesInHierarchy(currentInfo, true))
{
    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
    {
        CslaObjectInfo _child = FindChildInfo(currentInfo, childProp.TypeName);
        if (_child != null)
        {
            %>
            dr.NextResult();
<%
            if (IsCollectionType(_child.ObjectType))
            {
                %>
            while (dr.Read())
            {
                <%= FormatFieldName(_child.ObjectName) %>.Add(Fetch<%= _child.ItemType %>(dr));
            }
            <%
            }
            else
            {
                %>
            if (dr.Read())
                Fetch<%= _child.ObjectName %>(dr);
            <%
            }
        }
    }
}
        %>
        }
<%

foreach (ChildProperty childProp in currentInfo.GetAllChildProperties())
{
    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
    {
        CslaObjectInfo _child = FindChildInfo(currentInfo, childProp.TypeName);
        parentIsCollection = IsCollectionType(_child.ObjectType);
        if (IsCollectionType(_child.ObjectType))
            _child = FindChildInfo(_child, _child.ItemType);
        if (_child != null)
        {
            %>

        private <%= parentIsCollection ? _child.ObjectName + "Dto" : "void" %> Fetch<%= _child.ObjectName %>(SafeDataReader dr)
        {
            <%
            if (parentIsCollection)
            {
                %>
            var <%= FormatCamel(_child.ObjectName) %> = new <%= _child.ObjectName %>Dto();
            <%
            }
            %>
            // Value properties
            <%
            foreach (ValueProperty prop in _child.GetAllValueProperties())
            {
                if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                    prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly)
                {
                    try
                    {
                        %>
            <%= parentIsCollection ? FormatCamel(_child.ObjectName) : FormatFieldName(_child.ObjectName) %>.<%= FormatProperty(prop) %> = <%= GetDataReaderStatement(prop) %>;
            <%
                    }
                    catch (Exception ex)
                    {
                        Errors.Append(ex.Message + Environment.NewLine);
                    }
                }
            }

            childAncestorLoaderLevel = AncestorLoaderLevel(_child, out childAncestorIsCollection);
            // parent loading field
            bool useFieldForParentLoading2 = (((childAncestorLoaderLevel > 2 && !childAncestorIsCollection) ||
                (childAncestorLoaderLevel > 1 && childAncestorIsCollection)) && _child.ParentProperties.Count > 0);
            if (useFieldForParentLoading2)
            {
                childParentInfo = Info.Parent.CslaObjects.Find(_child.ParentType);
                childGrandParentInfo = Info.Parent.CslaObjects.Find(childParentInfo.ParentType);
                childIsItem = IsCollectionType(childParentInfo.ObjectType);
                %>
            // parent properties
            <%
                foreach(Property prop in _child.ParentProperties)
                {
                    %>
            <%= parentIsCollection ? FormatCamel(_child.ObjectName) : FormatFieldName(_child.ObjectName) %>.Parent_<%= FormatPascal(GetFKColumn(_child, (childIsItem ? childGrandParentInfo : childParentInfo), prop)) %> = dr.<%= GetReaderMethod(prop.PropertyType) %>("<%= GetFKColumn(_child, (childIsItem ? childGrandParentInfo : childParentInfo), prop) %>");
            <%
                }
            }
            if (parentIsCollection)
            {
                %>

            return <%= FormatCamel(_child.ObjectName) %>;
            <%
            }
            %>
        }
<%
        }
    }
}

foreach (ChildProperty childProp in GetParentLoadAllGrandChildPropertiesInHierarchy(currentInfo, true))
{
    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
    {
        CslaObjectInfo _child = FindChildInfo(currentInfo, childProp.TypeName);
        parentIsCollection = IsCollectionType(_child.ObjectType);
        if (IsCollectionType(_child.ObjectType))
            _child = FindChildInfo(_child, _child.ItemType);
        if (_child != null)
        {
            %>

        private <%= _child.ObjectName %>Dto Fetch<%= _child.ObjectName %>(SafeDataReader dr)
        {
            var <%= FormatCamel(_child.ObjectName) %> = new <%= _child.ObjectName %>Dto();
            // Value properties
            <%
            foreach (ValueProperty prop in _child.GetAllValueProperties())
            {
                if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                    prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly)
                {
                    try
                    {
                        %>
            <%= parentIsCollection ? FormatCamel(_child.ObjectName) : FormatFieldName(_child.ObjectName) %>.<%= FormatProperty(prop) %> = <%= GetDataReaderStatement(prop) %>;
            <%
                    }
                    catch (Exception ex)
                    {
                        Errors.Append(ex.Message + Environment.NewLine);
                    }
                }
            }

            childAncestorLoaderLevel = AncestorLoaderLevel(_child, out childAncestorIsCollection);
            // parent loading field
            bool useFieldForParentLoading2 = (((childAncestorLoaderLevel > 2 && !childAncestorIsCollection) ||
                (childAncestorLoaderLevel > 1 && childAncestorIsCollection)) && _child.ParentProperties.Count > 0);
            if (useFieldForParentLoading2)
            {
                childParentInfo = Info.Parent.CslaObjects.Find(_child.ParentType);
                childGrandParentInfo = Info.Parent.CslaObjects.Find(childParentInfo.ParentType);
                childIsItem = IsCollectionType(childParentInfo.ObjectType);
                %>
            // parent properties
            <%
                foreach(Property prop in _child.ParentProperties)
                {
                    %>
            <%= parentIsCollection ? FormatCamel(_child.ObjectName) : FormatFieldName(_child.ObjectName) %>.Parent_<%= FormatPascal(GetFKColumn(_child, (childIsItem ? childGrandParentInfo : childParentInfo), prop)) %> = dr.<%= GetReaderMethod(prop.PropertyType) %>("<%= GetFKColumn(_child, (childIsItem ? childGrandParentInfo : childParentInfo), prop) %>");
            <%
                }
            }
            if (parentIsCollection)
            {
                %>

            return <%= FormatCamel(_child.ObjectName) %>;
            <%
            }
            %>
        }
<%
        }
    }
}

%>
