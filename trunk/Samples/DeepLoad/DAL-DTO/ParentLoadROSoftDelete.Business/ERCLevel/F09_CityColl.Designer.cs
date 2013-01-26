using System;
using System.Collections.Generic;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F09_CityColl (read only list).<br/>
    /// This is a generated base class of <see cref="F09_CityColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F08_Region"/> read only object.<br/>
    /// The items of the collection are <see cref="F10_City"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F09_CityColl : ReadOnlyListBase<F09_CityColl, F10_City>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="F10_City"/> item is in the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F10_City is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int city_ID)
        {
            foreach (var f10_City in this)
            {
                if (f10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="F10_City"/> item of the <see cref="F09_CityColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="city_ID">The City_ID.</param>
        /// <returns>A <see cref="F10_City"/> object.</returns>
        public F10_City FindF10_CityByParentProperties(int city_ID)
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
        /// Factory method. Loads a <see cref="F09_CityColl"/> object from the given list of F10_CityDto.
        /// </summary>
        /// <param name="data">The list of <see cref="F10_CityDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="F09_CityColl"/> object.</returns>
        internal static F09_CityColl GetF09_CityColl(List<F10_CityDto> data)
        {
            F09_CityColl obj = new F09_CityColl();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F09_CityColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal F09_CityColl()
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
        /// Loads all <see cref="F09_CityColl"/> collection items from the given list of F10_CityDto.
        /// </summary>
        /// <param name="data">The list of <see cref="F10_CityDto"/>.</param>
        private void Fetch(List<F10_CityDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(data);
            OnFetchPre(args);
            foreach (var dto in data)
            {
                Add(F10_City.GetF10_City(dto));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="F10_City"/> items on the F09_CityObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="F07_RegionColl"/> collection.</param>
        internal void LoadItems(F07_RegionColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindF08_RegionByParentProperties(item.parent_Region_ID);
                obj.F09_CityObjects.IsReadOnly = false;
                var rlce = obj.F09_CityObjects.RaiseListChangedEvents;
                obj.F09_CityObjects.RaiseListChangedEvents = false;
                obj.F09_CityObjects.Add(item);
                obj.F09_CityObjects.RaiseListChangedEvents = rlce;
                obj.F09_CityObjects.IsReadOnly = true;
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
