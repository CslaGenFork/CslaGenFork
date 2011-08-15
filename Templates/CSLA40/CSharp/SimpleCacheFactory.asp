        #region Private Fields

        private static <%= Info.ObjectName %> _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory <%= Info.ObjectName %> cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            <%
    if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
        CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
        Info.GetRoles.Trim() != String.Empty)
    {
        %>if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.");

            <%
    }
        %>_list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(<%= Info.ObjectName %> list)
        {
            _list = list;
        }

        internal static bool IsCached
        {
            get { return _list != null; }
        }

        #endregion

<% %>
