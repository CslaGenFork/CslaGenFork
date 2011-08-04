<%
if (Info.Implements.Length > 0)
{
    //Response.Write(new string(' ', 8));
    for (int i = 0; i < Info.Implements.Length; i++)
    {
        Response.Write(", ");
        if (Info.Implements[i].Contains("<T>"))
            Response.Write(Info.Implements[i].Replace("<T>", "<" + Info.ObjectName + ">"));
        else
            Response.Write(Info.Implements[i]);
    }
    //Response.Write(Environment.NewLine);
}
%>
