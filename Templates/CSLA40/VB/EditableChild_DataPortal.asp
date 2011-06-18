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
<!-- #include file="InternalInsertUpdateDelete.asp" -->
<%
}
if (UseBoth() && (HasDataPortalCreate(Info) || ((HasDataPortalGetOrDelete(Info) || Info.GenerateDataPortalUpdate) && CurrentUnit.GenerationParams.SilverlightUsingServices)))
{
    %>

#else
<%
}
%>
<!-- #include file="DataPortalCreateSilverlight.asp" -->
<!-- #include file="DataPortalFetchSilverlight.asp" -->
<!-- #include file="InternalInsertUpdateDeleteSilverlight.asp" -->
<%
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
