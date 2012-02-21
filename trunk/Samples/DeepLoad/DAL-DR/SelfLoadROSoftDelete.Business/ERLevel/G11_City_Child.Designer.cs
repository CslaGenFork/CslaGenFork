using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess.ERLevel;
using SelfLoadROSoftDelete.DataAccess;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G11_City_Child (read only object).<br/>
    /// This is a generated base class of <see cref="G11_City_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="G10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G11_City_Child : ReadOnlyBase<G11_City_Child>
    {

        #region Business Properties

        /// <summary>
        /// Gets or sets the 6_CityRoads Child Name.
        /// </summary>
        /// <value>The 6_CityRoads Child Name.</value>
        public string City_Child_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G11_City_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="city_ID1">The City_ID1 parameter of the G11_City_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G11_City_Child"/> object.</returns>
        internal static G11_City_Child GetG11_City_Child(int city_ID1)
        {
            return DataPortal.FetchChild<G11_City_Child>(city_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G11_City_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G11_City_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G11_City_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="city_ID1">The City ID1.</param>
        protected void Child_Fetch(int city_ID1)
        {
            var args = new DataPortalHookArgs(city_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG11_City_ChildDal>();
                var data = dal.Fetch(city_ID1);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        private void Fetch(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="G11_City_Child"/> object from the given SafeDataReader.
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
