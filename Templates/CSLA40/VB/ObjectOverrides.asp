<%
if (Info.ToStringProperty != null && Info.ToStringProperty.Count > 0 &&
    Info.ObjectType != CslaObjectType.ReadOnlyObject)
{
    %>

        #region BusinessBase<T> overrides

        /// <summary>
        /// Returns a string that represents the current <see cref="<%=Info.ObjectName%>"/>
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            // Return the Primary Key as a string
            return <%
            bool firstLine = true;
            foreach (Property prop in Info.ToStringProperty)
            {
                if (!firstLine)
                {
                    %> + ", " + <%
                }
                else
                {
                    firstLine = false;
                }
                %><%=FormatProperty(prop.Name)%>.ToString()<%
             }%>;
        }

        #endregion
<%
}
%>
