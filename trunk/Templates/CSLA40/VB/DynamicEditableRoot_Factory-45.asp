        #Region " Factory Methods "
<%
// Silverlight is always different because of InternalGetObject.asp
if (UseBoth())
{
    %>

#If Not SILVERLIGHT Then
<%
}
%>
<!-- #include file="NewObject.asp" -->
<%
if (UseNoSilverlight())
{
    %>
<!-- #include file="InternalGetObject.asp" -->
<%
}
%>
<!-- #include file="GetObject.asp" -->
<!-- #include file="DeleteObject.asp" -->
<%
if (UseBoth())
{
    %>

#End If
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    forceGeneration = true;
    if (Info.HasCreateCriteriaFactory)
    {
        %>
<!-- #include file="NewObjectAsync.asp" -->
<%
    }
    if (Info.HasGetCriteriaFactory)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
    if (Info.HasDeleteCriteriaFactory)
    {
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
%>

        #End Region
