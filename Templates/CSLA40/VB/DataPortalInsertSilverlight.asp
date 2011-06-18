<%
if (Info.GenerateDataPortalInsert &&
    CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

        /// <summary>
        /// Insert the new <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        /// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public <%= isChild ? "void Child_Insert" : "override void DataPortal_Insert" %>(Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
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
        /// Implements <%= isChild ? "Child_Insert" : "DataPortal_Insert" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        partial void Service_Insert();
    <%
}
%>
