
<%
if ((Info.ObjectType == CslaObjectType.EditableRoot ||
    Info.ObjectType == CslaObjectType.DynamicEditableRoot ||
    Info.ObjectType == CslaObjectType.EditableSwitchable) &&
    Info.SupportUpdateProperties == true)
{
    %>

        #region Saved Event

        /// <summary> Use this event to signal a <see cref="<%= Info.ObjectName %>"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> <%= Info.ObjectName %>Saved;

        /// <summary>
        /// Called when a <see cref="<%= Info.ObjectName %>"/> object is saved.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        protected virtual void On<%= Info.ObjectName %>Saved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (<%= Info.ObjectName %>Saved != null)
                <%= Info.ObjectName %>Saved(sender, e);
        }

        #endregion

<%
}
%>
        #region Pseudo Events
<%
if (UseNoSilverlight())
{
    if (UseBoth())
    {
        %>

#if !SILVERLIGHT
<%
    }
    System.Collections.Generic.List<string> eventList = GetEventList(Info);
    foreach (string strEvent in eventList)
    {
    %>

        /// <summary>
        /// Occurs <%= FormatEventDocumentation(strEvent) %>
        /// </summary>
        partial void On<%= strEvent %>(DataPortalHookArgs args);
        <%
    }
    if (UseBoth())
    {
        %>

#endif
<%
    }
}
%>

        #endregion
