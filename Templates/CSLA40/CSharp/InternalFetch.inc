<%
if (!Info.UseCustomLoading)
{
    if (!Info.DataSetLoadingScheme)
    {
        %>
        /// <summary>
        /// Load a <see cref="<%=Info.ObjectName%>"/> object using given SafeDataReader.
        /// </summary>
        /// <param name="dr">The data reader.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            <%
        foreach (ValueProperty prop in Info.GetAllValueProperties())
        {
            if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly)
            {
                try
                {
                    %><%= GetReaderAssignmentStatement(prop) %>;
            <%
                }
                catch (Exception ex)
                {
                    Errors.Append(ex.Message + Environment.NewLine);
                }
            }
        }
        if (Info.ConvertValueProperties.Count > 0)
        {
            %>ConvertPropertiesOnRead();
            <%
        }
            %>var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }
        <%
        if (LoadsChildren(Info))
        {
            %>

        /// <summary>
        /// Load a child objects using given SafeDataReader.
        /// </summary>
        /// <param name="dr">The data reader.</param>
        private void FetchChildren(SafeDataReader dr)
        {
            <% foreach (ChildProperty childProp in Info.GetNonCollectionChildProperties()) {
                if (!childProp.LazyLoad && childProp.LoadingScheme != LoadingScheme.None) { %>
            dr.NextResult();
            if (dr.Read())
                <%= FormatFieldName(childProp.Name) %> = <%= childProp.Name %>.Get<%= childProp.Name %>(dr);
            <%    }
            } %>
            <% foreach (ChildProperty childProp in Info.GetCollectionChildProperties()) {
                if (!childProp.LazyLoad && childProp.LoadingScheme != LoadingScheme.None) { %>
            dr.NextResult();
            <%
            CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
            if (_child != null)
                if (childProp.DeclarationMode == PropertyDeclaration.Managed || childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion) { %>
            LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= childProp.TypeName %>.Get<%= childProp.TypeName %>(dr));
            <% } else { %>
            <%= GetFieldLoaderStatement(childProp, childProp.TypeName + ".Get" + childProp.TypeName +"(dr)") %>;
            <% }
                  }
            } %>
            <% if (ActiveObjects) { %>
            RegisterAndSubscribe();
            <% } %>
        }
        <% } %>
    <% } else { %>

        /// <summary>
        /// Load a <see cref="<%=Info.ObjectName%>"/> object using given DataRow.
        /// </summary>
        private void Fetch(DataRow dr)
        {
            // Value properties
            <% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
                if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None) {
                    if (prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly) {
                        if (prop.PropertyType == TypeCodeEx.SmartDate) { %>
            if (!dr.IsNull("<%= prop.ParameterName %>"))
                <%= FormatFieldName(prop.Name) %> = new SmartDate((DateTime)dr["<%= prop.ParameterName %>"]);
                        <% } else { %>
            if (!dr.IsNull("<%= prop.ParameterName %>"))
                <%=FormatFieldName(prop.Name)%> = (<%=GetDataTypeGeneric(prop, prop.PropertyType)%>) dr["<%= prop.ParameterName %>"];
            <%            }
                    }
                }
            } %>
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }
        <% if (LoadsChildren(Info)) { %>

        private void FetchChildren(DataRow dr)
        {
            DataRow[] childRows;
            <% foreach (ChildProperty childProp in Info.GetNonCollectionChildProperties()) {
                if (!childProp.LazyLoad && childProp.LoadingScheme != LoadingScheme.None) { %>
            childRows = dr.GetChildRows("<%= Info.ObjectName + childProp.TypeName %>");
            if (childRows.Length > 0)
                <%= FormatFieldName(childProp.Name) %> = <%= childProp.TypeName %>.Get<%= childProp.TypeName %>(childRows[0]);
            <%    }
            } %>
            <% foreach (ChildProperty childProp in Info.GetCollectionChildProperties()) {
                if (!childProp.LazyLoad && childProp.LoadingScheme != LoadingScheme.None) { %>
            childRows = dr.GetChildRows("<%=Info.ObjectName + FindChildInfo(Info, childProp.TypeName).ItemType %>");
            <%
            CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
            if (_child != null)
                %>
            <%= FormatFieldName(childProp.Name) %> = <%= childProp.TypeName %>.Get<%= childProp.TypeName %>(childRows);
            <%    }
            } %>
            <% if (ActiveObjects) { %>
            RegisterAndSubscribe();
            <% } %>
        }
        <%
        }
    }
}
%>
