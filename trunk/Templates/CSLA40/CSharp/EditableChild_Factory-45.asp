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
if (UseNoSilverlight())
{
    if (CurrentUnit.GenerationParams.DatabaseConnection != String.Empty)
    {
        if (parentInfo != null)
            isCollection = TypeHelper.IsCollectionType(parentInfo.ObjectType);
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
    }
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
    if (Info.HasCreateCriteriaFactory)
    {
        %>
<!-- #include file="NewObjectAsync.asp" -->
<%
    }
    if (Info.HasGetCriteriaFactory)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
}
%>

        #endregion
