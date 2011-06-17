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
        /// Update all changes made on <see cref="<%= Info.ObjectName %>"/> object in the database.
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
        //if (CurrentUnit.GenerationParams.UseChildDataPortal)
        if (true)
        {
            %>base.Child_Update();
<%
        }
        else
        {
            %>foreach (<%= Info.ItemType %> child in DeletedList)
                    child.DeleteSelf();

                // Now clear the deleted objects from the list
                DeletedList.Clear();

                foreach (<%= Info.ItemType %> child in this)
                {
                    if (child.IsNew)
                        child.Insert();
                    else
                        child.Update();
                }
                <%
        }
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
%>
<!-- #include file="DataPortalFetchSilverlight.asp" -->
<!-- #include file="DataPortalUpdateSilverlight.asp" -->
<%
if (UseBoth())
{
    %>

#endif
<%
}
%>

        #endregion
