using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

namespace ParentLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E05_CountryColl (editable child list).<br/>
    /// This is a generated base class of <see cref="E05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="E04_SubContinent"/> editable child object.<br/>
    /// The items of the collection are <see cref="E06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class E05_CountryColl : BusinessListBase<E05_CountryColl, E06_Country>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="E06_Country"/> item from the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to be removed.</param>
        public void Remove(int country_ID)
        {
            foreach (var e06_Country in this)
            {
                if (e06_Country.Country_ID == country_ID)
                {
                    Remove(e06_Country);
                    break;
                }
            }
        }

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

        /// <summary>
        /// Determines whether a <see cref="E06_Country"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E06_Country is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int country_ID)
        {
            foreach (var e06_Country in this.DeletedList)
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
        /// Factory method. Creates a new <see cref="E05_CountryColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="E05_CountryColl"/> collection.</returns>
        internal static E05_CountryColl NewE05_CountryColl()
        {
            return DataPortal.CreateChild<E05_CountryColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="E05_CountryColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E05_CountryColl"/> object.</returns>
        internal static E05_CountryColl GetE05_CountryColl(SafeDataReader dr)
        {
            E05_CountryColl obj = new E05_CountryColl();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E05_CountryColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E05_CountryColl()
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
        /// Loads all <see cref="E05_CountryColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
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
                var rlce = obj.E05_CountryObjects.RaiseListChangedEvents;
                obj.E05_CountryObjects.RaiseListChangedEvents = false;
                obj.E05_CountryObjects.Add(item);
                obj.E05_CountryObjects.RaiseListChangedEvents = rlce;
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
