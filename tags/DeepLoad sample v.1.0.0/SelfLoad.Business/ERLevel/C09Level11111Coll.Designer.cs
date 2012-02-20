using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C09Level11111Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="C09Level11111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="C08Level1111"/> editable child object.<br/>
    /// The items of the collection are <see cref="C10Level11111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class C09Level11111Coll : BusinessListBase<C09Level11111Coll, C10Level11111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="C10Level11111"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_1_1_1_ID)
        {
            foreach (var c10Level11111 in this)
            {
                if (c10Level11111.Level_1_1_1_1_1_ID == level_1_1_1_1_1_ID)
                {
                    Remove(c10Level11111);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="C10Level11111"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C10Level11111 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_1_1_1_ID)
        {
            foreach (var c10Level11111 in this)
            {
                if (c10Level11111.Level_1_1_1_1_1_ID == level_1_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="C10Level11111"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="level_1_1_1_1_1_ID">The Level_1_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C10Level11111 is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int level_1_1_1_1_1_ID)
        {
            foreach (var c10Level11111 in this.DeletedList)
            {
                if (c10Level11111.Level_1_1_1_1_1_ID == level_1_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C09Level11111Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="C09Level11111Coll"/> collection.</returns>
        internal static C09Level11111Coll NewC09Level11111Coll()
        {
            return DataPortal.CreateChild<C09Level11111Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C09Level11111Coll"/> object, based on given parameters.
        /// </summary>
        /// <param name="narentID1">The NarentID1 parameter of the C09Level11111Coll to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C09Level11111Coll"/> object.</returns>
        internal static C09Level11111Coll GetC09Level11111Coll(int narentID1)
        {
            return DataPortal.FetchChild<C09Level11111Coll>(narentID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C09Level11111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C09Level11111Coll()
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
        /// Loads a <see cref="C09Level11111Coll"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="narentID1">The Narent ID1.</param>
        protected void Child_Fetch(int narentID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC09Level11111Coll", ctx.Connection))
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
        /// Loads all <see cref="C09Level11111Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(C10Level11111.GetC10Level11111(dr));
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
