        #region Factory Methods
<%
if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
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
if (UseBoth())
{
    if (Info.UseUnitOfWorkType != string.Empty)
    {
        %>

#endif
<%
    }
    else
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
<!-- #include file="Save.asp" -->

        #endregion
