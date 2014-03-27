        #Region " Factory Methods "
<%
bool internalGetObjectUsed = false;
if (parentInfo != null)
    internalGetObjectUsed = !Info.HasGetCriteriaFactory && !IsChildSelfLoaded(parentInfo);
bool silverlightIsDifferent = UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || internalGetObjectUsed);

if (silverlightIsDifferent)
{
    %>

#If Not SILVERLIGHT Then
<%
}
if (UseNoSilverlight())
{
    %>
<!-- #include file="InternalGetObject.asp" -->
<%
}
%>
<!-- #include file="GetObject.asp" -->
<%
if (silverlightIsDifferent)
{
    %>

#End If
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    forceGeneration = true;
    if (Info.HasGetCriteriaFactory)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
}
%>

        #End Region
