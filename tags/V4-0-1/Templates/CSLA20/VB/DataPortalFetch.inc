
<% 
If Not Info.UseCustomLoading Then 
For Each c As Criteria In Info.CriteriaObjects 
	If c.GetOptions.DataPortal Then %>
		''' <summary>
		''' Retrieve an existing <see cref="<%=Info.ObjectName%>" /> object based on data in the database. 
		''' </summary>
		<% If c.GetOptions.RunLocal Then %><CSLA.RunLocal()> _
		<% End If %>Protected Overloads Sub DataPortal_Fetch(ByVal crit As <%=c.Name%>)
			<% If Info.ObjectType = CslaObjectType.EditableSwitchable Then %>
			If crit.IsChild Then MarkAsChild()
			<% End If %>
			Using cn As New SqlConnection(DataBase.<%= Info.DbName %>Connection)
				<% 
				If String.IsNullOrEmpty(c.GetOptions.ProcedureName) Then
					Errors.AppendFormat("Criteria '{0}' missing get procedure name", c.Name)
					Errors.AppendLine()
				End If %>
				Using cmd As new SqlCommand("<%= c.GetOptions.ProcedureName %>",cn)
					cmd.CommandType = CommandType.StoredProcedure
					<% For Each p As Metadata.Property In c.Properties %>
					cmd.Parameters.AddWithValue("@<%=p.ParameterName%>", <%=GetParameterSet(p,true)%>)
					<% Next %>
					cn.Open()
					LocalContext("dpCriteria") = crit
					LocalContext("dpConnection") = cn
					LocalContext("dpCommand") = cmd
					Fetch(cmd)
				End Using
			End Using
		End Sub
	
<% 	End If
Next %>
		<% If Info.HasGetCriteria Then %>
		<% If Not Info.DataSetLoadingScheme Then %>
		Private Sub Fetch(ByVal cmd As SqlCommand)
			RaiseEvent FetchPre(Me, EventArgs.Empty)
			Using dr As New SafeDataReader(cmd.ExecuteReader())
				LocalContext("dpDataReader") = dr
				dr.Read()
				Fetch(dr)
				<% If LoadsChildren(Info) Then %>		
				FetchChildren(dr)
				<% End If 
				   If Info.ObjectType <> CslaObjectType.ReadOnlyObject Then %>
				MarkOld()
				ValidationRules.CheckRules()
				<% End If %>				
			End Using
			RaiseEvent FetchPost(Me, EventArgs.Empty)
		End Sub
		<% Else %>
		Private Sub Fetch(ByVal cmd As SqlCommand)
			RaiseEvent FetchPre(Me, EventArgs.Empty)
			Dim ds As New DataSet
			LocalContext("dpDataSet") = ds
			Using da As New SqlDataAdapter(cmd)
				da.Fill(ds)
			End Using
			CreateRelations(ds)
			Fetch(ds.Tables(0).Rows(0))
			<% If LoadsChildren(Info) Then %>		
			FetchChildren(ds.Tables(0).Rows(0))
			<% End If 
			   If Info.ObjectType <> CslaObjectType.ReadOnlyObject Then %>
			MarkOld()
			ValidationRules.CheckRules()
			<% 	If ActiveObjects Then %>
			Me.RegisterAndSubscribe()
			<% 	End If 
			   End If %>	
			RaiseEvent FetchPost(Me, EventArgs.Empty)
		End Sub
<!-- #include file="CreateRelations.inc" -->
		<% End If %>
		<% End If %>
		
		<!-- #include file="InternalFetch.inc" -->
<% End If %>
