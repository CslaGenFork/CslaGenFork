<%
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.GetOptions.DataPortal)
    {
        if (usesDTO)
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
        /// <returns>A list of <see cref="<%= Info.ItemType %>Dto"/>.</returns>
        public List<<%= Info.ItemType %>Dto> Fetch(I<%= c.Name %> crit)
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        /// <returns>A list of <see cref="<%= Info.ItemType %>Dto"/>.</returns>
        public List<<%= Info.ItemType %>Dto> Fetch(<%= ReceiveSingleCriteria(c, "crit") %>)
        <%
            }
            else
            {
                %>
        /// <returns>A list of <see cref="<%= Info.ItemType %>Dto"/>.</returns>
        public List<<%= Info.ItemType %>Dto> Fetch()
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
        /// Loads a <%= Info.ObjectName %> collection from the database.
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
                %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
            }
            %>cmd.CommandType = CommandType.StoredProcedure;
                    <%
            foreach (Property p in c.Properties)
            {
                if (!usesDTO)
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(Info, p, false, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
                    <%
                }
                else
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

if (usesDTO)
{
    %>

        private List<<%= Info.ItemType %>Dto> LoadCollection(IDataReader data)
        {
            var <%= FormatCamel(Info.ObjectName) %> = new List<<%= Info.ItemType %>Dto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    <%= FormatCamel(Info.ObjectName) %>.Add(Fetch(dr));
                }
            }
            return <%= FormatCamel(Info.ObjectName) %>;
        }

<!-- #include file="Fetch_DalObject.asp" -->
        <%
}
%>
