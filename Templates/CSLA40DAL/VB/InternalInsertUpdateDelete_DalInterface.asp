<%
string parentType = Info.ParentType;
CslaObjectInfo parentInfo = FindChildInfo(Info, parentType);
if (parentInfo == null)
    parentType = "";
else if (parentInfo.ObjectType == CslaObjectType.EditableChildCollection)
    parentType = parentInfo.ParentType;
else if (parentInfo.ObjectType == CslaObjectType.EditableRootCollection)
    parentType = "";
else if (parentInfo.ObjectType == CslaObjectType.DynamicEditableRootCollection)
    parentType = "";

if (Info.GenerateDataPortalInsert)
{
    string strInsertComment = string.Empty;
    string strInsertCommentResult = string.Empty;
    string strInsertParams = string.Empty;
    bool hasInsertTimestamp = false;
    bool insertIsFirst = true;

    if (parentType.Length > 0)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (!insertIsFirst)
                strInsertParams += ", ";
            else
                insertIsFirst = false;

            TypeCodeEx propType = prop.PropertyType;

            strInsertComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strInsertParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
        }
    }
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

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalUpdate)
{
    string strUpdateComment = string.Empty;
    string strUpdateCommentResult = string.Empty;
    string strUpdateParams = string.Empty;
    bool hasUpdateTimestamp = false;
    bool updateIsFirst = true;

    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (!updateIsFirst)
                strUpdateParams += ", ";
            else
                updateIsFirst = false;

            TypeCodeEx propType = prop.PropertyType;

            strUpdateComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strUpdateParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
        }
    }
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

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalDelete)
{
    string strDeleteCritParams = string.Empty;
    string strDeleteComment = string.Empty;
    bool deleteIsFirst = true;

    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (!deleteIsFirst)
                strDeleteCritParams += ", ";
            else
                deleteIsFirst = false;

            TypeCodeEx propType = prop.PropertyType;

            strDeleteComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strDeleteCritParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
        }
    }
    foreach (ValueProperty prop in Info.ValueProperties)
    {
        if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            if (!deleteIsFirst)
                strDeleteCritParams += ", ";
            else
                deleteIsFirst = false;

            TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);

            strDeleteCritParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
            strDeleteComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
        }
    }
    %>

        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        <%= strDeleteComment %>void Delete(<%= strDeleteCritParams %>);<%
}
%>
