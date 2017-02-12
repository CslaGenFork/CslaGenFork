Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Rules
Imports Csla.Rules.CommonRules
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' Collection of folders where this document is archived (editable child list).<br/>
    ''' This is a generated base class of <see cref="DocFolderColl"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is child of <see cref="Doc"/> editable root object.<br/>
    ''' The items of the collection are <see cref="DocFolder"/> objects.
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable()>
    Public Partial Class DocFolderColl
        Inherits MyBusinessListBase(Of DocFolderColl, DocFolder)
        Implements IHaveInterface
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Adds a new <see cref="DocFolder"/> item to the collection.
        ''' </summary>
        ''' <param name="item">The item to add.</param>
        ''' <exception cref="System.Security.SecurityException">if the user isn't authorized to add items to the collection.</exception>
        ''' <exception cref="ArgumentException">if the item already exists in the collection.</exception>
        Public Overloads Sub Add(item As DocFolder)
            If Not CanAddObject() Then
                Throw New System.Security.SecurityException("User not authorized to create a DocFolder.")
            End If
            If Contains(item.FolderID) Then
                Throw New ArgumentException("DocFolder already exists.")
            End If

            Add(item)
        End Sub

        ''' <summary>
        ''' Removes a <see cref="DocFolder"/> item from the collection.
        ''' </summary>
        ''' <param name="item">The item to remove.</param>
        ''' <returns><c>True</c> if the item was removed from the collection, otherwise <c>false</c>.</returns>
        ''' <exception cref="System.Security.SecurityException">if the user isn't authorized to remove items from the collection.</exception>
        Public Overloads Function Remove(item As DocFolder) As Boolean
            If Not CanDeleteObject() Then
                Throw New System.Security.SecurityException("User not authorized to remove a DocFolder.")
            End If
            Return MyBase.Remove(item)
        End Function

        ''' <summary>
        ''' Adds a new <see cref="DocFolder"/> item to the collection.
        ''' </summary>
        ''' <param name="folderID">The FolderID of the object to be added.</param>
        ''' <returns>The new DocFolder item added to the collection.</returns>
        Public Overloads Function Add(folderID As Integer) As DocFolder
            Dim item = DataPortal.Create(Of DocFolder)(folderID)
            Add(item)
            Return item
        End Function

        ''' <summary>
        ''' Removes a <see cref="DocFolder"/> item from the collection.
        ''' </summary>
        ''' <param name="folderID">The FolderID of the item to be removed.</param>
        Public Overloads Sub Remove(folderID As Integer)
            For Each item As DocFolder In Me
                If item.FolderID = folderID Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="DocFolder"/> item is in the collection.
        ''' </summary>
        ''' <param name="folderID">The FolderID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocFolder is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(folderID As Integer) As Boolean
            For Each item As DocFolder In Me
                If item.FolderID = folderID Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="DocFolder"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="folderID">The FolderID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocFolder is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(folderID As Integer) As Boolean
            For Each item As DocFolder In DeletedList
                If item.FolderID = folderID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Find Methods "

        ''' <summary>
        ''' Finds a <see cref="DocFolder"/> item of the <see cref="DocFolderColl"/> collection, based on a given FolderID.
        ''' </summary>
        ''' <param name="folderID">The FolderID.</param>
        ''' <returns>A <see cref="DocFolder"/> object.</returns>
        Public Function FindDocFolderByFolderID(folderID As Integer) As DocFolder
            For i As Integer = 0 To Me.Count - 1
                If Me(i).FolderID.Equals(folderID) Then
                    Return Me(i)
                End If
            Next i

            Return Nothing
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocFolderColl"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            ' show the framework that this is a child object
            MarkAsChild()

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = DocFolderColl.CanAddObject()
            AllowEdit = DocFolderColl.CanEditObject()
            AllowRemove = DocFolderColl.CanDeleteObject()
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(DocFolderColl), New IsInRole(AuthorizationActions.CreateObject, "Archivist"))
            BusinessRules.AddRule(GetType(DocFolderColl), New IsInRole(AuthorizationActions.GetObject, "User"))
            BusinessRules.AddRule(GetType(DocFolderColl), New IsInRole(AuthorizationActions.EditObject, "Author"))
            BusinessRules.AddRule(GetType(DocFolderColl), New IsInRole(AuthorizationActions.DeleteObject, "Admin", "Manager"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can create a new DocFolderColl object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanAddObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, GetType(DocFolderColl))
        End Function

        ''' <summary>
        ''' Checks if the current user can retrieve DocFolderColl's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(DocFolderColl))
        End Function

        ''' <summary>
        ''' Checks if the current user can change DocFolderColl's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanEditObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, GetType(DocFolderColl))
        End Function

        ''' <summary>
        ''' Checks if the current user can delete a DocFolderColl object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanDeleteObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, GetType(DocFolderColl))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads all <see cref="DocFolderColl"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Dim args As New DataPortalHookArgs(dr)
            OnFetchPre(args)
            While dr.Read()
                Add(DataPortal.FetchChild(Of DocFolder)(dr))
            End While
            OnFetchPost(args)
            RaiseListChangedEvents = rlce
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

    End Class

End Namespace
