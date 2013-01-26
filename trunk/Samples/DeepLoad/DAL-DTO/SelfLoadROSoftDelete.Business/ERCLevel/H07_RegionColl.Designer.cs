using System;
using System.Collections.Generic;
using Csla;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H07_RegionColl (read only list).<br/>
    /// This is a generated base class of <see cref="H07_RegionColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="H06_Country"/> read only object.<br/>
    /// The items of the collection are <see cref="H08_Region"/> objects.
    /// </remarks>
    [Serializable]
    public partial class H07_RegionColl : ReadOnlyListBase<H07_RegionColl, H08_Region>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="H08_Region"/> item is in the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the H08_Region is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int region_ID)
        {
            foreach (var h08_Region in this)
            {
                if (h08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H07_RegionColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent_Country_ID parameter of the H07_RegionColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="H07_RegionColl"/> collection.</returns>
        internal static H07_RegionColl GetH07_RegionColl(int parent_Country_ID)
        {
            return DataPortal.FetchChild<H07_RegionColl>(parent_Country_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H07_RegionColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H07_RegionColl()
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
        /// Loads a <see cref="H07_RegionColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent Country ID.</param>
        protected void Child_Fetch(int parent_Country_ID)
        {
            var args = new DataPortalHookArgs(parent_Country_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IH07_RegionCollDal>();
                var data = dal.Fetch(parent_Country_ID);
                Fetch(data);
            }
            OnFetchPost(args);
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        }

        /// <summary>
        /// Loads all <see cref="H07_RegionColl"/> collection items from the given list of H08_RegionDto.
        /// </summary>
        /// <param name="data">The list of <see cref="H08_RegionDto"/>.</param>
        private void Fetch(List<H08_RegionDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(H08_Region.GetH08_Region(dto));
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
