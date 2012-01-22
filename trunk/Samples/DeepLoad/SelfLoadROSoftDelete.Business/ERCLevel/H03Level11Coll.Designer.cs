using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H03Level11Coll (read only list).<br/>
    /// This is a generated base class of <see cref="H03Level11Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="H02Level1"/> read only object.<br/>
    /// The items of the collection are <see cref="H04Level11"/> objects.
    /// </remarks>
    [Serializable]
    public partial class H03Level11Coll : ReadOnlyListBase<H03Level11Coll, H04Level11>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="H04Level11"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_ID">The Level_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the H04Level11 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_ID)
        {
            foreach (var h04Level11 in this)
            {
                if (h04Level11.Level_1_1_ID == level_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H03Level11Coll"/> object, based on given parameters.
        /// </summary>
        /// <param name="parentID1">The ParentID1 parameter of the H03Level11Coll to fetch.</param>
        /// <returns>A reference to the fetched <see cref="H03Level11Coll"/> object.</returns>
        internal static H03Level11Coll GetH03Level11Coll(int parentID1)
        {
            return DataPortal.FetchChild<H03Level11Coll>(parentID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H03Level11Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H03Level11Coll()
        {
            // Prevent direct creation

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
        /// Loads a <see cref="H03Level11Coll"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parentID1">The Parent ID1.</param>
        protected void Child_Fetch(int parentID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH03Level11Coll", ctx.Connection))
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
        /// Loads all <see cref="H03Level11Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(H04Level11.GetH04Level11(dr));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
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
