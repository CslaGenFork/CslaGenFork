Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Codisa.InterwayDocs.Rules

Namespace Codisa.InterwayDocs.Business.SearchObjects

    ''' <summary>
    ''' Search criteria that includes archive location (base class).<br/>
    ''' This is a generated base class of <see cref="SearchLocatableCriteriaBase"/> business object.
    ''' </summary>
    <Serializable>
    Public MustInherit Partial Class SearchLocatableCriteriaBase(Of T As {SearchLocatableCriteriaBase(Of T), IGenericCriteriaInformation, IHaveArchiveLocation})
        Inherits SearchCriteriaBase(Of T)
        Implements IGenericCriteriaInformation, IHaveArchiveLocation

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="ArchiveLocation"/> property.
        ''' </summary>
        Public Shared ReadOnly ArchiveLocationProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.ArchiveLocation, "Archive Location")
        ''' <summary>
        ''' Gets or sets the Archive Location.
        ''' </summary>
        ''' <value>The Archive Location.</value>
        Public Property ArchiveLocation As String
            Get
                Return GetProperty(ArchiveLocationProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(ArchiveLocationProperty, value)
            End Set
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SearchLocatableCriteriaBase"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Business Rules and Property Authorization "

        ''' <summary>
        ''' Override this method in your business class to be notified when you need to set up shared business rules.
        ''' </summary>
        ''' <remarks>
        ''' This method is automatically called by CSLA.NET when your object should associate
        ''' per-type validation rules with its properties.
        ''' </remarks>
        Protected Overrides Sub AddBusinessRules()
            MyBase.AddBusinessRules()

            ' Property Business Rules

            ' ArchiveLocation
            BusinessRules.AddRule(New CollapseWhiteSpace(ArchiveLocationProperty))

            AddBusinessRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom shared business rules.
        ''' </summary>
        Partial Private Sub AddBusinessRulesExtend()
        End Sub

        #End Region


    End Class
End Namespace
