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
    foreach (string method in MethodList)
    {
        %>

        /// <summary>
        /// Service implementation of DataPortal_Fetch for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%= method %>
        {
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
