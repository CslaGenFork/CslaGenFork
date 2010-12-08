		
		#region Business Properties and Methods
		<% if ((Info.ObjectType != CslaObjectType.ReadOnlyObject) && (Info.ChildProperties.Count > 0 || Info.ChildCollectionProperties.Count > 0)) { %>
		
		/// <summary>
		/// Returns true if the object is currently valid, false if the object or its children has broken rules.
		/// </summary>
		public override bool IsValid
		{
			get
			{
				//If the Business Object has Children, We Need to check it 
				//with an && Child.IsValid clause with the Base As well
				return (base.IsValid<%
				foreach (ChildProperty prop in Info.ChildProperties) { %> && <%=FormatPascal(prop.Name) %>.IsValid<% } 
				foreach (ChildProperty prop in Info.ChildCollectionProperties) { %> && <%=FormatPascal(prop.Name) %>.IsValid<% } %>);
	    	}
		}

		/// <summary>
		/// Returns true if this object's data has been changed.
		/// </summary>
		public override bool IsDirty
		{
			get
			{
				//If the Business Object has Children, We Need to check it 
				//with an || Child.IsDirty clause with the Base As well
				return (base.IsDirty<%
				foreach (ChildProperty prop in Info.ChildProperties) { %> || <%=FormatPascal(prop.Name) %>.IsDirty<% } 
				foreach (ChildProperty prop in Info.ChildCollectionProperties) { %> || <%=FormatPascal(prop.Name) %>.IsDirty<% } %>);
			}
		}
		<% } %>
		
		<% IndentLevel = 2; %>
		<% foreach (ValueProperty prop in Info.ValueProperties) {%>
		<% if (prop.Summary != String.Empty) { %>
		/// <summary>
<%= GetXmlCommentString(prop.Summary) %>
		/// </summary>
		<% } %>
		<% if (prop.Remarks != String.Empty) { %>
		/// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
		/// </remarks>
		<% } %>
		public <%if (prop.PropertyType == TypeCodeEx.SmartDate) {%>string<%}else{%><%=prop.PropertyType.ToString()%><%}%> <%=FormatPascal(prop.Name)%>
		{
			get { return <%=FormatFieldName(prop.Name)%><%if (prop.PropertyType == TypeCodeEx.SmartDate) {%>.Text<% } %>; }
			<% if (Info.ObjectType != CslaObjectType.ReadOnlyObject && prop.ReadOnly == false) { %>
			set 
			{ 
				if (<%=FormatFieldName(prop.Name)%><%if (prop.PropertyType == TypeCodeEx.SmartDate) {%>.Text<% } %> != value)
				{
					<%=FormatFieldName(prop.Name)%><%if (prop.PropertyType == TypeCodeEx.SmartDate) {%>.Text<% } %> = value;
					<% if (prop.Rules.Count > 0) { %>CheckRules("<%=prop.Name%>");<% } %>
					MarkDirty();
				}
			}
			<% } %>
		}
		
		
		<%if (prop.PropertyType == TypeCodeEx.SmartDate)
			{%>
		
		<% if (prop.Summary != String.Empty) { %>
		/// <summary>
<%= GetXmlCommentString(prop.Summary) %>
		/// </summary>
		<% } %>
		<% if (prop.Remarks != String.Empty) { %>
		/// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
		/// </remarks>
		<% } %>		
		public DateTime <%=FormatPascal(prop.Name)%>Date
		{
			get { return <%=FormatFieldName(prop.Name)%>.Date; }			
		}
		
			<%}%>
		<% } %>
		<% foreach (ChildProperty prop in Info.GetMyChildProperties()) {%>
		<% if (prop.Summary != String.Empty) { %>
		/// <summary>
<%= GetXmlCommentString(prop.Summary) %>
		/// </summary>
		<% } %>
		<% if (prop.Remarks != String.Empty) { %>
		/// <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
		/// </remarks>
		<% } %>
		public <%=prop.TypeName%> <%=FormatPascal(prop.Name)%>
		{
			get 
			{ 
				<% if (prop.LazyLoad) { %>
				if (!<%=FormatFieldName(prop.Name + "Loaded")%>)
				{
					<%=FormatFieldName(prop.Name)%> = <%=prop.TypeName%>.Get<%=prop.TypeName%>(<%
					 first = true;
					 foreach(Parameter p in prop.LoadParameters) {
					%><% if (!first) { %>, <%} else first = false; %><%=p.Property.Name%><% } %>);
					<%=FormatFieldName(prop.Name + "Loaded")%> = true;
				}
				<% } %>
				return <%=FormatFieldName(prop.Name)%>; 
			}
			<% if (Info.ObjectType != CslaObjectType.ReadOnlyObject && prop.ReadOnly == false) { %>
			set { <%=FormatFieldName(prop.Name)%> = value; }
			<% } %>
		}
		
		<% } %>
		#endregion
