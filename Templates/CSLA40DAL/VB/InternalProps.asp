<%
if (useParentReference)
{
    %>
        #region Internal ParentList Property

        /// <summary>
        /// Maintains metadata about <see cref="ParentList"/> property.
        /// </summary>
        public static readonly PropertyInfo<<%= Info.ParentType %>> ParentListProperty = RegisterProperty<<%= Info.ParentType %>>(p => p.ParentList);
        /// <summary>
        /// Gets or sets the parent list.
        /// </summary>
        /// <value>The parent list.</value>
        internal <%= Info.ParentType %> ParentList
        {
            get { return ReadProperty(ParentListProperty); }
            set { LoadProperty(ParentListProperty, value); }
        }

        #endregion

<%
}
%>
