        #region Factory Methods
<%
bool createRunLocal = false;
bool createNonLocal = false;
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.CreateOptions.Factory)
    {
        createRunLocal = createRunLocal || c.CreateOptions.RunLocal;
        createNonLocal = createNonLocal || !c.CreateOptions.RunLocal;
    }
}
bool createRunLocalSilverlight = CurrentUnit.GenerationParams.SilverlightUsingServices && (createRunLocal || createNonLocal) && !useUnitOfWorkCreator;
if (parentInfo != null)
    isCollection = IsCollectionType(parentInfo.ObjectType);

if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
%>
<!-- #include file="NewObject.asp" -->
<%
if (UseNoSilverlight())
{
    createGenerateLocal = true;
    forceGeneration = null;
    if (!UseSilverlight() || createRunLocalSilverlight)
        forceGeneration = true;
    if (CurrentUnit.GenerationParams.DatabaseConnection != String.Empty)
    {
        if (isChildSelfLoaded && !isCollection)
        {
            %>
<!-- #include file="GetObject.asp" -->
<%
        }
        else if (UseNoSilverlight())
        {
            %>
<!-- #include file="InternalGetObject.asp" -->
<%
        }
        %>
<!-- #include file="NewObjectAsync.asp" -->
<%
        if (isChildSelfLoaded && !isCollection)
        {
            if (CurrentUnit.GenerationParams.SilverlightUsingServices)
            {
                %>
<!-- #include file="GetObjectAsync.asp" -->
<%
            }
        }
    }
}
if (UseBoth() && (createRunLocal || CurrentUnit.GenerationParams.SilverlightUsingServices))
{
    %>

#else
<%
}
%>
<!-- #include file="NewObjectSilverlight.asp" -->
<!-- #include file="GetObjectSilverlight.asp" -->
<%
if (UseBoth())
{
    createGenerateLocal = false;
    %>

#endif
<%
    if (!CurrentUnit.GenerationParams.SilverlightUsingServices)
    {
        %>
<!-- #include file="NewObjectAsync.asp" -->
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
}
%>

        #endregion
