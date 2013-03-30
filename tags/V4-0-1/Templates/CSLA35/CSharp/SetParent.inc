<%
string strRecreateParentReferences = string.Empty;
foreach (ChildProperty chdProp in Info.GetMyChildProperties())
{
	CslaObjectInfo chdInfo = FindChildInfo(Info, chdProp.TypeName);
	if (chdInfo != null && chdInfo.AddParentReference)
		strRecreateParentReferences += FormatFieldName(chdProp.Name) + ".SetParent(this);" + "\r\n";
	strRecreateParentReferences = strRecreateParentReferences.TrimEnd("\r\n".ToCharArray());
}
if (strRecreateParentReferences.Length > 0) {
%>
		#region Serialization
		
		protected override void OnDeserialized(System.Runtime.Serialization.StreamingContext context)
		{
			base.OnDeserialized(context);
			<%= strRecreateParentReferences %>
		}
		
		#endregion
<% } %>

