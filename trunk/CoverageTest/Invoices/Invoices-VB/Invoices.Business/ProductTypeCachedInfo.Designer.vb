Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' ProductTypeCachedInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="ProductTypeCachedInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="ProductTypeCachedList"/> collection.
    ''' </remarks>
    <Serializable()>
    Public Partial Class ProductTypeCachedInfo
        Inherits ReadOnlyBase(Of ProductTypeCachedInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="ProductTypeId"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductTypeIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.ProductTypeId, "Product Type Id")
        ''' <summary>
        ''' Gets the Product Type Id.
        ''' </summary>
        ''' <value>The Product Type Id.</value>
        Public ReadOnly Property ProductTypeId As Integer
            Get
                Return GetProperty(ProductTypeIdProperty)
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
        ''' Initializes a new instance of the <see cref="ProductTypeCachedInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Update properties on saved object event "

        ''' <summary>
        ''' Existing <see cref="ProductTypeCachedInfo"/> object is updated by <see cref="ProductTypeItem"/> Saved event.
        ''' </summary>
        Friend Shared Function LoadInfo(productTypeItem As ProductTypeItem) As ProductTypeCachedInfo
            Dim info As New ProductTypeCachedInfo()
            info.UpdatePropertiesOnSaved(productTypeItem)
            Return info
        End Function

        ''' <summary>
        ''' Properties on <see cref="ProductTypeCachedInfo"/> object are updated by <see cref="ProductTypeItem"/> Saved event.
        ''' </summary>
        Friend Sub UpdatePropertiesOnSaved(productTypeItem As ProductTypeItem)
            LoadProperty(NameProperty, productTypeItem.Name)
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="ProductTypeCachedInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(ProductTypeIdProperty, dr.GetInt32("ProductTypeId"))
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
