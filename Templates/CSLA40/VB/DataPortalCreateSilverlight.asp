<%
if (CurrentUnit.GenerationParams.GenerateSilverlight4)
{
foreach (Criteria c in GetCriteriaObjects(Info))
{
    if (c.CreateOptions.DataPortal && c.CreateOptions.RunLocal)
    {
        %>
        /// <summary>
        /// Load default values for the <see cref="<%=Info.ObjectName%>"/> object properties.
        /// Values must be hardcoded.
        /// </summary>
        <%
        if (c.Properties.Count > 0)
        {
        %>/// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The create criteria.</param>
        <%
        }
        %>[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        <%
        if (c.Properties.Count > 1)
        {
            %>public void <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child_" : "DataPortal_" %>Create(<%= c.Name %> crit, Csla.DataPortalClient.LocalProxy<<%=Info.ObjectName%>>.CompletedHandler handler)<%
        }
        else if (c.Properties.Count > 0)
        {
            %>public void <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child_" : "DataPortal_" %>Create(<%= ReceiveSingleCriteria(c, "crit") %>, Csla.DataPortalClient.LocalProxy<<%=Info.ObjectName%>>.CompletedHandler handler)<%
        }
        else
        {
            %>public <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "void Child_" : "override void DataPortal_" %>Create(Csla.DataPortalClient.LocalProxy<<%=Info.ObjectName%>>.CompletedHandler handler)<%
        }
        %>
        {
            <%
    if (Info.ObjectType == CslaObjectType.EditableSwitchable)
    {
        %>
            if (crit.IsChild)
                MarkAsChild();
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
            <%= GetFieldLoaderStatement(prop, "System.Threading.Interlocked.Decrement(ref " + prop.DefaultValue.Trim() + ")") %>;
            <%
            }
            else
            {
                %>
            <%= GetFieldLoaderStatement(Info, prop, prop.DefaultValue) %>;
            <%
            }
        }
        else if (prop.Nullable && prop.PropertyType == TypeCodeEx.String)
        {
            %>
            <%= GetFieldLoaderStatement(Info, prop, "null") %>;
            <%
        }
    }
    ValuePropertyCollection valProps = Info.GetAllValueProperties();
    foreach (Property p in c.Properties)
    {
        if (valProps.Contains(p.Name))
        {
            ValueProperty prop = valProps.Find(p.Name);
            if (c.Properties.Count > 1)
            {
                %>
            <%= GetFieldLoaderStatement(prop, "crit." + FormatProperty(p.Name)) %>;
            <%
            }
            else
            {
                %>
            <%= GetFieldLoaderStatement(prop, AssignSingleCriteria(c, "crit")) %>;
            <%
            }
        }
    }
    foreach (ChildProperty childProp in Info.GetCollectionChildProperties())
    {
        CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
        if (_child != null && childProp.LoadingScheme == LoadingScheme.ParentLoad)
        {
            %>
            <%= GetNewChildLoadStatement(childProp, true) %>;
            <%
        }
    }
    // this is DataPortal_Create; so always CheckRules except for ReadOnlyCollection
    if (Info.ObjectType != CslaObjectType.ReadOnlyCollection)
    {
        %>
            BusinessRules.CheckRules();
            <%
    }
    %>
            base.<%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child_Create()" : "DataPortal_Create(handler)" %>;
        }
    <%
    }
}
}
%>
