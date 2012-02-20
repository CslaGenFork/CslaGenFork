<% If Not Info.UseCustomLoading Then %>
	<% If Not Info.DataSetLoadingScheme Then %>
		''' <summary>
		''' Factory method. New <see cref="<%=Info.ObjectName%>" /> object is created and loaded from the given SafeDataReader.
		''' </summary>
		Friend Shared Function Get<%=Info.ObjectName%>(ByVal dr As SafeDataReader) As <%=Info.ObjectName%> 
			<% If Info.GetRoles.Trim() <> String.Empty Then %>
			If Not CanGetObject() Then
				Throw New System.Security.SecurityException( _
					"User not authorized to load a <%= Info.ObjectName %>")
			End If
			<% End If %>
			Dim obj As New <%=Info.ObjectName%><% If Info.ObjectType = CslaObjectType.EditableSwitchable Then %>
			obj.MarkAsChild()<% End If %>
			obj.Fetch(dr)
			<% If LoadsChildren(Info) Then %>		
			obj.FetchChildren(dr)
			<% End If %>
      <% If Info.ObjectType <> CslaObjectType.ReadOnlyObject And Not IsCollectionType(Info.ObjectType) Then %>
			obj.MarkOld()
			obj.ValidationRules.CheckRules()
			<% End If %>
			<% If ActiveObjects Then %>
			obj.RegisterAndSubscribe()
			<% 	End If %>
			Return obj
		End Function
	<% Else %>
		''' <summary>
		''' Factory method. New <see cref="<%=Info.ObjectName%>" /> object is created and loaded from the given SafeDataReader.
		''' </summary>
		Friend Shared Function Get<%=Info.ObjectName%>(ByVal dr As DataRow<% If IsCollectionType(Info.ObjectType) Then %>()<%End If%>) As <%=Info.ObjectName%> 
			<% If Info.GetRoles.Trim() <> String.Empty Then %>
			If Not CanGetObject() Then
				Throw New System.Security.SecurityException( _
					"User not authorized to load a <%= Info.ObjectName %>")
			End If
			<% End If %>
			Dim obj As New <%=Info.ObjectName%><% If Info.ObjectType = CslaObjectType.EditableSwitchable Then %>
			obj.MarkAsChild()<% End If %>
			obj.Fetch(dr)
      <% If LoadsChildren(Info) And Not IsCollectionType(Info.ObjectType) Then %>
			obj.FetchChildren(dr)
			<% End If %><% If Info.ObjectType <> CslaObjectType.ReadOnlyObject And Not IsCollectionType(Info.ObjectType) Then %>
			obj.MarkOld()
			obj.ValidationRules.CheckRules()
			<% End If %>
			<% If ActiveObjects Then %>
			obj.RegisterAndSubscribe()
			<% 	End If %>
			Return obj
		End Function
	<% End If %>
<% End If %>
