<%
foreach (ChildProperty child in Info.GetCollectionChildProperties()) {
    CslaObjectInfo _child = FindChildInfo(Info, child.TypeName);
    if (_child != null && _child.ObjectType != CslaObjectType.ReadOnlyObject && _child.ObjectType != CslaObjectType.ReadOnlyCollection) { %>

                            // Update child Properties
                            if (<%=FormatFieldName(child.Name)%> != null)
                                <%=FormatFieldName(child.Name)%>.Update(this);
<%  }
}
foreach (ChildProperty child in Info.GetNonCollectionChildProperties()) {
    CslaObjectInfo _child = FindChildInfo(Info, child.TypeName);
    if (_child != null && _child.ObjectType != CslaObjectType.ReadOnlyObject && _child.ObjectType != CslaObjectType.ReadOnlyCollection) { %>

                            // Insert/Update child Properties
                            if (<%=FormatFieldName(child.Name)%> != null)
                            {
                                if (<%=FormatFieldName(child.Name)%>.IsNew)
                                    <%=FormatFieldName(child.Name)%>.Insert(this);
                                else
                                    <%=FormatFieldName(child.Name)%>.Update(<% if (!_child.ParentInsertOnly) { %>this<% } %>);
                            }
<%  }
} %>
