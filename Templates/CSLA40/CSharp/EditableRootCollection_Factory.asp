        #region Factory Methods<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, false) %>
<!-- #include file="NewObject.asp" -->
<!-- #include file="NewObjectAsync.asp" -->
<!-- #include file="GetObject.asp" -->
<%= IfSilverlight (Conditional.Else, 0, ref silverlightLevel, true, false) %><!-- #include file="NewObjectSilverlight.asp" -->
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true) %><!-- #include file="GetObjectAsync.asp" -->
<!-- #include file="Save.asp" -->

        #endregion
