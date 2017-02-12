Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' ProductInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="ProductInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="ProductList"/> collection.
    ''' </remarks>
    <Serializable()>
    Public Partial Class ProductInfo
        Inherits ReadOnlyBase(Of ProductInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="ProductId"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductIdProperty As PropertyInfo(Of Guid) = RegisterProperty(Of Guid)(Function(p) p.ProductId, "Product Id", Guid.NewGuid())
        ''' <summary>
        ''' Gets the Product Id.
        ''' </summary>
        ''' <value>The Product Id.</value>
        Public ReadOnly Property ProductId As Guid
            Get
                Return GetProperty(ProductIdProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ProductCode"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductCodeProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.ProductCode, "Product Code", New String(Nothing))
        ''' <summary>
        ''' Gets the Product Code.
        ''' </summary>
        ''' <value>The Product Code.</value>
        Public ReadOnly Property ProductCode As String
            Get
                Return GetProperty(ProductCodeProperty)
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
        ''' Maintains metadata about <see cref="UnitCost"/> property.
        ''' </summary>
        Public Shared ReadOnly UnitCostProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.UnitCost, "Unit Cost")
        ''' <summary>
        ''' Gets the Unit Cost.
        ''' </summary>
        ''' <value>The Unit Cost.</value>
        Public ReadOnly Property UnitCost As String
            Get
                Return GetProperty(UnitCostProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockByteNull"/> property.
        ''' </summary>
        Public Shared ReadOnly StockByteNullProperty As PropertyInfo(Of Byte?) = RegisterProperty(Of Byte?)(Function(p) p.StockByteNull, "Stock Byte Null", New Byte?(Nothing))
        ''' <summary>
        ''' Gets the Stock Byte Null.
        ''' </summary>
        ''' <value>The Stock Byte Null.</value>
        Public ReadOnly Property StockByteNull As Byte?
            Get
                Return GetProperty(StockByteNullProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockByte"/> property.
        ''' </summary>
        Public Shared ReadOnly StockByteProperty As PropertyInfo(Of Byte) = RegisterProperty(Of Byte)(Function(p) p.StockByte, "Stock Byte")
        ''' <summary>
        ''' Gets the Stock Byte.
        ''' </summary>
        ''' <value>The Stock Byte.</value>
        Public ReadOnly Property StockByte As Byte
            Get
                Return GetProperty(StockByteProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockShortNull"/> property.
        ''' </summary>
        Public Shared ReadOnly StockShortNullProperty As PropertyInfo(Of Short?) = RegisterProperty(Of Short?)(Function(p) p.StockShortNull, "Stock Short Null", New Short?(Nothing))
        ''' <summary>
        ''' Gets the Stock Short Null.
        ''' </summary>
        ''' <value>The Stock Short Null.</value>
        Public ReadOnly Property StockShortNull As Short?
            Get
                Return GetProperty(StockShortNullProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockShort"/> property.
        ''' </summary>
        Public Shared ReadOnly StockShortProperty As PropertyInfo(Of Short) = RegisterProperty(Of Short)(Function(p) p.StockShort, "Stock Short")
        ''' <summary>
        ''' Gets the Stock Short.
        ''' </summary>
        ''' <value>The Stock Short.</value>
        Public ReadOnly Property StockShort As Short
            Get
                Return GetProperty(StockShortProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockIntNull"/> property.
        ''' </summary>
        Public Shared ReadOnly StockIntNullProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.StockIntNull, "Stock Int Null", New Integer?(Nothing))
        ''' <summary>
        ''' Gets the Stock Int Null.
        ''' </summary>
        ''' <value>The Stock Int Null.</value>
        Public ReadOnly Property StockIntNull As Integer?
            Get
                Return GetProperty(StockIntNullProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockInt"/> property.
        ''' </summary>
        Public Shared ReadOnly StockIntProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.StockInt, "Stock Int")
        ''' <summary>
        ''' Gets the Stock Int.
        ''' </summary>
        ''' <value>The Stock Int.</value>
        Public ReadOnly Property StockInt As Integer
            Get
                Return GetProperty(StockIntProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockLongNull"/> property.
        ''' </summary>
        Public Shared ReadOnly StockLongNullProperty As PropertyInfo(Of Long?) = RegisterProperty(Of Long?)(Function(p) p.StockLongNull, "Stock Long Null", New Long?(Nothing))
        ''' <summary>
        ''' Gets the Stock Long Null.
        ''' </summary>
        ''' <value>The Stock Long Null.</value>
        Public ReadOnly Property StockLongNull As Long?
            Get
                Return GetProperty(StockLongNullProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockLong"/> property.
        ''' </summary>
        Public Shared ReadOnly StockLongProperty As PropertyInfo(Of Long) = RegisterProperty(Of Long)(Function(p) p.StockLong, "Stock Long")
        ''' <summary>
        ''' Gets the Stock Long.
        ''' </summary>
        ''' <value>The Stock Long.</value>
        Public ReadOnly Property StockLong As Long
            Get
                Return GetProperty(StockLongProperty)
            End Get
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ProductInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="ProductInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(ProductIdProperty, dr.GetGuid("ProductId"))
            LoadProperty(ProductCodeProperty, If(dr.IsDBNull("ProductCode"), Nothing, dr.GetString("ProductCode")))
            LoadProperty(NameProperty, dr.GetString("Name"))
            LoadProperty(ProductTypeIdProperty, dr.GetInt32("ProductTypeId"))
            LoadProperty(UnitCostProperty, dr.GetString("UnitCost"))
            LoadProperty(StockByteNullProperty, DirectCast(dr.GetValue("StockByteNull"), Byte?))
            LoadProperty(StockByteProperty, dr.GetByte("StockByte"))
            LoadProperty(StockShortNullProperty, DirectCast(dr.GetValue("StockShortNull"), Short?))
            LoadProperty(StockShortProperty, dr.GetInt16("StockShort"))
            LoadProperty(StockIntNullProperty, DirectCast(dr.GetValue("StockIntNull"), Integer?))
            LoadProperty(StockIntProperty, dr.GetInt32("StockInt"))
            LoadProperty(StockLongNullProperty, DirectCast(dr.GetValue("StockLongNull"), Long?))
            LoadProperty(StockLongProperty, dr.GetInt64("StockLong"))
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
