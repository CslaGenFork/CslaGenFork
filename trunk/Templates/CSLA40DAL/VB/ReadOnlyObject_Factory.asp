        #region Factory Methods
<%
bool internalGetObjectUsed = false;
if (parentInfo != null)
    internalGetObjectUsed = !Info.HasGetCriteriaFactory && !IsChildSelfLoaded(parentInfo);
bool asyncSilverlightIsDifferent = UseBoth() &&
    (CurrentUnit.GenerationParams.SilverlightUsingServices && (Info.UseUnitOfWorkType == string.Empty ||
    !CurrentUnit.GenerationParams.GenerateAsynchronous));
bool silverlightIsDifferent = UseBoth() &&
    (asyncSilverlightIsDifferent || CurrentUnit.GenerationParams.GenerateSynchronous || internalGetObjectUsed);
bool SilverlightServicesAlone = CurrentUnit.GenerationParams.SilverlightUsingServices && !UseNoSilverlight();
    
if (silverlightIsDifferent)
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
if (CurrentUnit.GenerationParams.GenerateAsynchronous && asyncSilverlightIsDifferent)
{
    %>
<!-- #include file="GetObjectAsync.asp" -->
<%
}
if (silverlightIsDifferent)
{
    if (asyncSilverlightIsDifferent && Info.HasGetCriteriaFactory)
    {
        %>

#else
<!-- #include file="GetObjectSilverlight.asp" -->
<%
%>

#endif
<%
    }
    else
    {
        %>

#endif
<%
    }
}
else if (SilverlightServicesAlone)
{
    %>
<!-- #include file="GetObjectSilverlight.asp" -->
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && !asyncSilverlightIsDifferent)
{
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
}
%>

        #endregion
