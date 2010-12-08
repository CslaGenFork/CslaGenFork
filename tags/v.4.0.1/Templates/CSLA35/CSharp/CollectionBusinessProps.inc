<% CslaObjectInfo childInfo2 = FindChildInfo(Info, Info.ItemType); %>
		#region Business Properties and Methods
<% 
foreach (Criteria c in childInfo2.CriteriaObjects) {
	if (c.CreateOptions.Factory) { %>
	
		/// <summary>
		/// Add new <see cref="<%=Info.ItemType%>"/> Object to the <%=Info.ObjectName%> collection.
		/// </summary>
		<% string prms = string.Empty;
		string factoryParams = string.Empty;
		foreach (CslaGenerator.Metadata.Property param in c.Properties) {
			prms += string.Concat(", ", GetDataType(param), " ", FormatCamel(param.Name));
			factoryParams += string.Concat(", ", FormatCamel(param.Name));
		}	
		if (factoryParams.Length > 1) {
			factoryParams = factoryParams.Substring(2);
			prms = prms.Substring(2); 
		} %>
		public void Add(<%=prms%>)
		{
		<%
		string newMethodName = "New" + Info.ItemType;
		if (childInfo2.ObjectType == CslaObjectType.EditableSwitchable) {
			newMethodName += "Child";
		}
		%>
			<%=Info.ItemType%> <%=FormatCamel(Info.ItemType)%> = <%=Info.ItemType%>.<%=newMethodName%><%=c.CreateOptions.FactorySuffix.Trim()%>(<%=factoryParams%>);
			Add(<%=FormatCamel(Info.ItemType)%>);
		}
<%	}
} %>

		#endregion
