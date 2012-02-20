<%
if (useParentReference || isRODeepLoadCollection)
{
    %>
        #region ParentList Property

        /// <summary>
        /// Maintains metadata about <see cref="ParentList"/> property.
        /// </summary>
        public static readonly PropertyInfo<<%= Info.ParentType %>> ParentListProperty = RegisterProperty<<%= Info.ParentType %>>(p => p.ParentList);
        /// <summary>
        /// Provide access to the parent list reference for use in child object code.
        /// </summary>
        /// <value>The parent list reference.</value>
        public <%= Info.ParentType %> ParentList
        {
            get { return ReadProperty(ParentListProperty); }
            internal set { LoadProperty(ParentListProperty, value); }
        }

        #endregion

<%
}
%>
