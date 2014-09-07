
        #region Inlines queries
<%
foreach (AdvancedGenerator.InlineQuery inlineQuery in InlineQueryList)
{
    %>

        private string <%= inlineQuery.ProcedureName %>InlineQuery(<%= inlineQuery.CriteriaParameter %>)
        {
            return "";
        }
<%
}
%>

        #endregion

