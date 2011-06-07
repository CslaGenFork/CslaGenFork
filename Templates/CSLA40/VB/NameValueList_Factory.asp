        #region Factory Methods<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, false) %>
<!-- #include file="GetNVL.asp" -->
<%= IfSilverlight (Conditional.Else, 0, ref silverlightLevel, true, false) %><!-- #include file="GetNVLSilverlight.asp" -->
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, false) %><!-- #include file="GetNVLAsync.asp" -->
<% Response.Write(Environment.NewLine); %>
        #endregion
