
        #region Business Object Rules and Validation
<%    bool hasRules = false;
    foreach (ValueProperty prop in Info.ValueProperties) {
        if (prop.Rules.Count > 0) {
            hasRules=true;
            break;
        }
    }
    if (hasRules) { %>

        private class <%=Info.ObjectName.Trim() %>Rules
        {

<%    foreach (ValueProperty prop in Info.ValueProperties) {
        foreach (CslaGenerator.Metadata.Rule rule in prop.Rules) { %>
            public static bool <%=rule.Name%>(<%=Info.ObjectName%> target, Csla.Validation.RuleArgs e)
            {
                e.Description = "<%=rule.Description%>";
                e.Severity = Csla.Validation.RuleSeverity.<%=rule.Severity.ToString()%>;
                return <%=rule.AssertExpression%>;
            }

<%        }
    } %>
        }

<%    string strEvent = "AddCustomBusinessRules"; %>
        protected delegate void AddBusinessRulesDelegate();

        [NonSerialized()]
        [NotUndoable()]
        private AddBusinessRulesDelegate <%= FormatDelegateName(strEvent) %>;
        protected event AddBusinessRulesDelegate <%= FormatPascal(strEvent) %>
        {
            add
            {
                <%= FormatDelegateName(strEvent) %> = (AddBusinessRulesDelegate)Delegate.Combine(<%= FormatDelegateName(strEvent) %>, value);
            }
            remove
            {
                <%= FormatDelegateName(strEvent) %> = (AddBusinessRulesDelegate)Delegate.Remove(<%= FormatDelegateName(strEvent) %>, value);
            }
        }
        private void on<%= FormatPascal(strEvent) %>()
        {
            if (<%= FormatDelegateName(strEvent) %> != null)
                <%= FormatDelegateName(strEvent) %>();
        }

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
<%        foreach (ValueProperty prop in Info.ValueProperties) {
            if (prop.Rules.Count > 0) { %>
            // Rules for "<%=prop.Name%>"
<%            foreach (CslaGenerator.Metadata.Rule rule in prop.Rules) { %>
            ValidationRules.AddRule<<%=Info.ObjectName%>, Csla.Validation.RuleArgs>(
                <%=Info.ObjectName.Trim()%>Rules.<%=rule.Name%>,
                new Csla.Validation.RuleArgs("<%=FormatPascal(prop.Name)%>"), <%=rule.Priority%>);
<%            }
        }
    } %>
            onAddCustomBusinessRules();
        }
    <% } %>

        #endregion
