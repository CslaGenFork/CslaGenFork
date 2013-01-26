using System;
using System.Collections.Generic;
using Csla;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H05_CountryColl (read only list).<br/>
    /// This is a generated base class of <see cref="H05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="H04_SubContinent"/> read only object.<br/>
    /// The items of the collection are <see cref="H06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class H05_CountryColl : ReadOnlyListBase<H05_CountryColl, H06_Country>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="H06_Country"/> item is in the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the H06_Country is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int country_ID)
        {
            foreach (var h06_Country in this)
            {
                if (h06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H05_CountryColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent_SubContinent_ID parameter of the H05_CountryColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="H05_CountryColl"/> collection.</returns>
        internal static H05_CountryColl GetH05_CountryColl(int parent_SubContinent_ID)
        {
            return DataPortal.FetchChild<H05_CountryColl>(parent_SubContinent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H05_CountryColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H05_CountryColl()
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
        /// Loads a <see cref="H05_CountryColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        protected void Child_Fetch(int parent_SubContinent_ID)
        {
            var args = new DataPortalHookArgs(parent_SubContinent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IH05_CountryCollDal>();
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
        /// Loads all <see cref="H05_CountryColl"/> collection items from the given list of H06_CountryDto.
        /// </summary>
        /// <param name="data">The list of <see cref="H06_CountryDto"/>.</param>
        private void Fetch(List<H06_CountryDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(H06_Country.GetH06_Country(dto));
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
