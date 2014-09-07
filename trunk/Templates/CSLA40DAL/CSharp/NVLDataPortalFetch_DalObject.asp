<%
useInlineQuery = false;
if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.Always)
    useInlineQuery = true;
else if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.SpecifyByObject)
{
    foreach (string item in Info.GenerateInlineQueries)
    {
        if (item == "Read")
        {
            useInlineQuery = true;
            break;
        }
    }
}
foreach (Criteria c in Info.CriteriaObjects)
{
    lastCriteria = "";
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
            if (c.Properties.Count > 1)
            {
                lastCriteria = ReceiveMultipleCriteriaTypeless(c);
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ReceiveMultipleCriteria(c)));
                %>
        /// <returns>A list of <see cref="<%= Info.ObjectName %>ItemDto"/>.</returns>
        public List<<%= Info.ObjectName %>ItemDto> Fetch(<%= ReceiveMultipleCriteria(c) %>)
        <%
            }
            else if (c.Properties.Count > 0)
            {
                lastCriteria = ReceiveSingleCriteriaTypeless(c, "crit");
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ReceiveSingleCriteria(c, "crit")));
                %>
        /// <returns>A list of <see cref="<%= Info.ObjectName %>ItemDto"/>.</returns>
        public List<<%= Info.ObjectName %>ItemDto> Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)
        <%
            }
            else
            {
                lastCriteria = "";
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, ""));
                %>
        /// <returns>A list of <see cref="<%= Info.ObjectName %>ItemDto"/>.</returns>
        public List<<%= Info.ObjectName %>ItemDto> Fetch()
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
                {
                    strGetCritParams += ", ";
                    lastCriteria += ", ";
                }
                else
                    getIsFirst = false;

                strGetComment += "/// <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(c.Properties[i].Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
                strGetCritParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                lastCriteria += FormatCamel(c.Properties[i].Name);
            }

            if (useInlineQuery)
                InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.GetOptions.ProcedureName, strGetCritParams));
            %>
        /// <summary>
        /// Loads a <%= Info.ObjectName %> list from the database.
        /// </summary>
        <%= strGetComment %>/// <returns>A data reader to the <%= Info.ObjectName %>.</returns>
        public IDataReader Fetch(<%= strGetCritParams %>)
        <%
        }
        %>
        {
            <%= GetConnection(Info, true) %>
            {
                <%= GetCommand(Info, c.GetOptions.ProcedureName, useInlineQuery, lastCriteria) %>
                {
                    <%
        if (Info.CommandTimeout != string.Empty)
        {
            %>
                    cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
        }
        %>
                    cmd.CommandType = CommandType.<%= useInlineQuery ? "Text" : "StoredProcedure" %>;
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
                    return LoadCollection(dr);
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
        if (usesDTO)
        {
            %>

        private List<<%= Info.ObjectName %>ItemDto> LoadCollection(IDataReader data)
        {
            var <%= FormatCamel(Info.ObjectName) %> = new List<<%= Info.ObjectName %>ItemDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    <%= FormatCamel(Info.ObjectName) %>.Add(Fetch(dr));
                }
            }
            return <%= FormatCamel(Info.ObjectName) %>;
        }

        private <%= Info.ObjectName %>ItemDto Fetch(SafeDataReader dr)
        {
            var <%= FormatCamel(Info.ObjectName) %>Item = new <%= Info.ObjectName %>ItemDto();
            <%= FormatCamel(Info.ObjectName) %>Item.<%= FormatPascal(valueProp.Name) %> = <%= String.Format(GetDataReaderStatement(valueProp)) %>;
            <%= FormatCamel(Info.ObjectName) %>Item.<%= FormatPascal(nameProp.Name) %> = <%= String.Format(GetDataReaderStatement(nameProp)) %>;

            return <%= FormatCamel(Info.ObjectName) %>Item;
        }
        <%
        }
    }
}
%>
