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
if (UseNoSilverlight())
{
    %>
<!-- #include file="InternalGetObject.asp" -->
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
if (UseBoth()) // check there is a fetch
{
    %>

#else
<%
}
%>
<!-- #include file="NewObjectSilverlight.asp" -->
<!-- #include file="GetObjectSilverlight.asp" -->
<!-- #include file="DeleteObjectSilverlight.asp" -->
<%
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
<!-- #include file="DeleteObjectAsync.asp" -->
<%
}
%>
<!-- #include file="Save.asp" -->

        #endregion
