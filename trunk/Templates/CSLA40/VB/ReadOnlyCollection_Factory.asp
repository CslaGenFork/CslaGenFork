        #region Factory Methods
<%
bool internalGetObjectUsed = false;
if (parentInfo != null)
    internalGetObjectUsed = !Info.HasGetCriteriaFactory && IsChildSelfLoaded(parentInfo);
if (UseBoth() &&
    (CurrentUnit.GenerationParams.GenerateSynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices || internalGetObjectUsed))
{
    %>

#if !SILVERLIGHT
<%
}
if (UseNoSilverlight())
{
    %>
<!-- #include file="InternalGetObject.asp" -->
<%
}
%>
<!-- #include file="GetObject.asp" -->
<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous && !CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    %>
<!-- #include file="GetObjectAsync.asp" -->
<%
}
if (UseBoth() && CurrentUnit.GenerationParams.SilverlightUsingServices && Info.HasGetCriteriaFactory)
{
    %>

#else
<%
}
%>
<!-- #include file="GetObjectSilverlight.asp" -->
<%
if (UseBoth() &&
    (CurrentUnit.GenerationParams.GenerateSynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices || internalGetObjectUsed))
{
    %>

#endif
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && CurrentUnit.GenerationParams.GenerateSilverlight4)
{
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
}
%>

        #endregion
