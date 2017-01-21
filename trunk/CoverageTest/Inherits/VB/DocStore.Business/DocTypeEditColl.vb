'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocTypeEditColl
' ObjectType:  DocTypeEditColl
' CSLAType:    EditableRootCollection

Imports System
Imports Csla
Imports DocStore.Business.Util

Namespace DocStore.Business

    Partial Public Class DocTypeEditColl

        #Region " OnDeserialized actions "

        ''' <summary>
        ''' This method is called on a newly deserialized object
        ''' after deserialization is complete.
        ''' </summary>
        Protected Overrides Sub OnDeserialized()
            MyBase.OnDeserialized()
            AddHandler Saved, AddressOf OnDocTypeEditCollSaved
            ' add your custom OnDeserialized actions here.
        End Sub

        #End Region

        #Region " Implementation of DataPortal Hooks "

        ' Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        #End Region

    End Class

End Namespace
