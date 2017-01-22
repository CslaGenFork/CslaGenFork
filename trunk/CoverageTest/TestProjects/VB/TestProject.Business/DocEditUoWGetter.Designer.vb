Imports System
Imports Csla
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' DocEditGetter (getter unit of work pattern).<br/>
    ''' This is a generated base class of <see cref="DocEditGetter"/> business object.
    ''' This class is a root object that implements the Unit of Work pattern.
    ''' </summary>
    <Attributable>
    <Serializable()>
    Partial Public Class DocEditGetter
    Inherits MyBusinessBase(Of DocEditGetter)
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
        ''' Factory method. Loads a <see cref="DocEditGetter"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the DocEditGetter to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="DocEditGetter"/> unit of objects.</returns>
        Public Shared Function GetDocEditGetter(docID As Integer) As DocEditGetter
            Return DataPortal.Fetch(Of DocEditGetter)(docID)
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocEditGetter"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocEditGetter"/> unit of objects, based on given criteria.
        ''' </summary>
        ''' <param name="docID">The fetch criteria.</param>
        Protected Sub DataPortal_Fetch(docID As Integer)
            LoadProperty(DocProperty, Doc.GetDoc(docID))
            LoadProperty(DocTypeNVLProperty, DocTypeNVL.GetDocTypeNVL())
        End Sub

        #End Region

    End Class
End Namespace
