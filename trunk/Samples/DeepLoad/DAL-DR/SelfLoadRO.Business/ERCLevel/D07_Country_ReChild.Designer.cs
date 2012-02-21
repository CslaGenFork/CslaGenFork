using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess.ERCLevel;
using SelfLoadRO.DataAccess;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D07_Country_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="D07_Country_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="D06_Country"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D07_Country_ReChild : ReadOnlyBase<D07_Country_ReChild>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Country_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Country_Child_NameProperty = RegisterProperty<string>(p => p.Country_Child_Name, "4_Regions Child Name");
        /// <summary>
        /// Gets the 4_Regions Child Name.
        /// </summary>
        /// <value>The 4_Regions Child Name.</value>
        public string Country_Child_Name
        {
            get { return GetProperty(Country_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D07_Country_ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="country_ID2">The Country_ID2 parameter of the D07_Country_ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D07_Country_ReChild"/> object.</returns>
        internal static D07_Country_ReChild GetD07_Country_ReChild(int country_ID2)
        {
            return DataPortal.FetchChild<D07_Country_ReChild>(country_ID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D07_Country_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D07_Country_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D07_Country_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="country_ID2">The Country ID2.</param>
        protected void Child_Fetch(int country_ID2)
        {
            var args = new DataPortalHookArgs(country_ID2);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadRO.GetManager())
            {
                var dal = dalManager.GetProvider<ID07_Country_ReChildDal>();
                var data = dal.Fetch(country_ID2);
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
                BusinessRules.CheckRules();
            }
        }

        /// <summary>
        /// Loads a <see cref="D07_Country_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_Child_NameProperty, dr.GetString("Country_Child_Name"));
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
