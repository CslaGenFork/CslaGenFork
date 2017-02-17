Imports System
Imports Csla
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' DocEditCreator (creator unit of work pattern).<br/>
    ''' This is a generated base class of <see cref="DocEditCreator"/> business object.
    ''' This class is a root object that implements the Unit of Work pattern.
    ''' </summary>
    <Attributable>
    <Serializable>
    Public Partial Class DocEditCreator
        Inherits MyBusinessBase(Of DocEditCreator)
        Implements IHaveInterface

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="Doc"/> property.
        ''' </summary>
        Public Shared ReadOnly DocProperty As PropertyInfo(Of Doc) = RegisterProperty(Of Doc)(Function(p) p.Doc, "Doc")
        ''' <summary>
        ''' Gets the Doc object (unit of work child property).
        ''' </summary>
        ''' <value>The Doc.</value>
        Public Property Doc As Doc
            Get
                Return GetProperty(DocProperty)
            End Get
            Private Set(ByVal value As Doc)
                LoadProperty(DocProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="DocTypeNVL"/> property.
        ''' </summary>
        Public Shared ReadOnly DocTypeNVLProperty As PropertyInfo(Of DocTypeNVL) = RegisterProperty(Of DocTypeNVL)(Function(p) p.DocTypeNVL, "Doc Type NVL")
        ''' <summary>
        ''' Gets the Doc Type NVL object (unit of work child property).
        ''' </summary>
        ''' <value>The Doc Type NVL.</value>
        Public Property DocTypeNVL As DocTypeNVL
            Get
                Return GetProperty(DocTypeNVLProperty)
            End Get
            Private Set(ByVal value As DocTypeNVL)
                LoadProperty(DocTypeNVLProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocEditCreator"/> unit of objects.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DocEditCreator"/> unit of objects.</returns>
        Public Shared Function NewDocEditCreator() As DocEditCreator
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            Return DataPortal.Fetch(Of DocEditCreator)()
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocEditCreator"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Creates a new <see cref="DocEditCreator"/> unit of objects.
        ''' </summary>
        ''' <remarks>
        ''' ReadOnlyBase&lt;T&gt; doesn't allow the use of DataPortal_Create and thus DataPortal_Fetch is used.
        ''' </remarks>
        Protected Sub DataPortal_Fetch()
            LoadProperty(DocProperty, Doc.NewDoc())
            LoadProperty(DocTypeNVLProperty, DocTypeNVL.GetDocTypeNVL())
        End Sub

        #End Region

    End Class
End Namespace
