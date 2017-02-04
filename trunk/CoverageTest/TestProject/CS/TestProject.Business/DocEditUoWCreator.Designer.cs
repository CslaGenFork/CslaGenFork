using System;
using Csla;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// DocEditCreator (creator unit of work pattern).<br/>
    /// This is a generated base class of <see cref="DocEditCreator"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Attributable]
    [Serializable]
    public partial class DocEditCreator : MyBusinessBase<DocEditCreator>, IHaveInterface
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
        /// Factory method. Creates a new <see cref="DocEditCreator"/> unit of objects.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocEditCreator"/> unit of objects.</returns>
        public static DocEditCreator NewDocEditCreator()
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            return DataPortal.Fetch<DocEditCreator>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocEditCreator"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocEditCreator()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Creates a new <see cref="DocEditCreator"/> unit of objects.
        /// </summary>
        /// <remarks>
        /// ReadOnlyBase&lt;T&gt; doesn't allow the use of DataPortal_Create and thus DataPortal_Fetch is used.
        /// </remarks>
        protected void DataPortal_Fetch()
        {
            LoadProperty(DocProperty, Doc.NewDoc());
            LoadProperty(DocTypeNVLProperty, DocTypeNVL.GetDocTypeNVL());
        }

        #endregion

    }
}
