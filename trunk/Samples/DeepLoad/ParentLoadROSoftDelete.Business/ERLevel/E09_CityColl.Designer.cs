using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E09_CityColl (read only list).<br/>
    /// This is a generated base class of <see cref="E09_CityColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="E08_Region"/> read only object.<br/>
    /// The items of the collection are <see cref="E10_City"/> objects.
    /// </remarks>
    [Serializable]
    public partial class E09_CityColl : ReadOnlyListBase<E09_CityColl, E10_City>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="E10_City"/> item is in the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E10_City is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int city_ID)
        {
            foreach (var e10_City in this)
            {
                if (e10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="E10_City"/> item of the <see cref="E09_CityColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="city_ID">The City_ID.</param>
        /// <returns>A <see cref="E10_City"/> object.</returns>
        public E10_City FindE10_CityByParentProperties(int city_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].City_ID.Equals(city_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E09_CityColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E09_CityColl"/> object.</returns>
        internal static E09_CityColl GetE09_CityColl(SafeDataReader dr)
        {
            E09_CityColl obj = new E09_CityColl();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E09_CityColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal E09_CityColl()
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
        /// Loads all <see cref="E09_CityColl"/> collection items from the given SafeDataReader.
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
                Add(E10_City.GetE10_City(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="E10_City"/> items on the E09_CityObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="E07_RegionColl"/> collection.</param>
        internal void LoadItems(E07_RegionColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindE08_RegionByParentProperties(item.parent_Region_ID);
                obj.E09_CityObjects.IsReadOnly = false;
                var rlce = obj.E09_CityObjects.RaiseListChangedEvents;
                obj.E09_CityObjects.RaiseListChangedEvents = false;
                obj.E09_CityObjects.Add(item);
                obj.E09_CityObjects.RaiseListChangedEvents = rlce;
                obj.E09_CityObjects.IsReadOnly = true;
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
