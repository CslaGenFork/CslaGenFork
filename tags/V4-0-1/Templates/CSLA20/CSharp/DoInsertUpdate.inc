
        private void DoInsertUpdate(SqlCommand cmd)
        {
            <% if (Info.ConvertValueProperties.Count > 0) { %>
            ConvertPropertiesOnWrite();
            <% }
            bool bHasTimeStamp = false;
            foreach (ValueProperty prop in Info.GetAllValueProperties())
            {
                if (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
                    prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly &&
                    (prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly || prop.DbBindColumn.NativeType == "timestamp")) {
                    if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                        prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK) {
                        if (prop.DbBindColumn.NativeType == "timestamp") {
                            bHasTimeStamp = true; %>
            cmd.Parameters.Add("@New<%=prop.ParameterName%>", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                     <% } else { %>
            cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%=GetParameterSet(prop)%>).DbType = DbType.<%=prop.DbBindColumn.DataType.ToString()%>;
                     <% } %>
                 <% }
                }
            } %>
        }
