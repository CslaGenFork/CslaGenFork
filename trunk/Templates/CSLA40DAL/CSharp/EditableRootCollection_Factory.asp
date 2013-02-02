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
    if (CurrentUnit.GenerationParams.SilverlightUsingServices)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
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
    else if (HasFactoryCreateOrGet(Info))
    {
        %>

#else
<%
    }
}
%>
<!-- #include file="NewObjectSilverlight.asp" -->
<!-- #include file="GetObjectSilverlight.asp" -->
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
<%
}
%>

        #endregion
