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
        %>
        <% if (Info.GenerateDataPortalInsert) { %>

        /// <summary>
        /// Insert <see cref="<%=Info.ObjectName%>" /> Object to database with or without transaction.
        /// </summary>
        <% if (Info.TransactionType == TransactionType.EnterpriseServices) { %>
        [Transactional()]
        <% } %>
        internal void Insert(<% if (parentType.Length > 0) { %><%= parentType %> parent<% } %>)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = (SqlConnection)ApplicationContext.LocalContext["dpConnection"];
                <% if (Info.TransactionType == TransactionType.ADO) { %>
                cmd.Transaction = (SqlTransaction)ApplicationContext.LocalContext["dpTransaction"];
                <% } %>
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "<%= Info.InsertProcedureName %>";
                <% if (parentType.Length > 0) {
                    foreach (CslaGenerator.Metadata.Property prop in Info.ParentProperties) {
                        if (prop.PropertyType == CslaGenerator.Metadata.TypeCodeEx.SmartDate) { %>
                SmartDate l<%=prop.Name%> = new SmartDate(parent.<%=prop.Name%>);
                cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", l<%=prop.Name%>.DBValue);
                        <% } else { %>
                cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", parent.<%=prop.Name%>);
                        <% }
                    }
                }
                foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                    if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
                        prop.DataAccess == ValueProperty.DataAccessBehaviour.CreateOnly) { %>
                cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>)<%
                    if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK) {
                        %>.Direction = ParameterDirection.Output<% } %>;
                <%    }
                } %>
                onInsertStart(this, EventArgs.Empty);
                DoInsertUpdate(cmd);
                ApplicationContext.LocalContext["dpCommand"] = cmd;
                onInsertPre(this, EventArgs.Empty);
                cmd.ExecuteNonQuery();
                ApplicationContext.LocalContext["dpCommand"] = cmd;
                ApplicationContext.LocalContext["dpConnection"] = cmd.Connection;
                <%  if (Info.TransactionType == TransactionType.ADO) { %>
                ApplicationContext.LocalContext["dpTransaction"] = cmd.Transaction;
                <%  } %>
                onInsertPost(this, EventArgs.Empty);
                <% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                    if (prop.DbBindColumn.NativeType == "timestamp") { %>
                <%=FormatFieldName(prop.Name)%> = (Byte[]) cmd.Parameters["@New<%=prop.ParameterName%>"].Value;
                <%     }
                }
                foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                    if (prop.DbBindColumn.IsPrimaryKey || prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default) { %>
                <%= FormatFieldName(prop.Name)%> = (<%=GetLanguageVariableType(prop.DbBindColumn.DataType)%>) cmd.Parameters["@<%=prop.ParameterName%>"].Value;
                <%    }
                } %>
                MarkOld();
            }
            <!-- #include file="UpdateChildProperties.inc" -->
        }
        <% } %>
        <% if (Info.GenerateDataPortalUpdate) { %>

        /// <summary>
        /// Save <see cref="<%=Info.ObjectName%>" /> Object to database with or without transaction.
        /// </summary>
        <% if (Info.TransactionType == TransactionType.EnterpriseServices) { %>
        [Transactional()]
        <% } %>
        internal void Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>)
        {
            if (base.IsDirty)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = (SqlConnection)ApplicationContext.LocalContext["dpConnection"];
                    <% if (Info.TransactionType == TransactionType.ADO) { %>
                    cmd.Transaction = (SqlTransaction)ApplicationContext.LocalContext["dpTransaction"];
                    <% } %>
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "<%= Info.UpdateProcedureName %>";
                    <% if (parentType.Length > 0 && !Info.ParentInsertOnly) {
                        foreach (CslaGenerator.Metadata.Property prop in Info.ParentProperties) {
                            if (prop.PropertyType == CslaGenerator.Metadata.TypeCodeEx.SmartDate) { %>
                    SmartDate l<%=prop.Name%> = new SmartDate(parent.<%=prop.Name%>);
                    cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", l<%=prop.Name%>.DBValue);
                            <% } else { %>
                    cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", parent.<%=prop.Name%>);
                            <% }
                        }
                    }
                    foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                        if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
                            prop.DataAccess == ValueProperty.DataAccessBehaviour.UpdateOnly ||
                            prop.DbBindColumn.NativeType == "timestamp") { %>
                    cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>);
                    <%    }
                    } %>
                    onUpdateStart(this, EventArgs.Empty);
                    DoInsertUpdate(cmd);
                    ApplicationContext.LocalContext["dpCommand"] = cmd;
                    onUpdatePre(this, EventArgs.Empty);
                    cmd.ExecuteNonQuery();
                    ApplicationContext.LocalContext["dpCommand"] = cmd;
                    ApplicationContext.LocalContext["dpConnection"] = cmd.Connection;
                    <%  if (Info.TransactionType == TransactionType.ADO) { %>
                    ApplicationContext.LocalContext["dpTransaction"] = cmd.Transaction;
                    <%  } %>
                    onUpdatePost(this, EventArgs.Empty);
                    ApplicationContext.LocalContext.Remove("dpCommand");
                    <% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                        if (prop.DbBindColumn.NativeType == "timestamp") { %>
                    <%=FormatFieldName(prop.Name)%> = (Byte[]) cmd.Parameters["@New<%=prop.ParameterName%>"].Value;
                    <%     }
                    } %>
                    MarkOld();
                }
            }
            <!-- #include file="UpdateChildProperties.inc" -->
        }
        <% } %>
<!-- #include file="DoInsertUpdate.inc" -->
<% Response.Write("\r\n"); %>
        /// <summary>
        /// Delete <see cref="<%=Info.ObjectName%>" /> Object from database with or without transaction.
        /// </summary>
        <% if (Info.TransactionType == TransactionType.EnterpriseServices ) { %>
        [Transactional()]
        <% } %>
        internal void DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = (SqlConnection)ApplicationContext.LocalContext["dpConnection"];
                <% if (Info.TransactionType == TransactionType.ADO) { %>
                cmd.Transaction = (SqlTransaction)ApplicationContext.LocalContext["dpTransaction"];
                <% } %>
                cmd.CommandType = CommandType.StoredProcedure;
                if (!IsNew)
                {
                    cmd.CommandText = "<%= Info.DeleteProcedureName %>";
                    <% foreach (ValueProperty prop in Info.ValueProperties) { %>
                        <% if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default) { %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%=GetParameterSet(prop)%>);
                        <% }
                    } %>
                    <% if (parentType.Length > 0 && !Info.ParentInsertOnly) {
                        foreach (CslaGenerator.Metadata.Property prop in Info.ParentProperties) {
                            if (prop.PropertyType == CslaGenerator.Metadata.TypeCodeEx.SmartDate) { %>
                    SmartDate l<%=prop.Name%> = new SmartDate(parent.<%=prop.Name%>);
                    cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", l<%=prop.Name%>.DBValue);
                        <% } else { %>
                    cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", parent.<%=prop.Name%>);
                        <% } %>
                    <% }
                    } %>
                    ApplicationContext.LocalContext["dpCommand"] = cmd;
                    onDeletePre(this, EventArgs.Empty);
                    cmd.ExecuteNonQuery();
                    ApplicationContext.LocalContext["dpCommand"] = cmd;
                    ApplicationContext.LocalContext["dpConnection"] = cmd.Connection;
                    <% if (Info.TransactionType == TransactionType.ADO) { %>
                    ApplicationContext.LocalContext["dpTransaction"] = cmd.Transaction;
                    <% } %>
                    onDeletePost(this, EventArgs.Empty);
                    ApplicationContext.LocalContext.Remove("dpCommand");
                }
            }
        }
