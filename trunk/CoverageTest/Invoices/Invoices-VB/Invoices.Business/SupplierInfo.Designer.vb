Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' SupplierInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="SupplierInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="SupplierList"/> collection.
    ''' </remarks>
    <Serializable>
    Public Partial Class SupplierInfo
        Inherits ReadOnlyBase(Of SupplierInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="SupplierId"/> property.
        ''' </summary>
        Public Shared ReadOnly SupplierIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.SupplierId, "Supplier Id")
        ''' <summary>
        ''' For simplicity sake, use the VAT number (no auto increment here).
        ''' </summary>
        ''' <value>The Supplier Id.</value>
        Public ReadOnly Property SupplierId As Integer
            Get
                Return GetProperty(SupplierIdProperty)
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

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SupplierInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Update properties on saved object event "

        ''' <summary>
        ''' Existing <see cref="SupplierInfo"/> object is updated by <see cref="SupplierEdit"/> Saved event.
        ''' </summary>
        Friend Shared Function LoadInfo(supplierEdit As SupplierEdit) As SupplierInfo
            Dim info As New SupplierInfo()
            info.UpdatePropertiesOnSaved(supplierEdit)
            Return info
        End Function

        ''' <summary>
        ''' Properties on <see cref="SupplierInfo"/> object are updated by <see cref="SupplierEdit"/> Saved event.
        ''' </summary>
        Friend Sub UpdatePropertiesOnSaved(supplierEdit As SupplierEdit)
            LoadProperty(SupplierIdProperty, supplierEdit.SupplierId)
            LoadProperty(NameProperty, supplierEdit.Name)
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="SupplierInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(SupplierIdProperty, dr.GetInt32("SupplierId"))
            LoadProperty(NameProperty, dr.GetString("Name"))
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
