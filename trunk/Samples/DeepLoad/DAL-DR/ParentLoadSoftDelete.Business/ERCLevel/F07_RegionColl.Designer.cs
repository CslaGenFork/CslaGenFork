using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F07_RegionColl (editable child list).<br/>
    /// This is a generated base class of <see cref="F07_RegionColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="F06_Country"/> editable child object.<br/>
    /// The items of the collection are <see cref="F08_Region"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F07_RegionColl : BusinessListBase<F07_RegionColl, F08_Region>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="F08_Region"/> item from the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to be removed.</param>
        public void Remove(int region_ID)
        {
            foreach (var f08_Region in this)
            {
                if (f08_Region.Region_ID == region_ID)
                {
                    Remove(f08_Region);
                    break;
                }
            }
        }

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

        /// <summary>
        /// Determines whether a <see cref="F08_Region"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F08_Region is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int region_ID)
        {
            foreach (var f08_Region in this.DeletedList)
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
        /// Factory method. Creates a new <see cref="F07_RegionColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="F07_RegionColl"/> collection.</returns>
        internal static F07_RegionColl NewF07_RegionColl()
        {
            return DataPortal.CreateChild<F07_RegionColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="F07_RegionColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F07_RegionColl"/> object.</returns>
        internal static F07_RegionColl GetF07_RegionColl(SafeDataReader dr)
        {
            F07_RegionColl obj = new F07_RegionColl();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F07_RegionColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F07_RegionColl()
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
        /// Loads all <see cref="F07_RegionColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(F08_Region.GetF08_Region(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
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
                var rlce = obj.F07_RegionObjects.RaiseListChangedEvents;
                obj.F07_RegionObjects.RaiseListChangedEvents = false;
                obj.F07_RegionObjects.Add(item);
                obj.F07_RegionObjects.RaiseListChangedEvents = rlce;
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
