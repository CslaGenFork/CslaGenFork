<%
if (Info.GenerateDataPortalInsert && CurrentUnit.GenerationParams.SilverlightUsingServices && UseNoSilverlight())
{
    MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert", "Partial Sub Service_Insert()"));
    %>

        ''' <summary>
        ''' Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        ''' </summary>
        <RunLocal>
        Protected <%= (isChildNotLazyLoaded ? "Sub Child_Insert" : "Overrides Sub DataPortal_Insert") %>()
            Service_Insert()
        End Sub

        ''' <summary>
        ''' Implements <%= isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert" %> for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        Partial Sub Service_Insert()
        End Sub
    <%
}
%>
