<%
if (Info.GenerateDataPortalUpdate)
{
    if (usesDTO)
    {
        if (isFirstMethod)
            isFirstMethod = false;
        else
            Response.Write(Environment.NewLine);

        %>
        /// <summary>
        /// Updates in the database all changes made to the <%= Info.ObjectName %> object.
        /// </summary>
        /// <param name="<%= FormatCamel(Info.ObjectName) %>">The <%= PropertyHelper.SplitOnCaps(FormatPascal(Info.ObjectName)) %> DTO.</param>
        /// <returns>The updated <see cref="<%= Info.ObjectName %>Dto"/>.</returns>
        <%= Info.ObjectName %>Dto Update(<%= Info.ObjectName %>Dto <%= FormatCamel(Info.ObjectName) %>);
        <%
    }
    else
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
                strUpdateCommentResult = System.Environment.NewLine + new string(' ', 8) + "/// <returns>The updated " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</returns>";
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

                strUpdateComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>";
                strUpdateParams += string.Concat(GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)), " ", FormatCamel(prop.Name));
            }
        }
        if (isFirstMethod)
            isFirstMethod = false;
        else
            Response.Write(Environment.NewLine);

        %>
        /// <summary>
        /// Updates in the database all changes made to the <%= Info.ObjectName %> object.
        /// </summary><%= strUpdateComment %><%= strUpdateCommentResult %>
        <%= hasUpdateTimestamp ? "byte[]" : "void" %> Update(<%= strUpdateParams %>);
        <%
    }
}
%>
