        #region Data Access
<%
if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
if (UseNoSilverlight())
{
    %>
<!-- #include file="CollectionDataPortalFetch.asp" -->
<%
}
if (UseNoSilverlight() && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

#else
<%
}
if (CurrentUnit.GenerationParams.TargetIsCsla40)
{
    %>
<!-- #include file="DataPortalFetchServices.asp" -->
<%
}
else
{
    %>
<!-- #include file="DataPortalFetchServices-45.asp" -->
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
