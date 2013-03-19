        #region Factory Methods
<%
if (UseBoth())
{
    %>

#if !SILVERLIGHT
<%
}
if (UseNoSilverlight())
{
    %>
<!-- #include file="NewObject.asp" -->
<!-- #include file="NewObjectAsync.asp" -->
<%
    if (CurrentUnit.GenerationParams.DatabaseConnection != String.Empty)
    {
        if (parentInfo != null)
            isCollection = IsCollectionType(parentInfo.ObjectType);
        if (isChildSelfLoaded && !isCollection)
        {
            %>
<!-- #include file="GetObject.asp" -->
<%
            if (CurrentUnit.GenerationParams.SilverlightUsingServices)
            {
                %>
<!-- #include file="GetObjectAsync.asp" -->
<%
            }
        }
        else if (UseNoSilverlight())
        {
            %>
<!-- #include file="InternalGetObject.asp" -->
<%
        }
    }
}
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.CreateOptions.Factory && !c.CreateOptions.RunLocal)
    {
        objectRunLocal = false;
        break;
    }
}
if (UseBoth() && (objectRunLocal || CurrentUnit.GenerationParams.SilverlightUsingServices))
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
<%
    }
}
if (!CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>
<!-- #include file="GetObjectAsync.asp" -->
<%
}
%>

        #endregion
