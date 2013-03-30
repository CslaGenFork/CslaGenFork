<% If Info.CriteriaObjects.Count > 0 Then %>

#Region " Criteria "
         	
      <% 
      For Each crit As Criteria In Info.CriteriaObjects 
		Dim strParams As String = String.Empty
		Dim strFieldAssignments As String = String.Empty
		'Temporary until Rocky provides a Fetch that can take no criteria
		'If crit.Properties.Count > 0 Then %>
      <Serializable()> _
      Protected Class <%=crit.Name%>
         <% 
		For Each prop As Metadata.Property In crit.Properties %>

			Private <%=FormatFieldName(prop.Name)%> As <%=GetDataType(prop)%>
			Public ReadOnly Property <%=FormatPascal(prop.Name)%>() As <%=GetDataType(prop)%>
				Get
					Return <%=FormatFieldName(prop.Name)%>
				End Get
			End Property
		
		<% 
		
		'Just creating strings for later use in the constructors in order to avoid another loop
		If strParams.Length > 0 Then
			strParams &= ", "
		End If
		strParams &= String.Concat("ByVal ", FormatCamel(prop.Name), " As ", GetDataType(prop))
		strFieldAssignments &= String.Concat(vbCrLf, New String(vbTab,4), FormatFieldName(prop.Name), " = ", FormatCamel(prop.Name))
		%>
         <% Next %>
			Public Sub New(<%= strParams %>)
				<% If strFieldAssignments.Length > 1 Then %>
<%=					strFieldAssignments.Substring(2) %>
				<% End If %>
			End Sub
		
		Public Overrides Function Equals(obj As Object) As Boolean
			If TypeOf obj Is <%=crit.Name%>
				Dim c As <%=crit.Name%> = DirectCast(obj, <%=crit.Name%>)
				<% For Each p As CriteriaProperty In crit.Properties %>
				If Not <%=FormatFieldName(p.Name)%>.Equals(c.<%=FormatFieldName(p.Name)%>) Then Return False
				<% Next %>
				Return True
			End If
			Return False
		End Function
		Public Overrides Function GetHashCode() As Integer
			Return String.Concat("<%=crit.Name%>"<% For Each p As CriteriaProperty In crit.Properties %>, <%=FormatFieldName(p.Name)%>.ToString()<% Next %>).GetHashCode()
		End Function
      End Class
      
      <% 
	' Else
	'	Errors.Append("	Criteria.inc: The criteria """ & crit.Name & """ has no properties")
	' End If
	 Next %>
#End Region
    
<% End If %>
