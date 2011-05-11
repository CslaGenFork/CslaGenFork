<%
if (Info.Implements.Length > 0)
{
    Response.Write(new string(' ', 8));
    for (int i = 0; i < Info.Implements.Length; i++)
    {
        Response.Write(", ");
        Response.Write(Info.Implements[i]);
    }
    Response.Write(Environment.NewLine);
}
%>
