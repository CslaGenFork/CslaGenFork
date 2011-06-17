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
<!-- #include file="DataPortalInsert.asp" -->
<!-- #include file="DataPortalUpdate.asp" -->
<%
    if (Info.GenerateDataPortalInsert || Info.GenerateDataPortalUpdate)
    {
        %>
<!-- #include file="DoInsertUpdate.asp" -->
<%
    }
    %>
<!-- #include file="DataPortalDelete.asp" -->
<%
}
if (UseBoth() && (HasDataPortalCreate(Info) || (HasDataPortalGetOrDelete(Info) && CurrentUnit.GenerationParams.SilverlightUsingServices)))
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
<!-- #include file="DataPortalDeleteSilverlight.asp" -->
<%
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
