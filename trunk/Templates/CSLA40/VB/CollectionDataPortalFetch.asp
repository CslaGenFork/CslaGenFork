<%
useInlineQuery = false;
if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.Always)
    useInlineQuery = true;
else if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.SpecifyByObject)
{
    foreach (string item in Info.GenerateInlineQueries)
    {
        if (item == "Read")
        {
            useInlineQuery = true;
            break;
        }
    }
}
if (!Info.UseCustomLoading)
{
    string createString = string.Empty;
    bool isChildCollection = (Info.IsEditableChildCollection() ||
        (Info.IsReadOnlyCollection() && Info.ParentType != string.Empty)) &&
        !isChildSelfLoaded;

    if (Info.CriteriaObjects.Count > 0)
    {
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (c.GetOptions.DataPortal)
            {
                string strGetCritParams = string.Empty;
                string strGetInvokeParams = string.Empty;
                string strGetComment = string.Empty;
                bool getIsFirst = true;

                foreach (CriteriaProperty p in c.Properties)
                {
                    if (!getIsFirst)
                    {
                        strGetCritParams += ", ";
                        strGetInvokeParams += ", ";
                        strGetComment += System.Environment.NewLine + new string(' ', 8);
                    }
                    else
                        getIsFirst = false;

                    strGetCritParams += string.Concat(FormatCamel(p.Name), " As ", (GetDataTypeGeneric(p, p.PropertyType)));
                    strGetInvokeParams += "crit." + FormatPascal(p.Name);
                    strGetComment += "''' <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
                }
                if (c.Properties.Count > 1)
                    strGetComment = "''' <param name=\"crit\">The fetch criteria.</param>";
                else if (c.Properties.Count > 0)
                    strGetInvokeParams = FormatCamel(c.Properties[0].Name);
                %>

        ''' <summary>
        ''' Loads a <see cref="<%= Info.ObjectName %>"/> collection from the database<%= (c.Properties.Count == 0 && Info.SimpleCacheOptions == SimpleCacheResults.DataPortal ? " or from the cache" : "") %><%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        ''' </summary>
        <%
                if (c.Properties.Count > 0)
                {
                    %>
        <%= strGetComment %>
        <%
                }
                if (c.GetOptions.RunLocal)
                {
                    %>
        <Csla.RunLocal()>
        <%
                }
                if (c.Properties.Count > 1)
                {
                    lastCriteria = "crit";
                    if (useInlineQuery)
                        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, "crit As " + c.Name));
                    %>
        Protected <%= isChildNotLazyLoaded ? "" : "Overloads" %> Sub <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(crit As <%= c.Name %>)
            <%
                }
                else if (c.Properties.Count > 0)
                {
                    lastCriteria = ReceiveSingleCriteriaTypeless(c, "crit");
                    if (useInlineQuery)
                        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ReceiveSingleCriteria(c, "crit")));
                    %>
        Protected <%= isChildNotLazyLoaded ? "" : "Overloads" %> Sub <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)
            <%
                }
                else
                {
                    if (useInlineQuery)
                        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ""));
                    %>
        Protected <%= isChildNotLazyLoaded ? "" : "Overloads" %> Sub <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch()
            <%
                    if (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal && c.Properties.Count == 0)
                    {
                        %>
            If IsCached Then
                LoadCachedList()
                Exit Sub
            End If

            <%
                    }
                }
                %>
            <%= GetConnection(Info, true) %>
                <%= GetCommand(Info, c.GetOptions.ProcedureName, useInlineQuery, lastCriteria) %>
                    <%
                if (Info.CommandTimeout != string.Empty)
                {
                    %>cmd.CommandTimeout = <%= Info.CommandTimeout %>
                    <%
                }
                %>cmd.CommandType = CommandType.<%= useInlineQuery ? "Text" : "StoredProcedure" %>
                    <%
                foreach (CriteriaProperty p in c.Properties)
                {
                    if (c.Properties.Count > 1)
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>
                    <%
                    }
                    else
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(p) %>
                    <%
                    }
                }
                if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
                {
                    %>cn.Open()
                    <%
                }
                string hookArgs = string.Empty;
                if (c.Properties.Count > 1)
                {
                    hookArgs = ", crit";
                }
                else if (c.Properties.Count > 0)
                {
                    hookArgs = ", " + HookSingleCriteria(c, "crit");
                }
                %>Dim args As New DataPortalHookArgs(cmd<%= hookArgs %>)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
            <%
                if (SelfLoadsChildren(Info) && TypeHelper.IsCollectionType(Info.ObjectType))
                {
                    %>
            For Each item As <%= Info.ItemType %> In Me
                item.FetchChildren()
            Next
        <%
                }
                if (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal && c.Properties.Count == 0)
                {
                    %>
            _list = Me
        <%
                }
                %>
        End Sub
<!-- #include file="SimpleCacheLoadCachedList.asp" -->
        <%
            }
        }

        if (Info.HasGetCriteria)
        {
            if (!Info.DataSetLoadingScheme)
            {
                %>

        Private Sub LoadCollection(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                Fetch(dr)
                <%
                if (itemInfo != null)
                {
                    if (ParentLoadsCollectionChildren(itemInfo))
                    {
                        %>
                If Me.Count > 0 Then
                    Me(0).FetchChildren(dr)
                End If
                <%
                    }
                }
                %>
            End Using
        End Sub
        <%
            }
            else
            {
                %>

        Private Sub LoadCollection(cmd As SqlCommand)
            Dim ds As New DataSet()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds)
            End Using
            CreateRelations(ds)
            Fetch(ds.Tables(0).Rows)
        End Sub

<!-- #include file="CreateRelations.asp" -->
<%
            }
        }
    }

    if (!Info.DataSetLoadingScheme)
    {
        %>

        ''' <summary>
        ''' Loads all <see cref="<%= Info.ObjectName %>"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub <%= (isChildCollection && !UseChildFactoryHelper ? "Child_" : "") %>Fetch(dr As SafeDataReader)
            <%
        if (Info.IsReadOnlyCollection())
        {
            %>
            IsReadOnly = False
            <%
        }
        %>
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            <%
        if (!Info.HasGetCriteria && Info.ParentType != string.Empty && !isChildSelfLoaded)
        {
            %>
            Dim args As New DataPortalHookArgs(dr)
            OnFetchPre(args)
            <%
        }
        %>
            While dr.Read()
                <%
        if (UseChildFactoryHelper)
        {
            %>
                Add(<%= Info.ItemType %>.Get<%= Info.ItemType %>(dr))
            <%
        }
        else
        {
            %>
                Add(DataPortal.Fetch<%= TypeHelper.IsNotRootType(itemInfo) ? "Child" : "" %>(Of <%= Info.ItemType %>)(dr))
            <%
        }
        %>
            End While
            <%
        if (!Info.HasGetCriteria && Info.ParentType != string.Empty && !isChildSelfLoaded)
        {
            %>
            OnFetchPost(args)
            <%
        }
        %>
            RaiseListChangedEvents = rlce
            <%
        if (Info.IsReadOnlyCollection())
        {
            %>
            IsReadOnly = True
            <%
        }
        %>
        End Sub
    <%
        if ((ancestorLoaderLevel > 1 && !ancestorIsCollection) || (ancestorLoaderLevel > 1 && ancestorIsCollection))
        {
            ChildProperty childProp = new ChildProperty();
            foreach (ChildProperty child in parentInfo.GetCollectionChildProperties())
            {
                if (child.TypeName == Info.ObjectName)
                {
                    childProp = child;
                    break;
                }
            }
            CslaObjectInfo childInfo = Info.Parent.CslaObjects.Find(childProp.TypeName);

            string findByParams = string.Empty;
            bool parentFirst = true;
            foreach(Property prop in itemInfo.ParentProperties)
            {
                if (parentFirst)
                    parentFirst = false;
                else
                    findByParams += ", ";

                findByParams += "item." + FormatCamel(GetFKColumn(itemInfo, parentInfo, prop));
            }
            string collectionObject = FormatPascal(childProp.Name);
            %>

        ''' <summary>
        ''' Loads <see cref="<%= FormatPascal(Info.ItemType) %>"/> items on the <%= FormatPascal(childProp.Name) %> collection.
        ''' </summary>
        ''' <param name="lcollection">The grand parent <see cref="<%= FormatPascal(parentInfo.ParentType) %>"/> collection.</param>
        Friend Sub LoadItems(lcollection As <%= FormatPascal(parentInfo.ParentType) %>)
            For Each item As <%= Info.ItemType %> In Me
                Dim obj = lcollection.Find<%= FormatPascal(Info.ParentType) %>ByParentProperties(<%= findByParams %>)
                <%
                if (childInfo.IsReadOnlyCollection())
                {
                    %>
                obj.<%= collectionObject %>.IsReadOnly = False
                <%
                }
                %>
                Dim rlce = obj.<%= collectionObject %>.RaiseListChangedEvents
                obj.<%= collectionObject %>.RaiseListChangedEvents = False
                obj.<%= collectionObject %>.Add(item)
                obj.<%= collectionObject %>.RaiseListChangedEvents = rlce
                <%
                if (childInfo.IsReadOnlyCollection())
                {
                    %>
                obj.<%= collectionObject %>.IsReadOnly = True
                <%
                }
                %>
            Next
        End Sub
    <%
        }
    }
    else
    {
        %>

        ''' <summary>
        ''' Loads all <see cref="<%= Info.ObjectName %>"/> collection items using given DataRow array.
        ''' </summary>
        Private Sub <%= isChildCollection ? "Child_" : "" %>Fetch(rows As DataRow())
            <%
        if (Info.IsReadOnlyCollection())
        {
            %>
            IsReadOnly = False
            <%
        }
        %>
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            For Each row As DataRow In rows
                <%
        if (UseChildFactoryHelper)
        {
            %>Add(<%= Info.ItemType %>.Get<%= Info.ItemType %>(row))
                <%
        }
        else
        {
            %>Add(DataPortal.Fetch<%= TypeHelper.IsNotRootType(itemInfo) ? "Child" : "" %>(Of <%= Info.ItemType %>)(row))
                <%
        }
        %>
        Next
            RaiseListChangedEvents = rlce
            <%
        if (Info.IsReadOnlyCollection())
        {
            %>
            IsReadOnly = True
            <%
        }
        %>
        End Sub
        <%
        if (Info.HasGetCriteria)
        {
            %>

        ''' <summary>
        ''' Loads all <see cref="<%= Info.ObjectName %>"/> collection items from given DataTable.
        ''' </summary>
        Private Sub <%= isChildCollection ? "Child_" : "" %>Fetch(rows As DataRowCollection)
            <%
            if (Info.IsReadOnlyCollection())
            {
                %>
            IsReadOnly = False
            <%
            }
            %>
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            For Each row As DataRow In rows
                <%
        if (UseChildFactoryHelper)
        {
            %>Add(<%= Info.ItemType %>.Get<%= Info.ItemType %>(row))
                <%
        }
        else
        {
            %>Add(DataPortal.Fetch<%= TypeHelper.IsNotRootType(itemInfo) ? "Child" : "" %>(Of <%= Info.ItemType %>)(row))
                <%
        }
        %>
            Next
            RaiseListChangedEvents = rlce
            <%
            if (Info.IsReadOnlyCollection())
            {
                %>
            IsReadOnly = True
            <%
            }
            %>
        End Sub
            <%
        }
    }
}
%>
