<%
// Check there is something to convert or else skip over
if (Info.ConvertValueProperties.Count > 0) { %>
        #region Convert Properties (must validate if both properties exist on this object)

        /// <summary>
        /// Update property value converting other property on Fetch/Read/UpdateOnSaved.
        /// </summary>
        private void ConvertPropertiesOnRead()
        {
            <% foreach (ConvertValueProperty prop in Info.ConvertValueProperties) {
                if (!string.IsNullOrEmpty(prop.NVLConverter)) { %>
            <%= GetFieldLoaderStatement(Info, prop, prop.NVLConverter + ".Value(" + GetSourceFieldReaderStatement(Info, prop) + ")") %>;
                <% } %>
            <% } %>
        }
        <% if (Info.ObjectType == CslaObjectType.EditableRoot ||
                Info.ObjectType == CslaObjectType.DynamicEditableRoot ||
                Info.ObjectType == CslaObjectType.EditableSwitchable ||
                Info.ObjectType == CslaObjectType.EditableChild) { %>

        /// <summary>
        /// Update property value converting other property on Update/Insert/Write.
        /// </summary>
        private void ConvertPropertiesOnWrite()
        {
            <% foreach (ConvertValueProperty prop in Info.ConvertValueProperties) {
                if (!string.IsNullOrEmpty(prop.NVLConverter)) { %>
            <%= GetFieldLoaderStatement(Info, prop, prop.NVLConverter + ".Key("+ GetSourceFieldReaderStatement(Info, prop) + ")") %>;
                <% } %>
            <% } %>
        }
        <% } %>

        #endregion

<% } %>
