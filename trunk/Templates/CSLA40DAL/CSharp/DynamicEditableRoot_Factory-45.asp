        #region Factory Methods
<%
// Silverlight is always different because of InternalGetObject.asp
if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
%>
<!-- #include file="NewObject.asp" -->
<%
if (UseNoSilverlight())
{
    %>
<!-- #include file="InternalGetObject.asp" -->
<%
}
%>
<!-- #include file="GetObject.asp" -->
<!-- #include file="DeleteObject.asp" -->
<%
if (UseBoth())
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
