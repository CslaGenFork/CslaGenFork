Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' MyBusinessBindingListBase (base class).<br/>
    ''' This is a generated base class of <see cref="MyBusinessBindingListBase"/> business object.
    ''' </summary>
    <Attributable>
    <Serializable()>
    Public MustInherit Partial Class MyBusinessBindingListBase(Of T As {BusinessBindingListBase(Of T, C), IHaveInterface}, C As BusinessBase(Of C))
        Inherits BusinessBindingListBase(Of T, C)
        Implements IHaveInterface

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="MyBusinessBindingListBase"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

    End Class
End Namespace
