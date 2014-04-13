
       #region Inlines queries
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

       private static string <%= inlineQuery.ProcedureName %>InlineQuery(<%= inlineQuery.CriteriaParameter %>)
       {
           return "";
       }
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
