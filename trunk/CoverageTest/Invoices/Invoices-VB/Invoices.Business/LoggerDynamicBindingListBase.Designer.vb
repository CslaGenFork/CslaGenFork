Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' LoggerDynamicBindingListBase (base class).<br/>
    ''' This is a generated base class of <see cref="LoggerDynamicBindingListBase"/> business object.
    ''' </summary>
    <Serializable>
    Public MustInherit Partial Class LoggerDynamicBindingListBase(Of T As LoggerBusinessBase(Of T))
        Inherits DynamicBindingListBase(Of T)
        Implements IListLog

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="LoggerDynamicBindingListBase"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

    End Class
End Namespace
