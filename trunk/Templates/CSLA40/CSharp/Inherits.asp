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
    result = result.Replace("<T>", "<" + Info.ItemType + ">");
else
    result = result.Replace("<T>", "<" + Info.ObjectName + ">");

if (result.Contains("<T,C>"))
    result = result.Replace("<T,C>", "<" + Info.ObjectName + ", " + Info.ItemType + ">");

if (result.Contains("<K,V>"))
    result = result.Replace("<K,V>", "<" + Info.ValueColumn + ", " + Info.NameColumn + ">");

    Response.Write(result);
%><!-- #include file="Implements.asp" -->
