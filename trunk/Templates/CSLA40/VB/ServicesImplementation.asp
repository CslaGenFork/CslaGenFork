<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    if (UseBoth())
    {
        %>

#If SILVERLIGHT Then
<%
    }
        %>

        #Region " Implementation of Services "
<%
    foreach (AdvancedGenerator.ServiceMethod method in MethodList)
    {
        %>

        ''' <summary>
        ''' Service implementation of <%= method.DataPortalMethod %> for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%= method.MethodHeader %>
        <%
        if (Info.IsUnitOfWork() && Info.UnitOfWorkType == UnitOfWorkFunction.Creator)
        {
            %>
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            <%
        }
        %>
            Throw New System.Exception("The service is not implemented.")
        End Sub
<%
    }
    %>

        #End Region
<%
    if (UseBoth())
    {
        %>

#End If
<%
    }
}
%>
