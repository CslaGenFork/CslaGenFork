<%
string resultWF = string.Empty;
if (Info.InheritedTypeWinForms.Type != string.Empty)
{
    resultWF = Info.InheritedTypeWinForms.Type;
}
else if (Info.InheritedTypeWinForms.ObjectName != string.Empty)
{
    resultWF = Info.InheritedTypeWinForms.ObjectName;
}

if (resultWF.Contains("<T>") && useItem)
    resultWF = resultWF.Replace("<T>", "(Of " + Info.ItemType + ")");
else
    resultWF = resultWF.Replace("<T>", "(Of " + Info.ObjectName + ")");

if (resultWF.Contains("<T,C>"))
    resultWF = resultWF.Replace("<T,C>", "(Of " + Info.ObjectName + ", " + Info.ItemType + ")");
Response.Write(resultWF);
%><!-- #include file="Implements.asp" -->
