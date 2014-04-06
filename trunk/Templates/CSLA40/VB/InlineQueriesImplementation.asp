
        #Region " Inlines queries "
<%
if (UseBoth())
{
    %>

#If Not SILVERLIGHT Then
<%
}
foreach (AdvancedGenerator.InlineQuery inlineQuery in InlineQueryList)
{
    %>

        Private Shared Function <%= inlineQuery.ProcedureName %>InlineQuery(<%= inlineQuery.CriteriaParameter %>) As String
            Return ""
        End Function
<%
}
if (UseBoth())
{
    %>

#End If
<%
}
%>

        #End Region
