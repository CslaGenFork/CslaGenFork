<% if (!Info.UseCustomLoading) { %>
    <% if (!Info.DataSetLoadingScheme) { %>
        /// <summary>
        /// Load a <see cref="<%=Info.ObjectName%>" /> Object from given SafeDataReader.
        /// </summary>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            <% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                        prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly) {
                    try { %>
            <%= GetReaderAssignmentStatement(prop) %>
            <%        }
                    catch (Exception ex) {
                        Errors.Append(ex.Message + Environment.NewLine);
                    }
                }
            } %>
            <% if (Info.ConvertValueProperties.Count > 0) { %>ConvertPropertiesOnRead();
            <% } %>ApplicationContext.LocalContext["dpDataReader"] = dr;
            onFetchRead(this, EventArgs.Empty);
            ApplicationContext.LocalContext["dpDataReader"] = null;
        }
        <% if (LoadsChildren(Info)) { %>

        private void FetchChildren(SafeDataReader dr)
        {
            <% foreach (ChildProperty childProp in Info.GetNonCollectionChildProperties()) {
                if (!childProp.LazyLoad && childProp.LoadingScheme != LoadingScheme.None) { %>
            dr.NextResult();
            if (dr.Read())
                <%=FormatFieldName(childProp.Name)%> = <%=childProp.Name%>.Get<%=childProp.Name%>(dr);
            <%    }
            } %>
            <% foreach (ChildProperty childProp in Info.GetCollectionChildProperties()) {
                if (!childProp.LazyLoad && childProp.LoadingScheme != LoadingScheme.None) { %>
            dr.NextResult();
            <%
            CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
            bool _fetchParentReference = false;
            if (_child != null)
                _fetchParentReference = _child.AddParentReference; %>
            <%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(dr);
            <% if (_fetchParentReference) { %>
            <%=FormatFieldName(childProp.Name)%>.SetParent(this);
            <% } %>
            <%    }
            } %>
            <% if (ActiveObjects) { %>
            RegisterAndSubscribe();
            <% } %>
        }
        <% } %>
    <% } else { %>

        /// <summary>
        /// Load a <see cref="<%=Info.ObjectName%>" /> object from given DataRow.
        /// </summary>
        private void Fetch(DataRow dr)
        {
            // Value properties
            <% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None) {
                    if (prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly) {
                        if (prop.PropertyType == TypeCodeEx.SmartDate) { %>
            if (!dr.IsNull("<%=prop.ParameterName%>"))
                <%=FormatFieldName(prop.Name)%> = new SmartDate((DateTime)dr["<%=prop.ParameterName%>"]);
                        <% } else { %>
            if (!dr.IsNull("<%=prop.ParameterName%>"))
                <%=FormatFieldName(prop.Name)%> = (<%=GetDataType(prop)%>) dr["<%=prop.ParameterName%>"];
            <%            }
                    }
                }
            } %>
            ApplicationContext.LocalContext["dpDataRow"] = dr;
            onFetchRead(this, EventArgs.Empty);
            ApplicationContext.LocalContext.Remove("dpDataRow");
        }
        <% if (LoadsChildren(Info)) { %>

        private void FetchChildren(DataRow dr)
        {
            DataRow[] childRows;
            <% foreach (ChildProperty childProp in Info.GetNonCollectionChildProperties()) {
                if (!childProp.LazyLoad && childProp.LoadingScheme != LoadingScheme.None) { %>
            childRows = dr.GetChildRows("<%=Info.ObjectName + childProp.TypeName%>");
            if (childRows.Length > 0)
                <%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(childRows[0]);
            <%    }
            } %>
            <% foreach (ChildProperty childProp in Info.GetCollectionChildProperties()) {
                if (!childProp.LazyLoad && childProp.LoadingScheme != LoadingScheme.None) { %>
            childRows = dr.GetChildRows("<%=Info.ObjectName + FindChildInfo(Info, childProp.TypeName).ItemType %>");
            <%
            CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
            bool _fetchParentReference = false;
            if (_child != null)
                _fetchParentReference = _child.AddParentReference; %>
            <%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(childRows);
            <% if (_fetchParentReference) { %>
            <%=FormatFieldName(childProp.Name)%>.SetParent(this);
            <% } %>
            <%    }
            } %>
            <% if (ActiveObjects) { %>
            RegisterAndSubscribe();
            <% } %>
        }
        <% } %>
    <% } %>
<% } %>
