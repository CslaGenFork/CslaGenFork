//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocStatusEditDynaColl
// ObjectType:  DocStatusEditDynaColl
// CSLAType:    DynamicEditableRootCollection

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using UsingLibrary;

namespace DocStore.Business
{

    /// <summary>
    /// DocStatusEditDynaColl (dynamic root list).<br/>
    /// This is a generated <see cref="DocStatusEditDynaColl"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="DocStatusEditDyna"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class DocStatusEditDynaColl : MyDynamicBindingListBase<DocStatusEditDyna>
#else
    public partial class DocStatusEditDynaColl : MyDynamicListBase<DocStatusEditDyna>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="DocStatusEditDyna"/> item from the collection.
        /// </summary>
        /// <param name="docStatusID">The DocStatusID of the item to be removed.</param>
        public void Remove(int docStatusID)
        {
            foreach (var docStatusEditDyna in this)
            {
                if (docStatusEditDyna.DocStatusID == docStatusID)
                {
                    Remove(docStatusEditDyna);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="DocStatusEditDyna"/> item is in the collection.
        /// </summary>
        /// <param name="docStatusID">The DocStatusID of the item to search for.</param>
        /// <returns><c>true</c> if the DocStatusEditDyna is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int docStatusID)
        {
            foreach (var docStatusEditDyna in this)
            {
                if (docStatusEditDyna.DocStatusID == docStatusID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocStatusEditDynaColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocStatusEditDynaColl"/> collection.</returns>
        public static DocStatusEditDynaColl NewDocStatusEditDynaColl()
        {
            return DataPortal.Create<DocStatusEditDynaColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocStatusEditDynaColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="DocStatusEditDynaColl"/> collection.</returns>
        public static DocStatusEditDynaColl GetDocStatusEditDynaColl()
        {
            return DataPortal.Fetch<DocStatusEditDynaColl>();
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="DocStatusEditDynaColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewDocStatusEditDynaColl(EventHandler<DataPortalResult<DocStatusEditDynaColl>> callback)
        {
            DataPortal.BeginCreate<DocStatusEditDynaColl>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="DocStatusEditDynaColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetDocStatusEditDynaColl(EventHandler<DataPortalResult<DocStatusEditDynaColl>> callback)
        {
            DataPortal.BeginFetch<DocStatusEditDynaColl>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocStatusEditDynaColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocStatusEditDynaColl()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocStatusEditDynaColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetDocStatusEditDynaColl", ctx.Connection))
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
        /// Loads all <see cref="DocStatusEditDynaColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DocStatusEditDyna.GetDocStatusEditDyna(dr));
            }
            RaiseListChangedEvents = rlce;
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
