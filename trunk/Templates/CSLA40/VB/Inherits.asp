<%
string result = string.Empty;
if (Info.InheritedType.Type != string.Empty)
{
    result = Info.InheritedType.Type;
}
else if (Info.InheritedType.ObjectName != string.Empty)
{
    result = Info.InheritedType.ObjectName;
}

if (result.Contains("<T>") && useItem)
    result = result.Replace("<T>", "(Of " + Info.ItemType + ")");
else
    result = result.Replace("<T>", "(Of " + Info.ObjectName + ")");

if (result.Contains("<T,C>"))
    result = result.Replace("<T,C>", "(Of " + Info.ObjectName + ", " + Info.ItemType + ")");
Response.Write(result);
%><!-- #include file="Implements.asp" -->
