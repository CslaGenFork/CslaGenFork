using System;
using System.Collections.Generic;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D07_RegionColl (editable child list).<br/>
    /// This is a generated base class of <see cref="D07_RegionColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="D06_Country"/> editable child object.<br/>
    /// The items of the collection are <see cref="D08_Region"/> objects.
    /// </remarks>
    [Serializable]
    public partial class D07_RegionColl : BusinessListBase<D07_RegionColl, D08_Region>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="D08_Region"/> item from the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to be removed.</param>
        public void Remove(int region_ID)
        {
            foreach (var d08_Region in this)
            {
                if (d08_Region.Region_ID == region_ID)
                {
                    Remove(d08_Region);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="D08_Region"/> item is in the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D08_Region is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int region_ID)
        {
            foreach (var d08_Region in this)
            {
                if (d08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="D08_Region"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D08_Region is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int region_ID)
        {
            foreach (var d08_Region in this.DeletedList)
            {
                if (d08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D07_RegionColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="D07_RegionColl"/> collection.</returns>
        internal static D07_RegionColl NewD07_RegionColl()
        {
            return DataPortal.CreateChild<D07_RegionColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D07_RegionColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent_Country_ID parameter of the D07_RegionColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D07_RegionColl"/> collection.</returns>
        internal static D07_RegionColl GetD07_RegionColl(int parent_Country_ID)
        {
            return DataPortal.FetchChild<D07_RegionColl>(parent_Country_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D07_RegionColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D07_RegionColl()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D07_RegionColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent Country ID.</param>
        protected void Child_Fetch(int parent_Country_ID)
        {
            var args = new DataPortalHookArgs(parent_Country_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<ID07_RegionCollDal>();
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
        /// Loads all <see cref="D07_RegionColl"/> collection items from the given list of D08_RegionDto.
        /// </summary>
        /// <param name="data">The list of <see cref="D08_RegionDto"/>.</param>
        private void Fetch(List<D08_RegionDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(D08_Region.GetD08_Region(dto));
            }
            RaiseListChangedEvents = rlce;
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
