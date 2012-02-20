<% if (Info.GenerateDataPortalUpdate) { %>

        /// <summary>
        /// Update all changes made on <see cref="<%=Info.ObjectName%>" /> Object to underlying database.
        /// </summary>
        <% if (Info.TransactionType == TransactionType.EnterpriseServices) { %>
        [Transactional()]
        <% } else if (Info.TransactionType == TransactionType.TransactionalAttribute) { %>
        [Transactional(TransactionalTypes.TransactionScope)]
        <% } %>
        protected override void DataPortal_Update()
        {
            using (SqlConnection cn = new SqlConnection(Database.<%= Info.DbName %>Connection))
            {
                cn.Open();
                ApplicationContext.LocalContext["dpConnection"] = cn;
                try
                {
                    using (SqlCommand cmd = new SqlCommand("<%= Info.UpdateProcedureName %>", cn))
                    {
                        <% if (Info.TransactionType == TransactionType.ADO) { %>
                        using (SqlTransaction tr = cn.BeginTransaction())
                        {
                            cmd.Transaction = tr;
                            ApplicationContext.LocalContext["dpTransaction"] = tr;
                            <% } %>
                            ApplicationContext.LocalContext["dpCommand"] = cmd;
                            if (base.IsDirty)
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                <% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                                    if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
                                        prop.DataAccess == ValueProperty.DataAccessBehaviour.UpdateOnly ||
                                        prop.DbBindColumn.NativeType == "timestamp") {  %>
                                cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>);
                                <%    }
                                   } %>
                                onUpdateStart(this, EventArgs.Empty);
                                DoInsertUpdate(cmd);
                                onUpdatePre(this, EventArgs.Empty);
                                cmd.ExecuteNonQuery();
                                onUpdatePost(this, EventArgs.Empty);
                                <% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                                    if (prop.DbBindColumn.NativeType == "timestamp") { %>
                                <%=FormatFieldName(prop.Name)%> = (Byte[]) cmd.Parameters["@New<%=prop.ParameterName%>"].Value;
                                <%     }
                                    } %>
                            }
                                <!-- #include file="UpdateChildProperties.inc" -->
                                <% if (Info.TransactionType == TransactionType.ADO ) { %>
                            tr.Commit();
                        }
                        <% }
                        if (ActiveObjects) {
                            if (Info.PublishToChannel.Length > 0) { %>
                        SafePublish("<%= Info.PublishToChannel %>", BusinessEvents.Updated, this);
                        <%    }
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
