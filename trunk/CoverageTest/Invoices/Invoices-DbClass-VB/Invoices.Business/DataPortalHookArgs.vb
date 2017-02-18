Imports System.Data
Imports System.Data.Common
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' Event arguments for the DataPortalHook.<br/>
    ''' This class holds the arguments for events that happen during DataPortal operations.
    ''' </summary>
    Public Class DataPortalHookArgs

        #Region " Properties "

        ''' <summary>
        ''' Gets or sets the criteria argument.
        ''' </summary>
        ''' <value>The criteria object.</value>
        Public Property CriteriaArg() As Object
            Get
                Return m_CriteriaArg
            End Get
            Private Set
                m_CriteriaArg = Value
            End Set
        End Property
        Private m_CriteriaArg As Object

        ''' <summary>
        ''' Gets or sets the connection argument.
        ''' </summary>
        ''' <value>The connection.</value>
        Public Property ConnectionArg() As DbConnection
            Get
                Return m_ConnectionArg
            End Get
            Private Set
                m_ConnectionArg = Value
            End Set
        End Property
        Private m_ConnectionArg As DbConnection

        ''' <summary>
        ''' Gets or sets the command argument.
        ''' </summary>
        ''' <value>The command.</value>
        Public Property CommandArg() As DbCommand
            Get
                Return m_CommandArg
            End Get
            Private Set
                m_CommandArg = Value
            End Set
        End Property
        Private m_CommandArg As DbCommand

        ''' <summary>
        ''' Gets or sets the ADO transaction argument.
        ''' </summary>
        ''' <value>The ADO transaction.</value>
        Public Property TransactionArg() As DbTransaction
            Get
                Return m_TransactionArg
            End Get
            Private Set
                m_TransactionArg = Value
            End Set
        End Property
        Private m_TransactionArg As DbTransaction

        ''' <summary>
        ''' Gets or sets the data reader argument.
        ''' </summary>
        ''' <value>The data reader.</value>
        Public Property DataReaderArg() As SafeDataReader
            Get
                Return m_DataReaderArg
            End Get
            Private Set
                m_DataReaderArg = Value
            End Set
        End Property
        Private m_DataReaderArg As SafeDataReader

        ''' <summary>
        ''' Gets or sets the data row argument.
        ''' </summary>
        ''' <value>The data row.</value>
        Public Property DataRowArg() As DataRow
            Get
                Return m_DataRowArg
            End Get
            Private Set
                m_DataRowArg = Value
            End Set
        End Property
        Private m_DataRowArg As DataRow

        ''' <summary>
        ''' Gets or sets the data set argument.
        ''' </summary>
        ''' <value>The data set.</value>
        Public Property DataSetArg() As DataSet
            Get
                Return m_DataSetArg
            End Get
            Private Set
                m_DataSetArg = Value
            End Set
        End Property
        Private m_DataSetArg As DataSet

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new empty instance of the <see cref="DataPortalHookArgs"/> class.
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DataPortalHookArgs"/> class.
        ''' </summary>
        ''' <param name="crit">The criteria object argument.</param>
        Public Sub New(crit As Object)
            CriteriaArg = crit
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DataPortalHookArgs"/> class.
        ''' </summary>
        ''' <param name="cmd">The command argument.</param>
        ''' <remarks>The connection and ADO transaction arguments are set automatically, based on the command argument.</remarks>
        Public Sub New(cmd As DbCommand)
            CommandArg = cmd
            ConnectionArg = cmd.Connection
            TransactionArg = cmd.Transaction
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DataPortalHookArgs"/> class.
        ''' </summary>
        ''' <param name="conn">The connection argument.</param>
        Public Sub New(conn As DbConnection)
            ConnectionArg = conn
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DataPortalHookArgs"/> class.
        ''' </summary>
        ''' <param name="cmd">The command argument.</param>
        ''' <param name="crit">The criteria argument.</param>
        ''' <remarks>The connection and ADO transaction arguments are set automatically, based on the command argument.</remarks>
        Public Sub New(cmd As DbCommand, crit As Object)
            Me.New(cmd)
            CriteriaArg = crit
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DataPortalHookArgs"/> class.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader argument.</param>
        Public Sub New(dr As SafeDataReader)
            DataReaderArg = dr
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DataPortalHookArgs"/> class.
        ''' </summary>
        ''' <param name="cmd">The command argument.</param>
        ''' <param name="dr">The SafeDataReader argument.</param>
        ''' <remarks>The connection and ADO transaction arguments are set automatically, based on the command argument.</remarks>
        Public Sub New(cmd As DbCommand, dr As SafeDataReader)
            Me.New(cmd)
            DataReaderArg = dr
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DataPortalHookArgs"/> class.
        ''' </summary>
        ''' <param name="cmd">The command argument.</param>
        ''' <param name="ds">The DataSet argument.</param>
        ''' <remarks>The connection and ADO transaction arguments are set automatically, based on the command argument.</remarks>
        Public Sub New(cmd As DbCommand, ds As DataSet)
            Me.New(cmd)
            DataSetArg = ds
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DataPortalHookArgs"/> class.
        ''' </summary>
        ''' <param name="dr">The data row argument.</param>
        Public Sub New(dr As DataRow)
            DataRowArg = dr
        End Sub

#End Region

    End Class

End Namespace
