<%
bool useParentReference = (Info.IsDynamicEditableRoot() ||
    (Info.IsReadOnlyObject() && Info.ParentType != string.Empty)) && Info.AddParentReference;
bool isRODeepLoadCollection =
    Info.IsReadOnlyObject() &&
    Info.ParentType != string.Empty &&
    TypeHelper.IsReadOnlyType(parentInfo.ObjectType) &&
    ancestorLoaderLevel == 1 &&
    ParentLoadsROChildren(Info);

IndentLevel = 2;
%>
<!-- #include file="InternalProps.asp" -->

        #Region " Business Properties "
        <%
string softDeleteColumn = Info.Parent.Params.SpBoolSoftDeleteColumn;
foreach (ValueProperty prop in Info.ValueProperties)
{
    if (isUndeletable == false && prop.DbBindColumn != null)
    {
        if (prop.DbBindColumn.ColumnName == softDeleteColumn)
        {
            softDeleteProperty = prop.Name;
            isUndeletable = true;
        }
    }

    bool useSetter = !prop.ReadOnly;
    if (Info.IsReadOnlyObject() && CurrentUnit.GenerationParams.ForceReadOnlyProperties)
    {
        useSetter = false;
    }

    string statement = PropertyInfoDeclare(Info, prop);
    if (!string.IsNullOrEmpty(statement))
    {
        %>

        ''' <summary>
        ''' Maintains metadata about <see cref="<%= string.IsNullOrEmpty(prop.Interfaces) ? prop.Name : prop.Interfaces %>"/> property.
        ''' </summary>
<%= statement %><%
    }
    if (prop.DeclarationMode != PropertyDeclaration.NoProperty)
    {
        if (prop.Summary != String.Empty)
        {
            IndentLevel = 2;
            %>
        ''' <summary>
<%= GetXmlCommentString(prop.Summary) %>
        ''' </summary>
        <%
        }
        else
        {
            %>

        ''' <summary>
        ''' Gets <%= useSetter ? "or sets " : "" %>the <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.
        ''' </summary>
        <%
        }
        if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == false)
        {
            %>
        ''' <value><c>True</c> if <%= prop.FriendlyName != String.Empty ? System.Net.WebUtility.HtmlEncode(prop.FriendlyName) : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>false</c>.</value>
        <%
        }
        else if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == true)
        {
            %>
        ''' <value><c>True</c> if <%= prop.FriendlyName != String.Empty ? System.Net.WebUtility.HtmlEncode(prop.FriendlyName) : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; <c>false</c> if not <%= prop.FriendlyName != String.Empty ? System.Net.WebUtility.HtmlEncode(prop.FriendlyName) : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>null</c>.</value>
        <%
        }
        else
        {
            %>
        ''' <value>The <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.</value>
        <%
        }
        if (prop.Remarks != String.Empty)
        {
            IndentLevel = 2;
            %>
        ''' <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        ''' </remarks>
        <%
        }
        %>
        <%
        if (GetAttributesString(prop.Attributes) != string.Empty)
        {
            %>
        <%= GetAttributesString(prop.Attributes) %>
        <%
        }
    }
    statement = PropertyDeclare(Info, prop);
    if (!string.IsNullOrEmpty(statement))
    {
        %>
        <%= statement %>
        <%
    }
}

// Convert properties
foreach (ConvertValueProperty prop in Info.ConvertValueProperties)
{
    bool useSetter = !prop.ReadOnly;
    if (Info.IsReadOnlyObject() && CurrentUnit.GenerationParams.ForceReadOnlyProperties)
    {
        useSetter = false;
    }

    if (prop.Summary != String.Empty)
    {
        IndentLevel = 2;
        %>
        ''' <summary>
<%= GetXmlCommentString(prop.Summary) %>
        ''' </summary>
        <%
    }
    else
    {
        %>

        ''' <summary>
        ''' Gets <%= useSetter ? "or sets " : "" %>the <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.
        ''' </summary>
        <%
    }
    if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == false)
    {
        %>
        ''' <value><c>True</c> if <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>false</c>.</value>
        <%
    }
    else if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == true)
    {
        %>
        ''' <value><c>True</c> if <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; <c>false</c> if not <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>null</c>.</value>
        <%
    }
    else
    {
        %>
        ''' <value>The <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.</value>
        <%
    }
    if (prop.Remarks != String.Empty)
    {
        IndentLevel = 2;
        %>
        ''' <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        ''' </remarks>
        <%
    }
        %>
        <%
    if (GetAttributesString(prop.Attributes) != string.Empty)
    {
        %>
        <%= GetAttributesString(prop.Attributes) %>
        <%
    }
    string statement = PropertyConvertDeclare(Info, prop);
    if (!string.IsNullOrEmpty(statement))
    {
        %>
        <%= statement %>
        <%
    }
}

// Child properties
int childCount = 0;
foreach (ChildProperty prop in Info.GetMyChildProperties())
{
    childCount ++;
    string statement = PropertyInfoChildDeclare(Info, prop);
    if (!string.IsNullOrEmpty(statement))
    {
        %>

        ''' <summary>
        ''' Maintains metadata about child <see cref="<%= string.IsNullOrEmpty(prop.Interfaces) ? prop.Name : prop.Interfaces %>"/> property.
        ''' </summary>
<%= statement %><%
    }
    if (prop.Summary != String.Empty)
    {
        IndentLevel = 2;
        %>
        ''' <summary>
<%= GetXmlCommentString(prop.Summary) %>
        ''' </summary>
        <%
    }
    else
    {
        %>

        ''' <summary>
        ''' Gets the <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %> (<%= (prop.LoadingScheme == LoadingScheme.ParentLoad) ? "\"parent load\" " : (prop.LazyLoad ? "\"lazy load\" " : "\"self load\" ") %>child property).
        ''' </summary>
        ''' <value>The <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.</value>
        <%
    }
    if (prop.Remarks != String.Empty)
    {
        IndentLevel = 2;
        %>
        ''' <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        ''' </remarks>
        <%
    }
    %>
    <%
    if (GetAttributesString(prop.Attributes) != string.Empty)
    {
        %>
        <%= GetAttributesString(prop.Attributes) %>
        <%
    }
    %>
        <%= ChildPropertyDeclare(Info, prop) %>
        <%
}

// Unit of Work properties
int uowCount = 0;
foreach (UnitOfWorkProperty prop in Info.UnitOfWorkProperties)
{
    uowCount ++;
    string statement = PropertyInfoUoWDeclare(Info, prop);
    if (!string.IsNullOrEmpty(statement))
    {
        %>

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="<%= prop.Name %>"/> property.
        ''' </summary>
<%= statement %><%
    }
    if (prop.Summary != String.Empty)
    {
        IndentLevel = 2;
        %>
        ''' <summary>
<%= GetXmlCommentString(prop.Summary) %>
        ''' </summary>
        <%
    }
    else
    {
        %>

        ''' <summary>
        ''' Gets the <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %> object (unit of work child property).
        ''' </summary>
        ''' <value>The <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.</value>
        <%
    }
    if (prop.Remarks != String.Empty)
    {
        IndentLevel = 2;
        %>
        ''' <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        ''' </remarks>
        <%
    }
    %>
        <%= UnitOfWorkPropertyDeclare(Info, prop) %>
        <%
}

string strGetIdValue = string.Empty;
bool singleProperty = true;
foreach (ValueProperty prop in Info.ValueProperties)
{
    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
    {
        if (strGetIdValue.Length > 0)
        {
            strGetIdValue += ".ToString() + \"!\" + ";
            singleProperty = false;
        }
        strGetIdValue += FormatFieldName(prop.Name);
    }
    if (!singleProperty)
    {
        strGetIdValue += ".ToString()";
    }
}
        %>

        #End Region
        <%
if (useIsLoadedProperty)
{
    %>

        #Region " State Property "

        ''' <summary>
        ''' Maintains metadata about <see cref="IsLoaded"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly IsLoadedProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.IsLoaded, String.Empty, False)
        ''' <summary>
        ''' Gets the IsLoaded state.
        ''' </summary>
        ''' <value>The IsLoaded state.</value>
        Public ReadOnly Property IsLoaded() As Boolean
            Get
                Return GetProperty(IsLoadedProperty)
            End Get
        End Property

        #End Region
        <%
}
        %>
