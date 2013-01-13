using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H01_ContinentColl (read only list).<br/>
    /// This is a generated base class of <see cref="H01_ContinentColl"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="H02_Continent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class H01_ContinentColl : ReadOnlyListBase<H01_ContinentColl, H02_Continent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="H02_Continent"/> item is in the collection.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the H02_Continent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int continent_ID)
        {
            foreach (var h02_Continent in this)
            {
                if (h02_Continent.Continent_ID == continent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H01_ContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="H01_ContinentColl"/> collection.</returns>
        public static H01_ContinentColl GetH01_ContinentColl()
        {
            return DataPortal.Fetch<H01_ContinentColl>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H01_ContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H01_ContinentColl()
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
        /// Loads a <see cref="H01_ContinentColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            var args = new DataPortalHookArgs();
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IH01_ContinentCollDal>();
                var data = dal.Fetch();
                LoadCollection(data);
            }
            OnFetchPost(args);
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        }

        private void LoadCollection(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="H01_ContinentColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(H02_Continent.GetH02_Continent(dr));
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
