        #region Factory Methods
<%
if (UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || Info.UseUnitOfWorkType == string.Empty))
{
    %>

#if !SILVERLIGHT
<%
}
if (UseNoSilverlight())
{
    %>
<!-- #include file="NewObject.asp" -->
<%
    if (Info.UseUnitOfWorkType == string.Empty)
    {
        %>
<!-- #include file="NewObjectAsync.asp" -->
<%
    }
%>
<!-- #include file="GetObject.asp" -->
<%
    if (CurrentUnit.GenerationParams.SilverlightUsingServices && Info.UseUnitOfWorkType == string.Empty)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
%>
<!-- #include file="DeleteObject.asp" -->
<%
    if (CurrentUnit.GenerationParams.SilverlightUsingServices)
    {
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
if (UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || Info.UseUnitOfWorkType == string.Empty))
{
    if (Info.UseUnitOfWorkType != string.Empty)
    {
        %>

#endif
<%
    }
    else if (HasFactoryCreateOrGetOrDelete(Info))
    {
        %>

#else
<%
    }
}
%>
<!-- #include file="NewObjectSilverlight.asp" -->
<!-- #include file="GetObjectSilverlight.asp" -->
<!-- #include file="DeleteObjectSilverlight.asp" -->
<%
if (UseBoth() && Info.UseUnitOfWorkType == string.Empty)
{
    %>

#endif
<%
}
if (!CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="GetObjectAsync.asp" -->
<!-- #include file="DeleteObjectAsync.asp" -->
<%
}
%>

        #endregion
