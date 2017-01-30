using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A09_CityColl (read only list).<br/>
    /// This is a generated base class of <see cref="A09_CityColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="A08_Region"/> read only object.<br/>
    /// The items of the collection are <see cref="A10_City"/> objects.
    /// </remarks>
    [Serializable]
    public partial class A09_CityColl : ReadOnlyListBase<A09_CityColl, A10_City>
    {

        #region Collection Business Methods

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
        /// Factory method. Loads a <see cref="A09_CityColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A09_CityColl"/> object.</returns>
        internal static A09_CityColl GetA09_CityColl(SafeDataReader dr)
        {
            A09_CityColl obj = new A09_CityColl();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A09_CityColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public A09_CityColl()
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
        /// Loads all <see cref="A09_CityColl"/> collection items from the given SafeDataReader.
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
                Add(A10_City.GetA10_City(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
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
                obj.A09_CityObjects.IsReadOnly = false;
                var rlce = obj.A09_CityObjects.RaiseListChangedEvents;
                obj.A09_CityObjects.RaiseListChangedEvents = false;
                obj.A09_CityObjects.Add(item);
                obj.A09_CityObjects.RaiseListChangedEvents = rlce;
                obj.A09_CityObjects.IsReadOnly = true;
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
