using System;
using Csla;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G07_Country_Child (read only object).<br/>
    /// This is a generated base class of <see cref="G07_Country_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="G06_Country"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G07_Country_Child : ReadOnlyBase<G07_Country_Child>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Country_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Country_Child_NameProperty = RegisterProperty<string>(p => p.Country_Child_Name, "Regions Child Name");
        /// <summary>
        /// Gets the Regions Child Name.
        /// </summary>
        /// <value>The Regions Child Name.</value>
        public string Country_Child_Name
        {
            get { return GetProperty(Country_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G07_Country_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="country_ID1">The Country_ID1 parameter of the G07_Country_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G07_Country_Child"/> object.</returns>
        internal static G07_Country_Child GetG07_Country_Child(int country_ID1)
        {
            return DataPortal.FetchChild<G07_Country_Child>(country_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G07_Country_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G07_Country_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G07_Country_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="country_ID1">The Country ID1.</param>
        protected void Child_Fetch(int country_ID1)
        {
            var args = new DataPortalHookArgs(country_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG07_Country_ChildDal>();
                var data = dal.Fetch(country_ID1);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        /// <summary>
        /// Loads a <see cref="G07_Country_Child"/> object from the given <see cref="G07_Country_ChildDto"/>.
        /// </summary>
        /// <param name="data">The G07_Country_ChildDto to use.</param>
        private void Fetch(G07_Country_ChildDto data)
        {
            // Value properties
            LoadProperty(Country_Child_NameProperty, data.Country_Child_Name);
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
