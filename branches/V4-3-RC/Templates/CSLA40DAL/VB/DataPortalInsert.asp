<%
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

            TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);

            if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
            {
                if (!usesDTO)
                {
                    strInsertPK = GetDataTypeGeneric(prop, propType) + " " + FormatCamel(prop.Name) + " = -1;" + Environment.NewLine + new string(' ', 20);
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
    if (usesDTO)
    {
        %>var dto = new <%= Info.ObjectName %>Dto();<%= strInsertDto %>
            <%
    }
    %>using (var dalManager = DalFactory<%= GetDalNameDot(CurrentUnit) %>GetManager())
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
%>
