        #Region " Factory Methods "
<%
if (UseBoth())
{
    %>

#If Not SILVERLIGHT Then
<%
}
if (UseNoSilverlight())
{
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
}
if (UseBoth() && HasFactoryCreateOrGetOrDelete(Info))
{
    %>

#Else
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

#End If
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

        #End Region
