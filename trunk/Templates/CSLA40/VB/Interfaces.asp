<%
if (Info.Interfaces.Length > 0)
{
    //Response.Write(new string(' ', 8));
    for (int i = 0; i < Info.Interfaces.Length; i++)
    {
        Response.Write(i == 0 ? Environment.NewLine + "        Implements " : ", ");
        if (Info.Interfaces[i].Contains("<T>"))
            Response.Write(Info.Interfaces[i].Replace("<T>", "(Of " + Info.ObjectName + ")"));
        else
            Response.Write(Info.Interfaces[i]);
    }
    Response.Write(Environment.NewLine);
}
%>
