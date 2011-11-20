using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using <%= GetContextObjectNamespace(Info, CurrentUnit, GenerationStep.DalInterface) %>;
<%
string baseUsing = GetContextObjectNamespace(Info, CurrentUnit, GenerationStep.DalInterface);
string utilUsing = GetContextUtilitiesNamespace(CurrentUnit, GenerationStep.DalInterface);
string objectUsing = GetContextObjectNamespace(Info, CurrentUnit, GenerationStep.DalInterface);
if (utilUsing != baseUsing && utilUsing != objectUsing)
{
    %>
using <%= utilUsing %>;
<%
}
Response.WriteLine();
%>
