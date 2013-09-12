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

#endif
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

        #endregion
