<%
CslaObjectInfo authzInfo = Info;
if (TypeHelper.IsCollectionType(Info.ObjectType))
{
    authzInfo = FindChildInfo(Info, Info.ItemType);
    if (authzInfo == null)
    {
        Errors.Append("Collection " + Info.ObjectName + " missing Item Type." + Environment.NewLine);
        return;
    }
}

if (!Info.DataSetLoadingScheme)
{
    if ((Info.ParentType != string.Empty || isItem) && !isChildLazyLoaded && !isChildSelfLoaded)
    {
        %>

        ''' <summary>
        ''' Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        Friend Shared Function Get<%= Info.ObjectName %>(dr As SafeDataReader) As <%= Info.ObjectName %>
            <%
        if (authzInfo.GetRoles.Trim() != String.Empty &&
            TypeHelper.IsCollectionType(Info.ObjectType) &&
            CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
            CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel)
        {
            %>
            If Not CanGetObject()
                Throw New System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.")
        End If

            <%
        }
        %>
            Dim obj As <%= Info.ObjectName %> = New <%= Info.ObjectName %>()
            <%
        if (Info.ObjectType == CslaObjectType.EditableSwitchable ||
            (Info.ObjectType == CslaObjectType.EditableChild ||
            Info.ObjectType == CslaObjectType.EditableChildCollection))
        {
            %>
            ' show the framework that this is a child object
            obj.MarkAsChild()
            <%
        }
        %>
            obj.Fetch(dr)
            <%
        if (isChildSelfLoaded && !TypeHelper.IsCollectionType(Info.ObjectType))
        {
            %>
            obj.FetchChildren(dr)
            <%
        }
        else if (ancestorLoaderLevel > 0)
        {
            foreach (ChildProperty childProp in Info.GetCollectionChildProperties())
            {
                CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                if (_child != null)
                {
                    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                    {
                        string internalCreateString = string.Empty;
                        if (TypeHelper.IsEditableType(_child.ObjectType))
                        {
                            if (UseChildFactoryHelper)
                                internalCreateString = FormatPascal(childProp.TypeName) + ".New" + FormatPascal(childProp.TypeName);
                            else
                                internalCreateString = "DataPortal.CreateChild(Of " + FormatPascal(childProp.TypeName) + ")";
                        }
                        else
                            internalCreateString = "New " + childProp.TypeName;

                        if ((childProp.DeclarationMode == PropertyDeclaration.Managed ||
                            childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion))
                        {
                            if (useBypassPropertyChecks && false) // disable this for now
                            {
                                %>
                obj.<%= FormatPascal(childProp.Name) %> = <%= internalCreateString %>()
            <%
                            }
                            else
                            {
                                %>
            obj.LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= internalCreateString %>())
        <%
                            }
                        }
                        else
                        {
                            %>
            <%= bpcSpacer %>obj.<%= GetFieldLoaderStatement(childProp, internalCreateString + "()") %>
        <%
                        }
                    }
                }
            }
        }
        if (Info.ObjectType != CslaObjectType.ReadOnlyObject && !TypeHelper.IsCollectionType(Info.ObjectType))
        {
            %>
            obj.MarkOld()
            <%
        }
        if (Info.CheckRulesOnFetch && !Info.EditOnDemand && !TypeHelper.IsCollectionType(Info.ObjectType))
        {
            %>
            ' check all object rules and property rules
            obj.BusinessRules.CheckRules()
            <%
        }
        %>
            Return obj
        End Function
    <%
    }
}
else
{
    %>

        ''' <summary>
        ''' Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> object from the given DataRow.
        ''' </summary>
        ''' <param name="dr">The DataRow to use.</param>
        ''' <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        Friend Shared Function Get<%= Info.ObjectName %>(DataRow<% if (TypeHelper.IsCollectionType(Info.ObjectType)) { %>[]<% } %> dr) As <%= Info.ObjectName %>
            <%
    if (TypeHelper.IsCollectionType(Info.ObjectType) &&
        CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
        CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
        authzInfo.GetRoles.Trim() != String.Empty)
    {
        %>
            If Not CanGetObject()
                Throw New System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.")
            End If

            <%
    }
    %>Dim obj As <%= Info.ObjectName %> = New <%= Info.ObjectName %>()
            <%
    if (Info.ObjectType == CslaObjectType.EditableSwitchable ||
        (Info.ObjectType == CslaObjectType.EditableChild ||
        Info.ObjectType == CslaObjectType.EditableChildCollection))
    {
        %>' show the framework that this is a child object
            obj.MarkAsChild()
            <%
    }
    %>obj.Fetch(dr)
            <%
    if (isChildSelfLoaded && !TypeHelper.IsCollectionType(Info.ObjectType))
    {
        %>obj.FetchChildren(dr)
            <%
    }
    if (Info.ObjectType != CslaObjectType.ReadOnlyObject && !TypeHelper.IsCollectionType(Info.ObjectType))
    {
        %>obj.MarkOld()
            <%
    }
    if (Info.CheckRulesOnFetch && !Info.EditOnDemand && !TypeHelper.IsCollectionType(Info.ObjectType))
    {
        %>' check all object rules and property rules
            obj.BusinessRules.CheckRules()
            <%
    }
    %>

            Return obj
        End Function
    <%
}
%>
