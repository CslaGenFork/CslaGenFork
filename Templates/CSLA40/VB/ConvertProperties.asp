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
    if (UseBoth())
    {
        %>
#if !SILVERLIGHT
<%
    }
    if (CurrentUnit.GenerationParams.GenerateSynchronous)
    {
        foreach (ConvertValueProperty prop in Info.ConvertValueProperties)
        {
            if (!string.IsNullOrEmpty(prop.NVLConverter))
            {
                string converter = prop.NVLConverter;
                if (converter.IndexOf(")") < 0)
                    converter += "()";
                %>
            <%= GetFieldLoaderStatement(Info, prop, converter + ".Value(" + GetFieldReaderStatement(GetSourceValueProperty(Info, prop)) + ")") %>;
                <%
            }
        }
    }
    if (UseBoth())
    {
        %>
#else
<%
    }
    if (!CurrentUnit.GenerationParams.GenerateSynchronous || UseSilverlight())
    {
        foreach (ConvertValueProperty prop in Info.ConvertValueProperties)
        {
            if (!string.IsNullOrEmpty(prop.NVLConverter))
            {
                %>

            <%= prop.NVLConverter %>((o, e) =>
                {
                    if (e.Error != null)
                        throw e.Error;
                    else
                        <%= GetFieldLoaderStatement(Info, prop, "e.Object.Value(" + GetFieldReaderStatement(GetSourceValueProperty(Info, prop)) + ")") %>;
                });
                <%
            }
        }
    }
    if (UseBoth())
    {
        %>
#endif
<%
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
    if (UseBoth())
    {
        %>
#if !SILVERLIGHT
<%
    }
    if (CurrentUnit.GenerationParams.GenerateSynchronous)
    {
        foreach (ConvertValueProperty prop in Info.ConvertValueProperties)
        {
            if (!string.IsNullOrEmpty(prop.NVLConverter))
            {
                string converter = prop.NVLConverter;
                if (converter.IndexOf(")") < 0)
                    converter += "()";
                %>
            <%= GetFieldLoaderStatement(Info, GetSourceValueProperty(Info, prop), converter + ".Key("+ GetFieldReaderStatement(prop) + ")") %>;
                <%
            }
        }
    }
    if (UseBoth())
    {
        %>
#else
<%
    }
    if (!CurrentUnit.GenerationParams.GenerateSynchronous || UseSilverlight())
    {
        foreach (ConvertValueProperty prop in Info.ConvertValueProperties)
        {
            if (!string.IsNullOrEmpty(prop.NVLConverter))
            {
                %>

            <%= prop.NVLConverter %>((o, e) =>
                {
                    if (e.Error != null)
                        throw e.Error;
                    else
                        <%= GetFieldLoaderStatement(Info, GetSourceValueProperty(Info, prop), "e.Object.Key(" + GetFieldReaderStatement(prop) + ")") %>;
                });
                <%
            }
        }
    }
    if (UseBoth())
    {
        %>
#endif
<%
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
