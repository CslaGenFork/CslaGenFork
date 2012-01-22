using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C03Level11Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="C03Level11Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="C02Level1"/> editable root object.<br/>
    /// The items of the collection are <see cref="C04Level11"/> objects.
    /// </remarks>
    [Serializable]
    public partial class C03Level11Coll : BusinessListBase<C03Level11Coll, C04Level11>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="C04Level11"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_ID)
        {
            foreach (var c04Level11 in this)
            {
                if (c04Level11.Level_1_1_ID == level_1_1_ID)
                {
                    Remove(c04Level11);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="C04Level11"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C04Level11 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_ID)
        {
            foreach (var c04Level11 in this)
            {
                if (c04Level11.Level_1_1_ID == level_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="C04Level11"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C04Level11 is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int level_1_1_ID)
        {
            foreach (var c04Level11 in this.DeletedList)
            {
                if (c04Level11.Level_1_1_ID == level_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C03Level11Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="C03Level11Coll"/> collection.</returns>
        internal static C03Level11Coll NewC03Level11Coll()
        {
            return DataPortal.CreateChild<C03Level11Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C03Level11Coll"/> object, based on given parameters.
        /// </summary>
        /// <param name="parentID1">The ParentID1 parameter of the C03Level11Coll to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C03Level11Coll"/> object.</returns>
        internal static C03Level11Coll GetC03Level11Coll(int parentID1)
        {
            return DataPortal.FetchChild<C03Level11Coll>(parentID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C03Level11Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C03Level11Coll()
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
        /// Loads a <see cref="C03Level11Coll"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parentID1">The Parent ID1.</param>
        protected void Child_Fetch(int parentID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC03Level11Coll", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ParentID1", parentID1).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, parentID1);
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
        /// Loads all <see cref="C03Level11Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(C04Level11.GetC04Level11(dr));
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
