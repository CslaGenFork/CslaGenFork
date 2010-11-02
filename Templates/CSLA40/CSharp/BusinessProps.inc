<%
IndentLevel = 2; 
%>
        #region Business Properties
        <%
foreach (ValueProperty prop in Info.AllValueProperties)
{
    bool isSetterReadOnly = prop.PropSetAccessibility == AccessorVisibility.NoSetter;
    string statement = PropertyInfoDeclare(Info, prop);
    if (!string.IsNullOrEmpty(statement))
    {
        Response.Write(Environment.NewLine); %>
        /// <summary>
        /// Maintains metadata about <see cref="<%= prop.Name %>"/> property.
        /// </summary>
        <%= statement %><%
    }
    if (prop.DeclarationMode != PropertyDeclaration.NoProperty)
    {
        if (prop.Summary != String.Empty)
        {
            %>
        /// <summary>
<%= GetXmlCommentString(prop.Summary) %>
        /// </summary>
        <%
        }
        else
        {
            Response.Write("\r\n");
            %>
        /// <summary>
        /// Gets <%= (isSetterReadOnly ? "" : "or sets ") %>the <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>.
        /// </summary>
        <%
        }
        if(prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == false)
        {
            %>
        /// <value><c>true</c> if <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>; otherwise, <c>false</c>.</value>
        <%
        }
        else if(prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == true)
        {
            %>
        /// <value><c>true</c> if <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>; <c>false</c> if not <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>; otherwise, <c>null</c>.</value>
        <%
        }
        else
        {
            %>
        /// <value>The <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>.</value>
        <%
        }
        if (prop.Remarks != String.Empty)
        {
            %>
        /// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        /// </remarks>
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
        <%= statement  + Environment.NewLine %><%
    }
    if (prop.DeclarationMode != PropertyDeclaration.Managed &&
        prop.DeclarationMode != PropertyDeclaration.ManagedWithTypeConversion)
    {
        if (Info.ObjectType != CslaObjectType.ReadOnlyObject && prop.ReadOnly == false)
        {
            if (prop.PropertyType != TypeCodeEx.ByteArray)
            {
            }
            else
            {
                %>
                bool setNewValue = false;
                if (value != null && <%=FormatFieldName(prop.Name)%> == null)
                    setNewValue = true;
                if (!setNewValue && value != null && <%=FormatFieldName(prop.Name)%> != null)
                {
                    if (<%=FormatFieldName(prop.Name)%>.Length != value.Length)
                    {
                        setNewValue = true;
                    }
                    else
                    {
                        for (int i=0; i < value.Length; i++)
                        {
                            if (value[i] != <%=FormatFieldName(prop.Name)%>[i])
                            {
                                setNewValue = true;
                                break;
                            }
                        }
                    }
                }
                if (setNewValue)
                {
                    <%
            }
        }
    }
}

int childCount = 0;
foreach (ChildProperty prop in Info.GetMyChildProperties())
{
    childCount ++;
    Response.Write("\r\n");
    string statement = PropertyInfoChildDeclare(Info, prop);
    if (!string.IsNullOrEmpty(statement))
    {
        %>
        /// <summary>
        /// Maintains metadata about child <see cref="<%= prop.Name %>"/> property.
        /// </summary>
        <%= statement + Environment.NewLine %><%
    }
    if (prop.Summary != String.Empty)
    {
        %>
        /// <summary>
<%= GetXmlCommentString(prop.Summary) %>
        /// </summary>
        <%
    }
    else
    {
        %>
        /// <summary>
        /// Gets the <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %> (child property).
        /// </summary>
        /// <value>The <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>.</value>
        <%
    }
    %>
        <%
    if (prop.Remarks != String.Empty)
    {
        %>
        /// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        /// </remarks>
        <%
    }
    %>
        <%= PropertyDeclare(Info, prop) %>
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
        strGetIdValue += ".ToString()";
}
        %>

        #endregion
