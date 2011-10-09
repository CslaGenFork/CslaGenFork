<%
if (!Info.UseCustomLoading)
{
    if (!Info.DataSetLoadingScheme)
    {
        %>

        /// <summary>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
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
                    %><%= GetReaderAssignmentStatement(Info, prop) %>;
            <%
                }
                catch (Exception ex)
                {
                    Errors.Append(ex.Message + Environment.NewLine);
                }
            }
        }
        if (plainConvertProperties.Count > 0)
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
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void FetchChildren(SafeDataReader dr)
        {
            <%
            foreach (ChildProperty childProp in Info.GetNonCollectionChildProperties())
            {
                if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    %>
            dr.NextResult();
            if (dr.Read())
            <%
                    CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                    if (_child != null)
                    {
                        if (childProp.DeclarationMode == PropertyDeclaration.Managed ||
                            childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                        {
                            %>
                LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= childProp.TypeName %>.Get<%= childProp.TypeName %>(dr));
            <%
                        }
                        else
                        {
                            %>
                <%= GetFieldLoaderStatement(childProp, childProp.TypeName + ".Get" + childProp.TypeName +"(dr)") %>;
            <%
                        }
                    }
                }
            }
            foreach (ChildProperty childProp in Info.GetCollectionChildProperties())
            {
                if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    %>
            dr.NextResult();
            <%
                    CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                    if (_child != null)
                    {
                        if (childProp.DeclarationMode == PropertyDeclaration.Managed ||
                            childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                        {
                            %>
            LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= childProp.TypeName %>.Get<%= childProp.TypeName %>(dr));
            <%
                        }
                        else
                        {
                            %>
            <%= GetFieldLoaderStatement(childProp, childProp.TypeName + ".Get" + childProp.TypeName +"(dr)") %>;
            <%
                        }
                    }
                }
            }
            %>
        }
        <%
        }
        if(SelfLoadsChildren(Info))
        {
            %>

        /// <summary>
        /// Load child objects using given criteria.
        /// </summary>
        <%
            string methodParam = string.Empty;
            string invokeParam = string.Empty;
            bool isParentEditableRoot = false;
            CslaObjectInfo parentInfo2 = Info.Parent.CslaObjects.Find(Info.ParentType);
            if (parentInfo2 != null)
                isParentEditableRoot = parentInfo2.ObjectType == CslaObjectType.EditableRootCollection;
            foreach (Criteria c in GetCriteriaObjects(Info))
            {
                bool first1 = true;
                foreach (Property p in c.Properties)
                {
            %>
        /// <param name="<%= FormatCamel(p.Name) %>">The <%= FormatProperty(p.Name) %> of the object to be fetched.</param>
        <%
                    if (first1)
                    {
                        first1 = false;
                    }
                    else
                    {
                        methodParam += ", ";
                        invokeParam += ", ";
                    }
                    methodParam += GetDataTypeGeneric(p, p.PropertyType) + " " + FormatCamel(p.Name);
                    invokeParam += FormatCamel(p.Name);
                }
            }
            %>
        <%= isParentEditableRoot ? "internal" : "private" %> void FetchChildren(<%= methodParam %>)
        {
            <%
            foreach (ChildProperty childProp in Info.GetCollectionChildProperties())
            {
                if (childProp.LoadingScheme != LoadingScheme.ParentLoad && !childProp.LazyLoad)
                {
                    CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                    if (_child != null)
                    {
                        if (childProp.DeclarationMode == PropertyDeclaration.Managed)
                        {
                            %>
            LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= childProp.TypeName %>.Get<%= childProp.TypeName %>(<%= invokeParam %>));
            <%
                        }
                        else if (childProp.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                            childProp.DeclarationMode == PropertyDeclaration.AutoProperty)
                        {
                            %>
            <%= GetFieldLoaderStatement(childProp, childProp.TypeName + ".Get" + childProp.TypeName +"(" + invokeParam + ")") %>;
            <%
                        }
                    }
                }
            }
            %>
        }
        <%
        }
    }
    else
    {
        %>

        /// <summary>
        /// Load a <see cref="<%= Info.ObjectName %>"/> object from the given DataRow.
        /// </summary>
        /// <param name="dr">The DataRow to use.</param>
        private void Fetch(DataRow dr)
        {
            // Value properties
            <%
            foreach (ValueProperty prop in Info.GetAllValueProperties())
            {
                if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None)
                {
                    if (prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly)
                    {
                        %>if (!dr.IsNull("<%= prop.ParameterName %>"))
                <%= GetReaderAssignmentStatement(Info, prop) %>;
            <%
                    }
                }
            }
            %>var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }
        <%
        if (LoadsChildren(Info))
        {
            %>

        /// <summary>
        /// Load child objects using given DataRow.
        /// </summary>
        /// <param name="dr">The DataRow to use.</param>
        private void FetchChildren(DataRow dr)
        {
            DataRow[] childRows;
            <%
            foreach (ChildProperty childProp in Info.GetNonCollectionChildProperties())
            {
                if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    %>
            childRows = dr.GetChildRows("<%= Info.ObjectName + childProp.TypeName %>");
            if (childRows.Length > 0)
                <%= FormatFieldName(childProp.Name) %> = <%= childProp.TypeName %>.Get<%= childProp.TypeName %>(childRows[0]);
            <%
                }
            }
            foreach (ChildProperty childProp in Info.GetCollectionChildProperties())
            {
                if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    %>
            childRows = dr.GetChildRows("<%=Info.ObjectName + FindChildInfo(Info, childProp.TypeName).ItemType %>");
            <%
            CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
            if (_child != null)
                %>
            <%= FormatFieldName(childProp.Name) %> = <%= childProp.TypeName %>.Get<%= childProp.TypeName %>(childRows);
            <%
                }
            }
            %>
        }
        <%
        }
    }
}
%>
