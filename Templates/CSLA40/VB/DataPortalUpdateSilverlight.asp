<%
if (Info.GenerateDataPortalUpdate &&
    CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

        /// <summary>
        /// Update all changes made on <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        /// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public <%= isChild ? "void Child" : "override void DataPortal" %>_Update(Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
        {
            try
            {
                Service_Update();
                handler(this, null);
            }
            catch (Exception ex)
            {
                handler(null, ex);
            }
        }

        /// <summary>
        /// Implements <%= isChild ? "Child_Update" : "DataPortal_Update" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        partial void Service_Update();
    <%
}
%>
