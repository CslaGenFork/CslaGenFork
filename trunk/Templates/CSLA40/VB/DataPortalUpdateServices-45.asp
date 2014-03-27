<%
if (Info.GenerateDataPortalUpdate && CurrentUnit.GenerationParams.SilverlightUsingServices && UseNoSilverlight())
{
    MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update", "Partial Sub Service_Update()"));
    %>

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <Csla.RunLocal>
        Protected <%= isChildNotLazyLoaded ? "Sub Child_Update" : "Overrides Sub DataPortal_Update" %>()
            Service_Update()
        End Sub

        ''' <summary>
        ''' Implements <%= isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update" %> for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        Partial Sub Service_Update()
        End Sub
    <%
}
%>
