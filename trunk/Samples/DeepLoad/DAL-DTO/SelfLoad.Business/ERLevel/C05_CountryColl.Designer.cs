using System;
using System.Collections.Generic;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C05_CountryColl (editable child list).<br/>
    /// This is a generated base class of <see cref="C05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="C04_SubContinent"/> editable child object.<br/>
    /// The items of the collection are <see cref="C06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class C05_CountryColl : BusinessListBase<C05_CountryColl, C06_Country>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="C06_Country"/> item from the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to be removed.</param>
        public void Remove(int country_ID)
        {
            foreach (var c06_Country in this)
            {
                if (c06_Country.Country_ID == country_ID)
                {
                    Remove(c06_Country);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="C06_Country"/> item is in the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C06_Country is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int country_ID)
        {
            foreach (var c06_Country in this)
            {
                if (c06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="C06_Country"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C06_Country is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int country_ID)
        {
            foreach (var c06_Country in DeletedList)
            {
                if (c06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="C06_Country"/> item of the <see cref="C05_CountryColl"/> collection, based on a given Country_ID.
        /// </summary>
        /// <param name="country_ID">The Country_ID.</param>
        /// <returns>A <see cref="C06_Country"/> object.</returns>
        public C06_Country FindC06_CountryByCountry_ID(int country_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Country_ID.Equals(country_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C05_CountryColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="C05_CountryColl"/> collection.</returns>
        internal static C05_CountryColl NewC05_CountryColl()
        {
            return DataPortal.CreateChild<C05_CountryColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C05_CountryColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent_SubContinent_ID parameter of the C05_CountryColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C05_CountryColl"/> collection.</returns>
        internal static C05_CountryColl GetC05_CountryColl(int parent_SubContinent_ID)
        {
            return DataPortal.FetchChild<C05_CountryColl>(parent_SubContinent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C05_CountryColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C05_CountryColl()
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
        /// Loads a <see cref="C05_CountryColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        protected void Child_Fetch(int parent_SubContinent_ID)
        {
            var args = new DataPortalHookArgs(parent_SubContinent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<IC05_CountryCollDal>();
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
        /// Loads all <see cref="C05_CountryColl"/> collection items from the given list of C06_CountryDto.
        /// </summary>
        /// <param name="data">The list of <see cref="C06_CountryDto"/>.</param>
        private void Fetch(List<C06_CountryDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(C06_Country.GetC06_Country(dto));
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
