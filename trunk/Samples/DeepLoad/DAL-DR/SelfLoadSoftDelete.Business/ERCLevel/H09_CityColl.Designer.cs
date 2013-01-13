using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H09_CityColl (editable child list).<br/>
    /// This is a generated base class of <see cref="H09_CityColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="H08_Region"/> editable child object.<br/>
    /// The items of the collection are <see cref="H10_City"/> objects.
    /// </remarks>
    [Serializable]
    public partial class H09_CityColl : BusinessListBase<H09_CityColl, H10_City>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="H10_City"/> item from the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to be removed.</param>
        public void Remove(int city_ID)
        {
            foreach (var h10_City in this)
            {
                if (h10_City.City_ID == city_ID)
                {
                    Remove(h10_City);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="H10_City"/> item is in the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the H10_City is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int city_ID)
        {
            foreach (var h10_City in this)
            {
                if (h10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="H10_City"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the H10_City is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int city_ID)
        {
            foreach (var h10_City in this.DeletedList)
            {
                if (h10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="H09_CityColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="H09_CityColl"/> collection.</returns>
        internal static H09_CityColl NewH09_CityColl()
        {
            return DataPortal.CreateChild<H09_CityColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="H09_CityColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent_Region_ID parameter of the H09_CityColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="H09_CityColl"/> collection.</returns>
        internal static H09_CityColl GetH09_CityColl(int parent_Region_ID)
        {
            return DataPortal.FetchChild<H09_CityColl>(parent_Region_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H09_CityColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H09_CityColl()
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
        /// Loads a <see cref="H09_CityColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent Region ID.</param>
        protected void Child_Fetch(int parent_Region_ID)
        {
            var args = new DataPortalHookArgs(parent_Region_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IH09_CityCollDal>();
                var data = dal.Fetch(parent_Region_ID);
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
        /// Loads all <see cref="H09_CityColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(H10_City.GetH10_City(dr));
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
