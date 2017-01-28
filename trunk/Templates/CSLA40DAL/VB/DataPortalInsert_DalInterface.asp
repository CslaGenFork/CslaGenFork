<%
if (Info.GenerateDataPortalInsert)
{
    if (usesDTO)
    {
        if (isFirstMethod)
            isFirstMethod = false;
        else
            Response.Write(Environment.NewLine);

        %>
        /// <summary>
        /// Inserts a new <%= Info.ObjectName %> object in the database.
        /// </summary>
        /// <param name="<%= FormatCamel(Info.ObjectName) %>">The <%= PropertyHelper.SplitOnCaps(FormatPascal(Info.ObjectName)) %> DTO.</param>
        /// <returns>The new <see cref="<%= Info.ObjectName %>Dto"/>.</returns>
        <%= Info.ObjectName %>Dto Insert(<%= Info.ObjectName %>Dto <%= FormatCamel(Info.ObjectName) %>);
        <%
    }
    else
    {
        string strInsertComment = string.Empty;
        string strInsertCommentResult = string.Empty;
        string strInsertParams = string.Empty;
        bool hasInsertTimestamp = false;
        bool insertIsFirst = true;

        foreach (ValueProperty prop in Info.GetAllValueProperties())
        {
            if (!prop.IsDatabaseBound)
                continue;

            if (prop.DbBindColumn.NativeType == "timestamp")
            {
                hasInsertTimestamp = true;
                strInsertCommentResult = System.Environment.NewLine + new string(' ', 8) + "/// <returns>The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + " of the new " + Info.ObjectName + ".</returns>";
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

                strInsertComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>";
                if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
                    strInsertParams += "out ";

                strInsertParams += string.Concat(GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)), " ", FormatCamel(prop.Name));
            }
        }
        if (isFirstMethod)
            isFirstMethod = false;
        else
            Response.Write(Environment.NewLine);

        %>
        /// <summary>
        /// Inserts a new <%= Info.ObjectName %> object in the database.
        /// </summary><%= strInsertComment %><%= strInsertCommentResult %>
        <%= hasInsertTimestamp ? "byte[]" : "void" %> Insert(<%= strInsertParams %>);
        <%
    }
}
%>
