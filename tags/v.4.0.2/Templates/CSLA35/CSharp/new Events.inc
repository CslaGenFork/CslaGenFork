
		#region Events

<%	
		System.Collections.Generic.List<string> eventList = new System.Collections.Generic.List<string>();
		if (Info.HasGetCriteria)
			eventList.AddRange(new string[] {"FetchPre", "FetchPost"});
		if (Info.ObjectType != CslaObjectType.ReadOnlyObject && Info.ObjectType != CslaObjectType.NameValueList && Info.ObjectType.ToString().IndexOf("Collection") == -1)
			eventList.AddRange(new string[] {"UpdatePre", "UpdatePost", "InsertPre", "InsertPost", "DeletePre", "DeletePost"});
		if (Info.ObjectType.ToString().IndexOf("Collection") == -1 && Info.ObjectType != CslaObjectType.NameValueList)
			eventList.Add("FetchRead");
		if (Info.ObjectType == CslaObjectType.EditableRoot || Info.ObjectType == CslaObjectType.EditableChild || Info.ObjectType == CslaObjectType.EditableSwitchable)
			eventList.Add("Create");
		if (Info.ObjectType == CslaObjectType.EditableChildCollection)
			eventList.AddRange(new string[] {"UpdatePre", "UpdatePost"});
		foreach (string strEvent in eventList) { %>
		[NonSerialized()]
		[NotUndoable()]
		private EventHandler <%= FormatDelegateName(strEvent) %>;
		protected event EventHandler <%= FormatPascal(strEvent) %>
        {
            add 
            {
                <%= FormatDelegateName(strEvent) %> = (EventHandler)Delegate.Combine(<%= FormatDelegateName(strEvent) %>, value);
            }
            remove 
            {
                <%= FormatDelegateName(strEvent) %> = (EventHandler)Delegate.Remove(<%= FormatDelegateName(strEvent) %>, value);
            }
        }
        private void on<%= FormatPascal(strEvent) %>(object sender, EventArgs e)
        {
			if (<%= FormatDelegateName(strEvent) %> != null)
				<%= FormatDelegateName(strEvent) %>(sender, e);
        }

		<% } %>
		#endregion
