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
%>
<!-- #include file="NewObjectAsync.asp" -->
<%
if (isChildSelfLoaded && UseNoSilverlight())
{
    if (CurrentUnit.GenerationParams.GenerateAsynchronous && !CurrentUnit.GenerationParams.GenerateSilverlight4)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
}
if (isChildLazyLoaded || createCriteria || parentCreateCriteria ||
    declarationMode == PropertyDeclaration.ClassicProperty ||
    declarationMode == PropertyDeclaration.AutoProperty)
{
    if (UseBoth())
    {
        %>

#Else
<%
    }
    %>
<!-- #include file="NewObjectSilverlight.asp" -->
<!-- #include file="GetObjectSilverlight.asp" -->
<%
}
if (UseBoth())
{
    %>

#End If
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && CurrentUnit.GenerationParams.GenerateSilverlight4)
{
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
}
%>

        #End Region
