using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D05Level111Coll (editable child list).<br/>
    /// This is a generated base class of <see cref="D05Level111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="D04Level11"/> editable child object.<br/>
    /// The items of the collection are <see cref="D06Level111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class D05Level111Coll : BusinessListBase<D05Level111Coll, D06Level111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="D06Level111"/> item from the collection.
        /// </summary>
        /// <param name="level_1_1_1_ID">The Level_1_1_1_ID of the item to be removed.</param>
        public void Remove(int level_1_1_1_ID)
        {
            foreach (D06Level111 d06Level111 in this)
            {
                if (d06Level111.Level_1_1_1_ID == level_1_1_1_ID)
                {
                      Remove(d06Level111);
                      break;
                }
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D05Level111Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="D05Level111Coll"/> collection.</returns>
        internal static D05Level111Coll NewD05Level111Coll()
        {
            return DataPortal.CreateChild<D05Level111Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D05Level111Coll"/> object, based on given parameters.
        /// </summary>
        /// <param name="marentID1">The MarentID1 parameter of the D05Level111Coll to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D05Level111Coll"/> object.</returns>
        internal static D05Level111Coll GetD05Level111Coll(int marentID1)
        {
            return DataPortal.FetchChild<D05Level111Coll>(marentID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D05Level111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D05Level111Coll()
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
        /// Loads a <see cref="D05Level111Coll"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="marentID1">The Marent ID1.</param>
        protected void Child_Fetch(int marentID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD05Level111Coll", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MarentID1", marentID1).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, marentID1);
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
        /// Loads all <see cref="D05Level111Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(D06Level111.GetD06Level111(dr));
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
