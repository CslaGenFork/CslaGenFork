<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    if (UseBoth())
    {
        %>

#if SILVERLIGHT
<%
    }
        %>

        #region Implementation of Services
<%
    foreach (AdvancedGenerator.ServiceMethod method in MethodList)
    {
        %>

        /// <summary>
        /// Service implementation of <%= method.DataPortalMethod %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%= method.MethodHeader %>
        {
        <%
        if (Info.IsUnitOfWork() && Info.UnitOfWorkType == UnitOfWorkFunction.Creator)
        {
            %>
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            <%
        }
        %>
            throw new System.Exception("The service is not implemented.");
        }
<%
    }
    %>

        #endregion
<%
    if (UseBoth())
    {
        %>

#endif
<%
    }
}
%>
