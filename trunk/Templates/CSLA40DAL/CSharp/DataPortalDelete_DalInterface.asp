<%
if (Info.GenerateDataPortalDelete)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.DeleteOptions.DataPortal)
        {
            if (usesDalCriteria)
            {
                %>

        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The delete criteria.</param>
        <%
                if (c.Properties.Count > 1)
                {
                    %>void Delete(<%= c.Name %> crit);<%
                }
                else
                {
                    %>void Delete(<%= ReceiveSingleCriteria(c, "crit") %>);<%
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

                    TypeCodeEx propType = c.Properties[i].PropertyType;

                    strDeleteCritParams += string.Concat(GetDataTypeGeneric(c.Properties[i], propType), " ", FormatCamel(c.Properties[i].Name));
                    strDeleteComment += "/// <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(c.Properties[i].Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
                }
                %>

        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        <%= strDeleteComment %>void Delete(<%= strDeleteCritParams %>);<%
            }
        }
    }
}
%>
