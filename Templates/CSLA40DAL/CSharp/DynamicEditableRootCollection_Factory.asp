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
<!-- #include file="NewObjectAsync.asp" -->
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
    %>

#else
<%
}
%>
<!-- #include file="NewObjectSilverlight.asp" -->
<!-- #include file="GetObjectSilverlight.asp" -->
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
<%
}
%>
<!-- #include file="Save.asp" -->

        #endregion
