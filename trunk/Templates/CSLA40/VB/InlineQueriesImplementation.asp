
        #Region " Inline queries "
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

        ' Private Sub GetQuery<%= inlineQuery.ProcedureName %>(<%= inlineQuery.CriteriaParameter %>)
        '     <%= FormatCamel(inlineQuery.ProcedureName) %>InlineQuery = ""
        ' End Sub
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
