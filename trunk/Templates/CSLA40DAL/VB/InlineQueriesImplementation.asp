
        #region Inline queries
<%
foreach (AdvancedGenerator.InlineQuery inlineQuery in InlineQueryList)
{
    %>

        //partial void GetQuery<%= inlineQuery.ProcedureName %>(<%= inlineQuery.CriteriaParameter %>)
        //{
        //    <%= FormatCamel(inlineQuery.ProcedureName) %>InlineQuery = "";
        //}
<%
}
%>

        #endregion

