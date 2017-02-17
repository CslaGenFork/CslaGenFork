<%
if (InlineQueryList.Count > 0)
{
    %>
        #Region " Inline queries fields and partial methods "
<%
    if (UseBoth())
    {
        %>

#If Not SILVERLIGHT Then
<%
    }
    List<String> ProcedureNames = new List<String>();
    foreach (AdvancedGenerator.InlineQuery inlineQuery in InlineQueryList)
    {
        if (ProcedureNames.IndexOf(inlineQuery.ProcedureName) > -1)
            continue;
        ProcedureNames.Add(inlineQuery.ProcedureName);
        %>

        <NotUndoable, NonSerialized>
        Private <%= FormatCamel(inlineQuery.ProcedureName) %>InlineQuery As String
<%
    }
    foreach (AdvancedGenerator.InlineQuery inlineQuery in InlineQueryList)
    {
        %>

        Partial Private Sub GetQuery<%= inlineQuery.ProcedureName %>(<%= inlineQuery.CriteriaParameter %>)
        End Sub
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

<%
}
%>
