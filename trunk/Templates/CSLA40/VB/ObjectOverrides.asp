<%
if (Info.ToStringProperty != null && Info.ToStringProperty.Count > 0 &&
    Info.IsNotReadOnlyObject())
{
    %>

        #Region " BusinessBase(Of T) Overrides "

        ''' <summary>
        ''' Returns a string that represents the current <see cref="<%= Info.ObjectName %>"/>
        ''' </summary>
        ''' <returns>A <see cref="System.String"/> that represents this instance.</returns>
        Public Overrides Function ToString() As String
            ' Return the Primary Key as a string
            Return <%
            bool firstLine = true;
            foreach (Property prop in Info.ToStringProperty)
            {
                if (!firstLine)
                {
                    %> + ", " + <%
                }
                else
                {
                    firstLine = false;
                }
                %><%= FormatProperty(prop.Name) %>.ToString()<%
             }%>
        End Function

        #End Region
<%
}
%>
