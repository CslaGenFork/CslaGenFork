		
#Region " Constructors "
	
	Protected <% If Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>Friend <% End If %>Sub New()
		' Prevent direct creation
		<% If ActiveObjects Then 
			If Info.ObjectType <> CslaObjectType.EditableChildCollection Then  %>
		RegisterAndSubscribe()
				<% End If 
		End If %>
	
		<%	If Info.ObjectType = CslaObjectType.EditableChild OrElse Info.ObjectType = CslaObjectType.EditableChildCollection Then %>
		
		' Show the framework that this is a child object
		MarkAsChild()
		<%	End If %>
    <% If Info.ObjectType = CslaObjectType.EditableChildCollection Or Info.ObjectType = CslaObjectType.EditableRootCollection Then %>
    Me.RaiseListChangedEvents = False
    AllowNew = <%=Info.AllowNew.ToString()%>
    AllowEdit = <%=Info.AllowEdit.ToString()%>
    AllowRemove = <%=Info.AllowRemove.ToString()%>
    Me.RaiseListChangedEvents = True
    <%	End If %>
	End Sub
	
	
#End Region
