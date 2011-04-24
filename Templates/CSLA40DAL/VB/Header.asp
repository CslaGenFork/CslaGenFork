<%
if (CurrentUnit.GenerationParams.HeaderVerbosity != HeaderVerbosity.None)
{
    %><!-- #include file="HeaderVersion.asp" -->
<%
    if (CurrentUnit.GenerationParams.HeaderVerbosity == HeaderVerbosity.Full)
    {
        %>
<!-- #include file="HeaderBody.asp" -->
<%
    }
    Response.Write(Environment.NewLine);
}
%>