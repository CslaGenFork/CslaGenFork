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
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
