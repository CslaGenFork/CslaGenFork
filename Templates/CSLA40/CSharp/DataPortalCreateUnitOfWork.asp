<%
Criteria crit = GetCriteriaObjects(Info)[0];
if (crit.CreateOptions.DataPortal)
{
    string createUowParam = string.Empty;
    string createUowCrit = string.Empty;
    string createUowCritParam = string.Empty;
    if (crit.Properties.Count > 1)
    {
        createUowParam = "crit";
        createUowCrit = crit.Name + " crit";
    }
    else if (crit.Properties.Count > 0)
    {
        createUowParam = HookSingleCriteria(crit, "crit");
        createUowCrit = ReceiveSingleCriteria(crit, "crit");
        createUowCritParam = HookSingleCriteria(crit, "crit");
    }
        %>
        /// <summary>
        /// Loads a new <see cref="<%=Info.ObjectName%>"/> unit of objects<%= crit.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
    if (crit.Properties.Count > 0)
    {
        %>/// <param name="<%= createUowParam %>">The create criteria.</param>
        <%
    }
        %>protected void DataPortal_Create(<%= createUowCrit %>)
        {
            <%
    foreach (UnitOfWorkProperty uowProp in Info.UnitOfWorkCollectionProperties)
    {
        bool isGetter = ForceIsGetter(Info, uowProp);
        if (CheckTargetPropertiesFound(Info, uowProp, crit))
        {
            createUowCritParam = string.Empty;
            if (crit.Properties.Count > 0)
            {
                bool firstUoW = true;
                foreach (Property prop in crit.Properties)
                {
                    if (IsTargetProperty(Info, uowProp, crit, prop))
                    {
                        if (firstUoW) firstUoW = false; else createUowCritParam += ", ";
                        createUowCritParam += "crit." + prop.Name;
                    }
                }
            }
            %>
            <%= GetFieldLoaderStatement(uowProp, uowProp.TypeName + (isGetter ? ".Get" : ".New") + uowProp.TypeName +"(" + createUowCritParam + ")") %>;
            <%
        }
        else
        {
                %>
            <%= GetFieldLoaderStatement(uowProp, uowProp.TypeName + (isGetter ? ".Get" : ".New") + uowProp.TypeName +"()") %>;
            <%
        }
    }
        %>
        }
<%
}
%>
