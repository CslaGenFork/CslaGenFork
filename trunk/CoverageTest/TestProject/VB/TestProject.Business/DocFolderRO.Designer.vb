Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' Folder where this document is archived (read only object).<br/>
    ''' This is a generated base class of <see cref="DocFolderRO"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="DocFolderCollRO"/> collection.
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable>
    Public Partial Class DocFolderRO
        Inherits ReadOnlyBase(Of DocFolderRO)
        Implements IHaveInterface

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="FolderID"/> property.
        ''' </summary>
        Public Shared ReadOnly FolderIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.FolderID, "Folder ID")
        ''' <summary>
        ''' Gets the Folder ID.
        ''' </summary>
        ''' <value>The Folder ID.</value>
        Public ReadOnly Property FolderID As Integer
            Get
                Return GetProperty(FolderIDProperty)
            End Get
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocFolderRO"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocFolderRO"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(FolderIDProperty, dr.GetInt32("FolderID"))
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
