using System;
using System.Collections.Generic;
using Csla;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B11_CityRoadColl (editable child list).<br/>
    /// This is a generated base class of <see cref="B11_CityRoadColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="B10_City"/> editable child object.<br/>
    /// The items of the collection are <see cref="B12_CityRoad"/> objects.
    /// </remarks>
    [Serializable]
    public partial class B11_CityRoadColl : BusinessListBase<B11_CityRoadColl, B12_CityRoad>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="B12_CityRoad"/> item from the collection.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID of the item to be removed.</param>
        public void Remove(int cityRoad_ID)
        {
            foreach (var b12_CityRoad in this)
            {
                if (b12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    Remove(b12_CityRoad);
                    break;
                }
            }
        }

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

        /// <summary>
        /// Determines whether a <see cref="B12_CityRoad"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID of the item to search for.</param>
        /// <returns><c>true</c> if the B12_CityRoad is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int cityRoad_ID)
        {
            foreach (var b12_CityRoad in this.DeletedList)
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
        /// Factory method. Creates a new <see cref="B11_CityRoadColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="B11_CityRoadColl"/> collection.</returns>
        internal static B11_CityRoadColl NewB11_CityRoadColl()
        {
            return DataPortal.CreateChild<B11_CityRoadColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B11_CityRoadColl"/> object from the given list of B12_CityRoadDto.
        /// </summary>
        /// <param name="data">The list of <see cref="B12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B11_CityRoadColl"/> object.</returns>
        internal static B11_CityRoadColl GetB11_CityRoadColl(List<B12_CityRoadDto> data)
        {
            B11_CityRoadColl obj = new B11_CityRoadColl();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B11_CityRoadColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B11_CityRoadColl()
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
        /// Loads all <see cref="B11_CityRoadColl"/> collection items from the given list of B12_CityRoadDto.
        /// </summary>
        /// <param name="data">The list of <see cref="B12_CityRoadDto"/>.</param>
        private void Fetch(List<B12_CityRoadDto> data)
        {
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
                var rlce = obj.B11_CityRoadObjects.RaiseListChangedEvents;
                obj.B11_CityRoadObjects.RaiseListChangedEvents = false;
                obj.B11_CityRoadObjects.Add(item);
                obj.B11_CityRoadObjects.RaiseListChangedEvents = rlce;
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
