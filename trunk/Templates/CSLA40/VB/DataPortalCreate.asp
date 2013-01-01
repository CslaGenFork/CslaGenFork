<%
string dataPortalCreate = string.Empty;
if (isChild)
dataPortalCreate = "Child_";
else
dataPortalCreate = "DataPortal_";
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.CreateOptions.DataPortal)
    {
        %>

        /// <summary>
        /// Loads default values for the <see cref="<%= Info.ObjectName %>"/> object properties<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
        if (c.Properties.Count > 0)
        {
            %>/// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The create criteria.</param>
        <%
        }
        if (c.CreateOptions.RunLocal)
        {
            %>[Csla.RunLocal]
        <%
        }
        if (c.Properties.Count > 1)
        {
            %>protected void <%= dataPortalCreate %>Create(<%= c.Name %> crit)<%
        }
        else if (c.Properties.Count > 0)
        {
            %>protected void <%= dataPortalCreate %>Create(<%= ReceiveSingleCriteria(c, "crit") %>)<%
        }
        else
        {
            %>protected <%= Info.ObjectType == CslaObjectType.ReadOnlyObject ? "" : "override " %>void <%= dataPortalCreate %>Create()<%
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
        foreach (ChildProperty childProp in Info.GetAllChildProperties())
        {
            CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
            if (_child != null)
            {
                if (IsEditableType(_child.ObjectType) &&
                    (childProp.LoadingScheme == LoadingScheme.ParentLoad || !childProp.LazyLoad))
                {
                    %>
            <%= GetNewChildLoadStatement(childProp, true) %>;
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
            var args = new DataPortalHookArgs(<%= hookArgs %>);
            OnCreate(args);
            <%
        if (Info.ObjectType != CslaObjectType.ReadOnlyObject)
        {
            %>
            base.<%= dataPortalCreate %>Create();
            <%
        }
        %>
        }
    <%
    }
}
%>
