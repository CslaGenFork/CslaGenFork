<%
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.GetOptions.DataPortal)
    {
        if (usesDTO)
        {
            %>
        /// <summary>
        /// Loads a <%= Info.ObjectName %> list from the database.
        /// </summary>
        <%
            if (c.Properties.Count > 1)
            {
                %>
        /// <param name="crit">The fetch criteria.</param>
        /// <returns>A list of <see cref="<%= Info.ObjectName %>ItemDto"/>.</returns>
        List<<%= Info.ObjectName %>ItemDto> Fetch(<%= c.Name %> crit);
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        /// <returns>A list of <see cref="<%= Info.ObjectName %>ItemDto"/>.</returns>
        List<<%= Info.ObjectName %>ItemDto> Fetch(<%= ReceiveSingleCriteria(c, "crit") %>);
        <%
            }
            else
            {
                %>
        /// <returns>A list of <see cref="<%= Info.ObjectName %>ItemDto"/>.</returns>
        List<<%= Info.ObjectName %>ItemDto> Fetch();
        <%
            }
        }
        else
        {
            string strGetCritParams = string.Empty;
            string strGetComment = string.Empty;
            bool getIsFirst = true;

            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (!getIsFirst)
                    strGetCritParams += ", ";
                else
                    getIsFirst = false;

                TypeCodeEx propType = c.Properties[i].PropertyType;

                strGetCritParams += string.Concat(GetDataTypeGeneric(c.Properties[i], propType), " ", FormatCamel(c.Properties[i].Name));
                strGetComment += "/// <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(c.Properties[i].Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            }
            %>

        /// <summary>
        /// Loads a <%= Info.ObjectName %> list from the database.
        /// </summary>
        <%= strGetComment %>/// <returns>A data reader to the <%= Info.ObjectName %>.</returns>
        IDataReader Fetch(<%= strGetCritParams %>);
        <%
        }
    }
}
%>
