using System;
using Csla;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// DocEditCreatorGetter (creator and getter unit of work pattern).<br/>
    /// This is a generated <see cref="DocEditCreatorGetter"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Attributable]
    [Serializable]
    public partial class DocEditCreatorGetter : MyBusinessBase<DocEditCreatorGetter>, IHaveInterface
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
        /// Factory method. Creates a new <see cref="DocEditCreatorGetter"/> unit of objects.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocEditCreatorGetter"/> unit of objects.</returns>
        public static DocEditCreatorGetter NewDocEditCreatorGetter()
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            return DataPortal.Fetch<DocEditCreatorGetter>(new Criteria1(true, new int()));
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocEditCreatorGetter"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the DocEditCreatorGetter to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DocEditCreatorGetter"/> unit of objects.</returns>
        public static DocEditCreatorGetter GetDocEditCreatorGetter(int docID)
        {
            return DataPortal.Fetch<DocEditCreatorGetter>(new Criteria1(false, docID));
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocEditCreatorGetter"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocEditCreatorGetter()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Criteria

        /// <summary>
        /// Criteria1 criteria.
        /// </summary>
        [Serializable]
        protected class Criteria1 : CriteriaBase<Criteria1>
        {

            /// <summary>
            /// Maintains metadata about <see cref="CreateDoc"/> property.
            /// </summary>
            public static readonly PropertyInfo<bool> CreateDocProperty = RegisterProperty<bool>(p => p.CreateDoc, "Create Doc");
            /// <summary>
            /// Gets or sets the Create Doc.
            /// </summary>
            /// <value><c>true</c> if Create Doc; otherwise, <c>false</c>.</value>
            public bool CreateDoc
            {
                get { return ReadProperty(CreateDocProperty); }
                set { LoadProperty(CreateDocProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="DocID"/> property.
            /// </summary>
            public static readonly PropertyInfo<int> DocIDProperty = RegisterProperty<int>(p => p.DocID, "Doc ID");
            /// <summary>
            /// Gets or sets the Doc ID.
            /// </summary>
            /// <value>The Doc ID.</value>
            public int DocID
            {
                get { return ReadProperty(DocIDProperty); }
                set { LoadProperty(DocIDProperty, value); }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria1"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public Criteria1()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria1"/> class.
            /// </summary>
            /// <param name="createDoc">The CreateDoc.</param>
            /// <param name="docID">The DocID.</param>
            public Criteria1(bool createDoc, int docID)
            {
                CreateDoc = createDoc;
                DocID = docID;
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (obj is Criteria1)
                {
                    var c = (Criteria1) obj;
                    if (!CreateDoc.Equals(c.CreateDoc))
                        return false;
                    if (!DocID.Equals(c.DocID))
                        return false;
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                return string.Concat("Criteria1", CreateDoc.ToString(), DocID.ToString()).GetHashCode();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Creates or loads a <see cref="DocEditCreatorGetter"/> unit of objects, based on given criteria.
        /// </summary>
        /// <param name="crit">The create/fetch criteria.</param>
        protected void DataPortal_Fetch(Criteria1 crit)
        {
            if (crit.CreateDoc)
                LoadProperty(DocProperty, Doc.NewDoc());
            else
                LoadProperty(DocProperty, Doc.GetDoc(crit.DocID));
            LoadProperty(DocTypeNVLProperty, DocTypeNVL.GetDocTypeNVL());
        }

        #endregion

    }
}
