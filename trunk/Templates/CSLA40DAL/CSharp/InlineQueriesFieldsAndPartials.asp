<%
if (InlineQueryList.Count > 0)
{
    %>
        #region Inline queries fields and partial methods
<%
    if (UseBoth())
    {
        %>

#if !SILVERLIGHT
<%
    }
    List<String> ProcedureNames = new List<String>();
    foreach (AdvancedGenerator.InlineQuery inlineQuery in InlineQueryList)
    {
        if (ProcedureNames.IndexOf(inlineQuery.ProcedureName) > -1)
            continue;
        ProcedureNames.Add(inlineQuery.ProcedureName);
        %>

        [NotUndoable, NonSerialized]
        private string <%= FormatCamel(inlineQuery.ProcedureName) %>InlineQuery;
<%
    }
    foreach (AdvancedGenerator.InlineQuery inlineQuery in InlineQueryList)
    {
        %>

        partial void GetQuery<%= inlineQuery.ProcedureName %>(<%= inlineQuery.CriteriaParameter %>);
<%
    }
    if (UseBoth())
    {
        %>

#endif
<%
    }
%>

        #endregion

<%
}
%>
