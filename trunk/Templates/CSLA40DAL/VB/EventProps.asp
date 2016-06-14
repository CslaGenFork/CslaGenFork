<%
if (Info.UpdaterType != string.Empty)
{
    %>

        #region Event handler properties

        [NotUndoable]
        private static bool _singleInstanceSavedHandler = true;

        /// <summary>
        /// Gets or sets a value indicating whether only a single instance should handle the Saved event.
        /// </summary>
        /// <value>
        /// <c>true</c> if only a single instance should handle the Saved event; otherwise, <c>false</c>.
        /// </value>
        public static bool SingleInstanceSavedHandler
        {
            get { return _singleInstanceSavedHandler; }
            set { _singleInstanceSavedHandler = value; }
        }

        #endregion
<%
}
%>
