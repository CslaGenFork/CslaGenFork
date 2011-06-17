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
<!-- #include file="DataPortalCreate.asp" -->
<!-- #include file="DataPortalFetch.asp" -->
<!-- #include file="InternalUpdate.asp" -->
<%
}
if (UseBoth() && (HasDataPortalCreate(Info) || (HasDataPortalGet(Info) && CurrentUnit.GenerationParams.SilverlightUsingServices)))
{
    %>

#else
<%
}
%>
<!-- #include file="DataPortalCreateSilverlight.asp" -->
<!-- #include file="DataPortalFetchSilverlight.asp" -->
<!-- #include file="DataPortalInsertSilverlight.asp" -->
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
