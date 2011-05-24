<% if (Info.SupportUpdateProperties == true)//Info.DeleteRoles != String.Empty || Info.UpdateRoles != String.Empty ||  Info.NewRoles != string.Empty)
{ %>

        /// <summary>
        /// Saves the <%=Info.ObjectName%> to the database.
        /// </summary>
        /// <returns>A reference to the new saved <see cref="<%=Info.ObjectName%>"/> object.</returns>
        public override <%=Info.ObjectName%> Save()
        {
            return base.Save();
        }
<% } %>
