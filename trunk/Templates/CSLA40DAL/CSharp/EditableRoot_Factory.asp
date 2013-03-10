        #region Factory Methods
<%
bool asyncSilverlightIsDifferent = UseBoth() &&
    (CurrentUnit.GenerationParams.SilverlightUsingServices && (Info.UseUnitOfWorkType == string.Empty ||
    !CurrentUnit.GenerationParams.GenerateAsynchronous));
bool silverlightIsDifferent = UseBoth() &&
    (asyncSilverlightIsDifferent || CurrentUnit.GenerationParams.GenerateSynchronous);
bool silverlightServicesAlone = CurrentUnit.GenerationParams.SilverlightUsingServices && !UseNoSilverlight();
    
if (UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || Info.UseUnitOfWorkType == string.Empty))
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
if (CurrentUnit.GenerationParams.GenerateAsynchronous && asyncSilverlightIsDifferent)
{
    %>
<!-- #include file="NewObjectAsync.asp" -->
<!-- #include file="GetObjectAsync.asp" -->
<!-- #include file="DeleteObjectAsync.asp" -->
<%
}
if (silverlightIsDifferent)
{
    if (asyncSilverlightIsDifferent && HasFactoryCreateOrGetOrDelete(Info))
    {
        %>

#else
<!-- #include file="NewObjectSilverlight.asp" -->
<!-- #include file="GetObjectSilverlight.asp" -->
<!-- #include file="DeleteObjectSilverlight.asp" -->
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
else if (silverlightServicesAlone)
{
    %>
<!-- #include file="NewObjectSilverlight.asp" -->
<!-- #include file="GetObjectSilverlight.asp" -->
<!-- #include file="DeleteObjectSilverlight.asp" -->
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && !asyncSilverlightIsDifferent)
{
        %>
<!-- #include file="NewObjectAsync.asp" -->
<!-- #include file="GetObjectAsync.asp" -->
<!-- #include file="DeleteObjectAsync.asp" -->
<%
}
%>

        #endregion
