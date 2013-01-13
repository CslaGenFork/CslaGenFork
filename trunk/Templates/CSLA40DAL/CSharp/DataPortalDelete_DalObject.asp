<%
if (Info.GenerateDataPortalDelete)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.DeleteOptions.DataPortal)
        {
            if (usesDTO)
            {
                %>

        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The delete criteria.</param>
        <%
                if (c.Properties.Count > 1)
                {
                    %>public void Delete(<%= c.Name %> crit)<%
                }
                else
                {
                    %>public void Delete(<%= ReceiveSingleCriteria(c, "crit") %>)<%
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
        <%= strDeleteComment %>public void Delete(<%= strDeleteCritParams %>)<%
            }
            %>
        {
            <%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, c.DeleteOptions.ProcedureName) %>
                {
                    <%
            if (Info.CommandTimeout != string.Empty)
            {
                %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
            }
            %>cmd.CommandType = CommandType.StoredProcedure;
                    <%
            foreach (Property p in c.Properties)
            {
                if (!usesDTO)
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(Info, p, false, true) %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
                    <%
                }
                else
                {
                    if (c.Properties.Count > 1)
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
                    <%
                    }
                    else
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
                    <%
                    }
                }
            }
            string hookArgs = string.Empty;
            if (c.Properties.Count > 1)
            {
                hookArgs = ", crit";
            }
            else if (c.Properties.Count > 0)
            {
                hookArgs = ", " + HookSingleCriteria(c, "crit");
            }
            %>var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("<%= Info.ObjectName %>");
                }
            }
        }
    <%
        }
    }
}
%>
