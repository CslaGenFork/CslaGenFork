<%
List<UnitOfWorkCriteriaManager.UoWCriteria> listUoWCriteriaCurrent = null;
if (Info.IsCreator || Info.IsCreatorGetter)
    listUoWCriteriaCurrent = UnitOfWorkCriteriaManager.CriteriaOutputForm(Info, UnitOfWorkFunction.Creator, true);
else if (Info.IsGetter)
    listUoWCriteriaCurrent = UnitOfWorkCriteriaManager.CriteriaOutputForm(Info, UnitOfWorkFunction.Getter, true);
else if (Info.IsDeleter)
    listUoWCriteriaCurrent = listUoWCriteriaDeleter;

int activeCriteria = 0;
foreach (UnitOfWorkCriteriaManager.UoWCriteria uowCrit in listUoWCriteriaCurrent)
{
    if (!string.IsNullOrEmpty(uowCrit.CriteriaName))
        activeCriteria ++;
}

if (activeCriteria > 0)
{
    CriteriaMode critCriteriaClassMode = CriteriaMode.CriteriaBase;
    string getterCriteria = string.Empty;
    string setterCriteria = string.Empty;
    genOptional = true;
    IndentLevel += 3;
    %>

        #Region " Criteria "
        <%
    foreach (UnitOfWorkCriteriaManager.UoWCriteria uowCrit in listUoWCriteriaCurrent)
    {
        string strParams = string.Empty;
        string strFieldAssignments = string.Empty;
        string strComment = string.Empty;
        %>

        ''' <summary>
        ''' <%= uowCrit.CriteriaName + " criteria." %>
        ''' </summary>
        <Serializable>
        <%
        if (UseBoth())
        {
            %>
#If SILVERLIGHT Then
        <%
        }
        if (UseSilverlight())
        {
            %>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        <%
            if (critCriteriaClassMode == CriteriaMode.Simple)
            {
                %>
        Public Class <%= uowCrit.CriteriaName %>
        <%
            }
            else
            {
                %>
        Public <%= critCriteriaClassMode == CriteriaMode.BusinessBase ? "Partial " : "" %>Class <%= uowCrit.CriteriaName %>
            Inherits <%= critCriteriaClassMode != CriteriaMode.BusinessBase ? "CriteriaBase" : "BusinessBase" %>(Of <%= uowCrit.CriteriaName %>)
        <%
            }
        }
        if (UseBoth())
        {
            %>
#Else
        <%
        }
        if (UseNoSilverlight())
        {
            if (critCriteriaClassMode == CriteriaMode.Simple)
            {
                %>
        Protected Class <%= uowCrit.CriteriaName %>
        <%
            }
            else
            {
                %>
        Protected <%= critCriteriaClassMode == CriteriaMode.BusinessBase ? "Partial " : "" %>Class <%= uowCrit.CriteriaName %>
            Inherits <%= critCriteriaClassMode != CriteriaMode.BusinessBase ? "CriteriaBase" : "BusinessBase" %>(Of <%= uowCrit.CriteriaName %>)
        <%
            }
        }
        if (UseBoth())
        {
            %>
#End If
        <%
        }
        %>
            <%
        getterCriteria = "Get";
        setterCriteria = "Set";
        if (critCriteriaClassMode != CriteriaMode.BusinessBase)
        {
            getterCriteria = "Read";
            setterCriteria = "Load";
        }
        foreach (UnitOfWorkCriteriaManager.ElementCriteria crit in uowCrit.ElementCriteriaList)
        {
            if (crit.Name == string.Empty)
                continue;
            %>

            <%
            if (critCriteriaClassMode != CriteriaMode.Simple)
            {
                string statement = PropertyInfoUoWCriteriaDeclare(Info, crit);
                %>
            ''' <summary>
            ''' Maintains metadata about <see cref="<%= FormatProperty(crit.Name) %>"/> property.
            ''' </summary>
    <%= statement %>
            <%
            }
            %>
            ''' <summary>
            ''' Gets or sets the <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(crit.Name) %>.
            ''' </summary>
            <%
            if (crit.Type == "bool")
            {
                %>
            ''' <value><c>True</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(crit.Name) %>; otherwise, <c>false</c>.</value>
            <%
            }
            else if (crit.Type == "bool?")
            {
                %>
            ''' <value><c>True</c> if <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(crit.Name) %>; <c>false</c> if not <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(crit.Name) %>; otherwise, <c>null</c>.</value>
            <%
            }
            else
            {
                %>
            ''' <value>The <%= CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(crit.Name) %>.</value>
            <%
            }
            // Just creating strings for later use in the constructors in order to avoid another loop
            if (strParams.Length > 0)
            {
                strParams += ", ";
            }
            strParams += string.Concat("p_", FormatCamel(crit.Name), " As ", crit.Type);
            strFieldAssignments += string.Concat("\r\n                ", FormatProperty(crit.Name), " = p_", FormatCamel(crit.Name));
            strComment += "\r\n            ''' <param name=\"p_" + FormatCamel(crit.Name) + "\">The "+ FormatProperty(crit.Name) + ".</param>";
            if (critCriteriaClassMode == CriteriaMode.Simple)
            {
                %>
            Public Property <%= FormatProperty(crit.Name) %> As <%= crit.Type %>
            <%
            }
            else
            {
                %>
            Public Property <%= FormatProperty(crit.Name) %> As <%= crit.Type %>
                Get
                    Return <%= getterCriteria %>Property(<%= FormatProperty(crit.Name) %>Property)
                End Get
                Set
                    <%= setterCriteria %>Property(<%= FormatProperty(crit.Name) %>Property, value)
                End Set
            End Property
            <%
            }
        }
        %>

            ''' <summary>
            ''' Initializes a new instance of the <see cref="<%= uowCrit.CriteriaName %>"/> class.
            ''' </summary>
            ''' <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
            Public Sub New()
            End Sub

            ''' <summary>
            ''' Initializes a new instance of the <see cref="<%= uowCrit.CriteriaName %>"/> class.
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
            ''' <returns><c>True</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            Public Overrides Function Equals(obj As object) As Boolean
                If TypeOf obj Is <%= uowCrit.CriteriaName %> Then
                    Dim c As <%= uowCrit.CriteriaName %> = obj
                    <%
        foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList)
        {
            if (c.Name == string.Empty)
                continue;

            %>
                    If Not <%= FormatProperty(c.Name) %>.Equals(c.<%= FormatProperty(c.Name) %>) Then
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
                Return String.Concat("<%= uowCrit.CriteriaName %>"<% foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList) { if (c.Name == string.Empty) continue; %>, <%= FormatProperty(c.Name) %>.ToString()<% } %>).GetHashCode()
            End Function
        End Class
        <%
    }
    %>

        #End Region
<%
    IndentLevel -=3;
}
%>
