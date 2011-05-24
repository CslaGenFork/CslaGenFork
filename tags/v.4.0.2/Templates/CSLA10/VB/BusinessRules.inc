		
#Region " Business Object Rules and Validation "
		<% If ActiveObjects Then %>
		'The publishevent method must be overwritten in the class that inherits from this one
		Protected Overridable Sub PublishEvent(ByVal EventName as String, Value as Object)
		End Sub
    
		<% End If %>	

			<% For Each prop As ValueProperty In Info.ValueProperties 
			    If prop.Rules.Count > 0 Then %>
				
			<%	For Each rule As CslaGenerator.Metadata.Rule In prop.Rules %>
		Protected Overridable Function <%=rule.Name%>(ByVal target As Object, ByVal e As CSLA.BrokenRules.RuleArgs) As Boolean
			e.Description = "<%=rule.Description%>"
			Return Not <%=rule.AssertExpression%> 
		End Function
			<%	Next %>

			<%  End If
			   Next %>
			   

		
   Protected Overrides Sub AddBusinessRules()
	 MyBase.AddBusinessRules()
      With BrokenRules
         .SetTargetObject(Me)
	<% For Each prop As ValueProperty In Info.ValueProperties 
	    If prop.Rules.Count > 0 Then %>
		'Rules for "<%=prop.Name%>"
		<%	For Each rule As CslaGenerator.Metadata.Rule In prop.Rules %>
		.AddRule(AddressOf <%=rule.Name%>, "<%=prop.Name%>", "<%=prop.Name%>")
		<%	Next %>
	<%  End If
	   Next %>
      End With
   End Sub
		
#End Region
