using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E11_CityRoadColl (read only list).<br/>
    /// This is a generated base class of <see cref="E11_CityRoadColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="E10_City"/> read only object.<br/>
    /// The items of the collection are <see cref="E12_CityRoad"/> objects.
    /// </remarks>
    [Serializable]
    public partial class E11_CityRoadColl : ReadOnlyListBase<E11_CityRoadColl, E12_CityRoad>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="E12_CityRoad"/> item is in the collection.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E12_CityRoad is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int cityRoad_ID)
        {
            foreach (var e12_CityRoad in this)
            {
                if (e12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E11_CityRoadColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E11_CityRoadColl"/> object.</returns>
        internal static E11_CityRoadColl GetE11_CityRoadColl(SafeDataReader dr)
        {
            E11_CityRoadColl obj = new E11_CityRoadColl();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E11_CityRoadColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public E11_CityRoadColl()
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
        /// Loads all <see cref="E11_CityRoadColl"/> collection items from the given SafeDataReader.
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
                Add(E12_CityRoad.GetE12_CityRoad(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="E12_CityRoad"/> items on the E11_CityRoadObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="E09_CityColl"/> collection.</param>
        internal void LoadItems(E09_CityColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindE10_CityByParentProperties(item.parent_City_ID);
                obj.E11_CityRoadObjects.IsReadOnly = false;
                var rlce = obj.E11_CityRoadObjects.RaiseListChangedEvents;
                obj.E11_CityRoadObjects.RaiseListChangedEvents = false;
                obj.E11_CityRoadObjects.Add(item);
                obj.E11_CityRoadObjects.RaiseListChangedEvents = rlce;
                obj.E11_CityRoadObjects.IsReadOnly = true;
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
