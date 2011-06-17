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
        public <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "void Child_Update" : "override void DataPortal_Update" %>(Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
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
        /// Implements <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child_Update()" : "DataPortal_Update" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        partial void Service_Update();
    <%
}
%>
