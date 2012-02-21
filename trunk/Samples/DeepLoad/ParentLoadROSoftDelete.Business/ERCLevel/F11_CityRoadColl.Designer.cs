using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F11_CityRoadColl (read only list).<br/>
    /// This is a generated base class of <see cref="F11_CityRoadColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F10_City"/> read only object.<br/>
    /// The items of the collection are <see cref="F12_CityRoad"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F11_CityRoadColl : ReadOnlyListBase<F11_CityRoadColl, F12_CityRoad>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="F12_CityRoad"/> item is in the collection.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F12_CityRoad is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int cityRoad_ID)
        {
            foreach (var f12_CityRoad in this)
            {
                if (f12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F11_CityRoadColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F11_CityRoadColl"/> object.</returns>
        internal static F11_CityRoadColl GetF11_CityRoadColl(SafeDataReader dr)
        {
            F11_CityRoadColl obj = new F11_CityRoadColl();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F11_CityRoadColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal F11_CityRoadColl()
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
        /// Loads all <see cref="F11_CityRoadColl"/> collection items from the given SafeDataReader.
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
                Add(F12_CityRoad.GetF12_CityRoad(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="F12_CityRoad"/> items on the F11_CityRoadObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="F09_CityColl"/> collection.</param>
        internal void LoadItems(F09_CityColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindF10_CityByParentProperties(item.parent_City_ID);
                obj.F11_CityRoadObjects.IsReadOnly = false;
                var rlce = obj.F11_CityRoadObjects.RaiseListChangedEvents;
                obj.F11_CityRoadObjects.RaiseListChangedEvents = false;
                obj.F11_CityRoadObjects.Add(item);
                obj.F11_CityRoadObjects.RaiseListChangedEvents = rlce;
                obj.F11_CityRoadObjects.IsReadOnly = true;
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
