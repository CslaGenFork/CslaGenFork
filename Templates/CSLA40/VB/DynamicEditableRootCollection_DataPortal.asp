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
%>
<!-- #include file="DataPortalFetchSilverlight.asp" -->
<!-- #include file="DataPortalUpdateSilverlight.asp" -->
<%
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
