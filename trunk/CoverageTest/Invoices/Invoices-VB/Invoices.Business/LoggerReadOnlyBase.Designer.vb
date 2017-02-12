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

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="ILog.LogAction"/> property.
        ''' </summary>
        Public Shared ReadOnly LogActionProperty As PropertyInfo(Of Byte) = RegisterProperty(Of Byte)(Function(p) DirectCast(p, ILog).LogAction, "Log Action")
        ''' <summary>
        ''' Gets or sets the Log Action.
        ''' </summary>
        ''' <value>The Log Action.</value>
        Public Property LogAction As LogActions Implements ILog.LogAction
            Get
                Return ReadPropertyConvert(Of Byte, LogActions)(LogActionProperty)
            End Get
            Set(ByVal value As LogActions)
                LoadPropertyConvert(Of Byte, LogActions)(LogActionProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ILog.LogDateTime"/> property.
        ''' </summary>
        Public Shared ReadOnly LogDateTimeProperty As PropertyInfo(Of Date) = RegisterProperty(Of Date)(Function(p) DirectCast(p, ILog).LogDateTime, "Log Date Time", DateTime.Now)
        ''' <summary>
        ''' Gets or sets the Log Date Time.
        ''' </summary>
        ''' <value>The Log Date Time.</value>
        Public Property LogDateTime As Date Implements ILog.LogDateTime
            Get
                Return ReadProperty(LogDateTimeProperty)
            End Get
            Set(ByVal value As Date)
                LoadProperty(LogDateTimeProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ILog.LogUser"/> property.
        ''' </summary>
        Public Shared ReadOnly LogUserProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) DirectCast(p, ILog).LogUser, "Log Useer")
        ''' <summary>
        ''' Gets or sets the Log Useer.
        ''' </summary>
        ''' <value>The Log Useer.</value>
        Public Property LogUser As Integer Implements ILog.LogUser
            Get
                Return ReadProperty(LogUserProperty)
            End Get
            Set(ByVal value As Integer)
                LoadProperty(LogUserProperty, value)
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
