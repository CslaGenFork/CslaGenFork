		
		''' <summary>
		''' Retrieve an existing <see cref="<%=Info.ObjectName%>" /> object based on data in the database. 
		''' </summary>
		Protected Overrides Sub DataPortal_Fetch(ByVal criteria As Object)
			
			Dim crit As <%=Info.GetObjectCriteriaType.Name%> = DirectCast(criteria, <%=Info.GetObjectCriteriaType.Name%>)
			<% If Info.ObjectType = CslaObjectType.EditableSwitchable Then %>
			If crit.IsChild Then MarkAsChild()
			
			<% End If %>
			Dim cn As New SqlConnection(DB("<%= Info.DbName %>"))
			Dim cmd As New SqlCommand()
			cn.Open()
			
			Try
					cmd.Connection  = cn
					cmd.CommandType = CommandType.StoredProcedure
					cmd.CommandText = "<%= Info.SelectProcedureName %>"
					<% For Each p As Parameter In Info.GetObjectParameters %>
					cmd.Parameters.Add("@<%=p.Property.ParameterName%>", <%=GetParameterSet(p.Property,true)%>)
					<% Next %>
					
					Dim dr As New SafeDataReader(cmd.ExecuteReader())
					Try
						dr.Read()
						<% For Each prop As ValueProperty In Info.GetAllValueProperties()
							If prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None Then %>		
						<%=GetReaderAssignmentStatement(prop)%>
						<%	End If
						   Next %>
						
						' Load Children here, if there are any
						<% If LoadsChildren(Info) Then %>
						
						<% For Each childProp As ChildProperty In Info.GetNonCollectionChildProperties()
								If Not childProp.LazyLoad Then %>
						dr.NextResult()
						If dr.read() Then
							<%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(dr)
						End If
						<%		End If
						   Next 
						  %>
						
						<% For Each childProp As ChildProperty In Info.GetCollectionChildProperties()
								If Not childProp.LazyLoad Then %>
						dr.NextResult()
						<%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(dr)
						<%		End If
						   Next 
						   End If %>
						<% If Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>
						
						Me.CheckRules()
							<% If ActiveObjects Then %>
						Me.RegisterAndSubscribe()
							<% End If %>
						<% End If %>

					Finally
						dr.Close()
					End Try
					
			Finally
				cn.Close()
				<% If Info.ObjectType <> CslaObjectType.ReadOnlyObject Then %>MarkOld()<% End If %>
			End Try
			
		End Sub
