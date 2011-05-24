					
<%
					'Update child Properties
					For Each child As ChildProperty In Info.GetCollectionChildProperties()
						Dim _child as CslaObjectInfo = FindChildInfo(Info, child.TypeName)
						If _child IsNot Nothing AndAlso _child.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso _child.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>
					If <%=FormatFieldName(child.Name)%> IsNot Nothing Then
						<%=FormatFieldName(child.Name)%>.Update(Me)
					End If 
					<%  End If
					Next
					For Each child As ChildProperty In Info.GetNonCollectionChildProperties()
						Dim _child as CslaObjectInfo = FindChildInfo(Info, child.TypeName)
						If _child IsNot Nothing AndAlso _child.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso _child.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>
					If <%=FormatFieldName(child.Name)%> IsNot Nothing Then
						If <%=FormatFieldName(child.Name)%>.IsNew Then
							<%=FormatFieldName(child.Name)%>.Insert(Me)
						Else
							<%=FormatFieldName(child.Name)%>.Update(<% If Not _child.ParentInsertOnly Then %>Me<%End If %>)
						End If
					End If 
					<%  End If
					Next %>
