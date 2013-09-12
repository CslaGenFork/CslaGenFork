<% %>

        #region Factory Methods
<%
bool silverlightIsDifferent = UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous;

if (silverlightIsDifferent)
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
if (silverlightIsDifferent)
{
    %>

#endif
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    forceGeneration = true;
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
