Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' MyBusinessListBase (base class).<br/>
    ''' This is a generated base class of <see cref="MyBusinessListBase"/> business object.
    ''' </summary>
    <Attributable>
    <Serializable()>
    Public MustInherit Partial Class MyBusinessListBase(Of T As {BusinessListBase(Of T, C), IHaveInterface}, C As BusinessBase(Of C))
        Inherits BusinessListBase(Of T, C)
        Implements IHaveInterface

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="MyBusinessListBase"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

    End Class
End Namespace
