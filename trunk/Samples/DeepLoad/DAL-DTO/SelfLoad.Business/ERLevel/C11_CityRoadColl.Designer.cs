using System;
using System.Collections.Generic;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C11_CityRoadColl (editable child list).<br/>
    /// This is a generated base class of <see cref="C11_CityRoadColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="C10_City"/> editable child object.<br/>
    /// The items of the collection are <see cref="C12_CityRoad"/> objects.
    /// </remarks>
    [Serializable]
    public partial class C11_CityRoadColl : BusinessListBase<C11_CityRoadColl, C12_CityRoad>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="C12_CityRoad"/> item from the collection.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID of the item to be removed.</param>
        public void Remove(int cityRoad_ID)
        {
            foreach (var c12_CityRoad in this)
            {
                if (c12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    Remove(c12_CityRoad);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="C12_CityRoad"/> item is in the collection.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C12_CityRoad is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int cityRoad_ID)
        {
            foreach (var c12_CityRoad in this)
            {
                if (c12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="C12_CityRoad"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C12_CityRoad is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int cityRoad_ID)
        {
            foreach (var c12_CityRoad in DeletedList)
            {
                if (c12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="C12_CityRoad"/> item of the <see cref="C11_CityRoadColl"/> collection, based on a given CityRoad_ID.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID.</param>
        /// <returns>A <see cref="C12_CityRoad"/> object.</returns>
        public C12_CityRoad FindC12_CityRoadByCityRoad_ID(int cityRoad_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].CityRoad_ID.Equals(cityRoad_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C11_CityRoadColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="C11_CityRoadColl"/> collection.</returns>
        internal static C11_CityRoadColl NewC11_CityRoadColl()
        {
            return DataPortal.CreateChild<C11_CityRoadColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C11_CityRoadColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_City_ID">The Parent_City_ID parameter of the C11_CityRoadColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C11_CityRoadColl"/> collection.</returns>
        internal static C11_CityRoadColl GetC11_CityRoadColl(int parent_City_ID)
        {
            return DataPortal.FetchChild<C11_CityRoadColl>(parent_City_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C11_CityRoadColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C11_CityRoadColl()
        {
            // Use factory methods and do not use direct creation.

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
        /// Loads a <see cref="C11_CityRoadColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_City_ID">The Parent City ID.</param>
        protected void Child_Fetch(int parent_City_ID)
        {
            var args = new DataPortalHookArgs(parent_City_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<IC11_CityRoadCollDal>();
                var data = dal.Fetch(parent_City_ID);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        /// <summary>
        /// Loads all <see cref="C11_CityRoadColl"/> collection items from the given list of C12_CityRoadDto.
        /// </summary>
        /// <param name="data">The list of <see cref="C12_CityRoadDto"/>.</param>
        private void Fetch(List<C12_CityRoadDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(C12_CityRoad.GetC12_CityRoad(dto));
            }
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region DataPortal Hooks

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
