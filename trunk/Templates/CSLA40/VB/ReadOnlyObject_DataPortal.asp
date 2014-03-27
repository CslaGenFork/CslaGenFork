        #Region " Data Access "
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
<!-- #include file="DataPortalFetch.asp" -->
<%
}
if (UseNoSilverlight() && Info.HasGetCriteria && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

#Else
<%
}
if (CurrentUnit.GenerationParams.TargetIsCsla40)
{
    %>
<!-- #include file="DataPortalFetchServices.asp" -->
<%
}
else
{
    %>
<!-- #include file="DataPortalFetchServices-45.asp" -->
<%
}
if (UseBoth())
{
    %>

#End If
<%
}
%>

        #End Region
