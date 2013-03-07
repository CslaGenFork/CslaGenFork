<% %>

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
    if (Info.IsCreatorGetter)
    {
        %>
<!-- #include file="DataPortalCreateFetchUnitOfWork.asp" -->
<%
    }
    if (Info.IsCreator)
    {
        %>
<!-- #include file="DataPortalCreateUnitOfWork.asp" -->
<%
    }
    if (Info.IsGetter)
    {
        %>
<!-- #include file="DataPortalFetchUnitOfWork.asp" -->
<%
    }
    if (Info.IsUpdater)
    {
        %>
<!-- #include file="DataPortalUpdateUnitOfWork.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DataPortalDeleteUnitOfWork.asp" -->
<%
    }
}
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    if (UseBoth())
    {
        %>

#else
<%
    }
    if (Info.IsCreatorGetter)
    {
        %>
<!-- #include file="DataPortalCreateFetchUnitOfWorkServices.asp" -->
<%
    }
    if (Info.IsCreator)
    {
        %>
<!-- #include file="DataPortalCreateUnitOfWorkServices.asp" -->
<%
    }
    if (Info.IsGetter)
    {
        %>
<!-- #include file="DataPortalFetchUnitOfWorkServices.asp" -->
<%
    }
    if (Info.IsUpdater)
    {
        %>
<!-- #include file="DataPortalUpdateUnitOfWorkServices.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DataPortalDeleteUnitOfWorkServices.asp" -->
<%
    }
}
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
