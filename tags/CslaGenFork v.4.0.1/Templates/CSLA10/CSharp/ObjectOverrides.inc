		
		#region System.Object Overrides
		<% if (Info.ToStringProperty != null && Info.ToStringProperty.Count > 0) { %>
		
		/// <summary>
		/// Returns a string that represents a current <see cref="<%=Info.ObjectName%>" />
		/// </summary>
		public override string ToString()
		{
			//Return the Primary Key As a String
			return <% 
			bool firstLine = true; 
			foreach (Property prop in Info.ToStringProperty) {
				if (!firstLine) { %> + ", " + <%} else { firstLine = false; }
			%><%=prop.Name %>.ToString()<%}%>;
		}
		<% } 
		   if (Info.EqualsProperty != null && Info.EqualsProperty.Count > 0) { %>
		
		/// <summary>
		/// Determines whether two <see cref="<%=Info.ObjectName%>" /> instances are equal.
		/// </summary>
		public bool Equals(<%=Info.ObjectName%> obj)
		{
			//Implement Equals Method Needed
			if (obj == null || obj.GetType() != this.GetType())
				return false;			 
			
			return <% 
			bool firstLine = true; 
			foreach (Property prop in Info.EqualsProperty) {
			if (!firstLine) { %> && <%} else { firstLine = false; }
			
			%>(<%=prop.Name%> == obj.<%=prop.Name%>)<%}%>;

		}	
		
		/// <summary>
		/// Static method. Determines whether two <see cref="<%=Info.ObjectName%>" /> instances are equal.
		/// </summary>
		public new static bool Equals(Object objA, Object objB)
		{
			if ( objA is <%=Info.ObjectName%> && objB is <%=Info.ObjectName%>)
			{
				return ((<%=Info.ObjectName%>)objA).Equals((<%=Info.ObjectName%>)objB);
			}
			else
			{
				return false;
			}
		}	
			
		/// <summary>
		/// Object.Equals override. Determines whether two <see cref="<%=Info.ObjectName%>" /> instances are equal.
		/// </summary>
		public override bool Equals(Object obj)
		{
			if ( obj is <%=Info.ObjectName%>)
			{
				return this.Equals((<%=Info.ObjectName%>)obj);
			}
			else
			{
				return false;
			}
		}	
		<% } 
		   if (Info.HashcodeProperty != null && Info.HashcodeProperty.Count > 0) { %>
		
		/// <summary>
		/// Serves as a hash function for a <see cref="<%=Info.ObjectName%>" />, suitable for use in hashing algorithms and data structures like a hash table.
		/// </summary>
		public override int GetHashCode()
		{
			// Get Hashcode
			return <% 
			bool firstLine = true; 
			foreach (Property prop in Info.HashcodeProperty) {
			if (!firstLine) { %> ^ <%} else { firstLine = false; }%><%= prop.Name %>.GetHashCode()<%}%>;
		}
		<% } %>
		
		#endregion // System.Object Overrides
