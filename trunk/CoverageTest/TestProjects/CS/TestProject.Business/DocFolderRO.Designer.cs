using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using UsingClass;

namespace TestProject.Business
{

    /// <summary>
    /// Folder where this document is archived (read only object).<br/>
    /// This is a generated base class of <see cref="DocFolderRO"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="DocFolderCollRO"/> collection.
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class DocFolderRO : ReadOnlyBase<DocFolderRO>, IHaveInterface
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="FolderID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> FolderIDProperty = RegisterProperty<int>(p => p.FolderID, "Folder ID");
        /// <summary>
        /// Gets the Folder ID.
        /// </summary>
        /// <value>The Folder ID.</value>
        public int FolderID
        {
            get { return GetProperty(FolderIDProperty); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocFolderRO"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocFolderRO()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocFolderRO"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(FolderIDProperty, dr.GetInt32("FolderID"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
