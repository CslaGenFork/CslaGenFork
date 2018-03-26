Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Codisa.InterwayDocs.Business.Properties
Imports Codisa.InterwayDocs.Rules

Namespace Codisa.InterwayDocs.Business.SearchObjects

    ''' <summary>
    ''' Common search criteria (base class).<br/>
    ''' This is a generated base class of <see cref="SearchCriteriaBase"/> business object.
    ''' </summary>
    <Serializable>
    Public MustInherit Partial Class SearchCriteriaBase(Of T As {SearchCriteriaBase(Of T), IGenericCriteriaInformation})
        Inherits BusinessBase(Of T)
        Implements IGenericCriteriaInformation

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="StartDate"/> property.
        ''' </summary>
        Public Shared ReadOnly StartDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.StartDate, "Start Date")
        ''' <summary>
        ''' Gets or sets the Start Date.
        ''' </summary>
        ''' <value>The Start Date.</value>
        Public Property StartDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(StartDateProperty)
            End Get
            Set(ByVal value As String)
                SetPropertyConvert(Of SmartDate, String)(StartDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="EndDate"/> property.
        ''' </summary>
        Public Shared ReadOnly EndDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.EndDate, "End Date")
        ''' <summary>
        ''' Gets or sets the End Date.
        ''' </summary>
        ''' <value>The End Date.</value>
        Public Property EndDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(EndDateProperty)
            End Get
            Set(ByVal value As String)
                SetPropertyConvert(Of SmartDate, String)(EndDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="FullText"/> property.
        ''' </summary>
        Public Shared ReadOnly FullTextProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.FullText, "Full Text")
        ''' <summary>
        ''' Gets or sets the Full Text.
        ''' </summary>
        ''' <value>The Full Text.</value>
        Public Property FullText As String
            Get
                Return GetProperty(FullTextProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(FullTextProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DateTypeList"/> property.
        ''' </summary>
        Public Shared ReadOnly DateTypeListProperty As PropertyInfo(Of CriteriaDateTypeList) = RegisterProperty(Of CriteriaDateTypeList)(Function(p) p.DateTypeList, "Date Type List")
        ''' <summary>
        ''' Gets or sets the Date Type List.
        ''' </summary>
        ''' <value>The Date Type List.</value>
        Public Property DateTypeList As CriteriaDateTypeList
            Get
                Return GetProperty(DateTypeListProperty)
            End Get
            Set(ByVal value As CriteriaDateTypeList)
                SetProperty(DateTypeListProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="SelectedDateTypeIndex"/> property.
        ''' </summary>
        Public Shared ReadOnly SelectedDateTypeIndexProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.SelectedDateTypeIndex, "Selected Date Type Index")
        ''' <summary>
        ''' Gets or sets the Selected Date Type Index.
        ''' </summary>
        ''' <value>The Selected Date Type Index.</value>
        Public Property SelectedDateTypeIndex As Integer
            Get
                Return GetProperty(SelectedDateTypeIndexProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(SelectedDateTypeIndexProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="SelectedFastDateIndex"/> property.
        ''' </summary>
        Public Shared ReadOnly SelectedFastDateIndexProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.SelectedFastDateIndex, "Selected Fast Date Index", -1)
        ''' <summary>
        ''' Gets or sets the Selected Fast Date Index.
        ''' </summary>
        ''' <value>The Selected Fast Date Index.</value>
        Public Property SelectedFastDateIndex As Integer
            Get
                Return GetProperty(SelectedFastDateIndexProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(SelectedFastDateIndexProperty, value)
            End Set
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SearchCriteriaBase"/> class.
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

            ' StartDate
            BusinessRules.AddRule(New DateNotInFuture(StartDateProperty) With { .MessageDelegate = () => Resources.DateNotInFuture })
            ' EndDate
            BusinessRules.AddRule(New DateNotInFuture(EndDateProperty) With { .MessageDelegate = () => Resources.DateNotInFuture })
            BusinessRules.AddRule(New GreaterThanOrEqual(EndDateProperty, StartDateProperty) With { .MessageDelegate = () => Resources.EndDateGreaterThanOrEqualStartDate, .Priority = 1 })
            ' FullText
            BusinessRules.AddRule(New CollapseWhiteSpace(FullTextProperty))
            BusinessRules.AddRule(New ThreePartsFullText(FullTextProperty) With { .MessageDelegate = () => Resources.ThreePartsFullText, .Priority = 1 })
            ' SelectedFastDateIndex
            BusinessRules.AddRule(New FastDateToDateRange(SelectedFastDateIndexProperty))

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
