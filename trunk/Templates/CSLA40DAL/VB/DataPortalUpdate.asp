<%
if (Info.GenerateDataPortalUpdate)
{
    bool propUpdatePropertyInfo = false;
    string strUpdateParams = string.Empty;
    string strUpdateDto = string.Empty;
    string strUpdateResult = string.Empty;
    string strUpdateResultTS = string.Empty;
    bool updateIsFirst = true;

    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (!prop.IsDatabaseBound)
            continue;

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
        %>[RunLocal]
        <%
    }
        %>protected override void DataPortal_Update()
        {
            <%
    if (TemplateHelper.UseSimpleAuditTrail(Info))
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
    if (Info.GetMyChildReadWriteProperties().Count > 0)
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
