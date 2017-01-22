//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    CircList
// ObjectType:  CircList
// CSLAType:    ReadOnlyCollection

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using UsingLibrary;

namespace DocStore.Business.Circulations
{

    /// <summary>
    /// Collection of circulations of documents and folders (read only list).<br/>
    /// This is a generated base class of <see cref="CircList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="CircInfo"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class CircList : MyReadOnlyBindingListBase<CircList, CircInfo>, IHaveInterface, IHaveGenericInterface<CircList>
#else
    public partial class CircList : MyReadOnlyListBase<CircList, CircInfo>, IHaveInterface, IHaveGenericInterface<CircList>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="CircInfo"/> item is in the collection.
        /// </summary>
        /// <param name="circID">The CircID of the item to search for.</param>
        /// <returns><c>true</c> if the CircInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int circID)
        {
            foreach (var circInfo in this)
            {
                if (circInfo.CircID == circID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="CircList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the CircList to fetch.</param>
        /// <param name="folderID">The FolderID parameter of the CircList to fetch.</param>
        /// <returns>A reference to the fetched <see cref="CircList"/> collection.</returns>
        public static CircList GetCircList(int? docID, int? folderID)
        {
            return DataPortal.Fetch<CircList>(new CriteriaGetByObject(docID, folderID));
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="CircList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the CircList to fetch.</param>
        /// <param name="folderID">The FolderID parameter of the CircList to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetCircList(int? docID, int? folderID, EventHandler<DataPortalResult<CircList>> callback)
        {
            DataPortal.BeginFetch<CircList>(new CriteriaGetByObject(docID, folderID), callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CircList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CircList()
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

        #region Criteria

        /// <summary>
        /// CriteriaGetByObject criteria.
        /// </summary>
        [Serializable]
        protected class CriteriaGetByObject : CriteriaBase<CriteriaGetByObject>
        {

            /// <summary>
            /// Maintains metadata about <see cref="DocID"/> property.
            /// </summary>
            public static readonly PropertyInfo<int?> DocIDProperty = RegisterProperty<int?>(p => p.DocID);
            /// <summary>
            /// Gets or sets the Doc ID.
            /// </summary>
            /// <value>The Doc ID.</value>
            public int? DocID
            {
                get { return ReadProperty(DocIDProperty); }
                set { LoadProperty(DocIDProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="FolderID"/> property.
            /// </summary>
            public static readonly PropertyInfo<int?> FolderIDProperty = RegisterProperty<int?>(p => p.FolderID);
            /// <summary>
            /// Gets or sets the Folder ID.
            /// </summary>
            /// <value>The Folder ID.</value>
            public int? FolderID
            {
                get { return ReadProperty(FolderIDProperty); }
                set { LoadProperty(FolderIDProperty, value); }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="CriteriaGetByObject"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public CriteriaGetByObject()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="CriteriaGetByObject"/> class.
            /// </summary>
            /// <param name="docID">The DocID.</param>
            /// <param name="folderID">The FolderID.</param>
            public CriteriaGetByObject(int? docID, int? folderID)
            {
                DocID = docID;
                FolderID = folderID;
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (obj is CriteriaGetByObject)
                {
                    var c = (CriteriaGetByObject) obj;
                    if (!DocID.Equals(c.DocID))
                        return false;
                    if (!FolderID.Equals(c.FolderID))
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
                return string.Concat("CriteriaGetByObject", DocID.ToString(), FolderID.ToString()).GetHashCode();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="CircList"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        protected void DataPortal_Fetch(CriteriaGetByObject crit)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetCircList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", crit.DocID == null ? (object)DBNull.Value : crit.DocID.Value).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FolderID", crit.FolderID == null ? (object)DBNull.Value : crit.FolderID.Value).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, crit);
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
        /// Loads all <see cref="CircList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(CircInfo.GetCircInfo(dr));
            }
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
