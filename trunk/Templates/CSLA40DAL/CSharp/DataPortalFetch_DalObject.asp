<%
bool isFirstMethod = true;
bool isFirstDPFDO = true;
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.GetOptions.DataPortal)
    {
        if (isFirstDPFDO)
            isFirstDPFDO = false;
        else
            Response.Write(Environment.NewLine);

        if (usesDTO)
        {
            %>
        /// <summary>
        /// Loads a <%= Info.ObjectName %> object from the database.
        /// </summary>
        <%
            if (c.Properties.Count > 1)
            {
                foreach (Property prop in c.Properties)
                {
                    string param = FormatCamel(prop.Name);
                    %>
        /// <param name="<%= param %>">The <%= param %> parameter of the <%= Info.ObjectName %> to fetch.</param>
        <%
                }
            }
            else if (c.Properties.Count > 0)
            {
                %>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        <%
            }
            %>
        /// <returns>A <%= (isItem ? "list of " : "") %><%= (isItem ? Info.ItemType : Info.ObjectName) %>Dto<%= (isItem ? "" : " object") %>.</returns>
        <%
            if (c.Properties.Count > 1)
            {
                %>
        public <%= (isItem ? "List<" + Info.ItemType + "Dto>" : Info.ObjectName + "Dto") %> Fetch((<%= ReceiveMultipleCriteria(c) %>)
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
        public <%= (isItem ? "List<" + Info.ItemType + "Dto>" : Info.ObjectName + "Dto") %> Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)
        <%
            }
            else
            {
                %>
        public <%= (isItem ? "List<" + Info.ItemType + "Dto>" : Info.ObjectName + "Dto") %> Fetch()
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

                strGetCritParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                strGetComment += "/// <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(c.Properties[i].Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            }
            %>
        /// <summary>
        /// Loads a <%= Info.ObjectName %> object from the database.
        /// </summary>
        <%= strGetComment %>/// <returns>A data reader to the <%= Info.ObjectName %>.</returns>
        public IDataReader Fetch(<%= strGetCritParams %>)
        <%
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
        %>
                    cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
    }
    %>
                    cmd.CommandType = CommandType.StoredProcedure;
                    <%
    foreach (CriteriaProperty p in c.Properties)
    {
        if (!usesDTO)
        {
            %>
                    cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(Info, p, false, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= GetDbType(p) %>;
                    <%
        }
        else
        {
            if (c.Properties.Count > 1)
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, false, false, false) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= GetDbType(p) %>;
                    <%
            }
            else
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= GetDbType(p) %>;
                    <%
            }
        }
    }
    if (usesDTO)
    {
        %>
                    var dr = cmd.ExecuteReader();
                    return <%= isCollection ? "LoadCollection(dr)" : "Fetch(dr)" %>;
                    <%
    }
    else
    {
        %>
                    return cmd.ExecuteReader();
                    <%
    }
    %>
                }
            }
        }
        <%
    }
}
if (usesDTO)
{
    if (ancestorLoaderLevel == 0 || IsChildSelfLoaded(Info))
    {
    %>

<!-- #include file="Fetch_DalObject.asp" -->
<%
        if (ParentLoadsChildren(Info))
        {
            %>
<!-- #include file="FetchChildren_DalObject.asp" -->
<%
        }
    }
}
isFirstMethod = isFirstDPFDO;
%>
