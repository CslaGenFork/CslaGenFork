<% %>

        #Region " Data Access "
<%
if (UseBoth())
{
    %>

#If Not SILVERLIGHT Then
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

#Else
<%
    }
    if (CurrentUnit.GenerationParams.TargetIsCsla40)
    {
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
    else
    {
        if (Info.IsCreatorGetter)
        {
            %>
<!-- #include file="DataPortalCreateFetchUnitOfWorkServices-45.asp" -->
<%
        }
        if (Info.IsCreator)
        {
            %>
<!-- #include file="DataPortalCreateUnitOfWorkServices-45.asp" -->
<%
        }
        if (Info.IsGetter)
        {
            %>
<!-- #include file="DataPortalFetchUnitOfWorkServices-45.asp" -->
<%
        }
        if (Info.IsUpdater)
        {
            %>
<!-- #include file="DataPortalUpdateUnitOfWorkServices-45.asp" -->
<%
        }
        if (Info.IsDeleter)
        {
            %>
<!-- #include file="DataPortalDeleteUnitOfWorkServices-45.asp" -->
<%
        }
    }
}
if (UseBoth())
{
    %>

#End If
<%
}
%>

        #End Region
