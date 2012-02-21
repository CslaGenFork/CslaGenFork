using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A07_RegionColl (editable child list).<br/>
    /// This is a generated base class of <see cref="A07_RegionColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="A06_Country"/> editable child object.<br/>
    /// The items of the collection are <see cref="A08_Region"/> objects.
    /// </remarks>
    [Serializable]
    public partial class A07_RegionColl : BusinessListBase<A07_RegionColl, A08_Region>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="A08_Region"/> item from the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to be removed.</param>
        public void Remove(int region_ID)
        {
            foreach (var a08_Region in this)
            {
                if (a08_Region.Region_ID == region_ID)
                {
                    Remove(a08_Region);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="A08_Region"/> item is in the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the A08_Region is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int region_ID)
        {
            foreach (var a08_Region in this)
            {
                if (a08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="A08_Region"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the A08_Region is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int region_ID)
        {
            foreach (var a08_Region in this.DeletedList)
            {
                if (a08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="A08_Region"/> item of the <see cref="A07_RegionColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="region_ID">The Region_ID.</param>
        /// <returns>A <see cref="A08_Region"/> object.</returns>
        public A08_Region FindA08_RegionByParentProperties(int region_ID)
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
        /// Factory method. Creates a new <see cref="A07_RegionColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="A07_RegionColl"/> collection.</returns>
        internal static A07_RegionColl NewA07_RegionColl()
        {
            return DataPortal.CreateChild<A07_RegionColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A07_RegionColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A07_RegionColl"/> object.</returns>
        internal static A07_RegionColl GetA07_RegionColl(SafeDataReader dr)
        {
            A07_RegionColl obj = new A07_RegionColl();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A07_RegionColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A07_RegionColl()
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
        /// Loads all <see cref="A07_RegionColl"/> collection items from the given SafeDataReader.
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
                Add(A08_Region.GetA08_Region(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="A08_Region"/> items on the A07_RegionObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="A05_CountryColl"/> collection.</param>
        internal void LoadItems(A05_CountryColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindA06_CountryByParentProperties(item.parent_Country_ID);
                var rlce = obj.A07_RegionObjects.RaiseListChangedEvents;
                obj.A07_RegionObjects.RaiseListChangedEvents = false;
                obj.A07_RegionObjects.Add(item);
                obj.A07_RegionObjects.RaiseListChangedEvents = rlce;
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
