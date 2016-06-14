<%
// Check if we are supposed to use the Updater or else skip over
if (Info.UpdaterType != string.Empty)
{
    %>
        #region <%= Info.UpdaterType %>Saved nested class
<%
    if (CurrentUnit.GenerationParams.WriteTodo)
    {
        %>

        // TODO: edit "<%= Info.ObjectName %>.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     <%= Info.UpdaterType %>Saved.Register(this);
<%
    }
    %>

        /// <summary>
        /// Nested class to manage the Saved events of <see cref="<%= Info.UpdaterType %>"/>
        /// to update the list of <see cref="<%= Info.ItemType %>"/> objects.
        /// </summary>
        private static class <%= Info.UpdaterType %>Saved
        {
            private static List<WeakReference> _references;

            private static bool Found(object obj)
            {
                return _references.Any(reference => Equals(reference.Target, obj));
            }

            /// <summary>
            /// Registers a <%= Info.ObjectName %> instance to handle Saved events.
            /// to update the list of <see cref="<%= Info.ItemType %>"/> objects.
            /// </summary>
            /// <param name="obj">The <%= Info.ObjectName %> instance.</param>
            public static void Register(<%= Info.ObjectName %> obj)
            {
                var mustRegistered = _references == null;

                if (mustRegistered)
                    _references = new List<WeakReference>();

                if (<%= Info.ObjectName %>.SingleInstanceSavedHandler)
                    _references.Clear();

                if (!Found(obj))
                    _references.Add(new WeakReference(obj));

                if (mustRegistered)
                    <%= Info.UpdaterType %>.<%= Info.UpdaterType %>Saved += <%= Info.UpdaterType %>SavedHandler;
            }

            /// <summary>
            /// Handles Saved events of <see cref="<%= Info.UpdaterType %>"/>.
            /// </summary>
            /// <param name="sender">The sender of the event.</param>
            /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            public static void <%= Info.UpdaterType %>SavedHandler(object sender, Csla.Core.SavedEventArgs e)
            {
                foreach (var reference in _references)
                {
                    if (reference.IsAlive)
                        ((<%= Info.ObjectName %>) reference.Target).<%= Info.UpdaterType %>SavedHandler(sender, e);
                }
            }

            /// <summary>
            /// Removes event handling and clears all registered <%= Info.ObjectName %> instances.
            /// </summary>
            public static void Unregister()
            {
                <%= Info.UpdaterType %>.<%= Info.UpdaterType %>Saved -= <%= Info.UpdaterType %>SavedHandler;
                _references = null;
            }
        }

        #endregion

    <%
}
%>
