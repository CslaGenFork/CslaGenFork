
	<% 
If Not Info.UseCustomLoading Then 
	For Each c As Criteria In Info.CriteriaObjects
	If c.GetOptions.DataPortal Then %>
	''' <summary>
	''' Load <see cref="<%=Info.ObjectName%>" /> collection from the database, based on given parameters.
	''' </summary>
	Protected Overloads Sub <% If Info.ObjectType = CslaObjectType.EditableChildCollection %>Child<% Else %>DataPortal<% End If %>_Fetch(ByVal crit As <%=c.Name%>)
		Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.<%= Info.DbName %>Connection, False)
			Using cmd As New SqlCommand("<%= c.GetOptions.ProcedureName %>", ctx.Connection)
				cmd.CommandType = CommandType.StoredProcedure
				<% For Each p As Metadata.Property In c.Properties %>
				cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%=GetParameterSet(p,true)%>)
				<% Next %>
				Dim args As New DataPortalHookArgs(cmd, crit)
				OnFetchPre(args)
				LoadCollection(cmd)
				OnFetchPost(args)
				<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>IsReadOnly = True<% End If %>
			End Using
		End Using
	End Sub
<%	End If
	Next %>

	<% If Info.HasGetCriteria Then %>
	<% If Not Info.DataSetLoadingScheme Then %>
	Private Sub LoadCollection(ByVal cmd As SqlCommand)
		Using dr As New SafeDataReader(cmd.ExecuteReader())
			Fetch(dr)
		End Using
	End Sub
	<% Else %>
	Private Sub LoadCollection(ByVal cmd As SqlCommand)
			Dim ds As New DataSet
			Using da As New SqlDataAdapter(cmd)
				da.Fill(ds)
			End Using
			CreateRelations(ds)
			Fetch(ds.Tables(0).Rows)
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
	