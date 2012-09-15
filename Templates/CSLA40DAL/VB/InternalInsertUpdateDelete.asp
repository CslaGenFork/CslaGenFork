<%
string parentType = Info.ParentType;
///CslaObjectInfo parentInfo = FindChildInfo(Info, parentType);/// DEPRECATED
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
    bool propInsertPropertyInfo = false;
    string strInsertPK = string.Empty;
    string strInsertResultPK = string.Empty;
    string strInsertParams = string.Empty;
    string strInsertResult = string.Empty;
    bool insertIsFirst = true;

    if (parentType.Length > 0)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (!insertIsFirst)
                strInsertParams += ", ";
            else
                insertIsFirst = false;

            strInsertParams += Environment.NewLine + new string(' ', 24);
            TypeCodeEx propType = prop.PropertyType;

            strInsertParams += "parent." + prop.Name;
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            if ((prop.DeclarationMode == PropertyDeclaration.Managed && !prop.ReadOnly) ||
                prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                strInsertResult = FormatPascal(prop.Name) + " = ";
            }
            else if ((prop.DeclarationMode == PropertyDeclaration.Managed && prop.ReadOnly) ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
            {
                propInsertPropertyInfo = true;
                strInsertResult = "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", ";
            }
            else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
            {
                strInsertResult = FormatFieldName(prop.Name) + " = ";
            }
        }
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            prop.DbBindColumn.NativeType != "timestamp" &&
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly || prop.DbBindColumn.NativeType == "timestamp"))
        {
            if (!insertIsFirst)
                strInsertParams += ",";
            else
                insertIsFirst = false;

            strInsertParams += Environment.NewLine + new string(' ', 24);
            TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);

            if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
            {
                strInsertPK = GetDataTypeGeneric(prop, propType) + " " + FormatCamel(prop.Name) + " = -1;" + Environment.NewLine + new string(' ', 20);
                strInsertParams += "out " + FormatCamel(prop.Name);

                strInsertResultPK = Environment.NewLine + new string(' ', 20);
                if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                    prop.ReadOnly)
                {
                    strInsertResultPK += "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", " + FormatCamel(prop.Name) +");";
                }
                else if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                    prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                {
                    strInsertResultPK += FormatPascal(prop.Name) + " = " + FormatCamel(prop.Name) +";";
                }
                else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
                {
                    strInsertResultPK += FormatFieldName(prop.Name) + " = " + FormatCamel(prop.Name) +";";
                }
            }
            else
            {
                if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
                {
                    strInsertParams += GetFieldReaderStatement(prop);
                }
                else if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                    prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                {
                    strInsertParams += FormatPascal(prop.Name);
                }
                else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
                {
                    strInsertParams += FormatFieldName(prop.Name);
                }
            }
        }
    }
    strInsertParams += Environment.NewLine + new string(' ', 24);
    %>

        /// <summary>
        /// Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        /// </summary>
        <%
    if (parentType.Length > 0)
    {
        %>/// <param name="parent">The parent object.</param>
        <%
    }
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope)
    {
        %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
    }
    %>private void Child_Insert(<% if (parentType.Length > 0) { %><%= parentType %> parent<% } %>)
        {
            <%
    if (UseSimpleAuditTrail(Info))
    {
        %>
            SimpleAuditTrail();
            <%
    }
    if (plainConvertPropertiesWrite.Count > 0)
    {
        %>
            ConvertPropertiesOnWrite();
            <%
    }
    %>
            using (var dalManager = DalFactory<%= GetDalName(CurrentUnit) %>.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<I<%= Info.ObjectName %>Dal>();
                using (BypassPropertyChecks)
                {
                    <%= strInsertPK %><%= strInsertResult %>dal.Insert(<%= strInsertParams %>)<%= propInsertPropertyInfo ? ")" : "" %>;<%= strInsertResultPK %>
                }
                OnInsertPost(args);
                <%
    if (Info.GetMyChildProperties().Count > 0)
    {
        %>
<!-- #include file="UpdateChildProperties.asp" -->
                <%
    }
    %>
            }
        }
    <%
}

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalUpdate)
{
    bool propUpdatePropertyInfo = false;
    string strUpdateResult = string.Empty;
    string strUpdateParams = string.Empty;
    bool updateIsFirst = true;

    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (!updateIsFirst)
                strUpdateParams += ", ";
            else
                updateIsFirst = false;

            strUpdateParams += Environment.NewLine + new string(' ', 24);
            TypeCodeEx propType = prop.PropertyType;

            strUpdateParams += "parent." + prop.Name;
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            if ((prop.DeclarationMode == PropertyDeclaration.Managed && !prop.ReadOnly) ||
                prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                strUpdateResult = FormatPascal(prop.Name) + " = ";
            }
            else if ((prop.DeclarationMode == PropertyDeclaration.Managed && prop.ReadOnly) ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
            {
                propUpdatePropertyInfo = true;
                strUpdateResult = "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", ";
            }
            else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
            {
                strUpdateResult = FormatFieldName(prop.Name) + " = ";
            }
        }
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly ||
            (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
            prop.DataAccess == ValueProperty.DataAccessBehaviour.UpdateOnly)) ||
            prop.DbBindColumn.NativeType == "timestamp")
        {
            if (!updateIsFirst)
                strUpdateParams += ",";
            else
                updateIsFirst = false;

            strUpdateParams += Environment.NewLine + new string(' ', 24);
            TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);

            if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                strUpdateParams += GetFieldReaderStatement(prop);
            }
            else if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                strUpdateParams += FormatPascal(prop.Name);
            }
            else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
            {
                strUpdateParams += FormatFieldName(prop.Name);
            }
        }
    }
    strUpdateParams += Environment.NewLine + new string(' ', 24);
    %>

        /// <summary>
        /// Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        %>/// <param name="parent">The parent object.</param>
        <%
    }
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope)
    {
        %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
    }
    %>private void Child_Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>)
        {
            <%
    if (UseSimpleAuditTrail(Info))
    {
        %>
            SimpleAuditTrail();
            <%
    }
    if (plainConvertPropertiesWrite.Count > 0)
    {
        %>
            ConvertPropertiesOnWrite();
            <%
    }
    %>
            using (var dalManager = DalFactory<%= GetDalName(CurrentUnit) %>.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<I<%= Info.ObjectName %>Dal>();
                using (BypassPropertyChecks)
                {
                    <%= strUpdateResult %>dal.Update(<%= strUpdateParams %>)<%= propUpdatePropertyInfo ? ")" : "" %>;
                }
                OnUpdatePost(args);
                <%
    if (Info.GetMyChildProperties().Count > 0)
    {
        %>
<!-- #include file="UpdateChildProperties.asp" -->
                <%
    }
    %>
            }
        }
    <%
}

if (Info.GenerateDataPortalInsert || Info.GenerateDataPortalUpdate || Info.GenerateDataPortalDelete)
{
    %>
<!-- #include file="SimpleAuditTrail.asp" -->
<%
}

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalDelete)
{
    string strDeleteCritParams = string.Empty;
    string strDeleteInvokeParams = string.Empty;
    string strDeleteComment = string.Empty;
    bool deleteIsFirst = true;

    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (!deleteIsFirst)
            {
                strDeleteCritParams += ", ";
                strDeleteInvokeParams += ", ";
            }
            else
                deleteIsFirst = false;

            TypeCodeEx propType = prop.PropertyType;

            strDeleteComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strDeleteCritParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
            strDeleteInvokeParams += "parent." + prop.Name;
        }
    }
    foreach (ValueProperty prop in Info.ValueProperties)
    {
        if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            if (!deleteIsFirst)
            {
                strDeleteCritParams += ", ";
                strDeleteInvokeParams += ", ";
            }
            else
                deleteIsFirst = false;

            TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);

            strDeleteCritParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
            strDeleteInvokeParams += GetParameterSet(Info, prop);
            strDeleteComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
        }
    }
    %>

        /// <summary>
        /// Self deletes the <see cref="<%= Info.ObjectName %>"/> object from database.
        /// </summary>
        <%
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        %>/// <param name="parent">The parent object.</param>
        <%
    }
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope)
    {
        %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
    }
        %>private void Child_DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>)
        {
                <%
    if (UseSimpleAuditTrail(Info))
    {
        %>
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            <%
    }
    %>
            using (var dalManager = DalFactory<%= GetDalName(CurrentUnit) %>.GetManager())
            {
                var args = new DataPortalHookArgs();
                <%
    if (Info.GetMyChildProperties().Count > 0)
    {
        %>
<!-- #include file="UpdateChildProperties.asp" -->
                <%
    }
    %>
                OnDeletePre(args);
                var dal = dalManager.GetProvider<I<%= Info.ObjectName %>Dal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(<%= strDeleteInvokeParams %>);
                }
                OnDeletePost(args);
            }
        }
    <%
}
%>
