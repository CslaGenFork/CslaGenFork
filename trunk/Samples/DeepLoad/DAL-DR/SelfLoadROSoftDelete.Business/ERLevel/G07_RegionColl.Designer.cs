using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess.ERLevel;
using SelfLoadROSoftDelete.DataAccess;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G07_RegionColl (read only list).<br/>
    /// This is a generated base class of <see cref="G07_RegionColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="G06_Country"/> read only object.<br/>
    /// The items of the collection are <see cref="G08_Region"/> objects.
    /// </remarks>
    [Serializable]
    public partial class G07_RegionColl : ReadOnlyListBase<G07_RegionColl, G08_Region>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="G08_Region"/> item is in the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the G08_Region is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int region_ID)
        {
            foreach (var g08_Region in this)
            {
                if (g08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G07_RegionColl"/> object, based on given parameters.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent_Country_ID parameter of the G07_RegionColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G07_RegionColl"/> object.</returns>
        internal static G07_RegionColl GetG07_RegionColl(int parent_Country_ID)
        {
            return DataPortal.FetchChild<G07_RegionColl>(parent_Country_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G07_RegionColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G07_RegionColl()
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
        /// Loads a <see cref="G07_RegionColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent Country ID.</param>
        protected void Child_Fetch(int parent_Country_ID)
        {
            var args = new DataPortalHookArgs(parent_Country_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG07_RegionCollDal>();
                var data = dal.Fetch(parent_Country_ID);
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
        /// Loads all <see cref="G07_RegionColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(G08_Region.GetG08_Region(dr));
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
