
#Region " Events "

<%
    Dim EventList as New System.Collections.Generic.List(Of String)()
    If Info.HasGetCriteria Then
    EventList.AddRange(New String() {"FetchPre", "FetchPost"})
    End If
    If Info.ObjectType <> CslaObjectType.ReadOnlyObject And Info.ObjectType <> CslaObjectType.NameValueList And Info.ObjectType.ToString().IndexOf("Collection") = -1 Then 
		EventList.AddRange(New String() {"UpdatePre", "UpdatePost", "InsertPre", _
			"InsertPost", "DeletePre", "DeletePost"})
    End If 
    If Info.ObjectType.ToString().IndexOf("Collection") = -1 And Info.ObjectType <> CslaObjectType.NameValueList Then
        EventList.Add("FetchRead")
    End If
    If Info.ObjectType = CslaObjectType.EditableRoot Or Info.ObjectType = CslaObjectType.EditableChild Or Info.ObjectType = CslaObjectType.EditableSwitchable Then 
	   EventList.Add("Create")
    End If
    If Info.ObjectType = CslaObjectType.EditableChildCollection Then
	   EventList.AddRange(New String() {"UpdatePre", "UpdatePost"})
    End If 
	Dim strEvent as String
    For Each strEvent in EventList %>
	<NonSerialized(), NotUndoable()> _
	Private <%= FormatDelegateName(strEvent) %> As EventHandler
	Protected Custom Event <%= FormatPascal(strEvent) %> As EventHandler
	AddHandler(ByVal value As EventHandler)
		<%= FormatDelegateName(strEvent) %> = CType([Delegate].Combine(<%= FormatDelegateName(strEvent) %>, value), EventHandler)
	End AddHandler
	
	RemoveHandler(ByVal value As EventHandler)
		<%= FormatDelegateName(strEvent) %> = CType([Delegate].Remove(<%= FormatDelegateName(strEvent) %>, value), EventHandler)
	End RemoveHandler
	
	RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
		If <%= FormatDelegateName(strEvent) %> IsNot Nothing Then <%= FormatDelegateName(strEvent) %>(sender, e)
	End RaiseEvent
	End Event
	
    <% Next %>
#End Region
