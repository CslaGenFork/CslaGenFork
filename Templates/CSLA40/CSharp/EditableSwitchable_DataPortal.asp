<%
if (true)
{
    %>
        #region Data Access<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, false) %>
<!-- #include file="DataPortalCreate.asp" -->
<!-- #include file="DataPortalFetch.asp" -->
<!-- #include file="DataPortalInsert.asp" -->
<!-- #include file="DataPortalUpdate.asp" -->
<!-- #include file="InternalInsertUpdateDelete.asp" -->
<%
        if (Info.GenerateDataPortalInsert || Info.GenerateDataPortalUpdate)
        {
            %>
<!-- #include file="DoInsertUpdate.asp" -->
<%
        }
        %>
<!-- #include file="DataPortalDelete.asp" -->
<%= IfSilverlight (Conditional.Else, 0, ref silverlightLevel, true, true) %>
<!-- #include file="DataPortalCreateSilverlight.asp" -->
<!-- #include file="DataPortalFetchSilverlight.asp" -->
<!-- #include file="InternalInsertUpdateDeleteSilverlight.asp" -->
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true) %>        #endregion
<%
}
%>
