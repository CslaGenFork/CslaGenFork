<%
bool isFirstMethod = true;
bool isFirstDPFDI = true;
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.GetOptions.DataPortal)
    {
        if (usesDTO)
        {
            if (isFirstDPFDI)
                isFirstDPFDI = false;
            else
                Response.Write(Environment.NewLine);

            isFirstMethod = false;
            %>
        /// <summary>
        /// Loads a <%= Info.ObjectName %> object from the database.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
        %>/// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param><%
            }
            %>
        /// <returns>A <%= (isItem ? "list of " : "") %><%= (isItem ? Info.ItemType : Info.ObjectName) %>Dto<%= (isItem ? "" : " object") %>.</returns>
        <%
            if (c.Properties.Count > 1)
            {
                %>public <%= (isItem ? "List<" + Info.ItemType + "Dto>" : Info.ObjectName + "Dto") %> Fetch(I<%= c.Name %> crit)<%
            }
            else if (c.Properties.Count > 0)
            {
                %>public <%= (isItem ? "List<" + Info.ItemType + "Dto>" : Info.ObjectName + "Dto") %> Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)<%
            }
            else
            {
                %>public <%= (isItem ? "List<" + Info.ItemType + "Dto>" : Info.ObjectName + "Dto") %> Fetch()<%
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
            if (isFirstDPFDI)
                isFirstDPFDI = false;
            else
                Response.Write(Environment.NewLine);

            isFirstMethod = false;
            %>
        /// <summary>
        /// Loads a <%= Info.ObjectName %> object from the database.
        /// </summary>
        <%= strGetComment %>/// <returns>A data reader to the <%= Info.ObjectName %>.</returns>
        public IDataReader Fetch(<%= strGetCritParams %>)<%
        }
        %>
        {
            <%= GetConnection(Info, true) %>
            {
                <%= GetCommand(Info, c.GetOptions.ProcedureName) %>
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
        if (c.Properties.Count > 1)
        {
            %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
                    <%
        }
        else
        {
            %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
                    <%
        }
    }
    if (usesDTO)
    {
        %>var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);<%
    }
    else
    {
        %>return cmd.ExecuteReader();<%
    }
    %>
                }
            }
        }
        <%
    }
}
%>
