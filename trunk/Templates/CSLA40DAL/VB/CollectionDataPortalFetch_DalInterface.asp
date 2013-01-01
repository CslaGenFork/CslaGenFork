<%
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.GetOptions.DataPortal)
    {
        if (usesDalCriteria)
        {
            %>

        /// <summary>
        /// Loads a <%= Info.ObjectName %> collection from the database.
        /// </summary>
        <%
            if (c.Properties.Count > 1)
            {
                %>
        /// <param name="crit">The fetch criteria.</param>
        /// <returns>A data reader to the <%= Info.ObjectName %>.</returns>
        <%= usesDTO ? (Info.ObjectName + "DTO") : "IDataReader" %> Fetch(<%= c.Name %> crit);<%
            }
            else if (c.Properties.Count > 0)
            {
                %>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        /// <returns>A data reader to the <%= Info.ObjectName %>.</returns>
        <%= usesDTO ? (Info.ObjectName + "DTO") : "IDataReader" %> Fetch(<%= ReceiveSingleCriteria(c, "crit") %>);<%
            }
            else
            {
                %>
        /// <returns>A data reader to the <%= Info.ObjectName %>.</returns>
        <%= usesDTO ? (Info.ObjectName + "DTO") : "IDataReader" %> Fetch();<%
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
        /// Loads a <%= Info.ObjectName %> collection from the database.
        /// </summary>
        <%= strGetComment %>/// <returns>A data reader to the <%= Info.ObjectName %>.</returns>
        <%= usesDTO ? (Info.ObjectName + "DTO") : "IDataReader" %> Fetch(<%= strGetCritParams %>);<%
        }
    }
}
%>
