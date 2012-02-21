using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess.ERLevel;
using SelfLoadROSoftDelete.DataAccess;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G03_Continent_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="G03_Continent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="G02_Continent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G03_Continent_ReChild : ReadOnlyBase<G03_Continent_ReChild>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_Child_NameProperty = RegisterProperty<string>(p => p.Continent_Child_Name, "2_SubContinents Child Name");
        /// <summary>
        /// Gets the 2_SubContinents Child Name.
        /// </summary>
        /// <value>The 2_SubContinents Child Name.</value>
        public string Continent_Child_Name
        {
            get { return GetProperty(Continent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G03_Continent_ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID2">The Continent_ID2 parameter of the G03_Continent_ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G03_Continent_ReChild"/> object.</returns>
        internal static G03_Continent_ReChild GetG03_Continent_ReChild(int continent_ID2)
        {
            return DataPortal.FetchChild<G03_Continent_ReChild>(continent_ID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G03_Continent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G03_Continent_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G03_Continent_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID2">The Continent ID2.</param>
        protected void Child_Fetch(int continent_ID2)
        {
            var args = new DataPortalHookArgs(continent_ID2);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG03_Continent_ReChildDal>();
                var data = dal.Fetch(continent_ID2);
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
        /// Loads a <see cref="G03_Continent_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Continent_Child_NameProperty, dr.GetString("Continent_Child_Name"));
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
