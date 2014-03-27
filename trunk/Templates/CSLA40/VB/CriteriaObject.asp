<%
if (Info.CriteriaObjects.Count > 0)
{
    bool isCriteriaObjectNeeded = IsCriteriaObjectNeeded(Info);

    if (isCriteriaObjectNeeded)
    {
        string getterCriteria = string.Empty;
        string setterCriteria = string.Empty;
        IndentLevel += 2;
        %>

    #Region " Criteria "
        <%
        foreach (Criteria crit in Info.CriteriaObjects)
        {
            string strParams = string.Empty;
            string strFieldAssignments = string.Empty;
            string strComment = string.Empty;
            if (crit.Properties.Count > 1)
            {
                    %>

    ''' <summary>
    ''' <%= crit.Summary  == string.Empty ? crit.Name + " criteria." : crit.Summary %>
    ''' </summary>
        <%
                if (crit.Remarks != string.Empty)
                {
                    %>
    ''' <remarks>
    ''' <%= crit.Remarks %>
    ''' </remarks>
        <%
                }
                %>
    <Serializable()>
    <%
                if (crit.CriteriaClassMode == CriteriaMode.Simple)
                {
                    %>
    Public Class <%= crit.Name %>
    <%
                }
                else
                {
                    %>
    Public <%= crit.CriteriaClassMode == CriteriaMode.BusinessBase ? "Partial " : "" %>Class <%= crit.Name %> 
        Inherits <%= crit.CriteriaClassMode != CriteriaMode.BusinessBase ? "CriteriaBase" : "BusinessBase" %>(Of <%= crit.Name %>)
    <%
                }
                %>
        <%
                if (Info.ObjectType == CslaObjectType.EditableSwitchable)
                {
                    strParams = "isChild As Boolean ";
                    strFieldAssignments = "  _isChild = isChild";
                    %>
        Private _isChild As Boolean

        Public ReadOnly Property IsChild As Boolean
            Get 
                Return _isChild
            End Get
        End Property
        <%
                }
                getterCriteria = "Get";
                setterCriteria = "Set";
                if (crit.CriteriaClassMode != CriteriaMode.BusinessBase)
                {
                    getterCriteria = "Read";
                    setterCriteria = "Load";
                }
                foreach (CriteriaProperty prop in crit.Properties)
                {
                    %>

            <%
                    if (crit.CriteriaClassMode != CriteriaMode.Simple)
                    {
                        string statement = PropertyInfoCriteriaDeclare(Info, prop);
                        %>
        ''' <summary>
        ''' Maintains metadata about <see cref="<%= FormatProperty(prop.Name) %>"/> property.
        ''' </summary>
<%= statement %>
<%
                    }
                    if (prop.Summary != string.Empty)
                    {
                        IndentLevel = 2;
                        %>
        ''' <summary>
<%= GetXmlCommentString(prop.Summary) %>
        ''' </summary>
        <%
                    }
                    else
                    {
                        %>
        ''' <summary>
        ''' Gets <%= (prop.ReadOnly ? "" : "or sets ") %>the <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.
        ''' </summary>
        <%
                    }
                    if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == false)
                    {
                        %>
        ''' <value><c>true</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>false</c>.</value>
        <%
                    }
                    else if (prop.PropertyType == TypeCodeEx.Boolean && prop.Nullable == true)
                    {
                        %>
        ''' <value><c>true</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; <c>false</c> if not <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>; otherwise, <c>null</c>.</value>
        <%
                    }
                    else
                    {
                        %>
        ''' <value>The <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) %>.</value>
        <%
                    }
                    if (prop.Remarks != string.Empty)
                    {
                        IndentLevel = 2;
                        %>
        ''' <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
        ''' </remarks>
        <%
                    }
                    // Just creating strings for later use in the constructors in order to avoid another loop
                    if (string.IsNullOrEmpty(prop.ParameterValue))
                    {
                        if (strParams.Length > 0)
                        {
                            strParams += ", ";
                        }
                        strParams += string.Concat(FormatCamel(prop.Name), " As ", GetDataTypeGeneric(prop, prop.PropertyType));
                        strFieldAssignments += string.Concat("\r\n            ", FormatProperty(prop.Name), " = ", FormatCamel(prop.Name));
                        strComment += "\r\n        ''' <param name=\"" + FormatCamel(prop.Name) + "\">The "+ FormatProperty(prop.Name) + ".</param>";
                    }
                    else
                    {
                        strFieldAssignments += string.Concat("\r\n            ", FormatProperty(prop.Name), " = ", prop.ParameterValue);
                    }
                    if (crit.CriteriaClassMode == CriteriaMode.Simple)
                    {
                        %>
        Public Property <%= FormatProperty(prop.Name) %> As <%= GetDataTypeGeneric(prop, prop.PropertyType) %>
        <%
                    }
                    else
                    {
                        %>
        Public Property <%= FormatProperty(prop.Name) %> As <%= GetDataTypeGeneric(prop, prop.PropertyType) %> 
            Get 
                Return <%= getterCriteria %>Property(<%= FormatProperty(prop.Name) %>Property)
            End Get
            <%= (prop.ReadOnly ? "Private " : "") %>Set (value As <%= GetDataTypeGeneric(prop, prop.PropertyType) %>)
                <%= setterCriteria %>Property(<%= FormatProperty(prop.Name) %>Property, value)
            End Set
        End Property
        <%
                    }
                }
                %>

        ''' <summary>
        ''' Initializes a new instance of the <see cref="<%= crit.Name %>"/> class.
        ''' </summary>
        ''' <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="<%= crit.Name %>"/> class.
        ''' </summary><%= strComment %>
        Public Sub New(<%= strParams %>)
            <%
                if (strFieldAssignments.Length > 1)
                {
                    %>
<%= strFieldAssignments.Substring(2) %>
                <%
                }
                %>
        End Sub

        ''' <summary>
        ''' Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        ''' </summary>
        ''' <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        ''' <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        Public Overrides Function Equals(obj As Object) As Boolean
            If GetType(obj) Is <%= crit.Name %> Then
                Dim c = DirectCast(obj, <%= crit.Name %>)
                <%
                foreach (CriteriaProperty p in crit.Properties)
                {
                    %>
                If Not <%= FormatProperty(p.Name) %>.Equals(c.<%= FormatProperty(p.Name) %>) Then
                    Return False
                End If
                <%
                }
                %>
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        ''' Returns a hash code for this instance.
        ''' </summary>
        ''' <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        Public Overrides Function GetHashCode() As Integer
            Return String.Concat("<%= crit.Name %>"<% foreach (CriteriaProperty p in crit.Properties) { %>, <%= FormatProperty(p.Name) %>.ToString()<% } %>).GetHashCode()
        End Function
    End Class
    <%
            }
        }
        %>

    #End Region

<%
        IndentLevel -=2;
    }
}
%>
