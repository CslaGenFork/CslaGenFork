		<% Dim childInfo2 As CslaObjectInfo = FindChildInfo(Info, Info.ItemType) %>		
#Region " Business Properties and Methods "

<% 
For Each c As Criteria In childInfo2.CriteriaObjects 
	If c.CreateOptions.Factory Then %>
		''' <summary>
		''' Add new <see cref="<%=Info.ItemType%>"/> object to the <%=Info.ObjectName%> collection.
		''' </summary>
		<% 	Dim params as string = String.Empty
			Dim factoryParams as String = String.Empty
		For Each param As Metadata.Property In c.Properties
			params &= String.Concat(", ByVal ", FormatCamel(param.Name), " As ", GetDataType(param))
			factoryParams &= String.Concat(", ", FormatCamel(param.Name))
		Next	
		If factoryParams.Length > 1 Then			
			factoryParams = factoryParams.Substring(2)
			params = params.Substring(2) 
		End If %>
		Public Overloads Sub Add(<%=params %>)
		<%	
		Dim newMethodName As String = "New" & Info.ItemType
		If childInfo2.ObjectType = CslaObjectType.EditableSwitchable Then
			newMethodName &= "Child"
		End If
		%>
    
			Dim o<%=FormatCamel(Info.ItemType)%> As <%=Info.ItemType%> = <%=Info.ItemType%>.<%=newMethodName%><%=c.CreateOptions.FactorySuffix.Trim()%>(<%=factoryParams%>) 
			Add(o<%=FormatCamel(Info.ItemType)%>)
			
		End Sub
<%	End If 
Next %>

#End Region
