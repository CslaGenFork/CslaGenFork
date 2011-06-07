<%
if (true)
{
    %>
        #region Data Access<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, false) %>
<!-- #include file="DataPortalCreate.asp" -->
<!-- #include file="DataPortalFetch.asp" -->
<!-- #include file="InternalUpdate.asp" -->
<%= IfSilverlight (Conditional.Else, 0, ref silverlightLevel, true, true) %><!-- #include file="DataPortalCreateSilverlight.asp" -->
<!-- #include file="DataPortalFetchSilverlight.asp" -->
<!-- #include file="DataPortalInsertSilverlight.asp" -->
<!-- #include file="DataPortalUpdateSilverlight.asp" -->
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true) %>        #endregion
<%
}
%>
