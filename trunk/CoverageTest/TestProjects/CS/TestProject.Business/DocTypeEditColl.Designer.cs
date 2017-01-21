using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using UsingClass;

namespace TestProject.Business
{

    /// <summary>
    /// Collection of document types (editable root list).<br/>
    /// This is a generated base class of <see cref="DocTypeEditColl"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="DocTypeEdit"/> objects.
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class DocTypeEditColl : BusinessBindingListBase<DocTypeEditColl, DocTypeEdit>, IHaveInterface
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="DocTypeEdit"/> item from the collection.
        /// </summary>
        /// <param name="docTypeID">The DocTypeID of the item to be removed.</param>
        public void Remove(int docTypeID)
        {
            foreach (var docTypeEdit in this)
            {
                if (docTypeEdit.DocTypeID == docTypeID)
                {
                    Remove(docTypeEdit);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="DocTypeEdit"/> item is in the collection.
        /// </summary>
        /// <param name="docTypeID">The DocTypeID of the item to search for.</param>
        /// <returns><c>true</c> if the DocTypeEdit is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int docTypeID)
        {
            foreach (var docTypeEdit in this)
            {
                if (docTypeEdit.DocTypeID == docTypeID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="DocTypeEdit"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="docTypeID">The DocTypeID of the item to search for.</param>
        /// <returns><c>true</c> if the DocTypeEdit is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int docTypeID)
        {
            foreach (var docTypeEdit in DeletedList)
            {
                if (docTypeEdit.DocTypeID == docTypeID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocTypeEditColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocTypeEditColl"/> collection.</returns>
        public static DocTypeEditColl NewDocTypeEditColl()
        {
            return DataPortal.Create<DocTypeEditColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocTypeEditColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="DocTypeEditColl"/> collection.</returns>
        public static DocTypeEditColl GetDocTypeEditColl()
        {
            return DataPortal.Fetch<DocTypeEditColl>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocTypeEditColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocTypeEditColl()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnDocTypeEditCollSaved;

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Cache Invalidation

        private void OnDocTypeEditCollSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client
            DocTypeList.InvalidateCache();
            DocTypeNVL.InvalidateCache();
        }

        /// <summary>
        /// Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        /// </summary>
        /// <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        protected override void DataPortal_OnDataPortalInvokeComplete(Csla.DataPortalEventArgs e)
        {
            if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server &&
                e.Operation == DataPortalOperations.Update)
            {
                // this runs on the server
                DocTypeList.InvalidateCache();
                DocTypeNVL.InvalidateCache();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocTypeEditColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("GetDocTypeEditColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="DocTypeEditColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<DocTypeEdit>(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DocTypeEditColl"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.TestProjectConnection, false))
            {
                base.Child_Update();
                ctx.Commit();
            }
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
