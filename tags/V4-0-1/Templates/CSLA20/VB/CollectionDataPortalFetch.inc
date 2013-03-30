
	<% 
If Not Info.UseCustomLoading Then 
	For Each c As Criteria In Info.CriteriaObjects
	If c.GetOptions.DataPortal Then %>
	''' <summary>
	''' Load <see cref="<%=Info.ObjectName%>" /> collection from the database, based on given parameters.
	''' </summary>
	Protected Overloads Sub DataPortal_Fetch(ByVal crit As <%=c.Name%>)
		Using cn As New SqlConnection(DataBase.<%= Info.DbName %>Connection)
			Using cmd As SqlCommand = cn.CreateCommand()
				cmd.CommandType = CommandType.StoredProcedure
				cmd.CommandText = "<%= c.GetOptions.ProcedureName %>"
				<% For Each p As Metadata.Property In c.Properties %>
				cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%=GetParameterSet(p,true)%>)
				<% Next %>
				cn.Open()
				LocalContext("dpCriteria") = crit
				LoadCollection(cmd)
				<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>IsReadOnly = True<% End If %>
			End Using
		End Using
	End Sub
<%	End If
	Next %>

	<% If Info.HasGetCriteria Then %>
	<% If Not Info.DataSetLoadingScheme Then %>
	Private Sub LoadCollection(ByVal cmd As SqlCommand)
		LocalContext("dpCommand") = cmd
		LocalContext("dpConnection") = cmd.Connection
		RaiseEvent FetchPre(Me, EventArgs.Empty)
		Using dr As New SafeDataReader(cmd.ExecuteReader())
			Fetch(dr)
		End Using
		LocalContext("dpCommand") = cmd
		LocalContext("dpConnection") = cmd.Connection
		RaiseEvent FetchPost(Me, EventArgs.Empty)
	End Sub
	<% Else %>
	Private Sub LoadCollection(ByVal cmd As SqlCommand)
			LocalContext("dpCommand") = cmd
			LocalContext("dpConnection") = cmd.Connection
			RaiseEvent FetchPre(Me, EventArgs.Empty)
			Dim ds As New DataSet
			LocalContext("dpDataSet") = ds
			Using da As New SqlDataAdapter(cmd)
				da.Fill(ds)
			End Using
			CreateRelations(ds)
			Fetch(ds.Tables(0).Rows)
			LocalContext("dpCommand") = cmd
			LocalContext("dpConnection") = cmd.Connection
			RaiseEvent FetchPost(Me, EventArgs.Empty)
		End Sub
		
<!-- #include file="CreateRelations.inc" -->
	<% End If %>
	<% End If
 	Dim isSwitchable As Boolean = False
	Dim childInfo As CslaObjectInfo = FindChildInfo(Info, Info.ItemType)
	If childInfo.ObjectType = CslaObjectType.EditableSwitchable Then 
		isSwitchable = True 
	End If %>
	<% If Not Info.DataSetLoadingScheme Then %>
		''' <summary>
		''' Load all <see cref="<%=Info.ObjectName%>" /> collection items from given SafeDataReader.
		''' </summary>
		Private Sub Fetch(ByVal dr As SafeDataReader)
			Me.RaiseListChangedEvents = False<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>
			IsReadOnly = False<% End If %>
			While dr.Read()
				Dim obj As <%= Info.ItemType %> = <%= Info.ItemType %>.Get<%= Info.ItemType %>(dr)
				Add(obj)
			End While<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>
			IsReadOnly = True<% End If %>
			Me.RaiseListChangedEvents = True
		End Sub
	<% Else %>
		''' <summary>
		''' Load all <see cref="<%=Info.ObjectName%>" /> collection items from given DataRow array.
		''' </summary>
		Private Sub Fetch(ByVal rows As DataRow())
			Me.RaiseListChangedEvents = False<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>
			IsReadOnly = False<% End If %>
			For Each row As DataRow In rows
				Dim obj As <%= Info.ItemType %> = <%= Info.ItemType %>.Get<%= Info.ItemType %>(row)
				Add(obj)
			Next<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>
			IsReadOnly = True<% End If %>
			Me.RaiseListChangedEvents = True
		End Sub
		<% If Info.HasGetCriteria Then %>
		''' <summary>
		''' Load all <see cref="<%=Info.ObjectName%>" /> collection items from given DataTable.
		''' </summary>
		Private Sub Fetch(ByVal rows As DataRowCollection)
			Me.RaiseListChangedEvents = False<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>
			IsReadOnly = False<% End If %>
			For Each row As DataRow In rows
				Dim obj As <%= Info.ItemType %> = <%= Info.ItemType %>.Get<%= Info.ItemType %>(row)
				Add(obj)
			Next<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>
			IsReadOnly = True<% End If %>
			Me.RaiseListChangedEvents = True
		End Sub
		<% End If %>
	<% End If %>
<%End If %>
	