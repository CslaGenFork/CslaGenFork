<% %>

        #region Factory Methods
<%
if (UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous)
{
    %>

#if !SILVERLIGHT
<%
}
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    if (Info.IsCreator || Info.IsCreatorGetter)
    {
        %>
<!-- #include file="NewObjectUnitOfWork.asp" -->
<%
    }
    if (Info.IsGetter || Info.IsCreatorGetter)
    {
        %>
<!-- #include file="GetObjectUnitOfWork.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DeleteObject.asp" -->
<%
    }
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && !CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    if (Info.IsCreator || Info.IsCreatorGetter)
    {
        %>
<!-- #include file="NewObjectUnitOfWorkAsync.asp" -->
<%
    }
    if (Info.IsGetter || Info.IsCreatorGetter)
    {
        %>
<!-- #include file="GetObjectUnitOfWorkAsync.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
if (UseBoth() && !CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    %>

#else
<%
}
if (!CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    if (Info.IsCreator || Info.IsCreatorGetter)
    {
        %>
<!-- #include file="NewObjectUnitOfWorkAsync.asp" -->
<%
    }
    if (Info.IsGetter || Info.IsCreatorGetter)
    {
        %>
<!-- #include file="GetObjectUnitOfWorkAsync.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
if (UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous)
{
    %>

#endif
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    if (Info.IsCreator || Info.IsCreatorGetter)
    {
        %>
<!-- #include file="NewObjectUnitOfWorkAsync.asp" -->
<%
    }
    if (Info.IsGetter || Info.IsCreatorGetter)
    {
        %>
<!-- #include file="GetObjectUnitOfWorkAsync.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
%>

        #endregion
