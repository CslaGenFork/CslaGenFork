<%
if (Info.GenerateDataPortalInsert &&
    CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    MethodList.Add("partial void Service_Insert()");
    %>

        /// <summary>
        /// Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        /// </summary>
        /// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public <%= isChildNotLazyLoaded ? "void Child_" : "override void DataPortal_" %>Insert(Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
        {
            try
            {
                Service_Insert();
                handler(this, null);
            }
            catch (Exception ex)
            {
                handler(null, ex);
            }
        }

        /// <summary>
        /// Implements <%= isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        partial void Service_Insert();
    <%
}
%>
