
        #region Inline queries
<%
if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
foreach (AdvancedGenerator.InlineQuery inlineQuery in InlineQueryList)
{
    %>

        //partial void GetQuery<%= inlineQuery.ProcedureName %>(<%= inlineQuery.CriteriaParameter %>)
        //{
        //    <%= FormatCamel(inlineQuery.ProcedureName) %>InlineQuery = "";
        //}
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
