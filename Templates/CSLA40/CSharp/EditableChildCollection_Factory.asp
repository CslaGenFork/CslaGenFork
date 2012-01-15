<%
if (isChildLazyLoaded || createCriteria || parentCreateCriteria ||
    declarationMode == PropertyDeclaration.ClassicProperty ||
    declarationMode == PropertyDeclaration.AutoProperty)
{
    %>
        #region Factory Methods
<%
    if (UseBoth())
    {
        %>

#if !SILVERLIGHT
<%
    }
%>
<!-- #include file="NewObject.asp" -->
<!-- #include file="NewObjectAsync.asp" -->
<%
}
if (!isChildSelfLoaded && UseNoSilverlight())
{
    %>
<!-- #include file="InternalGetObject.asp" -->
<%
}
else
{
    %>
<!-- #include file="GetObject.asp" -->
<%
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

#else
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

#endif
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && CurrentUnit.GenerationParams.GenerateSilverlight4)
{
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
}
%>

        #endregion
