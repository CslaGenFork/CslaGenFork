Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' CustomerInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="CustomerInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="CustomerList"/> collection.
    ''' </remarks>
    <Serializable()>
    Partial Public Class CustomerInfo
    Inherits ReadOnlyBase(Of CustomerInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="CustomerId"/> property.
        ''' </summary>
        Public Shared ReadOnly CustomerIdProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.CustomerId, "Customer Id")
        ''' <summary>
        ''' Gets the Customer Id.
        ''' </summary>
        ''' <value>The Customer Id.</value>
        Public ReadOnly Property CustomerId As String
            Get
                Return GetProperty(CustomerIdProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Name"/> property.
        ''' </summary>
        Public Shared ReadOnly NameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Name, "Name")
        ''' <summary>
        ''' Gets the Name.
        ''' </summary>
        ''' <value>The Name.</value>
        Public ReadOnly Property Name As String
            Get
                Return GetProperty(NameProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="FiscalNumber"/> property.
        ''' </summary>
        Public Shared ReadOnly FiscalNumberProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.FiscalNumber, "Fiscal Number", New String(Nothing))
        ''' <summary>
        ''' Gets the Fiscal Number.
        ''' </summary>
        ''' <value>The Fiscal Number.</value>
        Public ReadOnly Property FiscalNumber As String
            Get
                Return GetProperty(FiscalNumberProperty)
            End Get
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="CustomerInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Update properties on saved object event "

        ''' <summary>
        ''' Existing <see cref="CustomerInfo"/> object is updated by <see cref="CustomerEdit"/> Saved event.
        ''' </summary>
        Friend Shared Function LoadInfo(customerEdit As CustomerEdit) As CustomerInfo
            Dim info As New CustomerInfo()
            info.UpdatePropertiesOnSaved(customerEdit)
            Return info
        End Function

        ''' <summary>
        ''' Properties on <see cref="CustomerInfo"/> object are updated by <see cref="CustomerEdit"/> Saved event.
        ''' </summary>
        Friend Sub UpdatePropertiesOnSaved(customerEdit As CustomerEdit)
            LoadProperty(CustomerIdProperty, customerEdit.CustomerId)
            LoadProperty(NameProperty, customerEdit.Name)
            LoadProperty(FiscalNumberProperty, customerEdit.FiscalNumber)
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="CustomerInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(CustomerIdProperty, dr.GetString("CustomerId"))
            LoadProperty(NameProperty, dr.GetString("Name"))
            LoadProperty(FiscalNumberProperty, If(dr.IsDBNull("FiscalNumber"), Nothing, dr.GetString("FiscalNumber")))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
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
