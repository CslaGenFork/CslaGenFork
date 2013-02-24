using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H11_City_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="H11_City_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="H10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H11_City_ReChild : ReadOnlyBase<H11_City_ReChild>
    {

        #region Business Properties

        /// <summary>
        /// Gets the CityRoads Child Name.
        /// </summary>
        /// <value>The CityRoads Child Name.</value>
        public string City_Child_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H11_City_ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="city_ID2">The City_ID2 parameter of the H11_City_ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="H11_City_ReChild"/> object.</returns>
        internal static H11_City_ReChild GetH11_City_ReChild(int city_ID2)
        {
            return DataPortal.FetchChild<H11_City_ReChild>(city_ID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H11_City_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H11_City_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H11_City_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="city_ID2">The City ID2.</param>
        protected void Child_Fetch(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, city_ID2);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="H11_City_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            City_Child_Name = dr.GetString("City_Child_Name");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
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

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
