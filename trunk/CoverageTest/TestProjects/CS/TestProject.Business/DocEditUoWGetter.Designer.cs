using System;
using Csla;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// DocEditGetter (getter unit of work pattern).<br/>
    /// This is a generated base class of <see cref="DocEditGetter"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Attributable]
    [Serializable]
    public partial class DocEditGetter : MyBusinessBase<DocEditGetter>, IHaveInterface
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="Doc"/> property.
        /// </summary>
        public static readonly PropertyInfo<Doc> DocProperty = RegisterProperty<Doc>(p => p.Doc, "Doc");
        /// <summary>
        /// Gets the Doc object (unit of work child property).
        /// </summary>
        /// <value>The Doc.</value>
        public Doc Doc
        {
            get { return GetProperty(DocProperty); }
            private set { LoadProperty(DocProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="DocTypeNVL"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocTypeNVL> DocTypeNVLProperty = RegisterProperty<DocTypeNVL>(p => p.DocTypeNVL, "Doc Type NVL");
        /// <summary>
        /// Gets the Doc Type NVL object (unit of work child property).
        /// </summary>
        /// <value>The Doc Type NVL.</value>
        public DocTypeNVL DocTypeNVL
        {
            get { return GetProperty(DocTypeNVLProperty); }
            private set { LoadProperty(DocTypeNVLProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="DocEditGetter"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the DocEditGetter to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DocEditGetter"/> unit of objects.</returns>
        public static DocEditGetter GetDocEditGetter(int docID)
        {
            return DataPortal.Fetch<DocEditGetter>(docID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocEditGetter"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocEditGetter()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocEditGetter"/> unit of objects, based on given criteria.
        /// </summary>
        /// <param name="docID">The fetch criteria.</param>
        protected void DataPortal_Fetch(int docID)
        {
            LoadProperty(DocProperty, Doc.GetDoc(docID));
            LoadProperty(DocTypeNVLProperty, DocTypeNVL.GetDocTypeNVL());
        }

        #endregion

    }
}
