Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' LoggerReadOnlyBase (base class).<br/>
    ''' This is a generated base class of <see cref="LoggerReadOnlyBase"/> business object.
    ''' </summary>
    <Serializable()>
    Public MustInherit Partial Class LoggerReadOnlyBase(Of T As {LoggerReadOnlyBase(Of T), ILog})
        Inherits ReadOnlyBase(Of T)
        Implements ILog

        #Region " State Fields "

        Private _logAction As Byte = 0
        Private _logDateTime As Date = DateTime.Now
        Private _logUser As Integer = 0

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Gets or sets the Log Action.
        ''' </summary>
        ''' <value>The Log Action.</value>
        Public Property LogAction As LogActions Implements ILog.LogAction
            Get
                Return _logAction
            End Get
            Set(ByVal value As LogActions)
                _logAction = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the Log Date Time.
        ''' </summary>
        ''' <value>The Log Date Time.</value>
        Public Property LogDateTime As Date Implements ILog.LogDateTime
            Get
                Return _logDateTime
            End Get
            Set(ByVal value As Date)
                _logDateTime = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the Log Useer.
        ''' </summary>
        ''' <value>The Log Useer.</value>
        Public Property LogUser As Integer Implements ILog.LogUser
            Get
                Return _logUser
            End Get
            Set(ByVal value As Integer)
                _logUser = value
            End Set
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="LoggerReadOnlyBase"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

    End Class
End Namespace
