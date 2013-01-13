using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H07_RegionColl (editable child list).<br/>
    /// This is a generated base class of <see cref="H07_RegionColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="H06_Country"/> editable child object.<br/>
    /// The items of the collection are <see cref="H08_Region"/> objects.
    /// </remarks>
    [Serializable]
    public partial class H07_RegionColl : BusinessListBase<H07_RegionColl, H08_Region>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="H08_Region"/> item from the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to be removed.</param>
        public void Remove(int region_ID)
        {
            foreach (var h08_Region in this)
            {
                if (h08_Region.Region_ID == region_ID)
                {
                    Remove(h08_Region);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="H08_Region"/> item is in the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the H08_Region is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int region_ID)
        {
            foreach (var h08_Region in this)
            {
                if (h08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="H08_Region"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the H08_Region is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int region_ID)
        {
            foreach (var h08_Region in this.DeletedList)
            {
                if (h08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="H07_RegionColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="H07_RegionColl"/> collection.</returns>
        internal static H07_RegionColl NewH07_RegionColl()
        {
            return DataPortal.CreateChild<H07_RegionColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="H07_RegionColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent_Country_ID parameter of the H07_RegionColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="H07_RegionColl"/> collection.</returns>
        internal static H07_RegionColl GetH07_RegionColl(int parent_Country_ID)
        {
            return DataPortal.FetchChild<H07_RegionColl>(parent_Country_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H07_RegionColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H07_RegionColl()
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
        /// Loads a <see cref="H07_RegionColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent Country ID.</param>
        protected void Child_Fetch(int parent_Country_ID)
        {
            var args = new DataPortalHookArgs(parent_Country_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IH07_RegionCollDal>();
                var data = dal.Fetch(parent_Country_ID);
                LoadCollection(data);
            }
            OnFetchPost(args);
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        }

        private void LoadCollection(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="H07_RegionColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(H08_Region.GetH08_Region(dr));
            }
            RaiseListChangedEvents = rlce;
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
