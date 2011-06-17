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
<!-- #include file="DataPortalFetch.asp" -->
<%
}
if (UseNoSilverlight() && Info.HasGetCriteria && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

#else
<%
}
%>
<!-- #include file="DataPortalFetchSilverlight.asp" -->
<%
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
