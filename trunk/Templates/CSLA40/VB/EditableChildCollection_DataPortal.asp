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
<!-- #include file="CollectionDataPortalFetch.asp" -->
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
