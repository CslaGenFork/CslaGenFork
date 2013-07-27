        #region Data Access
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
<!-- #include file="CollectionDataPortalFetch.asp" -->
<% %>

        /// <summary>
        /// Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (Info.TransactionType == TransactionType.EnterpriseServices)
        {
            %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
        }
        else if (Info.TransactionType == TransactionType.TransactionScope)
        {
            %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
        }
        if (Info.InsertUpdateRunLocal)
        {
            %>[Csla.RunLocal]
        <%
        }
        %>protected override void DataPortal_Update()
        {
            <%= GetConnection(Info, false) %>
            {
                <%
        if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
        {
            %>cn.Open();
                <%
        }
            %>base.Child_Update();
<%
        if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
        {
            %>
                ctx.Commit();
                <%
        }
        %>
            }
        }
<%
}
if (UseNoSilverlight() && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

#else
<%
}
if (CurrentUnit.GenerationParams.TargetIsCsla40)
{
    %>
<!-- #include file="DataPortalFetchServices.asp" -->
<!-- #include file="DataPortalUpdateServices.asp" -->
<%
}
else
{
    %>
<!-- #include file="DataPortalFetchServices-45.asp" -->
<!-- #include file="DataPortalUpdateServices-45.asp" -->
<%
}
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
