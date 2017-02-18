Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' LoggerBusinessListBase (base class).<br/>
    ''' This is a generated base class of <see cref="LoggerBusinessListBase"/> business object.
    ''' </summary>
    <Serializable>
    Public MustInherit Partial Class LoggerBusinessListBase(Of T As {LoggerBusinessListBase(Of T, C), IListLog}, C As LoggerBusinessBase(Of C))
        Inherits BusinessListBase(Of T, C)
        Implements IListLog

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="LoggerBusinessListBase"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

    End Class
End Namespace
