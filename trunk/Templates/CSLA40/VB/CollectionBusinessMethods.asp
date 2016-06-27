<%
bool useParentReference = (Info.IsDynamicEditableRootCollection() ||
    (Info.IsReadOnlyCollection() && Info.ItemType != string.Empty)) && itemInfo.AddParentReference;
bool isRODeepLoadCollection =
    Info.IsReadOnlyCollection() &&
    Info.ItemType != string.Empty &&
    TypeHelper.IsReadOnlyType(itemInfo.ObjectType) &&
    ancestorLoaderLevel == 0 &&
    ParentLoadsROChildren(Info);

bool useAuthz = false;
if (!TypeHelper.IsReadOnlyType(itemInfo.ObjectType))
{
    if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
        CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel)
    {
        if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
            itemInfo.AuthzProvider != AuthorizationProvider.Custom)
        {
            if (!String.IsNullOrWhiteSpace(itemInfo.NewRoles) ||
                !String.IsNullOrWhiteSpace(itemInfo.DeleteRoles))
            {
                useAuthz = true;
            }
        }
        else if (itemInfo.NewAuthzRuleType.Constructors.Count > 0 ||
                 itemInfo.DeleteAuthzRuleType.Constructors.Count > 0)
        {
            useAuthz = true;
        }
    }
}
bool needsBusiness =
    (itemInfo.RemoveItem && itemInfo.IsEditableChild()) ||
    Info.ContainsItem;

if (!needsBusiness)
{
    foreach (Criteria crit in itemInfo.CriteriaObjects)
    {
        if (crit.CreateOptions.AddRemove ||
            (crit.DeleteOptions.AddRemove && crit.Properties.Count > 0 && itemInfo.IsNotEditableChild()))
        {
            needsBusiness = true;
            break;
        }
    }
}

if (useParentReference || isRODeepLoadCollection || useAuthz || Info.UniqueItems || needsBusiness)
{
    %>
        #Region " Collection Business Methods "
        <%
    if (useParentReference || isRODeepLoadCollection || Info.UniqueItems || useAuthz)
    {
        if (useParentReference || isRODeepLoadCollection || Info.UniqueItems || itemInfo.NewRoles.Trim() != String.Empty)
        {
            List<Property> propertyList = new List<Property>();
            string[] paramNameArray = null;
            if (Info.UniqueItems)
            {
                foreach (ValueProperty prop in itemInfo.ValueProperties)
                {
                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                    {
                        propertyList.Add(prop);
                    }
                }
                paramNameArray = new string[propertyList.Count];
                for (int i = 0; i < propertyList.Count; i++)
                {
                    Property param = propertyList[i];
                    paramNameArray[i] = param.Name;
                }
            }
            %>

        ''' <summary>
        ''' Adds a new <see cref="<%= Info.ItemType %>"/> item to the collection.
        ''' </summary>
        ''' <param name="item">The item to add.</param>
        <%
        if (useParentReference || isRODeepLoadCollection)
        {
            %>
        ''' <remarks>
        ''' There is no valid Parent property (inexistant or null).
        ''' The Add method is redefined so it takes care of filling the ParentList property.
        ''' </remarks>
        <%
        }
        if (itemInfo.NewRoles.Trim() != String.Empty)
        {
            %>
        ''' <exception cref="System.Security.SecurityException">if the user isn't authorized to add items to the collection.</exception>
        <%
        }
        if (Info.UniqueItems)
        {
            %>
        ''' <exception cref="ArgumentException">if the item already exists in the collection.</exception>
        <%
        }
        %>
        Public Overloads Sub Add(item As <%= Info.ItemType %>)
            <%
        if (itemInfo.NewRoles.Trim() != String.Empty)
        {
            %>
            If Not CanAddObject() Then
                Throw New System.Security.SecurityException("User not authorized to create a <%= Info.ItemType %>.")
            End If
        <%
        }
        if (Info.UniqueItems)
        {
            %>
            If Contains(<%
            for (int i = 0; i < propertyList.Count; i++)
            {
                %><%= (i == 0) ? "" : " AndAlso " %>item.<%= paramNameArray[i] %><%
            }
                            %>) Then
                Throw New ArgumentException("<%= Info.ItemType %> already exists.")
            End If

        <%
        }
        if (useParentReference || isRODeepLoadCollection)
        {
            %>
            item.ParentList = Me
        <%
        }
        %>
            MyBase.Add(item)
        End Sub
        <%
        }
        if (itemInfo.DeleteRoles.Trim() != String.Empty)
        {
            %>

        ''' <summary>
        ''' Removes a <see cref="<%= Info.ItemType %>"/> item from the collection.
        ''' </summary>
        ''' <param name="item">The item to remove.</param>
        ''' <returns><c>true</c> if the item was removed from the collection, otherwise <c>false</c>.</returns>
        ''' <exception cref="System.Security.SecurityException">if the user isn't authorized to remove items from the collection.</exception>
        Public Overloads Function Remove(item As <%= Info.ItemType %>) As Boolean
            If Not CanDeleteObject() Then
                Throw New System.Security.SecurityException("User not authorized to remove a <%= Info.ItemType %>.")
            End If
            Return MyBase.Remove(item)
        End Function
        <%
        }
    }

    foreach (Criteria crit in itemInfo.CriteriaObjects)
    {
        if (crit.CreateOptions.AddRemove)
        {
            if (UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous)
            {
                %>

#If Not SILVERLIGHT Then
<%
            }
            if (CurrentUnit.GenerationParams.GenerateSynchronous)
            {
                %>
<!-- #include file="AddItem.asp" -->
<%
            }
            if (!UseSilverlight() && CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                %>
<!-- #include file="AddItemAsync.asp" -->
<%
            }
            if (UseBoth() && !CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                %>

#Else
<%
            }
            if (UseSilverlight() && !CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                %>
<!-- #include file="AddItemAsync.asp" -->
<%
            }
            if (UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous)
            {
                %>

#End If
<%
            }
            if (UseSilverlight() && CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                %>
<!-- #include file="AddItemAsync.asp" -->
<%
            }
        }

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

        if (Info.IsDynamicEditableRootCollection() &&
            crit.DeleteOptions.AddRemove &&
            crit.Properties.Count > 0)
        {
            string prms = string.Empty;
            string factoryParams = string.Empty;
            string paramName = string.Empty;
            string[] factoryParamsArray = new string[crit.Properties.Count];
            string[] paramNameArray = new string[crit.Properties.Count];
            for (int i = 0; i < crit.Properties.Count; i++)
            {
                Property param = crit.Properties[i];
                prms += string.Concat(", ", FormatCamel(param.Name), " As ", GetDataTypeGeneric(param, param.PropertyType));
                factoryParams += string.Concat(", ", FormatCamel(param.Name));
                factoryParamsArray[i] = FormatCamel(param.Name);
                paramName += string.Concat(", ", param.Name);
                paramNameArray[i] = param.Name;
            }
            if (factoryParams.Length > 1)
            {
                factoryParams = factoryParams.Substring(2);
                prms = prms.Substring(2);
                paramName = paramName.Substring(2);
            }
            %>

        ''' <summary>
        ''' Removes a <see cref="<%= Info.ItemType %>"/> item from the collection.
        ''' </summary>
        <%
            for (int i = 0; i < crit.Properties.Count; i++)
            {
                %>
        ''' <param name="<%= FormatCamel(crit.Properties[i].Name) %>">The <%= FormatProperty(crit.Properties[i].Name) %> of the item to be removed.</param>
        <%
            }
            %>
        Public Overloads Sub Remove(<%= prms %>)
            For Each item As <%= Info.ItemType %> In Me
                If <%
            for (int i = 0; i < crit.Properties.Count; i++)
            {
                %><%= (i == 0) ? "" : " AndAlso " %>item.<%= paramNameArray[i] %> = <%= factoryParamsArray[i] %><%
            }
                        %> Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub
        <%
        }
    }

    if (Info.IsEditableRootCollection() ||
        Info.IsDynamicEditableRootCollection() ||
        Info.IsEditableChildCollection() ||
        Info.IsReadOnlyCollection())
    {
        List<Property> propertyList = new List<Property>();
        foreach (ValueProperty prop in itemInfo.ValueProperties)
        {
            if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
            {
                propertyList.Add(prop);
            }
        }
        string prms = string.Empty;
        string factoryParams = string.Empty;
        string paramName = string.Empty;
        string[] factoryParamsArray = new string[propertyList.Count];
        string[] paramNameArray = new string[propertyList.Count];
        for (int i = 0; i < propertyList.Count; i++)
        {
            Property param = propertyList[i];
            prms += string.Concat(", ", FormatCamel(param.Name), " As ", GetDataTypeGeneric(param, param.PropertyType));
            factoryParams += string.Concat(", ", FormatCamel(param.Name));
            factoryParamsArray[i] = FormatCamel(param.Name);
            paramName += string.Concat(", ", param.Name);
            paramNameArray[i] = param.Name;
        }
        if (factoryParams.Length > 1)
        {
            factoryParams = factoryParams.Substring(2);
            prms = prms.Substring(2);
            paramName = paramName.Substring(2);
        }
        bool removeFlag = false;
        if (itemInfo.IsEditableChild())
            removeFlag = itemInfo.RemoveItem;
        if (removeFlag)
        {
            %>

        ''' <summary>
        ''' Removes a <see cref="<%= Info.ItemType %>"/> item from the collection.
        ''' </summary>
        <%
            for (int i = 0; i < propertyList.Count; i++)
            {
                %>
        ''' <param name="<%= FormatCamel(propertyList[i].Name) %>">The <%= FormatProperty(propertyList[i].Name) %> of the item to be removed.</param>
        <%
            }
            %>
        Public Overloads Sub Remove(<%= prms %>)
            For Each item As <%= Info.ItemType %> In Me
                If <%
            for (int i = 0; i < propertyList.Count; i++)
            {
                %><%= (i == 0) ? "" : " AndAlso " %>item.<%= paramNameArray[i] %> = <%= factoryParamsArray[i] %><%
            }
                            %> Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub
        <%
        }
        if (Info.ContainsItem)
        {
            %>

        ''' <summary>
        ''' Determines whether a <see cref="<%= Info.ItemType %>"/> item is in the collection.
        ''' </summary>
        <%
            for (int i = 0; i < propertyList.Count; i++)
            {
                %>
        ''' <param name="<%= FormatCamel(propertyList[i].Name) %>">The <%= FormatProperty(propertyList[i].Name) %> of the item to search for.</param>
        <%
            }
        %>
        ''' <returns><c>true</c> if the <%= Info.ItemType %> is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(<%= prms %>) As Boolean
            For Each item As <%= Info.ItemType %> In Me
                If <%
            for (int i = 0; i < propertyList.Count; i++)
            {
                %><%= (i == 0) ? "" : " AndAlso " %>item.<%= paramNameArray[i] %> = <%= factoryParamsArray[i] %><%
            }
                            %> Then
                    Return True
                End If
            Next
            Return False
        End Function
        <%
            if (Info.IsNotReadOnlyCollection() && Info.IsNotDynamicEditableRootCollection())
            {
                %>

        ''' <summary>
        ''' Determines whether a <see cref="<%= Info.ItemType %>"/> item is in the collection's DeletedList.
        ''' </summary>
        <%
                for (int i = 0; i < propertyList.Count; i++)
                {
                    %>
        ''' <param name="<%= FormatCamel(propertyList[i].Name) %>">The <%= FormatProperty(propertyList[i].Name) %> of the item to search for.</param>
        <%
                }
                %>
        ''' <returns><c>true</c> if the <%= Info.ItemType %> is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(<%= prms %>) As Boolean
            For Each item As <%= Info.ItemType %> In Me.DeletedList
                If <%
                for (int i = 0; i < propertyList.Count; i++)
                {
                    %><%= (i == 0) ? "" : " AndAlso " %>item.<%= paramNameArray[i] %> = <%= factoryParamsArray[i] %><%
                }
                            %> Then
                    Return True
                End If
            Next
            Return False
        End Function
        <%
            }
        }
    }

%>

        #End Region
<%
}
Response.Write(Environment.NewLine);
%>
