        #Region " Data Access "
<%
bool createRunLocalDp = false;
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.CreateOptions.DataPortal)
    {
        createRunLocalDp = createRunLocalDp || c.CreateOptions.RunLocal;
    }
}
if (UseNoSilverlight() && CurrentUnit.GenerationParams.TargetIsCsla45 && createRunLocalDp &&
    !CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="DataPortalCreate.asp" -->
<%
}
if (UseBoth())
{
    %>

#If Not SILVERLIGHT Then
<%
}
if (UseNoSilverlight() && (CurrentUnit.GenerationParams.TargetIsCsla40 ||
    (CurrentUnit.GenerationParams.TargetIsCsla45 && (!createRunLocalDp || CurrentUnit.GenerationParams.SilverlightUsingServices))))
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

#Else
<%
}
if (CurrentUnit.GenerationParams.TargetIsCsla40)
{
    %>
<!-- #include file="DataPortalCreateServices.asp" -->
<!-- #include file="DataPortalFetchServices.asp" -->
<!-- #include file="DataPortalInsertServices.asp" -->
<!-- #include file="DataPortalUpdateServices.asp" -->
<!-- #include file="DataPortalDeleteServices.asp" -->
<%
}
else
{
    %>
<!-- #include file="DataPortalCreateServices-45.asp" -->
<!-- #include file="DataPortalFetchServices-45.asp" -->
<!-- #include file="DataPortalInsertServices-45.asp" -->
<!-- #include file="DataPortalUpdateServices-45.asp" -->
<!-- #include file="DataPortalDeleteServices-45.asp" -->
<%
}
if (UseBoth())
{
    %>

#End If
<%
}
%>

        #End Region
