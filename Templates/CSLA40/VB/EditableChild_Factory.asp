        #region Factory Methods<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, false) %>
<!-- #include file="NewObject.asp" -->
<!-- #include file="NewObjectAsync.asp" -->
<%
        bool selfLoad2 = GetSelfLoad(Info);
        bool lazyLoad2 = GetLazyLoad(Info);
        bool isCollection = false;
        if (Info.DbName != String.Empty)
        {
            CslaObjectInfo tmpInfo = Info.Parent.CslaObjects.Find(Info.ParentType);
            if (tmpInfo != null)
                isCollection = IsCollectionType(tmpInfo.ObjectType);
            if (selfLoad2 && lazyLoad2 && !isCollection)
            {
                %>
<!-- #include file="GetObject.asp" -->
<%
            }
            else
            {
                %>
<!-- #include file="InternalGetObject.asp" -->
<%
            }
        }
        %>
<%= IfSilverlight (Conditional.Else, 0, ref silverlightLevel, true, true) %><!-- #include file="NewObjectSilverlight.asp" -->
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true) %><!-- #include file="GetObjectAsync.asp" -->

        #endregion
