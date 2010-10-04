<%
if (CurrentUnit.GenerationParams.HeaderVerbosity != HeaderVerbosity.None)
{
    %><!-- #include file="HeaderVersion.inc" -->
<%
    if (CurrentUnit.GenerationParams.HeaderVerbosity == HeaderVerbosity.Full)
    {
        %>
<!-- #include file="HeaderBody.inc" -->
<%
    }
    Response.Write(Environment.NewLine);
}
%>