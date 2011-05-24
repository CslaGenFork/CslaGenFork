<% If Not Info.UseCustomLoading Then %>
	<% If Not Info.DataSetLoadingScheme Then %>
		''' <summary>
		''' Load a <see cref="<%=Info.ObjectName%>" /> object from given SafeDataReader.
		''' </summary>
		Private Sub Fetch(ByVal dr As SafeDataReader)
			' Value properties
			<% For Each prop As ValueProperty In Info.GetAllValueProperties()
				If prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None Then 
					If prop.DataAccess <> ValueProperty.DataAccessBehaviour.WriteOnly Then 
						Try %>		
			<%=GetReaderAssignmentStatement(prop)%>
			<%		
						Catch ex As Exception
							Errors.Append(ex.Message + Environment.NewLine)
						End Try
					End If
				End If
			   Next %>
			LocalContext("dpDataReader") = dr
			RaiseEvent FetchRead(Me, EventArgs.Empty)
			LocalContext("dpDataReader") = Nothing
		End Sub
		<% If LoadsChildren(Info) Then %>		
		Private Sub FetchChildren(ByVal dr As SafeDataReader)
			<% For Each childProp As ChildProperty In Info.GetNonCollectionChildProperties()
					If Not childProp.LazyLoad And childProp.LoadingScheme <> LoadingScheme.None Then %>
			dr.NextResult()
			If dr.read() Then
				<%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(dr)
			End If
			<%		End If
			   Next 
			  %>
			<% For Each childProp As ChildProperty In Info.GetCollectionChildProperties()
					If Not childProp.LazyLoad And childProp.LoadingScheme <> LoadingScheme.None Then %>
			dr.NextResult()
			<%
			Dim _child as CslaObjectInfo = FindChildInfo(Info, childProp.TypeName)
			Dim _fetchParentReference as Boolean = False
			If Not _child Is Nothing Then
				_fetchParentReference = _child.AddParentReference
			End If %>
			<%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(dr)
			<% If _fetchParentReference Then %>
				<%=FormatFieldName(childProp.Name)%>.SetParent(Me)
			<% End If %>
			<%		End If
			   Next %>
			<% If ActiveObjects Then %>
			RegisterAndSubscribe()
			<% End If %>
		End Sub
		<% End If %>
	<% Else %>	
		
		''' <summary>
		''' Load a <see cref="<%=Info.ObjectName%>" /> object from given DataRow.
		''' </summary>
		Private Sub Fetch(ByVal dr As DataRow)
			' Value properties
			<% For Each prop As ValueProperty In Info.GetAllValueProperties()
				If prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None Then 
					If prop.DataAccess <> ValueProperty.DataAccessBehaviour.WriteOnly Then  
						If prop.PropertyType = TypeCodeEx.SmartDate %>
			If Not dr.IsNull("<%=prop.ParameterName%>") Then <%=FormatFieldName(prop.Name)%> = New SmartDate(DirectCast(dr("<%=prop.ParameterName%>"), DateTime))
						<% Else %>		
			If Not dr.IsNull("<%=prop.ParameterName%>") Then <%=FormatFieldName(prop.Name)%> = DirectCast(dr("<%=prop.ParameterName%>"), <%=GetDataType(prop)%>)
			<%			End If
					End If
				End If
			   Next %>
			LocalContext("dpDataRow") = dr
			RaiseEvent FetchRead(Me, EventArgs.Empty)
			LocalContext("dpDataRow") = Nothing
		End Sub
		<% If LoadsChildren(Info) Then %>		
		Private Sub FetchChildren(ByVal dr As DataRow)
			Dim childRows as DataRow()
			<% For Each childProp As ChildProperty In Info.GetNonCollectionChildProperties()
					If Not childProp.LazyLoad And childProp.LoadingScheme <> LoadingScheme.None Then %>
			childRows=dr.GetChildRows("<%=Info.ObjectName & childProp.TypeName%>")
			If childRows.Length > 0 Then
				<%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(childRows(0))
			End If
			<%		End If
			   Next 
			  %>
			<% For Each childProp As ChildProperty In Info.GetCollectionChildProperties()
					If Not childProp.LazyLoad And childProp.LoadingScheme <> LoadingScheme.None Then 
						Dim _Child As CslaObjectInfo = FindChildInfo(info, childProp.TypeName)
						If _Child Is Nothing Then
							Errors.Append("	Warning: TypeName '" & childProp.TypeName & "' doesn't exist in this project")
							Errors.Append(vbCrLf)
						Else %>
			childRows=dr.GetChildRows("<%=Info.ObjectName & _child.ItemType %>")
			<%
			Dim _fetchParentReference as Boolean = False
			If Not _child Is Nothing Then
				_fetchParentReference = _child.AddParentReference
			End If %>
			<%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(childRows)
			<% If _fetchParentReference Then %>
				<%=FormatFieldName(childProp.Name)%>.SetParent(Me)
			<% End If %>
			<%			End If
					End If
			   Next %>
			<% If ActiveObjects Then %>
			RegisterAndSubscribe()
			<% End If %>
		End Sub
		<% End If %>
	<% End If %>
		
<% End If %>
