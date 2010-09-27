
        private void DoInsertUpdate(SqlCommand cmd)
        {
<%
if (Info.ConvertValueProperties.Count > 0)
{
    %>
            ConvertPropertiesOnWrite();
    <%
}
bool bHasTimeStamp = false;
%>
            var args = new DataPortalHookArgs(cmd);
<%
foreach (ValueProperty prop in Info.GetAllValueProperties())
{
    if (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
        prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly &&
        (prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly || prop.DbBindColumn.NativeType == "timestamp"))
    {
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
        {
            if (prop.DbBindColumn.NativeType == "timestamp")
            {
                bHasTimeStamp = true;
                %>
            cmd.Parameters.Add("@New<%= prop.ParameterName %>", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                <%
            }
            else
            {
                if (prop.DeclarationMode == PropertyDeclaration.Managed || prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                {
                    %>
            cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", ReadProperty(<%= FormatPropertyInfoName(prop.Name) %>)).DbType = DbType.<%=prop.DbBindColumn.DataType.ToString()%>;
                    <%
                }
                else
                {
                    %>
            cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %>).DbType = DbType.<%=prop.DbBindColumn.DataType.ToString()%>;
                    <%
                }
            }
        }
    }
}
%>
        }<%
if (UseSimpleAuditTrail(Info))
{
    %>

        private void SimpleAuditTrail()
        {
    <%
    ValueProperty changedDateProperty = new ValueProperty();
    if (GetValuePropertyByName(Info, Info.Parent.Params.ChangedDateColumn, ref changedDateProperty))
    {
        %>
            <%= GetFieldLoaderStatement(changedDateProperty, "DateTime.Now") %>;
        <%
    }
    ValueProperty changedUserProperty = new ValueProperty();
    if (GetValuePropertyByName(Info, Info.Parent.Params.ChangedUserColumn, ref changedUserProperty))
    {
        %>
            <%= GetFieldLoaderStatement(changedUserProperty, Info.Parent.Params.GetUserMethod) %>;
        <%
    }
    if (IsCreationDateColumnPresent(Info) || IsCreationUserColumnPresent(Info))
    {
        %>
            if (IsNew)
            {
                <%
                ValueProperty creationDateProperty = new ValueProperty();
                if (GetValuePropertyByName(Info, Info.Parent.Params.CreationDateColumn, ref creationDateProperty))
                {
                    if (IsChangedDateColumnPresent(Info))
                    {
                        %>
                <%= GetFieldLoaderStatement(creationDateProperty, GetFieldReaderStatement(changedDateProperty)) %>;
                        <%
                    }
                    else
                    {
                        %>
                <%= GetFieldLoaderStatement(creationDateProperty, "DateTime.Now") %>;
                        <%
                    }
                }
                ValueProperty creationUserProperty = new ValueProperty();
                if (GetValuePropertyByName(Info, Info.Parent.Params.CreationUserColumn, ref creationUserProperty))
                {
                    if (IsChangedUserColumnPresent(Info))
                    {
                        %>
                <%= GetFieldLoaderStatement(creationUserProperty, GetFieldReaderStatement(changedUserProperty)) %>;
                        <%
                    }
                    else
                    {
                        %>
                <%= GetFieldLoaderStatement(creationUserProperty, Info.Parent.Params.GetUserMethod) %>;
                        <%
                    }
                }
                %>
            }
        <%
    }
    %>
        }<%
}
%>
