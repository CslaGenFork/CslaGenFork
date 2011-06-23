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
<!-- #include file="DataPortalCreateServices.asp" -->
<!-- #include file="DataPortalFetchServices.asp" -->
<!-- #include file="DataPortalInsertServices.asp" -->
<!-- #include file="DataPortalUpdateServices.asp" -->
<!-- #include file="DataPortalDeleteServices.asp" -->
<%
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
