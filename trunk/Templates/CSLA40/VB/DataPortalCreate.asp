<%
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.CreateOptions.DataPortal)
    {
        string dataPortalCreate = string.Empty;
        if (isChildNotLazyLoaded && c.CreateOptions.RunLocal)
            dataPortalCreate = "Child_";
        else
            dataPortalCreate = "DataPortal_";
        %>

        ''' <summary>
        ''' Loads default values for the <see cref="<%= Info.ObjectName %>"/> object properties<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        ''' </summary>
        <%
        if (c.Properties.Count > 0)
        {
            %>''' <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The create criteria.</param>
        <%
        }
        if (c.CreateOptions.RunLocal)
        {
            %><Csla.RunLocal()>
        <%
        }
        if (c.Properties.Count > 1)
        {
            %>Protected <%= Info.IsReadOnlyObject() ? "" : "Overloads " %>Sub <%= dataPortalCreate %>Create(crit As <%= c.Name %>)<%
        }
        else if (c.Properties.Count > 0)
        {
            %>Protected <%= Info.IsReadOnlyObject() ? "" : "Overloads " %>Sub <%= dataPortalCreate %>Create(<%= ReceiveSingleCriteria(c, "crit") %>)<%
        }
        else
        {
            %>Protected <%= Info.IsReadOnlyObject() ? "" : "Overrides " %>Sub <%= dataPortalCreate %>Create()<%
        }
        %>
           <%
        if (Info.IsEditableSwitchable())
        {
            %>
            If crit.IsChild Then
                MarkAsChild()
            End If
            <%
        }
        foreach (ValueProperty prop in Info.ValueProperties)
        {
            if (prop.DefaultValue != String.Empty)
            {
                if (prop.DefaultValue.ToUpper() == "_lastID".ToUpper() &&
                    prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK &&
                    (prop.PropertyType == TypeCodeEx.Int16 ||
                    prop.PropertyType == TypeCodeEx.Int32 ||
                    prop.PropertyType == TypeCodeEx.Int64))
                {
                    %>
            <%= GetFieldLoaderStatement(prop, "System.Threading.Interlocked.Decrement(ref " + prop.DefaultValue.Trim() + ")") %>
            <%
                }
                else
                {
                    %>
            <%= GetFieldLoaderStatement(Info, prop, prop.DefaultValue) %>
            <%
                }
            }
            else if (prop.Nullable && prop.PropertyType == TypeCodeEx.String)
            {
                %>
            <%= GetFieldLoaderStatement(Info, prop, "Nothing") %>
            <%
            }
        }
        ValuePropertyCollection valProps = Info.GetAllValueProperties();
        foreach (CriteriaProperty p in c.Properties)
        {
            if (valProps.Contains(p.Name))
            {
                ValueProperty prop = valProps.Find(p.Name);
                if (c.Properties.Count > 1)
                {
                    %>
            <%= GetFieldLoaderStatement(prop, "crit." + FormatProperty(p.Name)) %>
            <%
                }
                else
                {
                    %>
            <%= GetFieldLoaderStatement(prop, AssignSingleCriteria(c, "crit")) %>
            <%
                }
            }
        }
        foreach (ChildProperty childProp in Info.GetAllChildProperties())
        {
            CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
            if (_child != null)
            {
                if (TypeHelper.IsEditableType(_child.ObjectType) &&
                    (childProp.LoadingScheme == LoadingScheme.ParentLoad || !childProp.LazyLoad))
                {
                    %>
            <%= GetNewChildLoadStatement(childProp, true) %>
            <%
                }
            }
        }
        string hookArgs = string.Empty;
        if (c.Properties.Count > 1)
        {
            hookArgs = "crit";
        }
        else if (c.Properties.Count > 0)
        {
            hookArgs = HookSingleCriteria(c, "crit");
        }
        %>
            Dim args As New DataPortalHookArgs(<%= hookArgs %>)
            OnCreate(args)
            <%
        if (Info.IsNotReadOnlyObject())
        {
            %>
            MyBase.<%= dataPortalCreate %>Create()
            <%
        }
        %>
        End Sub
    <%
    }
}
%>
