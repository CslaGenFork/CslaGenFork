<% 
if (Info.Implements.Length > 0) {
	Response.Write(new string('\t', 2));
	for (int i = 0; i < Info.Implements.Length; i++) {
		Response.Write(", ");
		Response.Write(Info.Implements[i]);
	}
}
Response.Write("\r\n");
%>