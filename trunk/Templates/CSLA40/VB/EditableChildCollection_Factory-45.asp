<%
if (isChildLazyLoaded || createCriteria || parentCreateCriteria ||
    declarationMode == PropertyDeclaration.ClassicProperty ||
    declarationMode == PropertyDeclaration.AutoProperty)
{
    %>
        #Region " Factory Methods "
<%
    if (UseBoth())
    {
        %>

#If Not SILVERLIGHT Then
<%
    }
%>
<!-- #include file="NewObject.asp" -->
<%
}
if (!isChildSelfLoaded && UseNoSilverlight())
{
    %>
<!-- #include file="InternalGetObject.asp" -->
<%
}
else if (UseNoSilverlight())
{
    %>
<!-- #include file="GetObject.asp" -->
<%
}
if (UseBoth())
{
    %>

#End If
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    forceGeneration = true;
    %>
<!-- #include file="NewObjectAsync.asp" -->
<%
    if (Info.HasGetCriteriaFactory)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
}
%>

        #End Region
