using System;
using System.Collections.Generic;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D05_CountryColl (editable child list).<br/>
    /// This is a generated base class of <see cref="D05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="D04_SubContinent"/> editable child object.<br/>
    /// The items of the collection are <see cref="D06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class D05_CountryColl : BusinessListBase<D05_CountryColl, D06_Country>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="D06_Country"/> item from the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to be removed.</param>
        public void Remove(int country_ID)
        {
            foreach (var d06_Country in this)
            {
                if (d06_Country.Country_ID == country_ID)
                {
                    Remove(d06_Country);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="D06_Country"/> item is in the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D06_Country is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int country_ID)
        {
            foreach (var d06_Country in this)
            {
                if (d06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="D06_Country"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D06_Country is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int country_ID)
        {
            foreach (var d06_Country in this.DeletedList)
            {
                if (d06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D05_CountryColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="D05_CountryColl"/> collection.</returns>
        internal static D05_CountryColl NewD05_CountryColl()
        {
            return DataPortal.CreateChild<D05_CountryColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D05_CountryColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent_SubContinent_ID parameter of the D05_CountryColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D05_CountryColl"/> collection.</returns>
        internal static D05_CountryColl GetD05_CountryColl(int parent_SubContinent_ID)
        {
            return DataPortal.FetchChild<D05_CountryColl>(parent_SubContinent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D05_CountryColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D05_CountryColl()
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
        /// Loads a <see cref="D05_CountryColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        protected void Child_Fetch(int parent_SubContinent_ID)
        {
            var args = new DataPortalHookArgs(parent_SubContinent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<ID05_CountryCollDal>();
                var data = dal.Fetch(parent_SubContinent_ID);
                Fetch(data);
            }
            OnFetchPost(args);
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        }

        /// <summary>
        /// Loads all <see cref="D05_CountryColl"/> collection items from the given list of D06_CountryDto.
        /// </summary>
        /// <param name="data">The list of <see cref="D06_CountryDto"/>.</param>
        private void Fetch(List<D06_CountryDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(D06_Country.GetD06_Country(dto));
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
