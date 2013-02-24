using System;
using Csla;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H03_Continent_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="H03_Continent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="H02_Continent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H03_Continent_ReChild : ReadOnlyBase<H03_Continent_ReChild>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_Child_NameProperty = RegisterProperty<string>(p => p.Continent_Child_Name, "SubContinents Child Name");
        /// <summary>
        /// Gets the SubContinents Child Name.
        /// </summary>
        /// <value>The SubContinents Child Name.</value>
        public string Continent_Child_Name
        {
            get { return GetProperty(Continent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H03_Continent_ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID2">The Continent_ID2 parameter of the H03_Continent_ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="H03_Continent_ReChild"/> object.</returns>
        internal static H03_Continent_ReChild GetH03_Continent_ReChild(int continent_ID2)
        {
            return DataPortal.FetchChild<H03_Continent_ReChild>(continent_ID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H03_Continent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H03_Continent_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H03_Continent_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID2">The Continent ID2.</param>
        protected void Child_Fetch(int continent_ID2)
        {
            var args = new DataPortalHookArgs(continent_ID2);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IH03_Continent_ReChildDal>();
                var data = dal.Fetch(continent_ID2);
                Fetch(data);
            }
            OnFetchPost(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Loads a <see cref="H03_Continent_ReChild"/> object from the given <see cref="H03_Continent_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The H03_Continent_ReChildDto to use.</param>
        private void Fetch(H03_Continent_ReChildDto data)
        {
            // Value properties
            LoadProperty(Continent_Child_NameProperty, data.Continent_Child_Name);
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
