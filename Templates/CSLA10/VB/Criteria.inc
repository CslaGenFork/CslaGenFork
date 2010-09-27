      
#Region " Criteria "

      <% For Each crit As Criteria In Info.CriteriaObjects %>
      <Serializable()> _
      Protected Class <%=crit.Name%> : Inherits CSLA.CriteriaBase
         <% For Each prop As Metadata.Property In crit.Properties %>
         Public <%=FormatPascal(prop.Name)%> As <%=prop.PropertyType.ToString()%>
         <% Next %>
         
         Public Sub New()
            MyBase.New(GetType(<%=Info.ObjectName%>))
         End Sub
      
      End Class
      
      <% Next %>
#End Region
