        #region Factory Methods
<%
if (UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices))
{
    %>

#if !SILVERLIGHT
<%
}
%>
<!-- #include file="GetNVL.asp" -->
<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous && !CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    %>
<!-- #include file="GetNVLAsync.asp" -->
<%
}
if (UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices))
{
    %>

#else
<%
}
if (CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    %>
<!-- #include file="GetNVLSyncSilverlight.asp" -->
<%
}
if (!CurrentUnit.GenerationParams.GenerateAsynchronous && CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    %>
<!-- #include file="GetNVLAsync.asp" -->
<%
}
else if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="GetNVLSyncSilverlight.asp" -->
<!-- #include file="GetNVLSilverlight.asp" -->
<%
}
if (UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices))
{
    %>

#endif
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && CurrentUnit.GenerationParams.GenerateSilverlight4)
{
        %>
<!-- #include file="GetNVLAsync.asp" -->
<%
}
%>

        #endregion
