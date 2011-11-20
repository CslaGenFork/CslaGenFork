<%
if ((firstComment == null && string.IsNullOrEmpty(Info.Parent.GenerationParams.ClassCommentFilenameSuffix)) ||
    (firstComment == true && !string.IsNullOrEmpty(Info.Parent.GenerationParams.ClassCommentFilenameSuffix)))
{
    firstComment = true;
    %>
    /// <summary>
    /// DAL Interface for <%= Info.ObjectName %> type
    /// </summary>
    <%
}
%>
