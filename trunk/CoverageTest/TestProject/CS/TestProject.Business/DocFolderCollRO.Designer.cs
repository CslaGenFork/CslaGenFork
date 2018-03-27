using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// Collection of folders where this document is archived (read only list).<br/>
    /// This is a generated <see cref="DocFolderCollRO"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="DocRO"/> read only object.<br/>
    /// The items of the collection are <see cref="DocFolderRO"/> objects.
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class DocFolderCollRO : ReadOnlyBindingListBase<DocFolderCollRO, DocFolderRO>, IHaveInterface
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="DocFolderRO"/> item is in the collection.
        /// </summary>
        /// <param name="folderID">The FolderID of the item to search for.</param>
        /// <returns><c>true</c> if the DocFolderRO is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int folderID)
        {
            foreach (var docFolderRO in this)
            {
                if (docFolderRO.FolderID == folderID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocFolderCollRO"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocFolderCollRO()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads all <see cref="DocFolderCollRO"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<DocFolderRO>(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

    }
}
