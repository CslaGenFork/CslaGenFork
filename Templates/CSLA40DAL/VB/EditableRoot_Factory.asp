        #region Factory Methods
<%
if (UseBoth())
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
if (UseBoth())
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
<!-- #include file="Save.asp" -->

        #endregion
