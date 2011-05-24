<%
IndentLevel = 2;
bool isReadOnly = (Info.ObjectType == CslaObjectType.ReadOnlyObject);
%>
        #region Business Properties
        <%
foreach (ValueProperty prop in Info.AllValueProperties)
{
    bool useSetter = true;

    if (Info.ObjectType == CslaObjectType.ReadOnlyObject)
    {
        if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
            prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
        {
            if (CurrentUnit.GenerationParams.ForceReadOnlyProperties)
            {
                useSetter = false;
            }
        }
        else if (prop.DeclarationMode != PropertyDeclaration.AutoProperty)
        {
            useSetter = false;
        }
    }

    if (prop.ReadOnly && prop.DeclarationMode != PropertyDeclaration.AutoProperty)
    {
        useSetter = false;
    }

    string statement = PropertyInfoDeclare(Info, prop, false);
    if (!string.IsNullOrEmpty(statement))
    {
        statement = new string(' ', 8) + statement;
        string statementSilverlight = string.Empty;
        if (!CurrentUnit.GenerationParams.UsePublicPropertyInfo)
        {
            if (CurrentUnit.GenerationParams.GenerateSilverlight4)
            {
                statementSilverlight = "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" + "\r\n" + new string(' ', 8);
                statementSilverlight += PropertyInfoDeclare(Info, prop, true);
            }
        }
        %>

        /// <summary>
        /// Maintains metadata about <see cref="<%= prop.Name %>"/> property.
        /// </summary>
<%= CurrentUnit.GenerationParams.UsePublicPropertyInfo ? "" : IfSilverlight (Conditional.Silverlight, 2, ref silverlightLevel, true, true) %><%= statementSilverlight %><%= CurrentUnit.GenerationParams.UsePublicPropertyInfo ? "" : IfSilverlight (Conditional.Else, 0, ref silverlightLevel, true, true) %><%= statement %><%= CurrentUnit.GenerationParams.UsePublicPropertyInfo ? "" : IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true) %><%
    }
    if (prop.DeclarationMode != PropertyDeclaration.NoProperty)
    {
        if (prop.Summary != String.Empty)
        {
            IndentLevel = 2;
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
        /// Gets <%= useSetter ? "or sets " : "" %>the <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>.
        /// </summary>
        <%
        }
        if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == false)
        {
            %>
        /// <value><c>true</c> if <%= prop.FriendlyName != String.Empty ? prop.FriendlyName : CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>; otherwise, <c>false</c>.</value>
        <%
        }
        else if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == true)
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
            IndentLevel = 2;
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
                // empty
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

// Child properties
int childCount = 0;
foreach (ChildProperty prop in Info.GetMyChildProperties())
{
    childCount ++;
    string statement = PropertyInfoChildDeclare(Info, prop, false);
    if (!string.IsNullOrEmpty(statement))
    {
        statement = new string(' ', 8) + statement;
        string statementSilverlight = string.Empty;
        if (!CurrentUnit.GenerationParams.UsePublicPropertyInfo)
        {
            if (CurrentUnit.GenerationParams.GenerateSilverlight4)
            {
                statementSilverlight = "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" + "\r\n" + new string(' ', 8);
                statementSilverlight += PropertyInfoChildDeclare(Info, prop, true);
            }
        }
        %>

        /// <summary>
        /// Maintains metadata about child <see cref="<%= prop.Name %>"/> property.
        /// </summary>
<%= CurrentUnit.GenerationParams.UsePublicPropertyInfo ? "" : IfSilverlight (Conditional.Silverlight, 2, ref silverlightLevel, true, true) %><%= statementSilverlight %><%= CurrentUnit.GenerationParams.UsePublicPropertyInfo ? "" : IfSilverlight (Conditional.Else, 0, ref silverlightLevel, true, true) %><%= statement %><%= CurrentUnit.GenerationParams.UsePublicPropertyInfo ? "" : IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true)+"\r\n" %><%
    }
    if (prop.Summary != String.Empty)
    {
        IndentLevel = 2;
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
        /// Gets the <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %> (<%= (prop.LoadingScheme == LoadingScheme.ParentLoad) ? "\"parent load\" " : (prop.LazyLoad ? "\"lazy load\" " : "\"self load\" ") %>child property).
        /// </summary>
        /// <value>The <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>.</value>
        <%
    }
    if (prop.Remarks != String.Empty)
    {
        IndentLevel = 2;
        %>
        /// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        /// </remarks>
        <%
    }
    %>
        <%= ChildPropertyDeclare(Info, prop) %>
        <%
}

// Unit of Work properties
int uowCount = 0;
foreach (UnitOfWorkProperty prop in Info.UnitOfWorkCollectionProperties)
{
    uowCount ++;
    string statement = PropertyInfoUoWDeclare(Info, prop, false);
    if (!string.IsNullOrEmpty(statement))
    {
        statement = new string(' ', 8) + statement;
        string statementSilverlight = string.Empty;
        if (!CurrentUnit.GenerationParams.UsePublicPropertyInfo)
        {
            if (CurrentUnit.GenerationParams.GenerateSilverlight4)
            {
                statementSilverlight = "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" + "\r\n" + new string(' ', 8);
                statementSilverlight += PropertyInfoUoWDeclare(Info, prop, true);
            }
        }
        %>

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="<%= prop.Name %>"/> property.
        /// </summary>
<%= CurrentUnit.GenerationParams.UsePublicPropertyInfo ? "" : IfSilverlight (Conditional.Silverlight, 2, ref silverlightLevel, true, true) %><%= statementSilverlight %><%= CurrentUnit.GenerationParams.UsePublicPropertyInfo ? "" : IfSilverlight (Conditional.Else, 0, ref silverlightLevel, true, true) %><%= statement %><%= CurrentUnit.GenerationParams.UsePublicPropertyInfo ? "" : IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true)+"\r\n" %><%
    }
    if (prop.Summary != String.Empty)
    {
        IndentLevel = 2;
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
        /// Gets the <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %> object (unit of work child property).
        /// </summary>
        /// <value>The <%= CslaGenerator.Metadata.ValueProperty.SplitOnCaps(prop.Name) %>.</value>
        <%
    }
    if (prop.Remarks != String.Empty)
    {
        IndentLevel = 2;
        %>
        /// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        /// </remarks>
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

        #endregion
