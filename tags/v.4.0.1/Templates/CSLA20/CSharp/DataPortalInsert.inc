<% if (Info.GenerateDataPortalInsert) { %>

        /// <summary>
        /// Insert the new <see cref="<%=Info.ObjectName%>" /> Object to underlying database.
        /// </summary>
        <% if (Info.TransactionType == TransactionType.EnterpriseServices ) { %>
        [Transactional()]
        <% } else if (Info.TransactionType == TransactionType.TransactionalAttribute) { %>
        [Transactional(TransactionalTypes.TransactionScope)]
        <% } %>
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.<%= Info.DbName %>Connection))
            {
                cn.Open();
                ApplicationContext.LocalContext["dpConnection"] = cn;
                try
                {
                    using (SqlCommand cmd = new SqlCommand("<%= Info.InsertProcedureName %>", cn))
                    {
                        <% if ( Info.TransactionType == TransactionType.ADO ) { %>
                        using (SqlTransaction tr = cn.BeginTransaction())
                        {
                            cmd.Transaction = tr;
                            ApplicationContext.LocalContext["dpTransaction"] = tr;
                            <% } %>
                            ApplicationContext.LocalContext["dpCommand"] = cmd;
                            cmd.CommandType = CommandType.StoredProcedure;
                            <% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                                if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
                                    prop.DataAccess == ValueProperty.DataAccessBehaviour.CreateOnly ) {  %>
                            cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>)<%
                            if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK) {
                            %>.Direction = ParameterDirection.Output<%
                        } %>;
                        <% }
                           } %>
                            onInsertStart(this, EventArgs.Empty);
                            DoInsertUpdate(cmd);
                            onInsertPre(this, EventArgs.Empty);
                            cmd.ExecuteNonQuery();
                            onInsertPost(this, EventArgs.Empty);
                            <% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                                  if (prop.DbBindColumn.NativeType == "timestamp") { %>
                            <%=FormatFieldName(prop.Name)%> = (Byte[]) cmd.Parameters["@New<%=prop.ParameterName%>"].Value;
                            <%    }
                            } %>
                            <% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                                  if (prop.DbBindColumn.IsPrimaryKey || prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default) { %>
                            <%=FormatFieldName(prop.Name)%> = (<%=GetLanguageVariableType(prop.DbBindColumn.DataType)%>) cmd.Parameters["@<%=prop.ParameterName%>"].Value;
                            <%    }
                            } %>
                            <!-- #include file="UpdateChildProperties.inc" -->
                            <% if (Info.TransactionType == TransactionType.ADO) { %>
                            tr.Commit();
                        }
                        <% }
                        if (ActiveObjects) {
                            if (Info.PublishToChannel.Length > 0) { %>
                                SafePublish("<%= Info.PublishToChannel %>", BusinessEvents.Added, this);
                        <% }
                        } %>
                    }
                }
                finally
                {
                    ApplicationContext.LocalContext.Remove("dpConnection");
                }
            }
        }
<% } %>
