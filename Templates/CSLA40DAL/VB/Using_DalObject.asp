using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using <%= GetContextBaseNamespace(Info, CurrentUnit, GenerationStep.DalInterface) %>;
<%
string baseUsing = GetContextBaseNamespace(Info, CurrentUnit, GenerationStep.DalInterface);
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
