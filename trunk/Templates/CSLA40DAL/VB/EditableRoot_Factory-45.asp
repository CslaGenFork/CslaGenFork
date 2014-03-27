        #region Factory Methods
<%
bool silverlightIsDifferent = UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous;

if (silverlightIsDifferent)
{
    %>

#if !SILVERLIGHT
<%
}
%>
<!-- #include file="NewObject.asp" -->
<!-- #include file="GetObject.asp" -->
<!-- #include file="DeleteObject.asp" -->
<%
if (silverlightIsDifferent)
{
    %>

#endif
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    forceGeneration = true;
    if (Info.HasCreateCriteriaFactory)
    {
        %>
<!-- #include file="NewObjectAsync.asp" -->
<%
    }
    if (Info.HasGetCriteriaFactory)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
    if (Info.HasDeleteCriteriaFactory)
    {
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
%>

        #endregion
