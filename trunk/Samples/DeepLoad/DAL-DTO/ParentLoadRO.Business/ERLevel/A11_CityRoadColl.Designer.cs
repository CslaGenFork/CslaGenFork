using System;
using System.Collections.Generic;
using Csla;
using ParentLoadRO.DataAccess.ERLevel;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A11_CityRoadColl (read only list).<br/>
    /// This is a generated base class of <see cref="A11_CityRoadColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="A10_City"/> read only object.<br/>
    /// The items of the collection are <see cref="A12_CityRoad"/> objects.
    /// </remarks>
    [Serializable]
    public partial class A11_CityRoadColl : ReadOnlyListBase<A11_CityRoadColl, A12_CityRoad>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="A12_CityRoad"/> item is in the collection.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID of the item to search for.</param>
        /// <returns><c>true</c> if the A12_CityRoad is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int cityRoad_ID)
        {
            foreach (var a12_CityRoad in this)
            {
                if (a12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A11_CityRoadColl"/> object from the given list of A12_CityRoadDto.
        /// </summary>
        /// <param name="data">The list of <see cref="A12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="A11_CityRoadColl"/> object.</returns>
        internal static A11_CityRoadColl GetA11_CityRoadColl(List<A12_CityRoadDto> data)
        {
            A11_CityRoadColl obj = new A11_CityRoadColl();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A11_CityRoadColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public A11_CityRoadColl()
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
        /// Loads all <see cref="A11_CityRoadColl"/> collection items from the given list of A12_CityRoadDto.
        /// </summary>
        /// <param name="data">The list of <see cref="A12_CityRoadDto"/>.</param>
        private void Fetch(List<A12_CityRoadDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(data);
            OnFetchPre(args);
            foreach (var dto in data)
            {
                Add(A12_CityRoad.GetA12_CityRoad(dto));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="A12_CityRoad"/> items on the A11_CityRoadObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="A09_CityColl"/> collection.</param>
        internal void LoadItems(A09_CityColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindA10_CityByParentProperties(item.parent_City_ID);
                obj.A11_CityRoadObjects.IsReadOnly = false;
                var rlce = obj.A11_CityRoadObjects.RaiseListChangedEvents;
                obj.A11_CityRoadObjects.RaiseListChangedEvents = false;
                obj.A11_CityRoadObjects.Add(item);
                obj.A11_CityRoadObjects.RaiseListChangedEvents = rlce;
                obj.A11_CityRoadObjects.IsReadOnly = true;
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
