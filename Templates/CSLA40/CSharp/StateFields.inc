<% if (StateFieldsForAllValueProperties(Info) || StateFieldsForAllChildProperties(Info)) { %>

        #region State Fields

<%
        // Value Properties
        foreach (ValueProperty prop in Info.AllValueProperties) {
            string statement = FieldDeclare(prop);
            if (!string.IsNullOrEmpty(statement)) { %>
        <%= statement %>
<%          }
        }

        // if the object has child properties, then add a new line
        if (StateFieldsForAllValueProperties(Info) && StateFieldsForAllChildProperties(Info)) { %><%= "\r\n" %><% }

        // Child Properties
        foreach (ChildProperty prop in Info.AllChildProperties) { if (prop.DeclarationMode == PropertyDeclaration.Unmanaged || prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion || prop.DeclarationMode == PropertyDeclaration.ClassicProperty || prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion) {
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
        [NotUndoable]
        <% } %>
        private <%=prop.TypeName%> <%=FormatFieldName(prop.Name)%><% if (_child.ObjectType != CslaObjectType.ReadOnlyObject && _child.ObjectType != CslaObjectType.ReadOnlyCollection && !_fieldParentReference) { %> = <%=prop.TypeName%>.New<%=prop.TypeName%>()<% } %>;
        <%  if (prop.LazyLoad) { %>
        private bool <%=FormatFieldName(prop.Name + "Loaded")%> = false;<%= "\r\n" %><% }
            }
            //}
        } %>
        #endregion
<% } %>