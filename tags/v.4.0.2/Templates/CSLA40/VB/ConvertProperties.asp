<%
// Check there is something to convert or else skip over
if (Info.ConvertValueProperties.Count > 0)
{
    if (!genOptional)
    {
        Response.Write(Environment.NewLine);
    }
    genOptional = true;
    %>
        #region Convert Properties
        // todo: validation template must check both properties exist on this object

        /// <summary>
        /// Update property value converting other property on Fetch/Read<%= Info.SupportUpdateProperties ? "/UpdateOnSaved" : "" %>.
        /// </summary>
        private void ConvertPropertiesOnRead()
        {
            <%
    foreach (ConvertValueProperty prop in Info.ConvertValueProperties)
    {
        if (!string.IsNullOrEmpty(prop.NVLConverter))
        {
            %>
            <%= GetFieldLoaderStatement(Info, prop, prop.NVLConverter + ".Value(" + GetFieldReaderStatement(GetSourceValueProperty(Info, prop)) + ")") %>;
                <%
        }
    }
    %>
        }
        <%
    if (Info.ObjectType == CslaObjectType.EditableRoot ||
        Info.ObjectType == CslaObjectType.DynamicEditableRoot ||
        Info.ObjectType == CslaObjectType.EditableSwitchable ||
        Info.ObjectType == CslaObjectType.EditableChild)
    {
        %>

        /// <summary>
        /// Update property value converting other property on Update/Insert/Write.
        /// </summary>
        private void ConvertPropertiesOnWrite()
        {
            <%
        foreach (ConvertValueProperty prop in Info.ConvertValueProperties)
        {
            if (!string.IsNullOrEmpty(prop.NVLConverter))
            {
                %>
            <%= GetFieldLoaderStatement(Info, GetSourceValueProperty(Info, prop), prop.NVLConverter + ".Key("+ GetFieldReaderStatement(prop) + ")") %>;
                <%
            }
        }
        %>
        }
        <%
    }
    %>

        #endregion

<%
}
%>
