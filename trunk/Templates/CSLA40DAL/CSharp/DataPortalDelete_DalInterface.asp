<%
if (Info.GenerateDataPortalDelete)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.DeleteOptions.DataPortal)
        {
            if (usesDTO)
            {
                if (isFirstMethod)
                    isFirstMethod = false;
                else
                    Response.Write(Environment.NewLine);

                %>
        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        <%
                if (c.Properties.Count > 1)
                {
                    foreach (Property prop in c.Properties)
                    {
                        string param = FormatCamel(prop.Name);
                        %>
        /// <param name="<%= param %>">The <%= param %> parameter of the <%= Info.ObjectName %> to delete.</param>
        <%
                    }
                }
                else if (c.Properties.Count > 0)
                {
                    %>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The delete criteria.</param>
        <%
                }
                if (c.Properties.Count > 1)
                {
                    %>
        void Delete(<%= ReceiveMultipleCriteria(c) %>);
        <%
                }
                else
                {
                    %>
        void Delete(<%= ReceiveSingleCriteria(c, "crit") %>);
        <%
                }
            }
            else
            {
                string strDeleteCritParams = string.Empty;
                string strDeleteComment = string.Empty;
                bool deleteIsFirst = true;

                for (int i = 0; i < c.Properties.Count; i++)
                {
                    if (!deleteIsFirst)
                        strDeleteCritParams += ", ";
                    else
                        deleteIsFirst = false;

                    strDeleteCritParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                    strDeleteComment += "/// <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(c.Properties[i].Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
                }
                if (isFirstMethod)
                    isFirstMethod = false;
                else
                    Response.Write(Environment.NewLine);

                %>
        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        <%= strDeleteComment %>void Delete(<%= strDeleteCritParams %>);
        <%
            }
        }
    }
}
%>
