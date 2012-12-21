<%
if (Info.GenerateDataPortalInsert)
{
    string strInsertComment = string.Empty;
    string strInsertCommentResult = string.Empty;
    string strInsertParams = string.Empty;
    bool hasInsertTimestamp = false;
    bool insertIsFirst = true;

    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            hasInsertTimestamp = true;
            strInsertCommentResult = "/// <returns>The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + " of the new " + Info.ObjectName + ".</returns>";
        }
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            prop.DbBindColumn.NativeType != "timestamp" &&
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly || prop.DbBindColumn.NativeType == "timestamp"))
        {
            if (!insertIsFirst)
                strInsertParams += ", ";
            else
                insertIsFirst = false;

            TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);

            strInsertComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
                strInsertParams += "out ";

            strInsertParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
        }
    }
    %>

        /// <summary>
        /// Inserts a new <%= Info.ObjectName %> object in the database.
        /// </summary>
        <%= strInsertComment %><%= strInsertCommentResult %>
        <%= hasInsertTimestamp ? "byte[]" : "void" %> Insert(<%= strInsertParams %>);<%
}
%>
