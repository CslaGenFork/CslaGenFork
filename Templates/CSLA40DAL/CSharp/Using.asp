using System;
<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, false, true) %>using System.Data;<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, false) %>
using Csla;
<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, false, true) %>using Csla.Data;<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, false) %>
<%= GetUsingStatementsString(Info, CurrentUnit) %>
