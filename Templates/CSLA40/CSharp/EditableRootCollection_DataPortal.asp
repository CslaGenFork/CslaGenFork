<%
if (true)
{
    %>
        #region Data Access<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, false) %>
<!-- #include file="CollectionDataPortalFetch.asp" -->

        /// <summary>
        /// Saves (delete, add, update) all child objects to database.
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
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true) %>        #endregion
<%
}
%>
