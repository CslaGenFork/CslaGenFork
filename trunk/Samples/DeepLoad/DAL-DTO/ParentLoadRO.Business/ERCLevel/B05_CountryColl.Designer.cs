using System;
using System.Collections.Generic;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B05_CountryColl (read only list).<br/>
    /// This is a generated base class of <see cref="B05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="B04_SubContinent"/> read only object.<br/>
    /// The items of the collection are <see cref="B06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class B05_CountryColl : ReadOnlyListBase<B05_CountryColl, B06_Country>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="B06_Country"/> item is in the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the B06_Country is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int country_ID)
        {
            foreach (var b06_Country in this)
            {
                if (b06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="B06_Country"/> item of the <see cref="B05_CountryColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="country_ID">The Country_ID.</param>
        /// <returns>A <see cref="B06_Country"/> object.</returns>
        public B06_Country FindB06_CountryByParentProperties(int country_ID)
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
        /// Factory method. Loads a <see cref="B05_CountryColl"/> object from the given list of B06_CountryDto.
        /// </summary>
        /// <param name="data">The list of <see cref="B06_CountryDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B05_CountryColl"/> object.</returns>
        internal static B05_CountryColl GetB05_CountryColl(List<B06_CountryDto> data)
        {
            B05_CountryColl obj = new B05_CountryColl();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B05_CountryColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal B05_CountryColl()
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
        /// Loads all <see cref="B05_CountryColl"/> collection items from the given list of B06_CountryDto.
        /// </summary>
        /// <param name="data">The list of <see cref="B06_CountryDto"/>.</param>
        private void Fetch(List<B06_CountryDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(data);
            OnFetchPre(args);
            foreach (var dto in data)
            {
                Add(B06_Country.GetB06_Country(dto));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="B06_Country"/> items on the B05_CountryObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="B03_SubContinentColl"/> collection.</param>
        internal void LoadItems(B03_SubContinentColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindB04_SubContinentByParentProperties(item.parent_SubContinent_ID);
                obj.B05_CountryObjects.IsReadOnly = false;
                var rlce = obj.B05_CountryObjects.RaiseListChangedEvents;
                obj.B05_CountryObjects.RaiseListChangedEvents = false;
                obj.B05_CountryObjects.Add(item);
                obj.B05_CountryObjects.RaiseListChangedEvents = rlce;
                obj.B05_CountryObjects.IsReadOnly = true;
            }
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
