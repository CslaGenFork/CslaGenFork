<%
if (Info.SupportUpdateProperties == true)//Info.DeleteRoles != String.Empty || Info.UpdateRoles != String.Empty ||  Info.NewRoles != string.Empty)
{
    %>

        /// <summary>
        /// Saves the <%= Info.ObjectName %> to the database.
        /// </summary>
        /// <returns>A reference to the new saved <see cref="<%= Info.ObjectName %>"/> object.</returns>
        <%
        if ((Info.ObjectType == CslaObjectType.EditableRoot ||
            Info.ObjectType == CslaObjectType.DynamicEditableRoot ||
            Info.ObjectType == CslaObjectType.EditableSwitchable) &&
            Info.SupportUpdateProperties == true)
        {
            %>
        /// <remarks>Raises <see cref="On<%= Info.ObjectName %>Saved"/> event.</remarks>
        <%
        }
        %>
        public override <%= Info.ObjectName %> Save()
        {
            <%
            if ((Info.ObjectType == CslaObjectType.EditableRoot ||
                Info.ObjectType == CslaObjectType.DynamicEditableRoot ||
                Info.ObjectType == CslaObjectType.EditableSwitchable) &&
                Info.SupportUpdateProperties == true)
            {
                %>
            var result = base.Save();
            On<%= Info.ObjectName %>Saved(this, new Csla.Core.SavedEventArgs(result));
            return result;<%
            }
            else
            {
                %>
            return base.Save();<%
            }
            %>
        }
<%
}
else
{
    Response.Write(Environment.NewLine);
}
%>
