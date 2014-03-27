        #Region " Factory Methods "
<%
if (UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices))
{
    %>

#If Not SILVERLIGHT Then
<%
}
%>
<!-- #include file="GetNVL.asp" -->
<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous && !CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    %>
<!-- #include file="GetNVLAsync.asp" -->
<%
}
if (UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices))
{
    %>

#Else
<%
}
if (CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    %>
<!-- #include file="GetNVLSyncSilverlight.asp" -->
<%
}
if (!CurrentUnit.GenerationParams.GenerateAsynchronous && CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    %>
<!-- #include file="GetNVLAsync.asp" -->
<%
}
else if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="GetNVLSyncSilverlight.asp" -->
<!-- #include file="GetNVLSilverlight.asp" -->
<%
}
if (UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices))
{
    %>

#End If
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && CurrentUnit.GenerationParams.GenerateSilverlight4)
{
        %>
<!-- #include file="GetNVLAsync.asp" -->
<%
}
%>

        #End Region
