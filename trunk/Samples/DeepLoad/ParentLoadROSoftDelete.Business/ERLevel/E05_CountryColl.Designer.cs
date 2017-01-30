using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E05_CountryColl (read only list).<br/>
    /// This is a generated base class of <see cref="E05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="E04_SubContinent"/> read only object.<br/>
    /// The items of the collection are <see cref="E06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class E05_CountryColl : ReadOnlyListBase<E05_CountryColl, E06_Country>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="E06_Country"/> item is in the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E06_Country is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int country_ID)
        {
            foreach (var e06_Country in this)
            {
                if (e06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="E06_Country"/> item of the <see cref="E05_CountryColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="country_ID">The Country_ID.</param>
        /// <returns>A <see cref="E06_Country"/> object.</returns>
        public E06_Country FindE06_CountryByParentProperties(int country_ID)
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
        /// Factory method. Loads a <see cref="E05_CountryColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E05_CountryColl"/> object.</returns>
        internal static E05_CountryColl GetE05_CountryColl(SafeDataReader dr)
        {
            E05_CountryColl obj = new E05_CountryColl();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E05_CountryColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public E05_CountryColl()
        {
            // Use factory methods and do not use direct creation.

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
        /// Loads all <see cref="E05_CountryColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(E06_Country.GetE06_Country(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="E06_Country"/> items on the E05_CountryObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="E03_SubContinentColl"/> collection.</param>
        internal void LoadItems(E03_SubContinentColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindE04_SubContinentByParentProperties(item.parent_SubContinent_ID);
                obj.E05_CountryObjects.IsReadOnly = false;
                var rlce = obj.E05_CountryObjects.RaiseListChangedEvents;
                obj.E05_CountryObjects.RaiseListChangedEvents = false;
                obj.E05_CountryObjects.Add(item);
                obj.E05_CountryObjects.RaiseListChangedEvents = rlce;
                obj.E05_CountryObjects.IsReadOnly = true;
            }
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
