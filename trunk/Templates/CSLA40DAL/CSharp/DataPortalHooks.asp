<%
if ((Info.IsEditableRoot() ||
    Info.IsEditableChild() ||
    Info.IsDynamicEditableRoot() ||
    Info.IsEditableSwitchable()) &&
    Info.SupportUpdateProperties == true)
{
    Infos.Append("To do list: edit \"" + Info.ObjectName + ".cs\", uncomment the \"OnDeserialized\" method and add the following line:" + Environment.NewLine);
    Infos.Append("      Saved += On" + Info.ObjectName + "Saved;" + Environment.NewLine);
    %>
        #region Saved Event
<%
        if (CurrentUnit.GenerationParams.WriteTodo)
        {
            %>

        // TODO: edit "<%= Info.ObjectName %>.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     Saved += On<%= Info.ObjectName %>Saved;
<%
        }
        %>

        private void On<%= Info.ObjectName %>Saved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (<%= Info.ObjectName %>Saved != null)
                <%= Info.ObjectName %>Saved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="<%= Info.ObjectName %>"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> <%= Info.ObjectName %>Saved;

        #endregion

<%
}
System.Collections.Generic.List<string> hookList = GetHookList(Info);
if (hookList.Count > 0 && UseNoSilverlight())
{
    %>
        #region DataPortal Hooks
<%
    if (UseBoth() && !HasSilverlightLocalDataPortalCreate(Info))
    {
        %>

#if !SILVERLIGHT
<%
    }
    foreach (string hookName in hookList)
    {
    %>

        /// <summary>
        /// Occurs <%= FormatHookDocumentation(hookName) %>
        /// </summary>
        partial void On<%= hookName %>(DataPortalHookArgs args);
        <%
        if (hookName == "Create" && HasSilverlightLocalDataPortalCreate(Info))
        {
            %>

#if !SILVERLIGHT
        <%
        }
    }
    if (UseBoth())
    {
        %>

#endif
<%
    }
%>

        #endregion

<%
}
%>
