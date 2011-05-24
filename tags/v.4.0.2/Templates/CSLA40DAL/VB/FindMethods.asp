<%
if (Info.FindMethodsParameters.Count > 0)
{
    %>
        #region Find Methods

        <%
        foreach (Property prop in Info.FindMethodsParameters)
        {
            %>
        /// <summary>
        /// Find a <see cref="<%=Info.ItemType%>"/> object in the <see cref="<%=Info.ObjectName%>"/> collection, based on given <%= prop.Name %>.
        /// </summary>
        /// <param name="<%= FormatCamel(prop.Name) %>">The <%= FormatProperty(prop.Name) %>.</param>
        /// <returns>A <see cref="<%= Info.ItemType %>"/> object.</returns>
        public <%= Info.ItemType %> Find<%= Info.ItemType %>By<%= prop.Name %>(<%= GetDataTypeGeneric(prop, prop.PropertyType) %> <%= FormatCamel(prop.Name) %>)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].<%= prop.Name %>.Equals(<%= FormatCamel(prop.Name) %>))
                {
                    return this[i];
                }
            }
            return null;
        }

        <%
        }
        %>
        #endregion
<%
}
%>
<% Response.Write(Environment.NewLine); %>
