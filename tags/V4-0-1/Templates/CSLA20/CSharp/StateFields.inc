
        #region State Fields
<%
            // Value Properties
            foreach (ValueProperty prop in Info.AllValueProperties) { %><% if (!prop.Undoable) {%>
        [NotUndoable()]<% } %>
        private <%=GetDataType(prop)%> <%=FormatFieldName(prop.Name)%> = <%=GetInitValue(prop)%>;<%
            }

            // If Object has Child properties, then add new line
            if (Info.ChildProperties.Count > 0 || Info.ChildCollectionProperties.Count > 0) { %><%= "\r\n" %><% }

            // Child Properties
            foreach (ChildProperty prop in Info.GetMyChildProperties()) { %>
        <%
        CslaObjectInfo _child = FindChildInfo(Info, prop.TypeName);
        bool _fieldParentReference = false;
        if (_child == null) {
            Warnings.Append("TypeName '" + prop.TypeName + "' doesn't exist in this project." + Environment.NewLine);
        } else {
            _fieldParentReference = _child.AddParentReference;
        }

        //if (_fieldParentReference) {
        if (ActiveObjects) { %>
        [RegisterNotify("IsValid, IsDirty, BrokenRulesChanged")]
        <% }
        if (!prop.Undoable) { %>
        [NotUndoable()]
        <% } %>
        private <%=prop.TypeName%> <%=FormatFieldName(prop.Name)%><% if (_child.ObjectType != CslaObjectType.ReadOnlyObject && _child.ObjectType != CslaObjectType.ReadOnlyCollection && !_fieldParentReference) { %> = <%=prop.TypeName%>.New<%=prop.TypeName%>()<% } %>;<%
            if (prop.LazyLoad) { %>
        private bool <%=FormatFieldName(prop.Name + "Loaded")%> = false;<% }
        //}
            } %>

        #endregion
