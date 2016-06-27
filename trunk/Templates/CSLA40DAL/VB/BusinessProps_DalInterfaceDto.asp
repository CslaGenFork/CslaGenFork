        <%
string parentType = Info.ParentType;
if (parentInfo == null)
    parentType = "";
else if (parentInfo.IsEditableChildCollection())
    parentType = parentInfo.ParentType;
else if (parentInfo.IsEditableRootCollection())
    parentType = "";
else if (parentInfo.IsDynamicEditableRootCollection())
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
        public <%= GetDataTypeGeneric(prop, prop.PropertyType) %> Parent_<%= FormatPascal(prop.Name) %> { get; set; }
        <%
    }
}
foreach (ValueProperty prop in Info.GetAllValueProperties())
{
    if (isFirst)
        isFirst = false;
    else
        Response.Write(Environment.NewLine);

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
        public <%= GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)) %> <%= FormatPascal(prop.Name) %> { get; set; }
        <%
}
%>
