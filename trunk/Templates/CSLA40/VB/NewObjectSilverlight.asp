<%
if (UseSilverlight())
{
    int createCriteriaCount = 0;
    bool runLocal = true;
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.CreateOptions.Factory)
        {
            runLocal = c.CreateOptions.RunLocal;
            createCriteriaCount ++;
        }
    }
    if (createCriteriaCount == 0 && runLocal &&
        (Info.IsEditableRootCollection() ||
        Info.IsDynamicEditableRootCollection() ||
        Info.IsEditableChildCollection()))
    {
        %>

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Sub New<%= Info.ObjectName %>(callback As EventHandler(Of DataPortalResult(Of <%= Info.ObjectName %>)))
            DataPortal.BeginCreate(Of <%= Info.ObjectName %>)(callback, DataPortal.ProxyModes.LocalOnly)
        End Sub
        <%
    }
    else
    {
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (c.CreateOptions.Factory &&
                (CurrentUnit.GenerationParams.SilverlightUsingServices ||
                (CurrentUnit.GenerationParams.GenerateSilverlight4 && c.CreateOptions.RunLocal)))
            {
                string strNewParams = string.Empty;
                string strNewCritParams = string.Empty;
                string strNewComment = string.Empty;
                string strNewCallback = string.Empty;
                /*string strNewProxyMode = string.Empty;*/
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    if (i > 0)
                    {
                        strNewParams += ", ";
                        strNewCritParams += ", ";
                    }
                    strNewParams += string.Concat(FormatCamel(c.Properties[i].Name), " As ", GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType));
                    strNewCritParams += FormatCamel(c.Properties[i].Name);
                    strNewComment += "''' <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + FormatProperty(c.Properties[i].Name) + " of the " + Info.ObjectName + " to create.</param>" + System.Environment.NewLine + new string(' ', 8);
                }
                if (!useUnitOfWorkCreator)
                {
                    strNewCallback = (strNewCritParams.Length > 0 ? ", " : "") + "callback";
                    /*if (c.CreateOptions.RunLocal ||
                        CurrentUnit.GenerationParams.SilverlightUsingServices)
                    {
                        strNewProxyMode = "DataPortal.ProxyModes.LocalOnly";
                    }
                    else
                    {
                        strNewProxyMode = "DataPortal.ProxyModes.Auto";
                    }*/
                }
                else
                {
                    strNewCallback = (strNewCritParams.Length > 0 ? ", " : "");
                }
                strNewParams += (strNewParams.Length > 0 ? ", " : "") +  "callback As EventHandler(Of DataPortalResult(Of " + Info.ObjectName + "))";
                if (!isChild && !c.NestedClass && c.Properties.Count > 1 && Info.IsNotEditableSwitchable())
                {
                    %>

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %>, based on given parameters.
        ''' </summary>
        ''' <param name="crit">The create criteria.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Function New<%= Info.ObjectName %><%= c.CreateOptions.FactorySuffix %>(crit As <%= c.Name %>, callback As EventHandler(Of DataPortalResult(Of <%= Info.ObjectName %>))) As <%= Info.ObjectName %>
        {
            <%
                    if (!useUnitOfWorkCreator)
                    {
                        %>
            DataPortal.BeginCreate(Of <%= Info.ObjectName %>)(crit, callback, DataPortal.ProxyModes.LocalOnly)
        <%
                    }
                    else
                    {
                        %>
            <%= Info.UseUnitOfWorkType %>.New<%= Info.UseUnitOfWorkType %>(crit, Function(o, e)
                callback(o, New DataPortalResult(Of <%= Info.ObjectName %>)(e.[Object].<%= Info.ObjectName %>, e.Error, Nothing))
            End Function)
            <%
                    }
                    %>
        End Function
        <%
                }
                %>

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %><%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        ''' </summary>
        <%= strNewComment %>''' <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Sub New<%= Info.ObjectName %><%= c.CreateOptions.FactorySuffix %>(<%= strNewParams %>)
            <%
                if (Info.IsEditableSwitchable())
                {
                    if (strNewCritParams.Length > 0)
                    {
                        strNewCritParams = "False, " + strNewCritParams;
                    }
                    else
                    {
                        strNewCritParams = "False" ;
                    }
                }
                if (c.Properties.Count > 1)
                {
                    if (!useUnitOfWorkCreator)
                    {
                        %>
            DataPortal.BeginCreate(Of <%= Info.ObjectName %>)(New <%= c.Name %>(<%= strNewCritParams %>)<%= strNewCallback %>, DataPortal.ProxyModes.LocalOnly)
                <%
                    }
                    else
                    {
                        %>
            <%= Info.UseUnitOfWorkType %>.New<%= Info.UseUnitOfWorkType %>(<%= strNewCritParams %><%= strNewCallback %>Function (o, e)
                callback(o, New DataPortalResult(Of <%= Info.ObjectName %>)(e.[Object].<%= Info.ObjectName %>, e.Error, Nothing));
            End Function)
            <%
                    }
                }
                else if (c.Properties.Count > 0)
                {
                    if (!useUnitOfWorkCreator)
                    {
                        %>
            DataPortal.BeginCreate(Of <%= Info.ObjectName %>)(<%= SendSingleCriteria(c, strNewCritParams) %><%= strNewCallback %>, DataPortal.ProxyModes.LocalOnly)
                    <%
                    }
                    else
                    {
                        %>
            <%= Info.UseUnitOfWorkType %>.New<%= Info.UseUnitOfWorkType %>(<%= SendSingleCriteria(c, strNewCritParams) %><%= strNewCallback %>Function (o, e)
                callback(o, New DataPortalResult(Of <%= Info.ObjectName %>)(e.[Object].<%= Info.ObjectName %>, e.Error, Nothing));
            End Function)
            <%
                    }
                }
                else
                {
                    if (!useUnitOfWorkCreator)
                    {
                        %>
            DataPortal.BeginCreate(Of <%= Info.ObjectName %>)(<%= strNewCallback %>, DataPortal.ProxyModes.LocalOnly)
                    <%
                    }
                    else
                    {
                        %>
            <%= Info.UseUnitOfWorkType %>.New<%= Info.UseUnitOfWorkType %>(<%= strNewCallback %>Function (o, e)
                callback(o, New DataPortalResult(Of <%= Info.ObjectName %>)(e.[Object].<%= Info.ObjectName %>, e.Error, Nothing));
            End Function)
            <%
                    }
                }
                %>
        End Sub
        <%
            }
        }
    }
}
%>
