<%
if (useParentReference || isRODeepLoadCollection)
{
    string statement = PropertyInfoParentListDeclare(Info);
    %>
        #Region " ParentList Property "

        ''' <summary>
        ''' Maintains metadata about <see cref="ParentList"/> property.
        ''' </summary>
        <NotUndoable, NonSerialized>
        <%
        if (!string.IsNullOrEmpty(statement))
        {
            %>
<%= statement %>
        <%
        }
        %>
        ''' <summary>
        ''' Provide access to the parent list reference for use in child object code.
        ''' </summary>
        ''' <value>The parent list reference.</value>
        Public Property ParentList As <%= Info.ParentType %>
            Get
                Return ReadProperty(ParentListProperty)
            End Get
            Friend Set(value As <%= Info.ParentType %>)
                LoadProperty(ParentListProperty, value)
            End Set
        End Property

        #End Region

<%
}
%>
