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
%>
<!-- #include file="NVLDataPortalFetchServices.asp" -->
<%
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
