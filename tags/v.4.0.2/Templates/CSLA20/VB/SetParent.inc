
<%
Dim strRecreateParentReferences as String = String.Empty
For each chdProp As ChildProperty In Info.GetMyChildProperties()
	Dim chdInfo as CslaObjectInfo = FindChildInfo(Info, chdProp.TypeName)
	If Not chdInfo Is Nothing AndAlso chdInfo.AddParentReference Then
		strRecreateParentReferences &= FormatFieldName(chdProp.Name) & ".SetParent(Me)" & vbCrLf
	End If
Next
If strRecreateParentReferences.Length > 0 Then
%>
#Region " Serialization "
	Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
		MyBase.OnDeserialized(context)
		<%= strRecreateParentReferences %>
     End Sub
#End Region
<% End If %>
