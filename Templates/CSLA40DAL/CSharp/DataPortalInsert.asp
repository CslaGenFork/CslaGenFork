<%
if (Info.GenerateDataPortalInsert)
{
    bool propInsertPropertyInfo = false;
    string strInsertPK = string.Empty;
    string strInsertResultPK = string.Empty;
    string strInsertParams = string.Empty;
    string strInsertResult = string.Empty;
    bool insertIsFirst = true;

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
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope || Info.TransactionType == TransactionType.TransactionScope)
    {
        %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
    }
    if (Info.InsertUpdateRunLocal)
    {
        %>[Csla.RunLocal]
        <%
    }
        %>protected override void DataPortal_Insert()
        {
            <%
    if (UseSimpleAuditTrail(Info))
    {
            %>SimpleAuditTrail();
            <%
    }
    %>
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactory<%= GetConnectionName(CurrentUnit) %>.GetManager())
            {
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
%>
