using System;
using System.Collections.Generic;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B11_CityRoadColl (read only list).<br/>
    /// This is a generated base class of <see cref="B11_CityRoadColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="B10_City"/> read only object.<br/>
    /// The items of the collection are <see cref="B12_CityRoad"/> objects.
    /// </remarks>
    [Serializable]
    public partial class B11_CityRoadColl : ReadOnlyListBase<B11_CityRoadColl, B12_CityRoad>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="B12_CityRoad"/> item is in the collection.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID of the item to search for.</param>
        /// <returns><c>true</c> if the B12_CityRoad is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int cityRoad_ID)
        {
            foreach (var b12_CityRoad in this)
            {
                if (b12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B11_CityRoadColl"/> object from the given list of B12_CityRoadDto.
        /// </summary>
        /// <param name="data">The list of <see cref="B12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B11_CityRoadColl"/> object.</returns>
        internal static B11_CityRoadColl GetB11_CityRoadColl(List<B12_CityRoadDto> data)
        {
            B11_CityRoadColl obj = new B11_CityRoadColl();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B11_CityRoadColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public B11_CityRoadColl()
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
        /// Loads all <see cref="B11_CityRoadColl"/> collection items from the given list of B12_CityRoadDto.
        /// </summary>
        /// <param name="data">The list of <see cref="B12_CityRoadDto"/>.</param>
        private void Fetch(List<B12_CityRoadDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(data);
            OnFetchPre(args);
            foreach (var dto in data)
            {
                Add(B12_CityRoad.GetB12_CityRoad(dto));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="B12_CityRoad"/> items on the B11_CityRoadObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="B09_CityColl"/> collection.</param>
        internal void LoadItems(B09_CityColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindB10_CityByParentProperties(item.parent_City_ID);
                obj.B11_CityRoadObjects.IsReadOnly = false;
                var rlce = obj.B11_CityRoadObjects.RaiseListChangedEvents;
                obj.B11_CityRoadObjects.RaiseListChangedEvents = false;
                obj.B11_CityRoadObjects.Add(item);
                obj.B11_CityRoadObjects.RaiseListChangedEvents = rlce;
                obj.B11_CityRoadObjects.IsReadOnly = true;
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
