
       #region Inlines queries
<%
foreach (AdvancedGenerator.InlineQuery inlineQuery in InlineQueryList)
{
   %>

       private static string <%= inlineQuery.ProcedureName %>InlineQuery(<%= inlineQuery.CriteriaParameter %>)
       {
           return "";
       }
<%
}
%>

       #endregion

