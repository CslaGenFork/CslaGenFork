        #region Factory Methods
<%
bool silverlightIsDifferent = UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous;

if (silverlightIsDifferent)
{
    %>

#if !SILVERLIGHT
<%
}
%>
<!-- #include file="GetNVL.asp" -->
<%
if (silverlightIsDifferent)
{
    %>

#else
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

#endif
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

        #endregion
