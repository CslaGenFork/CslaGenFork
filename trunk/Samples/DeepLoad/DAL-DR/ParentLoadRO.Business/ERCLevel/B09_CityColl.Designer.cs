using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B09_CityColl (read only list).<br/>
    /// This is a generated base class of <see cref="B09_CityColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="B08_Region"/> read only object.<br/>
    /// The items of the collection are <see cref="B10_City"/> objects.
    /// </remarks>
    [Serializable]
    public partial class B09_CityColl : ReadOnlyListBase<B09_CityColl, B10_City>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="B10_City"/> item is in the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the B10_City is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int city_ID)
        {
            foreach (var b10_City in this)
            {
                if (b10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="B10_City"/> item of the <see cref="B09_CityColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="city_ID">The City_ID.</param>
        /// <returns>A <see cref="B10_City"/> object.</returns>
        public B10_City FindB10_CityByParentProperties(int city_ID)
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
        /// Factory method. Loads a <see cref="B09_CityColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B09_CityColl"/> object.</returns>
        internal static B09_CityColl GetB09_CityColl(SafeDataReader dr)
        {
            B09_CityColl obj = new B09_CityColl();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B09_CityColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public B09_CityColl()
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
        /// Loads all <see cref="B09_CityColl"/> collection items from the given SafeDataReader.
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
                Add(B10_City.GetB10_City(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="B10_City"/> items on the B09_CityObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="B07_RegionColl"/> collection.</param>
        internal void LoadItems(B07_RegionColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindB08_RegionByParentProperties(item.parent_Region_ID);
                obj.B09_CityObjects.IsReadOnly = false;
                var rlce = obj.B09_CityObjects.RaiseListChangedEvents;
                obj.B09_CityObjects.RaiseListChangedEvents = false;
                obj.B09_CityObjects.Add(item);
                obj.B09_CityObjects.RaiseListChangedEvents = rlce;
                obj.B09_CityObjects.IsReadOnly = true;
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
