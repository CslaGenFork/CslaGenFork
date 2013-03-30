<% if (Info.FindMethodsParameters.Count > 0) { %>

        #region Find Methods

        <% foreach (CslaGenerator.Metadata.Property prop in Info.FindMethodsParameters) { %>
        /// <summary>
        /// Find a <see cref="<%=Info.ItemType%>" /> Object in the <see cref="<%=Info.ObjectName%>" /> collection, based on given <%=prop.Name%>.
        /// </summary>
        public <%=Info.ItemType%> Find<%=Info.ItemType%>By<%=prop.Name%>(<%=GetDataType(prop)%> <%=FormatCamel(prop.Name)%>)
        {
            for (int i = 0; i < this.Count; i++) {
                if (this[i].<%=prop.Name%>.Equals(<%=FormatCamel(prop.Name)%>)) {
                    return this[i];
                }
            }
            return null;
        }

        <% } %>
        #endregion
<% } %>
<% Response.Write("\r\n"); %>
