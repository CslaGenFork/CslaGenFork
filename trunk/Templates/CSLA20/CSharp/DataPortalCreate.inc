<%
foreach (Criteria c in Info.CriteriaObjects) {
    if (c.CreateOptions.DataPortal) { %>
        /// <summary>
        /// Load default values for the <see cref="<%=Info.ObjectName%>" /> Object's properties from the database.
        /// </summary>
        <% if (c.CreateOptions.RunLocal) { %>[Csla.RunLocal()]
        <% } %>protected void DataPortal_Create(<%= c.Name %> crit)
        {
            <% if (Info.ObjectType == CslaObjectType.EditableSwitchable) { %>
            if (crit.IsChild)
                MarkAsChild();
            <% } %>
            <% foreach (ValueProperty prop in Info.ValueProperties) {
                if (prop.DefaultValue != String.Empty) { 
                    if (prop.DefaultValue.Trim().ToUpper() == "_lastID".ToUpper() && 
                    prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK && 
                    (prop.PropertyType == TypeCodeEx.Int16 || 
                    prop.PropertyType == TypeCodeEx.Int32 || 
                    prop.PropertyType == TypeCodeEx.Int64)) {%>
            <%= FormatFieldName(prop.Name) %> = System.Threading.Interlocked.Decrement(ref <%= prop.DefaultValue.Trim()%>);
                    <% } else {%>
            <%= FormatFieldName(prop.Name) %> = <%= prop.DefaultValue %>;
                    <% }
                }
            } %>
            <% ValuePropertyCollection valProps = Info.GetAllValueProperties();
            foreach (Property p in c.Properties)
            {
                if (valProps.Contains(p.Name)) { %>
            <%= FormatFieldName(p.Name) %> = crit.<%= FormatPascal(p.Name) %>;
            <%     }
            } %>
            <% foreach (ChildProperty childProp in Info.GetCollectionChildProperties()) {
                CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                if (_child != null && _child.AddParentReference) { %>
            <%=FormatFieldName(childProp.Name)%>.SetParent(this);
                <% } %>
            <% } %>
            onCreate(this, EventArgs.Empty);
            <% if (Info.ObjectType != CslaObjectType.ReadOnlyCollection) { %>
            this.ValidationRules.CheckRules();
            <% } %>
        }
<%    }
} %>
