using System;
using System.Collections.Generic;
using Csla;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERLevel;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A09_CityColl (editable child list).<br/>
    /// This is a generated base class of <see cref="A09_CityColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="A08_Region"/> editable child object.<br/>
    /// The items of the collection are <see cref="A10_City"/> objects.
    /// </remarks>
    [Serializable]
    public partial class A09_CityColl : BusinessListBase<A09_CityColl, A10_City>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="A10_City"/> item from the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to be removed.</param>
        public void Remove(int city_ID)
        {
            foreach (var a10_City in this)
            {
                if (a10_City.City_ID == city_ID)
                {
                    Remove(a10_City);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="A10_City"/> item is in the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the A10_City is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int city_ID)
        {
            foreach (var a10_City in this)
            {
                if (a10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="A10_City"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the A10_City is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int city_ID)
        {
            foreach (var a10_City in this.DeletedList)
            {
                if (a10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="A10_City"/> item of the <see cref="A09_CityColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="city_ID">The City_ID.</param>
        /// <returns>A <see cref="A10_City"/> object.</returns>
        public A10_City FindA10_CityByParentProperties(int city_ID)
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
        /// Factory method. Creates a new <see cref="A09_CityColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="A09_CityColl"/> collection.</returns>
        internal static A09_CityColl NewA09_CityColl()
        {
            return DataPortal.CreateChild<A09_CityColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A09_CityColl"/> object from the given list of A10_CityDto.
        /// </summary>
        /// <param name="data">The list of <see cref="A10_CityDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="A09_CityColl"/> object.</returns>
        internal static A09_CityColl GetA09_CityColl(List<A10_CityDto> data)
        {
            A09_CityColl obj = new A09_CityColl();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A09_CityColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A09_CityColl()
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
        /// Loads all <see cref="A09_CityColl"/> collection items from the given list of A10_CityDto.
        /// </summary>
        /// <param name="data">The list of <see cref="A10_CityDto"/>.</param>
        private void Fetch(List<A10_CityDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(data);
            OnFetchPre(args);
            foreach (var dto in data)
            {
                Add(A10_City.GetA10_City(dto));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="A10_City"/> items on the A09_CityObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="A07_RegionColl"/> collection.</param>
        internal void LoadItems(A07_RegionColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindA08_RegionByParentProperties(item.parent_Region_ID);
                var rlce = obj.A09_CityObjects.RaiseListChangedEvents;
                obj.A09_CityObjects.RaiseListChangedEvents = false;
                obj.A09_CityObjects.Add(item);
                obj.A09_CityObjects.RaiseListChangedEvents = rlce;
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
