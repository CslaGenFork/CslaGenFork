<%
        if (lazyLoad3 || createCriteria || parentCreateCriteria ||
            declarationMode == PropertyDeclaration.ClassicProperty ||
            declarationMode == PropertyDeclaration.AutoProperty)
        {
            if (selfLoad3 && Info.DbName.Equals(String.Empty))
            {
                Warnings.Append("Make sure you specify a DB name." + Environment.NewLine);
            }
            %>
        #region Factory Methods<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, false) %>

        /// <summary>
        /// Factory method. Creates a new <see cref="<%=Info.ObjectName%>"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="<%=Info.ObjectName%>"/> object.</returns>
        internal static <%= Info.ObjectName %> New<%= Info.ObjectName %>()
        {
            return DataPortal.CreateChild<<%= Info.ObjectName %>>();
        }
        <%
            if (CurrentUnit.GenerationParams.GenerateSilverlight4)
            {
                %>

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="<%=Info.ObjectName%>"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        internal static void New<%= Info.ObjectName %>(EventHandler<DataPortalResult<<%= Info.ObjectName %>>> callback)
        {
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(callback);
        }
        <%
            }
        }
        if (!selfLoad3)
        {
            %>
<!-- #include file="InternalGetObject.asp" -->
<%
        }
        else
        {
            %>
<!-- #include file="GetObject.asp" -->
<%
        }
        if (lazyLoad3 || createCriteria || parentCreateCriteria ||
            declarationMode == PropertyDeclaration.ClassicProperty ||
            declarationMode == PropertyDeclaration.AutoProperty)
        {
            if (CurrentUnit.GenerationParams.GenerateSilverlight4)
            {
    %>
<%= IfSilverlight (Conditional.Else, 0, ref silverlightLevel, true, false) %>

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="<%=Info.ObjectName%>"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        internal static void New<%= Info.ObjectName %>(EventHandler<DataPortalResult<<%= Info.ObjectName %>>> callback)
        {
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(callback<%= strNewCallback2 %>);
        }
        <%
            }
        }
        if (CurrentUnit.GenerationParams.GenerateAsynchronous)
        {
            %>
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true) %><!-- #include file="GetObjectAsync.asp" --><%
        }
        else
        {
            %>
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, false) %><%
        }
%>        #endregion
