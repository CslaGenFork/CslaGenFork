<%
if (CurrentUnit.GenerationParams.HeaderVerbosity != HeaderVerbosity.None)
{
    %><!-- #include file="HeaderVersion.asp" -->
<%
    if (CurrentUnit.GenerationParams.HeaderVerbosity == HeaderVerbosity.Full)
    {
        %>
<!-- #include file="HeaderBody_DalInterfaceDto.asp" -->
<%
    }
    Response.Write(Environment.NewLine);
}
%>