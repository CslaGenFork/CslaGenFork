					
<%
					'Update child Properties
					For Each child As ChildProperty In Info.GetCollectionChildProperties()
						Dim _child as CslaObjectInfo = FindChildInfo(Info, child.TypeName)
						If _child IsNot Nothing AndAlso _child.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso _child.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>
					If FieldManager.FieldExists(<%=FormatManaged(child.Name)%>) Then
						DataPortal.UpdateChild(ReadProperty(Of <%= child.TypeName %>)(<%= FormatManaged(child.Name) %>), Me)
					End If 
					<%  End If
					Next
					%>
					
