        #region Data Access
<%
bool createRunLocalDp = false;
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.CreateOptions.DataPortal)
    {
        createRunLocalDp = createRunLocalDp || c.CreateOptions.RunLocal;
    }
}
if (UseNoSilverlight() && CurrentUnit.GenerationParams.TargetIsCsla45 && createRunLocalDp)
{
    %>
<!-- #include file="DataPortalCreate.asp" -->
<%
}
if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
if (UseNoSilverlight() && (CurrentUnit.GenerationParams.TargetIsCsla40 ||
    (CurrentUnit.GenerationParams.TargetIsCsla45 && !createRunLocalDp)))
{
    %>
<!-- #include file="DataPortalCreate.asp" -->
<%
}
if (UseNoSilverlight())
{
    %>
<!-- #include file="DataPortalFetch.asp" -->
<!-- #include file="DataPortalInsert.asp" -->
<!-- #include file="DataPortalUpdate.asp" -->
<!-- #include file="InternalInsertUpdateDelete.asp" -->
<%
    if (Info.GenerateDataPortalInsert || Info.GenerateDataPortalUpdate || Info.GenerateDataPortalDelete)
    {
        %>
<!-- #include file="SimpleAuditTrail.asp" -->
<%
    }
%>
<!-- #include file="DataPortalDelete.asp" -->
<%
}
if (UseBoth() &&
    ((CurrentUnit.GenerationParams.TargetIsCsla40 && createRunLocalDp) ||
    ((HasDataPortalGetOrDelete(Info) || Info.GenerateDataPortalUpdate) && CurrentUnit.GenerationParams.SilverlightUsingServices)))
{
    %>

#else
<%
}
if (CurrentUnit.GenerationParams.TargetIsCsla40)
{
    %>
<!-- #include file="DataPortalCreateServices.asp" -->
<!-- #include file="DataPortalFetchServices.asp" -->
<!-- #include file="InternalInsertUpdateDeleteServices.asp" -->
<%
}
else
{
    %>
<!-- #include file="DataPortalCreateServices-45.asp" -->
<!-- #include file="DataPortalFetchServices-45.asp" -->
<!-- #include file="InternalInsertUpdateDeleteServices-45.asp" -->
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
