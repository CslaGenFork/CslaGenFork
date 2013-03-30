		Private Sub CreateRelations(ByVal ds As DataSet)
			<% 
			<script runat="template">
				Public Function GetDSRelations(ByVal Info As CslaObjectInfo) As String
					Dim sb As New System.Text.StringBuilder()
					For Each item As CslaObjectInfo In GetChildItems(Info)
						If item.ParentProperties.Count > 0 Then
							sb.Append("			ds.Relations.Add(""")
							sb.Append(Info.ObjectName)
							sb.Append(item.ObjectName)
							sb.Append(""", New DataColumn() {")
							Dim i as Integer = 0
							For Each prop As Metadata.Property In item.ParentProperties
								If I > 0 Then
									sb.Append(", ")
								End If
								sb.Append("ds.Tables(""")
								sb.Append(Info.ObjectName)
								sb.Append(""").Columns(""")
								sb.Append(prop.Name)
								sb.Append(""")")
								i +=1
							Next
							i=0
							sb.Append("}, New DataColumn() {")
							For Each prop As Metadata.Property In item.ParentProperties
								If I > 0 Then
									sb.Append(", ")
								End If
								sb.Append("ds.Tables(""")
								sb.Append(item.ObjectName)
								sb.Append(""").Columns(""")
								sb.Append(prop.Name)
								sb.Append(""")")
								i +=1
							Next
							sb.Append("}, False)")
							sb.AppendLine()
							sb.Append(GetDSRelations(item))
						End If
					Next
					return sb.ToString()
				End Function
			</script>
			%> <%
			Dim obj As CslaObjectInfo
			If IsCollectionType(Info.ObjectType) Then 
				obj = FindChildInfo(Info, Info.ItemType) 
			Else
				obj = Info
			End If
			If obj IsNot Nothing Then
				Dim objectNames As String() = GetAllChildItemsInHierarchy(obj) %>
			ds.Tables(0).TableName = "<%=obj.ObjectName%>"
			<%	For i As Integer = 0 To objectNames.Length - 1 %>
			ds.Tables(<%=(i+1).ToString()%>).TableName = "<%=objectNames(i)%>"
			<% 	Next %>
<%=GetDSRelations(obj)%>	
			<% End If %>
		End Sub
		