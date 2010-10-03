<%
if (CurrentUnit.GenerationParams.HeaderVerbosity != HeaderVerbosity.None)
{
    %><!-- #include file="HeaderVersion.inccs" -->
<%
    if (CurrentUnit.GenerationParams.HeaderVerbosity == HeaderVerbosity.Full)
    {
        %>
<!-- #include file="HeaderBody.inccs" -->
<%
    }
    Response.Write(Environment.NewLine);
}
%>