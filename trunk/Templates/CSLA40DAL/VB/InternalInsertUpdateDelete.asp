<%
string parentType = Info.ParentType;
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
    string strInsertDto = string.Empty;
    string strInsertResult = string.Empty;
    string strInsertResultTS = string.Empty;
    bool insertIsFirst = true;

    if (parentType.Length > 0)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (usesDTO)
            {
                strInsertDto += Environment.NewLine + new string(' ', 12) + "dto.Parent_" + FormatPascal(prop.Name) + " = parent." + prop.Name +";";
            }
            else
            {
                if (!insertIsFirst)
                    strInsertParams += ", ";
                else
                    insertIsFirst = false;

                strInsertParams += Environment.NewLine + new string(' ', 24);
                strInsertParams += "parent." + prop.Name;
            }
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            if ((prop.DeclarationMode == PropertyDeclaration.Managed && !prop.ReadOnly) ||
                prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                if (usesDTO)
                {
                    strInsertResultTS = FormatPascal(prop.Name) + " = resultDto." + FormatPascal(prop.Name) +";";
                }
                else
                {
                    strInsertResult = FormatPascal(prop.Name) + " = ";
                }
            }
            else if ((prop.DeclarationMode == PropertyDeclaration.Managed && prop.ReadOnly) ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
            {
                if (usesDTO)
                {
                    strInsertResultTS = "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", resultDto." + FormatPascal(prop.Name) +");";
                }
                else
                {
                    propInsertPropertyInfo = true;
                    strInsertResult = "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", ";
                }
            }
            else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
            {
                if (usesDTO)
                {
                    strInsertResultTS = FormatFieldName(prop.Name) + " = resultDto." + FormatPascal(prop.Name) +";";
                }
                else
                {
                    strInsertResult = FormatFieldName(prop.Name) + " = ";
                }
            }
        }
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            prop.DbBindColumn.NativeType != "timestamp" &&
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly || prop.DbBindColumn.NativeType == "timestamp"))
        {
            if (!usesDTO)
            {
                if (!insertIsFirst)
                    strInsertParams += ",";
                else
                    insertIsFirst = false;

                strInsertParams += Environment.NewLine + new string(' ', 24);
            }

            if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
            {
                if (!usesDTO)
                {
                    strInsertPK = GetDataTypeGeneric(prop, TypeHelper.GetBackingFieldType(prop)) + " " + FormatCamel(prop.Name) + " = -1;" + Environment.NewLine + new string(' ', 20);
                    strInsertParams += "out " + FormatCamel(prop.Name);
                }

                strInsertResultPK = Environment.NewLine + new string(' ', 20);
                if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                    prop.ReadOnly)
                {
                    strInsertResultPK += "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", ";
                    if (usesDTO)
                    {
                        strInsertResultPK += "resultDto." + FormatPascal(prop.Name) +");";
                    }
                    else
                    {
                        strInsertResultPK += FormatCamel(prop.Name) +");";
                    }
                }
                else if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                    prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                {
                    strInsertResultPK += FormatPascal(prop.Name) + " = ";
                    if (usesDTO)
                    {
                        strInsertResultPK += "resultDto." + FormatPascal(prop.Name) +";";
                    }
                    else
                    {
                        strInsertResultPK += FormatCamel(prop.Name) +";";
                    }
                }
                else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
                {
                    strInsertResultPK += FormatFieldName(prop.Name) + " = ";
                    if (usesDTO)
                    {
                        strInsertResultPK += "resultDto." + FormatPascal(prop.Name) +";";
                    }
                    else
                    {
                        strInsertResultPK += FormatCamel(prop.Name) +";";
                    }
                }
            }
            else
            {
                if (usesDTO)
                {
                    strInsertDto += Environment.NewLine + new string(' ', 12) + "dto." + FormatPascal(prop.Name) + " = ";
                }
                if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
                {
                    if (usesDTO)
                    {
                        strInsertDto += GetFieldReaderStatement(prop) + ";";
                    }
                    else
                        strInsertParams += GetFieldReaderStatement(prop);
                }
                else if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                    prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                {
                    if (usesDTO)
                    {
                        strInsertDto += FormatPascal(prop.Name) + ";";
                    }
                    else
                        strInsertParams += FormatPascal(prop.Name);
                }
                else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
                {
                    if (usesDTO)
                    {
                        strInsertDto += FormatFieldName(prop.Name) + ";";
                    }
                    else
                        strInsertParams += FormatFieldName(prop.Name);
                }
            }
        }
    }
    if (usesDTO)
    {
        strInsertResult += "var resultDto = ";
        strInsertParams += "dto";
        if (strInsertResultTS != string.Empty)
            strInsertResultTS = Environment.NewLine + new string(' ', 20) + strInsertResultTS;
    }
    else
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
        %>SimpleAuditTrail();
            <%
    }
    if (usesDTO)
    {
        %>var dto = new <%= Info.ObjectName %>Dto();<%= strInsertDto %>
            <%
    }
    %>using (var dalManager = DalFactory<%= GetDalName(CurrentUnit) %>.GetManager())
            {
                var args = new DataPortalHookArgs(<%= usesDTO ? "dto" : "" %>);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<I<%= Info.ObjectName %>Dal>();
                using (BypassPropertyChecks)
                {
                    <%= strInsertPK %><%= strInsertResult %>dal.Insert(<%= strInsertParams %>)<%= propInsertPropertyInfo ? ")" : "" %>;<%= strInsertResultPK %><%= strInsertResultTS %>
                <%
                if (usesDTO)
                {
                    %>
                    args = new DataPortalHookArgs(resultDto);
                <%
                }
                %>
                }
                OnInsertPost(args);
                <%
    if (Info.GetMyChildProperties().Count > 0)
    {
        string ucpSpacer = new string(' ', 4);
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
    string strUpdateParams = string.Empty;
    string strUpdateDto = string.Empty;
    string strUpdateResult = string.Empty;
    string strUpdateResultTS = string.Empty;
    bool updateIsFirst = true;

    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (usesDTO)
            {
                strUpdateDto += Environment.NewLine + new string(' ', 12) + "dto.Parent_" + FormatPascal(prop.Name) + " = parent." + prop.Name +";";
            }
            else
            {
                if (!updateIsFirst)
                    strUpdateParams += ", ";
                else
                    updateIsFirst = false;

                strUpdateParams += Environment.NewLine + new string(' ', 24);
                strUpdateParams += "parent." + prop.Name;
            }
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            if ((prop.DeclarationMode == PropertyDeclaration.Managed && !prop.ReadOnly) ||
                prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                if (usesDTO)
                {
                    strUpdateResultTS = FormatPascal(prop.Name) + " = resultDto." + FormatPascal(prop.Name) +";";
                }
                else
                {
                    strUpdateResult = FormatPascal(prop.Name) + " = ";
                }
            }
            else if ((prop.DeclarationMode == PropertyDeclaration.Managed && prop.ReadOnly) ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
            {
                if (usesDTO)
                {
                    strUpdateResultTS = "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", resultDto." + FormatPascal(prop.Name) +");";
                }
                else
                {
                    propUpdatePropertyInfo = true;
                    strUpdateResult = "LoadProperty(" + FormatPropertyInfoName(prop.Name) + ", ";
                }
            }
            else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
            {
                if (usesDTO)
                {
                    strUpdateResultTS = FormatFieldName(prop.Name) + " = resultDto." + FormatPascal(prop.Name) +";";
                }
                else
                {
                    strUpdateResult = FormatFieldName(prop.Name) + " = ";
                }
            }
        }
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly ||
            (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
            prop.DataAccess == ValueProperty.DataAccessBehaviour.UpdateOnly)) ||
            prop.DbBindColumn.NativeType == "timestamp")
        {
            if (usesDTO)
            {
                strUpdateDto += Environment.NewLine + new string(' ', 12) + "dto." + FormatPascal(prop.Name) + " = ";
            }
            else
            {
                if (!updateIsFirst)
                    strUpdateParams += ",";
                else
                    updateIsFirst = false;

                strUpdateParams += Environment.NewLine + new string(' ', 24);
            }

            if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                if (usesDTO)
                {
                    strUpdateDto += GetFieldReaderStatement(prop) + ";";
                }
                else
                    strUpdateParams += GetFieldReaderStatement(prop);
            }
            else if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                if (usesDTO)
                {
                    strUpdateDto += FormatPascal(prop.Name) + ";";
                }
                else
                    strUpdateParams += FormatPascal(prop.Name);
            }
            else //Unmanaged, ClassicProperty, ClassicPropertyWithTypeConversion
            {
                if (usesDTO)
                {
                    strUpdateDto += FormatFieldName(prop.Name) + ";";
                }
                else
                    strUpdateParams += FormatFieldName(prop.Name);
            }
        }
    }
    if (usesDTO)
    {
        strUpdateResult += "var resultDto = ";
        strUpdateParams += "dto";
        if (strUpdateResultTS != string.Empty)
            strUpdateResultTS = Environment.NewLine + new string(' ', 20) + strUpdateResultTS;
    }
    else
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
    if (CurrentUnit.GenerationParams.UpdateOnlyDirtyChildren)
    {
        %>
            if (!IsDirty)
                return;

            <%
    }
    if (UseSimpleAuditTrail(Info))
    {
        %>SimpleAuditTrail();
            <%
    }
    if (usesDTO)
    {
        %>var dto = new <%= Info.ObjectName %>Dto();<%= strUpdateDto %>
            <%
    }
    %>using (var dalManager = DalFactory<%= GetDalNameDot(CurrentUnit) %>GetManager())
            {
                var args = new DataPortalHookArgs(<%= usesDTO ? "dto" : "" %>);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<I<%= Info.ObjectName %>Dal>();
                using (BypassPropertyChecks)
                {
                    <%= strUpdateResult %>dal.Update(<%= strUpdateParams %>)<%= propUpdatePropertyInfo ? ")" : "" %>;<%= strUpdateResultTS %>
                <%
                if (usesDTO)
                {
                    %>
                    args = new DataPortalHookArgs(resultDto);
                <%
                }
                %>
                }
                OnUpdatePost(args);
                <%
    if (Info.GetMyChildProperties().Count > 0)
    {
        string ucpSpacer = new string(' ', 4);
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

            strDeleteComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strDeleteCritParams += string.Concat(GetDataTypeGeneric(prop, prop.PropertyType), " ", FormatCamel(prop.Name));
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

            strDeleteCritParams += string.Concat(GetDataTypeGeneric(prop, TypeHelper.GetBackingFieldType(prop)), " ", FormatCamel(prop.Name));
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
        string ucpSpacer = new string(' ', 4);
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
