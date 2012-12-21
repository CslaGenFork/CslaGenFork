
		Private Sub DoInsertUpdate(ByVal cmd as SqlCommand)
		<% Dim bHasTimeStamp as Boolean = False 
			For Each prop As ValueProperty In Info.GetAllValueProperties()
				If prop.DataAccess <> ValueProperty.DataAccessBehaviour.ReadOnly And _
					prop.DataAccess <> ValueProperty.DataAccessBehaviour.CreateOnly And _
					(prop.DataAccess <> ValueProperty.DataAccessBehaviour.UpdateOnly Or prop.DbBindColumn.NativeType = "timestamp") Then
					If prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None _
						And prop.PrimaryKey <> ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK Then
						If prop.DbBindColumn.NativeType = "timestamp" Then
							bHasTimeStamp = True %>
			cmd.Parameters.Add("@New<%=prop.ParameterName%>", SqlDbType.Timestamp).Direction = ParameterDirection.Output
					<% Else %>
			cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%=GetParameterSet(prop)%>).DbType = DbType.<%=prop.DbBindColumn.DataType.ToString()%>
					<% End If %>
				<%	End If
				End If
			Next %>
		End Sub
		