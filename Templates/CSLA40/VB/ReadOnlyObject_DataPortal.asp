<%
if (true)
{
    %>
        #region Data Access<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, false) %>
<!-- #include file="DataPortalFetch.asp" -->
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, false, true) %>        #endregion
<%
}
%>
