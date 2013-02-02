
<%
if ((Info.ObjectType == CslaObjectType.EditableRoot ||
    Info.ObjectType == CslaObjectType.DynamicEditableRoot ||
    Info.ObjectType == CslaObjectType.EditableSwitchable) &&
    Info.SupportUpdateProperties == true)
{
    Infos.Append("To do list: edit \"" + Info.ObjectName + ".cs\", uncomment the \"OnDeserialized\" method and add the following line:" + Environment.NewLine);
    Infos.Append("      Saved += " + Info.ObjectName + "_Saved;" + Environment.NewLine);
    %>
        #region Saved Event

        // TODO: edit "<%= Info.ObjectName %>.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     Saved += <%= Info.ObjectName %>_Saved;

        private void <%= Info.ObjectName %>_Saved(object sender, Csla.Core.SavedEventArgs e)
        {
            On<%= Info.ObjectName %>Saved(this, e);
        }

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
