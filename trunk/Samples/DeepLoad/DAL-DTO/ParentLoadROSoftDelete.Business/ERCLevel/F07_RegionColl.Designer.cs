using System;
using System.Collections.Generic;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F07_RegionColl (read only list).<br/>
    /// This is a generated base class of <see cref="F07_RegionColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F06_Country"/> read only object.<br/>
    /// The items of the collection are <see cref="F08_Region"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F07_RegionColl : ReadOnlyListBase<F07_RegionColl, F08_Region>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="F08_Region"/> item is in the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F08_Region is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int region_ID)
        {
            foreach (var f08_Region in this)
            {
                if (f08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="F08_Region"/> item of the <see cref="F07_RegionColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="region_ID">The Region_ID.</param>
        /// <returns>A <see cref="F08_Region"/> object.</returns>
        public F08_Region FindF08_RegionByParentProperties(int region_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Region_ID.Equals(region_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F07_RegionColl"/> object from the given list of F08_RegionDto.
        /// </summary>
        /// <param name="data">The list of <see cref="F08_RegionDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="F07_RegionColl"/> object.</returns>
        internal static F07_RegionColl GetF07_RegionColl(List<F08_RegionDto> data)
        {
            F07_RegionColl obj = new F07_RegionColl();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F07_RegionColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal F07_RegionColl()
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
        /// Loads all <see cref="F07_RegionColl"/> collection items from the given list of F08_RegionDto.
        /// </summary>
        /// <param name="data">The list of <see cref="F08_RegionDto"/>.</param>
        private void Fetch(List<F08_RegionDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(data);
            OnFetchPre(args);
            foreach (var dto in data)
            {
                Add(F08_Region.GetF08_Region(dto));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="F08_Region"/> items on the F07_RegionObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="F05_CountryColl"/> collection.</param>
        internal void LoadItems(F05_CountryColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindF06_CountryByParentProperties(item.parent_Country_ID);
                obj.F07_RegionObjects.IsReadOnly = false;
                var rlce = obj.F07_RegionObjects.RaiseListChangedEvents;
                obj.F07_RegionObjects.RaiseListChangedEvents = false;
                obj.F07_RegionObjects.Add(item);
                obj.F07_RegionObjects.RaiseListChangedEvents = rlce;
                obj.F07_RegionObjects.IsReadOnly = true;
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
