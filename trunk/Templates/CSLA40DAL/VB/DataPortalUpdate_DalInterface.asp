<%
if (Info.GenerateDataPortalUpdate)
{
    string strUpdateComment = string.Empty;
    string strUpdateCommentResult = string.Empty;
    string strUpdateParams = string.Empty;
    bool hasUpdateTimestamp = false;
    bool updateIsFirst = true;

    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            hasUpdateTimestamp = true;
            strUpdateCommentResult = "/// <returns>The updated " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</returns>";
        }

        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly ||
            (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
            prop.DataAccess == ValueProperty.DataAccessBehaviour.UpdateOnly)) ||
            prop.DbBindColumn.NativeType == "timestamp")
        {
            if (!updateIsFirst)
                strUpdateParams += ", ";
            else
                updateIsFirst = false;

            TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);

            strUpdateComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strUpdateParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
        }
    }
    %>

        /// <summary>
        /// Updates in the database all changes made to the <%= Info.ObjectName %> object.
        /// </summary>
        <%= strUpdateComment %><%= strUpdateCommentResult %>
        <%= hasUpdateTimestamp ? "byte[]" : "void" %> Update(<%= strUpdateParams %>);<%
}
%>
