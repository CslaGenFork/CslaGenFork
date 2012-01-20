<%
if (!Info.UseCustomLoading && !Info.DataSetLoadingScheme)
{
    string fetchString = string.Empty;
    if (IsNotRootType(Info) && !useChildFactory)
        fetchString = "Child_";
    if (Info.ObjectType == CslaObjectType.DynamicEditableRoot && !useChildFactory)
        fetchString = "DataPortal_";
    %>

        /// <summary>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void <%= fetchString %>Fetch(SafeDataReader dr)
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
    bool isRoot = IsRootType(Info);
    if (plainConvertProperties.Count > 0)
    {
        %>ConvertPropertiesOnRead();
            <%
    }
    %>var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }
        <%
    if (ParentLoadsChildren(Info))
    {
        %>

        /// <summary>
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        <%= isRoot ? "private" : "internal" %> void FetchChildren(SafeDataReader dr)
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
                    if (useChildFactory)
                        fetchString = childProp.TypeName + ".Get" + childProp.TypeName;
                    else
                        fetchString = "DataPortal.FetchChild<" + childProp.TypeName + ">";

                    if (childProp.DeclarationMode == PropertyDeclaration.Managed ||
                        childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                    {
                        %>
                LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= fetchString %>(dr));
            <%
                    }
                    else
                    {
                        %>
            <%= GetFieldLoaderStatement(childProp, fetchString +"(dr)") %>;
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
                    if (useChildFactory)
                        fetchString = childProp.TypeName + ".Get" + childProp.TypeName;
                    else
                        fetchString = "DataPortal.FetchChild<" + childProp.TypeName + ">";

                    if (childProp.DeclarationMode == PropertyDeclaration.Managed ||
                        childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                    {
                        %>
            LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= fetchString %>(dr));
            <%
                    }
                    else
                    {
                        %>
            <%= GetFieldLoaderStatement(childProp, fetchString +"(dr)") %>;
            <%
                    }
                }
            }
        }
        %>
        }
        <%
    }
    if (SelfLoadsChildren(Info))
    {
        bool isParentRootCollection = false;
        CslaObjectInfo parentInfo2 = Info.Parent.CslaObjects.Find(Info.ParentType);
        if (parentInfo2 != null)
            isParentRootCollection = (parentInfo2.ObjectType == CslaObjectType.EditableRootCollection) ||
                (parentInfo2.ObjectType == CslaObjectType.ReadOnlyCollection && parentInfo2.ParentType == String.Empty);
        %>

        /// <summary>
        /// Loads child objects.
        /// </summary>
        <%= isParentRootCollection ? "internal" : "private" %> void FetchChildren()
        {
            <%
        foreach (ChildProperty childProp in Info.GetMyChildProperties())
        {
            if (childProp.LoadingScheme == LoadingScheme.SelfLoad && !childProp.LazyLoad)
            {
                CslaObjectInfo childInfo = FindChildInfo(Info, childProp.TypeName);
                if (childInfo != null)
                {
                    string invokeParam = string.Empty;
                    bool first1 = true;
                    if (isParentRootCollection)
                    {
                        foreach (Property prop in childProp.ParentLoadProperties)
                        {
                            if (first1)
                                first1 = false;
                            else
                                invokeParam += ", ";

                            invokeParam += FormatPascal(prop.Name);
                        }
                    }
                    else
                    {
                        foreach (Parameter parm in childProp.LoadParameters)
                        {
                            if (first1)
                                first1 = false;
                            else
                                invokeParam += ", ";

                            invokeParam += FormatPascal(parm.Property.Name);
                        }
                    }
                    if (useChildFactory)
                        fetchString = childProp.TypeName + ".Get" + childProp.TypeName;
                    else
                        fetchString = "DataPortal.FetchChild<" + childProp.TypeName + ">";

                    if (childProp.DeclarationMode == PropertyDeclaration.Managed)
                    {
                        %>
            LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= fetchString %>(<%= invokeParam %>));
            <%
                    }
                    else if (childProp.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                        childProp.DeclarationMode == PropertyDeclaration.AutoProperty)
                    {
                        %>
            <%= GetFieldLoaderStatement(childProp, fetchString +"(" + invokeParam + ")") %>;
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
%>
