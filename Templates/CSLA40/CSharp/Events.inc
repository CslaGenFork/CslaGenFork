
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
        /// Called when a <see cref="<%= Info.ObjectName %>"/> object is saved..
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
System.Collections.Generic.List<string> eventList = new System.Collections.Generic.List<string>();
if (Info.HasGetCriteria)
    eventList.AddRange(new string[] {"FetchPre", "FetchPost"});
if (Info.ObjectType != CslaObjectType.ReadOnlyObject && Info.ObjectType != CslaObjectType.NameValueList && Info.ObjectType.ToString().IndexOf("Collection") == -1)
    eventList.AddRange(new string[] {"UpdateStart", "UpdatePre", "UpdatePost", "InsertStart", "InsertPre", "InsertPost", "DeletePre", "DeletePost"});
if (Info.ObjectType.ToString().IndexOf("Collection") == -1 && Info.ObjectType != CslaObjectType.NameValueList)
    eventList.Add("FetchRead");
if (Info.ObjectType == CslaObjectType.EditableRoot || Info.ObjectType == CslaObjectType.DynamicEditableRoot || Info.ObjectType == CslaObjectType.EditableChild || Info.ObjectType == CslaObjectType.EditableSwitchable)
    eventList.Add("Create");
if (Info.ObjectType == CslaObjectType.EditableChildCollection)
    eventList.AddRange(new string[] {"UpdateStart", "UpdatePre", "UpdatePost"});
foreach (string strEvent in eventList)
{
    %>

        /// <summary>
        /// Occurs <%= FormatEventDocumentation(strEvent) %>
        /// </summary>
        partial void On<%= strEvent %>(DataPortalHookArgs args);
        <%
}
%>

        #endregion
