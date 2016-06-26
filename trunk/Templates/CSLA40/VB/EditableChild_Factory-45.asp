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

#End If
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

        #End Region
