        #region Factory Methods
<%
if (UseBoth()) // check there is a fetch OR Sync
{
    %>

#if !SILVERLIGHT
<%
}
%>
<!-- #include file="NewObject.asp" -->
<!-- #include file="NewObjectAsync.asp" -->
<!-- #include file="GetObject.asp" -->
<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="GetObjectAsync.asp" -->
<%
}
if (UseBoth()) // check there is a fetch
{
    %>

#else
<%
}
%>
<!-- #include file="NewObjectSilverlight.asp" -->
<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="GetObjectSilverlight.asp" -->
<%
}
if (UseBoth())
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
