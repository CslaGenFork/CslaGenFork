<%
if (true)
{
    %>
        #region Data Access<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, true) %>
<!-- #include file="NVLDataPortalFetch.asp" -->
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true) %>        #endregion
<%
}
%>
