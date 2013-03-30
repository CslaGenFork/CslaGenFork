        <%
string parentType = Info.ParentType;
if (parentInfo == null)
    parentType = "";
else if (parentInfo.ObjectType == CslaObjectType.EditableChildCollection)
    parentType = parentInfo.ParentType;
else if (parentInfo.ObjectType == CslaObjectType.EditableRootCollection)
    parentType = "";
else if (parentInfo.ObjectType == CslaObjectType.DynamicEditableRootCollection)
    parentType = "";
bool isFirst = true;
if (parentType.Length > 0)
{
    foreach (Property prop in Info.ParentProperties)
    {
        if (isFirst)
            isFirst = false;
        else
            Response.Write(Environment.NewLine);

        TypeCodeEx parentPropType = prop.PropertyType;
        %>
        /// <summary>
        /// Gets or sets the parent <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.
        /// </summary>
        <%
        if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == false)
        {
            %>
        /// <value><c>true</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>false</c>.</value>
        <%
        }
        else if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == true)
        {
            %>
        /// <value><c>true</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; <c>false</c> if not <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>null</c>.</value>
        <%
        }
        else
        {
            %>
        /// <value>The <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.</value>
        <%
        }
        %>
        public <%= GetDataTypeGeneric(prop, parentPropType) %> Parent_<%= FormatPascal(prop.Name) %> { get; set; }
        <%
    }
}
foreach (ValueProperty prop in Info.GetAllValueProperties())
{
    if (isFirst)
        isFirst = false;
    else
        Response.Write(Environment.NewLine);

    TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);
    %>
        /// <summary>
        /// Gets or sets the <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.
        /// </summary>
        <%
        if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == false)
        {
            %>
        /// <value><c>true</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>false</c>.</value>
        <%
        }
        else if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == true)
        {
            %>
        /// <value><c>true</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; <c>false</c> if not <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>null</c>.</value>
        <%
        }
        else
        {
            %>
        /// <value>The <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.</value>
        <%
        }
        %>
        public <%= GetDataTypeGeneric(prop, propType) %> <%= FormatPascal(prop.Name) %> { get; set; }
        <%
}
%>
