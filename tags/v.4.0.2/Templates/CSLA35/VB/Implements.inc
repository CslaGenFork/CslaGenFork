<% 
If Info.Implements.Length > 0 Then
	Response.Write(New String(vbTab, 2))
	Response.Write("Implements ")
	For i As Integer = 0 To Info.Implements.Length - 1
		If i>0 Then
			Response.Write(", ")
		End If
		Response.Write(Info.Implements(i))
	Next 
End If 
Response.Write(Environment.NewLine)
%>
