Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Rules
Imports Csla.Rules.CommonRules
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' Document type basic information (read only object).<br/>
    ''' This is a generated base class of <see cref="DocTypeInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="DocTypeList"/> collection.
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable()>
    Partial Public Class DocTypeInfo
    Inherits ReadOnlyBase(Of DocTypeInfo)
        Implements IHaveInterface

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="DocTypeID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocTypeIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocTypeID, "Doc Type ID", -1)
        ''' <summary>
        ''' Gets the Doc Type ID.
        ''' </summary>
        ''' <value>The Doc Type ID.</value>
        Public ReadOnly Property DocTypeID As Integer
            Get
                Return GetProperty(DocTypeIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocTypeName"/> property.
        ''' </summary>
        Public Shared ReadOnly DocTypeNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocTypeName, "Doc Type Name")
        ''' <summary>
        ''' Gets the Doc Type Name.
        ''' </summary>
        ''' <value>The Doc Type Name.</value>
        Public ReadOnly Property DocTypeName As String
            Get
                Return GetProperty(DocTypeNameProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="IsActive"/> property.
        ''' </summary>
        Public Shared ReadOnly IsActiveProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.IsActive, "IsActive")
        ''' <summary>
        ''' Gets the active or deleted state.
        ''' </summary>
        ''' <value><c>True</c> if IsActive; otherwise, <c>false</c>.</value>
        Public ReadOnly Property IsActive As Boolean
            Get
                Return GetProperty(IsActiveProperty)
            End Get
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocTypeInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(DocTypeInfo), New IsInRole(AuthorizationActions.GetObject, "User"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can retrieve DocTypeInfo's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(DocTypeInfo))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocTypeInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"))
            LoadProperty(DocTypeNameProperty, dr.GetString("DocTypeName"))
            LoadProperty(IsActiveProperty, dr.GetBoolean("IsActive"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after the low level fetch operation, before the data reader is destroyed.
        ''' </summary>
        Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class
End Namespace
