<%
foreach (Criteria crit in Info.CriteriaObjects)
{
    if (crit.Properties.Count == 0)
        continue;
    if (crit.GetOptions.DataPortal)
    {
        string strGetComment = string.Empty;
        bool getIsFirst = true;

        foreach (Property p in crit.Properties)
        {
            if (!getIsFirst)
            {
                strGetComment += System.Environment.NewLine + new string(' ', 8);
            }
            else
                getIsFirst = false;

            TypeCodeEx propType = p.PropertyType;

            strGetComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
        }

        string fetchUowParam = string.Empty;
        string fetchUowCrit = string.Empty;
        string fetchUowCritParam = string.Empty;
        if (crit.Properties.Count > 1)
        {
            strGetComment = "/// <param name=\"crit\">The fetch criteria.</param>";
            fetchUowParam = "crit";
            fetchUowCrit = crit.Name + " crit";
        }
        else if (crit.Properties.Count > 0)
        {
            fetchUowParam = HookSingleCriteria(crit, "crit");
            fetchUowCrit = ReceiveSingleCriteria(crit, "crit");
            fetchUowCritParam = HookSingleCriteria(crit, "crit");
        }
            %>

        /// <summary>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= crit.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
        if (crit.Properties.Count > 0)
        {
            %><%= strGetComment %>
        <%
        }
        %>protected void DataPortal_Fetch(<%= fetchUowCrit %>)
        {
            <%
        foreach (UnitOfWorkProperty uowProp in Info.UnitOfWorkProperties)
        {
            if (CheckTargetPropertiesFound(Info, uowProp, crit))
            {
                fetchUowCritParam = string.Empty;
                if (crit.Properties.Count > 0)
                {
                    Criteria tempCrit = new Criteria();
                    foreach (Property prop in crit.Properties)
                    {
                        if (IsTargetProperty(Info, uowProp, crit, prop))
                            tempCrit.Properties.Add(prop);
                    }
                    bool firstUoW = true;
                    if (tempCrit.Properties.Count > 1)
                    {
                        foreach (Property prop in tempCrit.Properties)
                        {
                            if (firstUoW) firstUoW = false; else fetchUowCritParam += ", ";
                            fetchUowCritParam += "crit." + prop.Name;
                        }
                    }
                    else if (tempCrit.Properties.Count > 0)
                        fetchUowCritParam = HookSingleCriteria(crit, "crit");
                }
            %>
            if (<%= fetchUowCritParam %> == -1)
                <%= GetFieldLoaderStatement(uowProp, uowProp.TypeName + ".New" + uowProp.TypeName +"()") %>;
            else
                <%= GetFieldLoaderStatement(uowProp, uowProp.TypeName + ".Get" + uowProp.TypeName +"(" + fetchUowCritParam + ")") %>;
            <%
            }
            else
            {
                %>
            <%= GetFieldLoaderStatement(uowProp, uowProp.TypeName + ".Get" + uowProp.TypeName +"()") %>;
            <%
            }
        }
    %>
        }
<%
    }
}
%>
