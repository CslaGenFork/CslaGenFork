
<%
    String[] clauses = GetGenericWhereClause(Info);
    if (Info.InheritedType.FinalName != string.Empty)
    {
        %><%= GetBaseClassDeclarationInheritedType(Info) %>
<%
        if (clauses.Length > 0)
        {
            %>
        <%= clauses[0] %>
<%
        }
        if (clauses.Length > 1)
        {
            %>
        <%= clauses[1] %>
<%
        }
    }
    else
    {
        %><%= GetBaseClassDeclaration(Info) %>
<%
        if (clauses.Length > 0)
        {
            %>
        <%= clauses[0] %>
<%
        }
        if (clauses.Length > 1)
        {
            %>
        <%= clauses[1] %>
<%
        }
    }
    %>
