using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G07Level1111Coll (read only list).<br/>
    /// This is a generated base class of <see cref="G07Level1111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="G06Level111"/> read only object.<br/>
    /// The items of the collection are <see cref="G08Level1111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class G07Level1111Coll : ReadOnlyListBase<G07Level1111Coll, G08Level1111>
    {

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G07Level1111Coll"/> object, based on given parameters.
        /// </summary>
        /// <param name="larentID1">The LarentID1 parameter of the G07Level1111Coll to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G07Level1111Coll"/> object.</returns>
        internal static G07Level1111Coll GetG07Level1111Coll(int larentID1)
        {
            return DataPortal.FetchChild<G07Level1111Coll>(larentID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G07Level1111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G07Level1111Coll()
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
        /// Loads a <see cref="G07Level1111Coll"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="larentID1">The Larent ID1.</param>
        protected void Child_Fetch(int larentID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG07Level1111Coll", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LarentID1", larentID1).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, larentID1);
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
        /// Loads all <see cref="G07Level1111Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(G08Level1111.GetG08Level1111(dr));
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
