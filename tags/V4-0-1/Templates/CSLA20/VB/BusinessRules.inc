		
#Region " Business Object Rules and Validation "

			<%
      Dim hasRules As Boolean = False
      For Each prop As ValueProperty In Info.ValueProperties 
		If prop.Rules.Count > 0 Then 
			hasRules = True
			Exit For
		End If
	 Next
	If hasRules Then %>
	Private Class <%=Info.ObjectName.Trim() %>Rules
	
	<%
	For Each prop As ValueProperty In Info.ValueProperties 
		For Each rule As CslaGenerator.Metadata.Rule In prop.Rules
			If rule.Mode = RuleMode.Generated Then 
				Dim argList As New List(Of String)
				argList.Add("target." & FormatFieldName(prop.Name))
				For Each arg As DecoratorArgument In rule.DecoratorArgs
					argList.Add(String.Format("DirectCast(e(""{0}""),{1})",arg.Name,GetDataType(arg.ValueType)))
				Next
				Dim assertExpression As String=String.Empty
				Try
					assertExpression=String.Format(rule.AssertExpression,argList.ToArray())
				Catch ex as FormatException
					Errors.AppendFormat("{0}: Rule ""{1}"" has an invalid format string. ",prop.Name, rule.Name)
					Errors.AppendLine(ex.Message)
				End Try%>
		Public Shared Function <%=rule.Name%>(ByVal target As <%=Info.ObjectName %>, ByVal e As Csla.Validation.<%=rule.ArgumentType.ToString()%>) As Boolean
			Dim result As Boolean = <%=assertExpression%>
			If result = False Then
				e.Description = String.Format(<% 
					If rule.DescriptionType = RuleDescriptionType.String Then 
					%>"<%=rule.Description%>"<% 
					Else 
					%><%=rule.Description%><% 
					End If 
					%>, "<%=prop.FriendlyName%>"<%
					For Each arg As DecoratorArgument In rule.DecoratorArgs
						%>, e("<%= arg.Name %>").ToString()<%
					Next
					%>)
				e.Severity = Csla.Validation.RuleSeverity.<%=rule.Severity.ToString()%>
			End If
			Return result 
		End Function
		<% 	End If
		Next 
	Next %>
	End Class
	
    Public Delegate Sub AddBusinessRulesDelegate()
	<NonSerialized(), NotUndoable()> _
    Private <%= FormatDelegateName("AddCustomBusinessRules") %> As AddBusinessRulesDelegate
    Protected Custom Event <%= FormatPascal("AddCustomBusinessRules") %> As AddBusinessRulesDelegate
        AddHandler(ByVal value As AddBusinessRulesDelegate)
            <%= FormatDelegateName("AddCustomBusinessRules") %> = CType([Delegate].Combine(<%= FormatDelegateName("AddCustomBusinessRules") %>, value), AddBusinessRulesDelegate)
        End AddHandler

        RemoveHandler(ByVal value As AddBusinessRulesDelegate)
            <%= FormatDelegateName("AddCustomBusinessRules") %> = CType([Delegate].Remove(<%= FormatDelegateName("AddCustomBusinessRules") %>, value), AddBusinessRulesDelegate)
        End RemoveHandler

        RaiseEvent()
            If <%= FormatDelegateName("AddCustomBusinessRules") %> IsNot Nothing Then <%= FormatDelegateName("AddCustomBusinessRules") %>()
        End RaiseEvent
    End Event
   Protected Overrides Sub AddBusinessRules()
	 MyBase.AddBusinessRules()
	<% For Each prop As ValueProperty In Info.ValueProperties 
	    If prop.Rules.Count > 0 Then %>
		'Rules for "<%=prop.Name%>"
		<% For Each rule As CslaGenerator.Metadata.Rule In prop.Rules %>
			Dim <%=rule.Name%>Args As New <%=rule.ArgumentType.ToString()%>("<%=FormatPascal(prop.Name)%>")
			<% If rule.ArgumentType = ArgumentType.DecoratedRuleArgs Then
				For Each arg As DecoratorArgument In rule.DecoratorArgs %>
			<%=rule.Name%>Args("<%=arg.Name%>") = <%=arg.Value%>
			<%	Next
			End If %>
		ValidationRules.AddRule(Of <% If rule.Mode = RuleMode.Custom Then %>Object<% Else %><%=Info.ObjectName %><% End If %>, <%=rule.ArgumentType.ToString()%>)( _
			AddressOf <% If rule.Mode = RuleMode.Generated Then %><%=Info.ObjectName.Trim() %>Rules.<% End If %><%=rule.Name%>, _
			<%=rule.Name%>Args, <%=rule.Priority%>)
		<% Next %>
	<%  End If
	   Next %>
	   RaiseEvent AddCustomBusinessRules()
   End Sub
   
   
	<% End If %>	
#End Region
