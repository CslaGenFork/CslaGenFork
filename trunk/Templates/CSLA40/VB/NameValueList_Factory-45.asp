        #Region " Factory Methods "
<%
bool silverlightIsDifferent = UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous;

if (silverlightIsDifferent)
{
    %>

#If Not SILVERLIGHT Then
<%
}
%>
<!-- #include file="GetNVL.asp" -->
<%
if (silverlightIsDifferent)
{
    %>

#Else
<%
}
if (UseSilverlight())
{
    %>
<!-- #include file="GetNVLSyncSilverlight.asp" -->
<%
}
if (silverlightIsDifferent)
{
    %>

#End If
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    forceGeneration = true;
    %>
<!-- #include file="GetNVLAsync.asp" -->
<%
}
%>

        #End Region
