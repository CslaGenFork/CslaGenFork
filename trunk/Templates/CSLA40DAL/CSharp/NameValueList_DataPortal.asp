        #region Data Access
<%
if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
%>
<!-- #include file="NVLDataPortalFetch.asp" -->
<%
if (UseNoSilverlight() && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

#else
<%
}
if (CurrentUnit.GenerationParams.TargetIsCsla40)
{
    %>
<!-- #include file="NVLDataPortalFetchServices.asp" -->
<%
}
else
{
    %>
<!-- #include file="NVLDataPortalFetchServices-45.asp" -->
<%
}
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
