using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G05Level111Coll (read only list).<br/>
    /// This is a generated base class of <see cref="G05Level111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="G04Level11"/> read only object.<br/>
    /// The items of the collection are <see cref="G06Level111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class G05Level111Coll : ReadOnlyListBase<G05Level111Coll, G06Level111>
    {

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G05Level111Coll"/> object, based on given parameters.
        /// </summary>
        /// <param name="marentID1">The MarentID1 parameter of the G05Level111Coll to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G05Level111Coll"/> object.</returns>
        internal static G05Level111Coll GetG05Level111Coll(int marentID1)
        {
            return DataPortal.FetchChild<G05Level111Coll>(marentID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G05Level111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G05Level111Coll()
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
        /// Loads a <see cref="G05Level111Coll"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="marentID1">The Marent ID1.</param>
        protected void Child_Fetch(int marentID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG05Level111Coll", ctx.Connection))
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
        /// Loads all <see cref="G05Level111Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(G06Level111.GetG06Level111(dr));
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
