
        #region Business Properties and Methods
        <% if (Info.ObjectType != CslaObjectType.ReadOnlyObject && (Info.ChildProperties.Count > 0 || Info.ChildCollectionProperties.Count > 0) && Info.ObjectType != CslaObjectType.ReadOnlyCollection) { %>

        /// <summary>
        /// Returns true if the Object is currently valid, false if the Object or its children has broken rules.
        /// </summary>
        public override bool IsValid
        {
            get
            {
                // If the Business Object has Children, We need to check it
                // with an && Child.IsValid clause with the Base As well
                return base.IsValid<%
                foreach (ChildProperty prop in Info.GetAllChildProperties()) {
                    CslaObjectInfo child = FindChildInfo(Info, prop.TypeName);
                    if (child != null && child.ObjectType != CslaObjectType.ReadOnlyObject && child.ObjectType != CslaObjectType.ReadOnlyCollection) {
                    %> && <% if (prop.LazyLoad) { %>(!<%=FormatFieldName(prop.Name + "Loaded")%> || <% } %><%=FormatPascal(prop.Name) %>.IsValid<% if (prop.LazyLoad) { %>)<% }
                    }
                } %>;
            }
        }

        /// <summary>
        /// Returns true if this Object's data has been changed.
        /// </summary>
        public override bool IsDirty
        {
            get
            {
                // If the Business Object has Children, We need to check it
                // with an || Child.IsDirty clause with the Base As well
                return base.IsDirty<%
                foreach (ChildProperty prop in Info.GetAllChildProperties()) {
                CslaObjectInfo child = FindChildInfo(Info, prop.TypeName);
                    if (child != null && child.ObjectType != CslaObjectType.ReadOnlyObject && child.ObjectType != CslaObjectType.ReadOnlyCollection) {
                    %> || <% if (prop.LazyLoad) { %>(<%=FormatFieldName(prop.Name + "Loaded")%> && <% } %><%=FormatPascal(prop.Name) %>.IsDirty<% if (prop.LazyLoad) { %>)<% }
                    }
                } %>;
            }
        }
        <% } %>
        <% IndentLevel = 2; %>
        <% foreach (ValueProperty prop in Info.AllValueProperties) {%>

<%            if (prop.Summary != String.Empty) { %>
        /// <summary>
<%= GetXmlCommentString(prop.Summary) %>
        /// </summary>
        <%    } %>
        <%    if (prop.Remarks != String.Empty) { %>
        /// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        /// </remarks>
        <%    } %>
        <%    if (GetAttributesString(prop.Attributes) != string.Empty) { %>
        <%= GetAttributesString(prop.Attributes) %>
        <%    } %>
        <% if (prop.Access == CslaGenerator.Metadata.PropertyAccess.IsProtected) { %>protected<% }
        else if (prop.Access == CslaGenerator.Metadata.PropertyAccess.IsInternal) { %>internal<% }
        else if (prop.Access == CslaGenerator.Metadata.PropertyAccess.IsProtectedInternal) { %>protected internal<% }
        else { %>public<%
        } %> <% if (prop.PropertyType == TypeCodeEx.SmartDate && Info.ObjectType != CslaObjectType.ReadOnlyCollection ) { %>string<%  } else { %><%=GetDataType(prop)%><% } %> <%=FormatPascal(prop.Name)%>
        {
            get
            {
                <% if (Info.ObjectType != CslaObjectType.ReadOnlyObject) { %>CanReadProperty("<%=FormatPascal(prop.Name)%>", true);
                <% } %>return <%=FormatFieldName(prop.Name)%><% if ( prop.PropertyType == TypeCodeEx.SmartDate && Info.ObjectType != CslaObjectType.ReadOnlyCollection ) { %>.Text<% } %>;
            }
            <% if (Info.ObjectType != CslaObjectType.ReadOnlyObject && prop.ReadOnly == false) { %>
            set
            {
                CanWriteProperty("<%=FormatPascal(prop.Name)%>", true);
                <% if (prop.PropertyType != TypeCodeEx.ByteArray) { %>
                if (<%=FormatFieldName(prop.Name)%><% if (prop.PropertyType == TypeCodeEx.SmartDate) { %>.Text<% } %> != value)
                {
                <% } else { %>
                bool setNewValue = false;
                if (value != null && <%=FormatFieldName(prop.Name)%> == null)
                    setNewValue = true;
                if (!setNewValue && value != null && <%=FormatFieldName(prop.Name)%> != null) {
                    if (<%=FormatFieldName(prop.Name)%>.Length != value.Length) {
                        setNewValue = true;
                    }
                    else {
                        for (int i=0; i < value.Length; i++) {
                            if (value[i] != <%=FormatFieldName(prop.Name)%>[i]) {
                                setNewValue = true;
                                break;
                            }
                        }
                    }
                }
                if (setNewValue)
                {
                <% } %>
                    <%=FormatFieldName(prop.Name)%><% if (prop.PropertyType == TypeCodeEx.SmartDate) { %>.Text<% } %> = value;
                    <% if (prop.MarkDirtyOnChange) { %>
                    PropertyHasChanged("<%=FormatPascal(prop.Name)%>");<% } %>
                }
            }
            <% } %>
        }
        <% } %>
        <% foreach (ChildProperty prop in Info.GetMyChildProperties()) { %>

<%            if ( prop.Summary != String.Empty ) { %>
        /// <summary>
<%= GetXmlCommentString(prop.Summary) %>
        /// </summary>
        <%    } %>
        <%    if ( prop.Remarks != String.Empty ) { %>
        /// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        /// </remarks>
        <%    } %>
        public  <%=prop.TypeName%> <%=FormatPascal(prop.Name)%>
        {
            get
            {
                <% if ( prop.LazyLoad ) { %>
                if (!<%=FormatFieldName(prop.Name + "Loaded")%>) {
                    <%=FormatFieldName(prop.Name)%> = <%=prop.TypeName%>.Get<%=prop.TypeName%>(<%
                    first = true;
                    foreach (Parameter p in prop.LoadParameters) {
                        if (!first) {
                            %>, <%
                         } else {
                            first = false;
                        }
                    %><%=p.Property.Name%><%
                    } %>);
                    <%=FormatFieldName(prop.Name + "Loaded")%> = true;
                }
                <% } %>
                return <%=FormatFieldName(prop.Name)%>;
            }
            <% if ( Info.ObjectType != CslaObjectType.ReadOnlyObject && prop.ReadOnly == false ) { %>
            set
            {
                <%=FormatFieldName(prop.Name)%> = value;
            }
            <% } %>
        }
        <% } %>
     <% string strGetIdValue = string.Empty;
        bool singleProperty = true;
        foreach (ValueProperty prop in Info.ValueProperties) {
            if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default) {
                if (strGetIdValue.Length > 0) {
                    strGetIdValue += ".ToString() + \"!\" + ";
                    singleProperty = false;
                }
                strGetIdValue += FormatFieldName(prop.Name);
            }
            if (!singleProperty)
                strGetIdValue += ".ToString()";
        }
        if (strGetIdValue.Length > 0) { %>

        protected override object GetIdValue()
        {
            return <%= strGetIdValue %>;
        }
        <% } %>

        #endregion
