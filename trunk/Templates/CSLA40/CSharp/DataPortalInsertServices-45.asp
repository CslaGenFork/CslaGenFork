<%
if (Info.GenerateDataPortalInsert && CurrentUnit.GenerationParams.SilverlightUsingServices && UseNoSilverlight())
{
    MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert", "partial void Service_Insert()"));
    %>

        /// <summary>
        /// Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        /// </summary>
        [RunLocal]
        protected <%= (isChildNotLazyLoaded ? "void Child_Insert" : "override void DataPortal_Insert") %>()
        {
            Service_Insert();
        }

        /// <summary>
        /// Implements <%= isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        partial void Service_Insert();
    <%
}
%>
