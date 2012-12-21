<%
if ((firstComment == null && string.IsNullOrEmpty(Info.Parent.GenerationParams.ClassCommentFilenameSuffix)) ||
    (firstComment == true && !string.IsNullOrEmpty(Info.Parent.GenerationParams.ClassCommentFilenameSuffix)))
{
    firstComment = true;
    %>
    /// <summary>
    /// DAL SQL Server implementation of <see cref="I<%= Info.ObjectName %>Dal"/>
    /// </summary>
    <%
}
%>
