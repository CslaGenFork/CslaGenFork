'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocClassEditDyna
' ObjectType:  DocClassEditDyna
' CSLAType:    DynamicEditableRoot

Imports System
Imports Csla
Imports DocStore.Business.Util

Namespace DocStore.Business

    Public Partial Class DocClassEditDyna

        #Region " OnDeserialized actions "

        ''' <summary>
        ''' This method is called on a newly deserialized object
        ''' after deserialization is complete.
        ''' </summary>
        ''' <param name="context">Serialization context object.</param>
        Protected Overrides Sub OnDeserialized(context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            AddHandler Saved, AddressOf OnDocClassEditDynaSaved
            ' add your custom OnDeserialized actions here.
        End Sub

        #End Region

        #Region " Custom Business Rules and Property Authorization "

        ' Partial Private Sub AddBusinessRulesExtend()
        '     Throw New NotImplementedException()
        ' End Sub

        #End Region

        #Region " Custom Object Authorization "

        ' Partial Shared Sub AddObjectAuthorizationRulesExtend()
        '     Throw New NotImplementedException()
        ' End Sub

        #End Region

        #Region " Implementation of DataPortal Hooks "

        ' Partial Private Sub OnCreate(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnDeletePre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnDeletePost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnUpdatePre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnUpdatePost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnInsertPre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnInsertPost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        #End Region

    End Class

End Namespace
