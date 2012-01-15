using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D11Level111111Coll (read only list).<br/>
    /// This is a generated base class of <see cref="D11Level111111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="D10Level11111"/> read only object.<br/>
    /// The items of the collection are <see cref="D12Level111111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class D11Level111111Coll : ReadOnlyListBase<D11Level111111Coll, D12Level111111>
    {

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D11Level111111Coll"/> object, based on given parameters.
        /// </summary>
        /// <param name="qarentID1">The QarentID1 parameter of the D11Level111111Coll to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D11Level111111Coll"/> object.</returns>
        internal static D11Level111111Coll GetD11Level111111Coll(int qarentID1)
        {
            return DataPortal.FetchChild<D11Level111111Coll>(qarentID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D11Level111111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D11Level111111Coll()
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
        /// Loads a <see cref="D11Level111111Coll"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="qarentID1">The Qarent ID1.</param>
        protected void Child_Fetch(int qarentID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD11Level111111Coll", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QarentID1", qarentID1).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, qarentID1);
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
        /// Loads all <see cref="D11Level111111Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(D12Level111111.GetD12Level111111(dr));
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
