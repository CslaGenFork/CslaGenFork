        #region Factory Methods<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, false) %>

        /// <summary>Adds a new item to the end of the <see cref="<%=Info.ObjectName%>"/> collection.</summary>
        protected override object AddNewCore()
        {
            <%= Info.ItemType %> item = <%= Info.ItemType %>.New<%= Info.ItemType %>();
            Add(item);
            return item;
        }

        /// <summary>
        /// Factory method. Creates a new <see cref="<%=Info.ObjectName%>"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="<%=Info.ObjectName%>"/> object.</returns>
        public static <%= Info.ObjectName %> New<%= Info.ObjectName %>()
        {
            <%
        if (CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
            CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel &&
            Info.GetRoles.Trim() != String.Empty)
        {
            %>
            //if (!CanAddObject())
            //    throw new System.Security.SecurityException("User not authorized to create a <%= Info.ObjectName %>.");aaa

            <%
        }
        %>
            return DataPortal.Create<<%= Info.ObjectName %>>();
        }
<!-- #include file="GetObject.asp" -->
<!-- #include file="Save.asp" -->

        #endregion
