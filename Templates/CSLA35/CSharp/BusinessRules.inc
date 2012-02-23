		
		#region Business Object Rules and Validation
<%	bool hasRules = false;
	foreach (ValueProperty prop in Info.ValueProperties) { 
		if (prop.Rules.Count > 0) { 
			hasRules=true;
			break;
		}
	}
	if (hasRules) { %>
	
		private class <%=Info.ObjectName.Trim() %>Rules
		{
		
<%	foreach (ValueProperty prop in Info.ValueProperties) { 
		foreach (CslaGenerator.Metadata.Rule rule in prop.Rules) {
			if (rule.Mode == RuleMode.Generated) {
				List<String> argList = new List<String>();
				argList.Add("target." + FormatFieldName(prop.Name));
				foreach (DecoratorArgument arg in rule.DecoratorArgs)
					argList.Add(String.Format("(({1})e[\"{0}\"])",arg.Name,GetDataType(arg.ValueType)));
				string assertExpression = String.Empty;
				try
				{
					assertExpression=String.Format(rule.AssertExpression,argList.ToArray());
				}
				catch (FormatException ex)
				{
					Errors.AppendFormat("{0}: Rule \"{1}\" has an invalid format string. ", new string[] {prop.Name, rule.Name});
					Errors.AppendLine(ex.Message);
				}
				%>
			public static bool <%=rule.Name%>(<%=Info.ObjectName%> target, Csla.Validation.<%=rule.ArgumentType.ToString()%> e) 
			{
				bool result = (<%=assertExpression%>);
				if (!result)
				{
					e.Description = String.Format(<% 
						if (rule.DescriptionType == RuleDescriptionType.String) { 
							%>"<%=rule.Description%>"<% 
						} 
						else { 
							%><%=rule.Description%><% 
						}
						%>, "<%=prop.FriendlyName%>"<%
						foreach (DecoratorArgument arg in rule.DecoratorArgs) {
							%>, e["<%= arg.Name %>"].ToString()<%
						}
						%>);
					e.Severity = Csla.Validation.RuleSeverity.<%=rule.Severity.ToString()%>;
				}
				return result;
			}
			
<%		
			}
		}
	} %>
		} 

<%	string strEvent = "AddCustomBusinessRules"; %>
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
<%		foreach (ValueProperty prop in Info.ValueProperties) {	
			if (prop.Rules.Count > 0) { %>
			// Rules for "<%=prop.Name%>"
<%			foreach (CslaGenerator.Metadata.Rule rule in prop.Rules) { %>
			<%=rule.ArgumentType.ToString()%> <%=rule.Name%>Args = new <%=rule.ArgumentType.ToString()%>("<%=FormatPascal(prop.Name)%>");
			<% foreach (DecoratorArgument arg in rule.DecoratorArgs) { %>
			<%=rule.Name%>Args["<%=arg.Name%>"] = <%=arg.Value%>;
			<% } %>
			ValidationRules.AddRule<<% if (rule.Mode == RuleMode.Custom) { %>Object<% } else { %><%=Info.ObjectName%><% } %>, Csla.Validation.<%=rule.ArgumentType.ToString()%>>(
				<% if (rule.Mode == RuleMode.Generated) { %><%=Info.ObjectName.Trim()%>Rules.<% } %><%=rule.Name%>, 
				<%=rule.Name%>Args, <%=rule.Priority%>);
<%			}
		}
		
	} %>
			onAddCustomBusinessRules();
		}
	<% } %>
	
		#endregion
