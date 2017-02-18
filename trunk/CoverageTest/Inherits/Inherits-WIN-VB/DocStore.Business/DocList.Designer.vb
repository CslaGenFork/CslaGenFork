'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocList
' ObjectType:  DocList
' CSLAType:    ReadOnlyCollection

Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports UsingLibrary

Namespace DocStore.Business

    ''' <summary>
    ''' Collection of document's basic information (read only list).<br/>
    ''' This is a generated base class of <see cref="DocList"/> business object.
    ''' This class is a root collection.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="DocInfo"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class DocList
#If WINFORMS Then
        Inherits MyReadOnlyBindingListBase(Of DocList, DocInfo)
        Implements IHaveInterface, IHaveGenericInterface(Of DocList)
#Else
        Inherits MyReadOnlyListBase(Of DocList, DocInfo)
        Implements IHaveInterface, IHaveGenericInterface(Of DocList)
#End If

        #Region " Event handler properties "

        <NotUndoable>
        Private Shared _singleInstanceSavedHandler As Boolean = True

        ''' <summary>
        ''' Gets or sets a value indicating whether only a single instance should handle the Saved event.
        ''' </summary>
        ''' <value>
        ''' <c>true</c> if only a single instance should handle the Saved event; otherwise, <c>false</c>.
        ''' </value>
        Public Shared Property SingleInstanceSavedHandler() As Boolean
            Get
                Return _singleInstanceSavedHandler
            End Get
            Set(ByVal value As Boolean)
                _singleInstanceSavedHandler = value
            End Set
        End Property

        #End Region

        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="DocInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="docID">The DocID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(docID As Integer) As Boolean
            For Each item As DocInfo In Me
                If item.DocID = docID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Find Methods "

        ''' <summary>
        ''' Finds a <see cref="DocInfo"/> item of the <see cref="DocList"/> collection, based on a given DocID.
        ''' </summary>
        ''' <param name="docID">The DocID.</param>
        ''' <returns>A <see cref="DocInfo"/> object.</returns>
        Public Function FindDocInfoByDocID(docID As Integer) As DocInfo
            For i As Integer = 0 To Me.Count - 1
                If Me(i).DocID.Equals(docID) Then
                    Return Me(i)
                End If
            Next i

            Return Nothing
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocList"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DocList"/> collection.</returns>
        Public Shared Function GetDocList() As DocList
            Return DataPortal.Fetch(Of DocList)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocList"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="crit">The fetch criteria.</param>
        ''' <returns>A reference to the fetched <see cref="DocList"/> collection.</returns>
        Public Shared Function GetDocList(crit As DocListFilteredCriteria) As DocList
            Return DataPortal.Fetch(Of DocList)(crit)
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocList"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the DocList to fetch.</param>
        ''' <param name="docClassID">The DocClassID parameter of the DocList to fetch.</param>
        ''' <param name="docTypeID">The DocTypeID parameter of the DocList to fetch.</param>
        ''' <param name="senderID">The SenderID parameter of the DocList to fetch.</param>
        ''' <param name="recipientID">The RecipientID parameter of the DocList to fetch.</param>
        ''' <param name="docRef">The DocRef parameter of the DocList to fetch.</param>
        ''' <param name="docDate">The DocDate parameter of the DocList to fetch.</param>
        ''' <param name="subject">The Subject parameter of the DocList to fetch.</param>
        ''' <param name="docStatusID">The DocStatusID parameter of the DocList to fetch.</param>
        ''' <param name="createDate">The CreateDate parameter of the DocList to fetch.</param>
        ''' <param name="createUserID">The CreateUserID parameter of the DocList to fetch.</param>
        ''' <param name="changeDate">The ChangeDate parameter of the DocList to fetch.</param>
        ''' <param name="changeUserID">The ChangeUserID parameter of the DocList to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="DocList"/> collection.</returns>
        Public Shared Function GetDocList(docID As Integer?, docClassID As Integer?, docTypeID As Integer?, senderID As Integer?, recipientID As Integer?, docRef As String, docDate As SmartDate, subject As String, docStatusID As Integer?, createDate As SmartDate, createUserID As Integer?, changeDate As SmartDate, changeUserID As Integer?) As DocList
            Return DataPortal.Fetch(Of DocList)(New DocListFilteredCriteria(docID, docClassID, docTypeID, senderID, recipientID, docRef, docDate, subject, docStatusID, createDate, createUserID, changeDate, changeUserID))
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="DocList"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDocList(ByVal callback As EventHandler(Of DataPortalResult(Of DocList)))
            DataPortal.BeginFetch(Of DocList)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="DocList"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="crit">The fetch criteria.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDocList(crit As DocListFilteredCriteria, callback As EventHandler(Of DataPortalResult(Of DocList)))
            DataPortal.BeginFetch(Of DocList)(crit, callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="DocList"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the DocList to fetch.</param>
        ''' <param name="docClassID">The DocClassID parameter of the DocList to fetch.</param>
        ''' <param name="docTypeID">The DocTypeID parameter of the DocList to fetch.</param>
        ''' <param name="senderID">The SenderID parameter of the DocList to fetch.</param>
        ''' <param name="recipientID">The RecipientID parameter of the DocList to fetch.</param>
        ''' <param name="docRef">The DocRef parameter of the DocList to fetch.</param>
        ''' <param name="docDate">The DocDate parameter of the DocList to fetch.</param>
        ''' <param name="subject">The Subject parameter of the DocList to fetch.</param>
        ''' <param name="docStatusID">The DocStatusID parameter of the DocList to fetch.</param>
        ''' <param name="createDate">The CreateDate parameter of the DocList to fetch.</param>
        ''' <param name="createUserID">The CreateUserID parameter of the DocList to fetch.</param>
        ''' <param name="changeDate">The ChangeDate parameter of the DocList to fetch.</param>
        ''' <param name="changeUserID">The ChangeUserID parameter of the DocList to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDocList(docID As Integer?, docClassID As Integer?, docTypeID As Integer?, senderID As Integer?, recipientID As Integer?, docRef As String, docDate As SmartDate, subject As String, docStatusID As Integer?, createDate As SmartDate, createUserID As Integer?, changeDate As SmartDate, changeUserID As Integer?, ByVal callback As EventHandler(Of DataPortalResult(Of DocList)))
            DataPortal.BeginFetch(Of DocList)(New DocListFilteredCriteria(docID, docClassID, docTypeID, senderID, recipientID, docRef, docDate, subject, docStatusID, createDate, createUserID, changeDate, changeUserID), callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocList"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            DocSaved.Register(Me)

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = False
            AllowEdit = False
            AllowRemove = False
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Saved Event Handler "

        ''' <summary>
        ''' Handle Saved events of <see cref="Doc"/> to update the list of <see cref="DocInfo"/> objects.
        ''' </summary>
        ''' <param name="sender">The sender of the event.</param>
        ''' <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        Private Sub DocSavedHandler(sender As Object, e As Csla.Core.SavedEventArgs)
            Dim obj As Doc = CType(e.NewObject, Doc)
            If CType(sender, Doc).IsNew Then
                IsReadOnly = False
                Dim rlce As Boolean = RaiseListChangedEvents
                RaiseListChangedEvents = True
                Add(DocInfo.LoadInfo(obj))
                RaiseListChangedEvents = rlce
                IsReadOnly = True
            ElseIf CType(sender, Doc).IsDeleted Then
                For index = 0 To Count - 1
                    Dim child As DocInfo = Me(index)
                    If child.DocID = obj.DocID Then
                        IsReadOnly = False
                        Dim rlce As Boolean = RaiseListChangedEvents
                        RaiseListChangedEvents = True
                        RemoveItem(index)
                        RaiseListChangedEvents = rlce
                        IsReadOnly = True
                        Exit For
                    End If
                Next
            Else
                For index = 0 To Count - 1
                    Dim child As DocInfo = Me(index)
                    If child.DocID = obj.DocID Then
                        child.UpdatePropertiesOnSaved(obj)
#If Not WINFORMS Then
                        Dim notifyCollectionChangedEventArgs As New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, child, child, index)
                        OnCollectionChanged(notifyCollectionChangedEventArgs)
#Else
                        Dim listChangedEventArgs As New ListChangedEventArgs(ListChangedType.ItemChanged, index)
                        OnListChanged(listChangedEventArgs)
#End If
                        Exit For
                    End If
                Next
            End If
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocList"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                GetQueryGetDocList()
                Using cmd = New SqlCommand(getDocListInlineQuery, ctx.Connection)
                    cmd.CommandType = CommandType.Text
                    Dim args As New DataPortalHookArgs(cmd)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Loads a <see cref="DocList"/> collection from the database, based on given criteria.
        ''' </summary>
        ''' <param name="crit">The fetch criteria.</param>
        Protected Overloads Sub DataPortal_Fetch(crit As DocListFilteredCriteria)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                GetQueryGetDocList(crit)
                Using cmd = New SqlCommand(getDocListInlineQuery, ctx.Connection)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@DocID", If(crit.DocID Is Nothing, DBNull.Value, crit.DocID.Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocClassID", If(crit.DocClassID Is Nothing, DBNull.Value, crit.DocClassID.Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocTypeID", If(crit.DocTypeID Is Nothing, DBNull.Value, crit.DocTypeID.Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@SenderID", If(crit.SenderID Is Nothing, DBNull.Value, crit.SenderID.Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@RecipientID", If(crit.RecipientID Is Nothing, DBNull.Value, crit.RecipientID.Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocRef", If(crit.DocRef Is Nothing, DBNull.Value, crit.DocRef)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@DocDate", If(crit.DocDate.IsEmpty, DBNull.Value, crit.DocDate).DBValue).DbType = DbType.Date
                    cmd.Parameters.AddWithValue("@Subject", If(crit.Subject Is Nothing, DBNull.Value, crit.Subject)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@DocStatusID", If(crit.DocStatusID Is Nothing, DBNull.Value, crit.DocStatusID.Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@CreateDate", If(crit.CreateDate.IsEmpty, DBNull.Value, crit.CreateDate).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@CreateUserID", If(crit.CreateUserID Is Nothing, DBNull.Value, crit.CreateUserID.Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ChangeDate", If(crit.ChangeDate.IsEmpty, DBNull.Value, crit.ChangeDate).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUserID", If(crit.ChangeUserID Is Nothing, DBNull.Value, crit.ChangeUserID.Value)).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, crit)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
        End Sub

        Private Sub LoadCollection(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                Fetch(dr)
            End Using
        End Sub

        ''' <summary>
        ''' Loads all <see cref="DocList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DocInfo.GetDocInfo(dr))
            End While
            RaiseListChangedEvents = rlce
            IsReadOnly = True
        End Sub

        #End Region

        #Region " Inline queries fields and partial methods "

        <NotUndoable, NonSerialized>
        Private getDocListInlineQuery As String

        Partial Private Sub GetQueryGetDocList()
        End Sub

        Partial Private Sub GetQueryGetDocList(crit As DocListFilteredCriteria)
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting query parameters and before the fetch operation.
        ''' </summary>
        Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the fetch operation (object or collection is fully loaded and set up).
        ''' </summary>
        Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        End Sub

        #End Region

        #Region " DocSaved nested class "

        ''' <summary>
        ''' Nested class to manage the Saved events of <see cref="Doc"/>
        ''' to update the list of <see cref="DocInfo"/> objects.
        ''' </summary>
        Private NotInheritable Class DocSaved
            Private Shared _references As List(Of WeakReference)

            Private Sub New()
            End Sub

            Private Shared Function Found(ByVal obj As Object) As Boolean
                Return _references.Any(Function(reference) Equals(reference.Target, obj))
            End Function

            ''' <summary>
            ''' Registers a DocList instance to handle Saved events.
            ''' to update the list of <see cref="DocInfo"/> objects.
            ''' </summary>
            ''' <param name="obj">The DocList instance.</param>
            Public Shared Sub Register(ByVal obj As DocList)
                Dim mustRegister As Boolean = _references Is Nothing

                If mustRegister Then
                    _references = New List(Of WeakReference)()
                End If

                If DocList.SingleInstanceSavedHandler Then
                    _references.Clear()
                End If

                If Not Found(obj) Then
                    _references.Add(New WeakReference(obj))
                End If

                If mustRegister Then
                    AddHandler Doc.DocSaved, AddressOf DocSavedHandler
                End If
            End Sub

            ''' <summary>
            ''' Handles Saved events of <see cref="Doc"/>.
            ''' </summary>
            ''' <param name="sender">The sender of the event.</param>
            ''' <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            Public Shared Sub DocSavedHandler(ByVal sender As Object, ByVal e As Csla.Core.SavedEventArgs)
                For Each reference As WeakReference In _references
                    If reference.IsAlive Then
                        CType(reference.Target, DocList).DocSavedHandler(sender, e)
                    End If
                Next reference
            End Sub

            ''' <summary>
            ''' Removes event handling and clears all registered DocList instances.
            ''' </summary>
            Public Shared Sub Unregister()
                RemoveHandler Doc.DocSaved, AddressOf DocSavedHandler
                _references = Nothing
            End Sub
        End Class

        #End Region

    End Class

    #Region " Criteria "

    ''' <summary>
    ''' DocListFilteredCriteria criteria.
    ''' </summary>
    <Serializable>
    Public Class DocListFilteredCriteria
        Inherits CriteriaBase(Of DocListFilteredCriteria)

        ''' <summary>
        ''' Maintains metadata about <see cref="DocID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.DocID)
        ''' <summary>
        ''' Gets or sets the Doc ID.
        ''' </summary>
        ''' <value>The Doc ID.</value>
        Public Property DocID As Integer?
            Get
                Return ReadProperty(DocIDProperty)
            End Get
            Set (value As Integer?)
                LoadProperty(DocIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocClassID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocClassIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.DocClassID)
        ''' <summary>
        ''' Gets or sets the Doc Class ID.
        ''' </summary>
        ''' <value>The Doc Class ID.</value>
        Public Property DocClassID As Integer?
            Get
                Return ReadProperty(DocClassIDProperty)
            End Get
            Set (value As Integer?)
                LoadProperty(DocClassIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocTypeID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocTypeIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.DocTypeID)
        ''' <summary>
        ''' Gets or sets the Doc Type ID.
        ''' </summary>
        ''' <value>The Doc Type ID.</value>
        Public Property DocTypeID As Integer?
            Get
                Return ReadProperty(DocTypeIDProperty)
            End Get
            Set (value As Integer?)
                LoadProperty(DocTypeIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="SenderID"/> property.
        ''' </summary>
        Public Shared ReadOnly SenderIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.SenderID)
        ''' <summary>
        ''' Gets or sets the Sender ID.
        ''' </summary>
        ''' <value>The Sender ID.</value>
        Public Property SenderID As Integer?
            Get
                Return ReadProperty(SenderIDProperty)
            End Get
            Set (value As Integer?)
                LoadProperty(SenderIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RecipientID"/> property.
        ''' </summary>
        Public Shared ReadOnly RecipientIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.RecipientID)
        ''' <summary>
        ''' Gets or sets the Recipient ID.
        ''' </summary>
        ''' <value>The Recipient ID.</value>
        Public Property RecipientID As Integer?
            Get
                Return ReadProperty(RecipientIDProperty)
            End Get
            Set (value As Integer?)
                LoadProperty(RecipientIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocRef"/> property.
        ''' </summary>
        Public Shared ReadOnly DocRefProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocRef)
        ''' <summary>
        ''' Gets or sets the Doc Ref.
        ''' </summary>
        ''' <value>The Doc Ref.</value>
        Public Property DocRef As String
            Get
                Return ReadProperty(DocRefProperty)
            End Get
            Set (value As String)
                LoadProperty(DocRefProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocDate"/> property.
        ''' </summary>
        Public Shared ReadOnly DocDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.DocDate)
        ''' <summary>
        ''' Gets or sets the Doc Date.
        ''' </summary>
        ''' <value>The Doc Date.</value>
        Public Property DocDate As SmartDate
            Get
                Return ReadProperty(DocDateProperty)
            End Get
            Set (value As SmartDate)
                LoadProperty(DocDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Subject"/> property.
        ''' </summary>
        Public Shared ReadOnly SubjectProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Subject)
        ''' <summary>
        ''' Gets or sets the Subject.
        ''' </summary>
        ''' <value>The Subject.</value>
        Public Property Subject As String
            Get
                Return ReadProperty(SubjectProperty)
            End Get
            Set (value As String)
                LoadProperty(SubjectProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocStatusID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocStatusIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.DocStatusID)
        ''' <summary>
        ''' Gets or sets the Doc Status ID.
        ''' </summary>
        ''' <value>The Doc Status ID.</value>
        Public Property DocStatusID As Integer?
            Get
                Return ReadProperty(DocStatusIDProperty)
            End Get
            Set (value As Integer?)
                LoadProperty(DocStatusIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateDate"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.CreateDate)
        ''' <summary>
        ''' Gets or sets the Create Date.
        ''' </summary>
        ''' <value>The Create Date.</value>
        Public Property CreateDate As SmartDate
            Get
                Return ReadProperty(CreateDateProperty)
            End Get
            Set (value As SmartDate)
                LoadProperty(CreateDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateUserID"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateUserIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.CreateUserID)
        ''' <summary>
        ''' Gets or sets the Create User ID.
        ''' </summary>
        ''' <value>The Create User ID.</value>
        Public Property CreateUserID As Integer?
            Get
                Return ReadProperty(CreateUserIDProperty)
            End Get
            Set (value As Integer?)
                LoadProperty(CreateUserIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeDate"/> property.
        ''' </summary>
        Public Shared ReadOnly ChangeDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.ChangeDate)
        ''' <summary>
        ''' Gets or sets the Change Date.
        ''' </summary>
        ''' <value>The Change Date.</value>
        Public Property ChangeDate As SmartDate
            Get
                Return ReadProperty(ChangeDateProperty)
            End Get
            Set (value As SmartDate)
                LoadProperty(ChangeDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeUserID"/> property.
        ''' </summary>
        Public Shared ReadOnly ChangeUserIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.ChangeUserID)
        ''' <summary>
        ''' Gets or sets the Change User ID.
        ''' </summary>
        ''' <value>The Change User ID.</value>
        Public Property ChangeUserID As Integer?
            Get
                Return ReadProperty(ChangeUserIDProperty)
            End Get
            Set (value As Integer?)
                LoadProperty(ChangeUserIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocListFilteredCriteria"/> class.
        ''' </summary>
        ''' <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocListFilteredCriteria"/> class.
        ''' </summary>
        ''' <param name="p_docID">The DocID.</param>
        ''' <param name="p_docClassID">The DocClassID.</param>
        ''' <param name="p_docTypeID">The DocTypeID.</param>
        ''' <param name="p_senderID">The SenderID.</param>
        ''' <param name="p_recipientID">The RecipientID.</param>
        ''' <param name="p_docRef">The DocRef.</param>
        ''' <param name="p_docDate">The DocDate.</param>
        ''' <param name="p_subject">The Subject.</param>
        ''' <param name="p_docStatusID">The DocStatusID.</param>
        ''' <param name="p_createDate">The CreateDate.</param>
        ''' <param name="p_createUserID">The CreateUserID.</param>
        ''' <param name="p_changeDate">The ChangeDate.</param>
        ''' <param name="p_changeUserID">The ChangeUserID.</param>
        Public Sub New(p_docID As Integer?, p_docClassID As Integer?, p_docTypeID As Integer?, p_senderID As Integer?, p_recipientID As Integer?, p_docRef As String, p_docDate As SmartDate, p_subject As String, p_docStatusID As Integer?, p_createDate As SmartDate, p_createUserID As Integer?, p_changeDate As SmartDate, p_changeUserID As Integer?)
            DocID = p_docID
            DocClassID = p_docClassID
            DocTypeID = p_docTypeID
            SenderID = p_senderID
            RecipientID = p_recipientID
            DocRef = p_docRef
            DocDate = p_docDate
            Subject = p_subject
            DocStatusID = p_docStatusID
            CreateDate = p_createDate
            CreateUserID = p_createUserID
            ChangeDate = p_changeDate
            ChangeUserID = p_changeUserID
        End Sub

        ''' <summary>
        ''' Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        ''' </summary>
        ''' <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        ''' <returns><c>True</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is DocListFilteredCriteria Then
                Dim c = DirectCast(obj, DocListFilteredCriteria)
                If Not DocID.Equals(c.DocID) Then
                    Return False
                End If
                If Not DocClassID.Equals(c.DocClassID) Then
                    Return False
                End If
                If Not DocTypeID.Equals(c.DocTypeID) Then
                    Return False
                End If
                If Not SenderID.Equals(c.SenderID) Then
                    Return False
                End If
                If Not RecipientID.Equals(c.RecipientID) Then
                    Return False
                End If
                If Not DocRef.Equals(c.DocRef) Then
                    Return False
                End If
                If Not DocDate.Equals(c.DocDate) Then
                    Return False
                End If
                If Not Subject.Equals(c.Subject) Then
                    Return False
                End If
                If Not DocStatusID.Equals(c.DocStatusID) Then
                    Return False
                End If
                If Not CreateDate.Equals(c.CreateDate) Then
                    Return False
                End If
                If Not CreateUserID.Equals(c.CreateUserID) Then
                    Return False
                End If
                If Not ChangeDate.Equals(c.ChangeDate) Then
                    Return False
                End If
                If Not ChangeUserID.Equals(c.ChangeUserID) Then
                    Return False
                End If
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        ''' Returns a hash code for this instance.
        ''' </summary>
        ''' <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        Public Overrides Function GetHashCode() As Integer
            Return String.Concat("DocListFilteredCriteria", DocID.ToString(), DocClassID.ToString(), DocTypeID.ToString(), SenderID.ToString(), RecipientID.ToString(), DocRef.ToString(), DocDate.ToString(), Subject.ToString(), DocStatusID.ToString(), CreateDate.ToString(), CreateUserID.ToString(), ChangeDate.ToString(), ChangeUserID.ToString()).GetHashCode()
        End Function
    End Class

    #End Region

End Namespace
