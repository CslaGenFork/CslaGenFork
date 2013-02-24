using System;
using Csla;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERLevel;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C11_City_Child (read only object).<br/>
    /// This is a generated base class of <see cref="C11_City_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="C10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C11_City_Child : ReadOnlyBase<C11_City_Child>
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
        /// Factory method. Loads a <see cref="C11_City_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="city_ID1">The City_ID1 parameter of the C11_City_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C11_City_Child"/> object.</returns>
        internal static C11_City_Child GetC11_City_Child(int city_ID1)
        {
            return DataPortal.FetchChild<C11_City_Child>(city_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C11_City_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C11_City_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C11_City_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="city_ID1">The City ID1.</param>
        protected void Child_Fetch(int city_ID1)
        {
            var args = new DataPortalHookArgs(city_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadRO.GetManager())
            {
                var dal = dalManager.GetProvider<IC11_City_ChildDal>();
                var data = dal.Fetch(city_ID1);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        /// <summary>
        /// Loads a <see cref="C11_City_Child"/> object from the given <see cref="C11_City_ChildDto"/>.
        /// </summary>
        /// <param name="data">The C11_City_ChildDto to use.</param>
        private void Fetch(C11_City_ChildDto data)
        {
            // Value properties
            City_Child_Name = data.City_Child_Name;
            var args = new DataPortalHookArgs(data);
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
