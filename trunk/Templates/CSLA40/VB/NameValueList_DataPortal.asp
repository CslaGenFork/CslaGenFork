        #Region " Data Access "
<%
if (UseBoth())
{
    %>

#If Not SILVERLIGHT Then
<%
}
%>
<!-- #include file="NVLDataPortalFetch.asp" -->
<%
if (UseNoSilverlight() && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

#Else
<%
}
if (CurrentUnit.GenerationParams.TargetIsCsla40)
{
    %>
<!-- #include file="NVLDataPortalFetchServices.asp" -->
<%
}
else
{
    %>
<!-- #include file="NVLDataPortalFetchServices-45.asp" -->
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
