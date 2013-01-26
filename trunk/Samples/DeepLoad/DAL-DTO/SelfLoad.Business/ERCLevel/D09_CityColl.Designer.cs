using System;
using System.Collections.Generic;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D09_CityColl (editable child list).<br/>
    /// This is a generated base class of <see cref="D09_CityColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="D08_Region"/> editable child object.<br/>
    /// The items of the collection are <see cref="D10_City"/> objects.
    /// </remarks>
    [Serializable]
    public partial class D09_CityColl : BusinessListBase<D09_CityColl, D10_City>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="D10_City"/> item from the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to be removed.</param>
        public void Remove(int city_ID)
        {
            foreach (var d10_City in this)
            {
                if (d10_City.City_ID == city_ID)
                {
                    Remove(d10_City);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="D10_City"/> item is in the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D10_City is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int city_ID)
        {
            foreach (var d10_City in this)
            {
                if (d10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="D10_City"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D10_City is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int city_ID)
        {
            foreach (var d10_City in this.DeletedList)
            {
                if (d10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D09_CityColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="D09_CityColl"/> collection.</returns>
        internal static D09_CityColl NewD09_CityColl()
        {
            return DataPortal.CreateChild<D09_CityColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D09_CityColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent_Region_ID parameter of the D09_CityColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D09_CityColl"/> collection.</returns>
        internal static D09_CityColl GetD09_CityColl(int parent_Region_ID)
        {
            return DataPortal.FetchChild<D09_CityColl>(parent_Region_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D09_CityColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D09_CityColl()
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
        /// Loads a <see cref="D09_CityColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent Region ID.</param>
        protected void Child_Fetch(int parent_Region_ID)
        {
            var args = new DataPortalHookArgs(parent_Region_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<ID09_CityCollDal>();
                var data = dal.Fetch(parent_Region_ID);
                Fetch(data);
            }
            OnFetchPost(args);
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        }

        /// <summary>
        /// Loads all <see cref="D09_CityColl"/> collection items from the given list of D10_CityDto.
        /// </summary>
        /// <param name="data">The list of <see cref="D10_CityDto"/>.</param>
        private void Fetch(List<D10_CityDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(D10_City.GetD10_City(dto));
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
