<%
if (true)
{
    %>
        #region Data Access<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, true) %>
<!-- #include file="CollectionDataPortalFetch.asp" -->

        <%
        //if (!CurrentUnit.GenerationParams.UseChildDataPortal)
        if (false)
        {
            %>
        /// <summary>
        /// Update all changes made on <see cref="<%=Info.ObjectName%>"/> object's children to the database.
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
            if (Info.ParentType.Length == 0)
            {
                Errors.Append("ParentType not set." + Environment.NewLine + Info.ObjectName + " will not compile." + Environment.NewLine);
            }
            %>internal void Update(<%= Info.ParentType %> parent)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs();
            OnUpdateStart(args);
            OnUpdatePre(args);
            <%
            CslaObjectInfo cldInfo = FindChildInfo(Info, Info.ItemType);
            bool ParentInsertOnly = cldInfo.ParentInsertOnly;
            %>
            // Loop through the deleted child objects and call their Update methods
            foreach (<%= Info.ItemType %> child in DeletedList)
                child.DeleteSelf(<%    if (!ParentInsertOnly) { %>parent<% } %>);

            //Now clear the deleted objects from the list
            DeletedList.Clear();

            // Loop through the objects to add and update, calling the Update Method
            foreach (<%= Info.ItemType %> child in this)
            {
                if (child.IsNew)
                    child.Insert(parent);
                else
                    child.Update(<% if (!ParentInsertOnly) { %>parent<% } %>);
            }
            OnUpdatePost(args);
            RaiseListChangedEvents = rlce;
        }

        <%
        }
        %>
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, false, true) %>        #endregion
<%
}
%>
