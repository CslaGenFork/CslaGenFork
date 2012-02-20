using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G09Level11111Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="G09Level11111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="G08Level1111"/> editable child object.<br/>
    /// The items of the collection are <see cref="G10Level11111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class G09Level11111Coll : BusinessListBase<G09Level11111Coll, G10Level11111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="G10Level11111"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_1_1_1_ID)
        {
            foreach (var g10Level11111 in this)
            {
                if (g10Level11111.Level_1_1_1_1_1_ID == level_1_1_1_1_1_ID)
                {
                    Remove(g10Level11111);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="G10Level11111"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the G10Level11111 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_1_1_1_ID)
        {
            foreach (var g10Level11111 in this)
            {
                if (g10Level11111.Level_1_1_1_1_1_ID == level_1_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="G10Level11111"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the G10Level11111 is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int level_1_1_1_1_1_ID)
        {
            foreach (var g10Level11111 in this.DeletedList)
            {
                if (g10Level11111.Level_1_1_1_1_1_ID == level_1_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="G09Level11111Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="G09Level11111Coll"/> collection.</returns>
        internal static G09Level11111Coll NewG09Level11111Coll()
        {
            return DataPortal.CreateChild<G09Level11111Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="G09Level11111Coll"/> object, based on given parameters.
        /// </summary>
        /// <param name="narentID1">The NarentID1 parameter of the G09Level11111Coll to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G09Level11111Coll"/> object.</returns>
        internal static G09Level11111Coll GetG09Level11111Coll(int narentID1)
        {
            return DataPortal.FetchChild<G09Level11111Coll>(narentID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G09Level11111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G09Level11111Coll()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();

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
        /// Loads a <see cref="G09Level11111Coll"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="narentID1">The Narent ID1.</param>
        protected void Child_Fetch(int narentID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG09Level11111Coll", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NarentID1", narentID1).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, narentID1);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            foreach (var item in this)
            {
                item.FetchChildren();
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
        /// Loads all <see cref="G09Level11111Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(G10Level11111.GetG10Level11111(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Pseudo Events

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
