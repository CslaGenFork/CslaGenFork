		
		#region Business Properties and Methods

		/// <summary>
		/// Gets the <see cref="<%=Info.ItemType%>" /> from the specified index.
		/// </summary>
		public <%=Info.ItemType %> this[int Index]
		{
			get
			{
				return((<%=Info.ItemType%>)base.List[Index]);			
			}
		}
		<% if (Info.ObjectType != CslaObjectType.ReadOnlyCollection) { %>
		
		/// <summary>
		/// Removes the <see cref="<%=Info.ItemType%>" /> object from the <see cref="<%=Info.ObjectName%>" /> collection.
		/// </summary>
		public void Remove(<%=Info.ItemType %> <%=FormatCamel(Info.ItemType)%>)
		{
			List.Remove(<%=FormatCamel(Info.ItemType)%>);
		}

		/// <summary>
		/// Add an <see cref="<%=Info.ItemType%>" /> object to the <see cref="<%=Info.ObjectName%>" /> collection.
		/// </summary>
		public void Add(<%=Info.ItemType%> <%=FormatCamel(Info.ItemType)%>)
		{
			List.Add(<%=FormatCamel(Info.ItemType)%>);
		}
		<% } %>
		
		<%
		CslaObjectInfo childInfoAdd = FindChildInfo(Info, Info.ItemType);
		bool firstAdd;
		%>
		<%if (Info.ObjectType == CslaObjectType.EditableChildCollection) {%>
		/// <summary>
		/// Add an <see cref="<%=Info.ItemType%>" /> object to the <see cref="<%=Info.ObjectName%>" /> collection.
		/// </summary>
		public <%=Info.ItemType%> Add(<%				
		firstAdd = true;
		foreach (Parameter param in childInfoAdd.NewObjectParameters)
		{
			if (!firstAdd) { writer.Write(", "); }
			else { firstAdd = false; }
			%><%=param.Property.PropertyType.ToString()%> <%=FormatCamel(param.Property.Name)%><%
		}
		%>)
		{
			<%=childInfoAdd.ObjectName %> item =  <%=childInfoAdd.ObjectName %>.New<%=childInfoAdd.ObjectName %><%
			if (childInfoAdd.ObjectType == CslaObjectType.EditableSwitchable ) {%>Child<% }%>(<%
			firstAdd = true;
			foreach (Parameter param in childInfoAdd.NewObjectParameters)
			{
				if (!firstAdd) { writer.Write(", "); }
				else { firstAdd = false; }
				%><%=FormatCamel(param.Property.Name)%><%
			}
			%>);
			Add(item);
			return item;
		}
		<%}%>		
		
		public virtual <%=childInfoAdd.ObjectName %> GetById(<%
		firstAdd = true;
		foreach (Parameter param in childInfoAdd.GetObjectParameters)		
		{
			if (!firstAdd) { writer.Write(", "); }
			else { firstAdd = false; }
			%><%=param.Property.PropertyType.ToString()%> <%=FormatCamel(param.Property.Name)%><%
		}
		%>)
		{
			foreach (<%=childInfoAdd.ObjectName %> item in this.List)
			{
				if (<%
				firstAdd = true;
				foreach (Parameter param in childInfoAdd.GetObjectParameters)		
				{
					if (!firstAdd) { writer.Write(" && "); }
					else { firstAdd = false; }
					%>item.<%=FormatPascal(param.Property.Name)%>.Equals(<%=FormatCamel(param.Property.Name)%>)<%
				}
				%>)
				{
					return item;
				}
			}
			return null;			
		}
		
		#endregion
