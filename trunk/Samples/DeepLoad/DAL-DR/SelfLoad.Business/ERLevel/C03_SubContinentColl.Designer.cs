using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C03_SubContinentColl (editable child list).<br/>
    /// This is a generated base class of <see cref="C03_SubContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="C02_Continent"/> editable root object.<br/>
    /// The items of the collection are <see cref="C04_SubContinent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class C03_SubContinentColl : BusinessListBase<C03_SubContinentColl, C04_SubContinent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="C04_SubContinent"/> item from the collection.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to be removed.</param>
        public void Remove(int subContinent_ID)
        {
            foreach (var c04_SubContinent in this)
            {
                if (c04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    Remove(c04_SubContinent);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="C04_SubContinent"/> item is in the collection.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C04_SubContinent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int subContinent_ID)
        {
            foreach (var c04_SubContinent in this)
            {
                if (c04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="C04_SubContinent"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C04_SubContinent is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int subContinent_ID)
        {
            foreach (var c04_SubContinent in this.DeletedList)
            {
                if (c04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C03_SubContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="C03_SubContinentColl"/> collection.</returns>
        internal static C03_SubContinentColl NewC03_SubContinentColl()
        {
            return DataPortal.CreateChild<C03_SubContinentColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C03_SubContinentColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent_Continent_ID parameter of the C03_SubContinentColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C03_SubContinentColl"/> collection.</returns>
        internal static C03_SubContinentColl GetC03_SubContinentColl(int parent_Continent_ID)
        {
            return DataPortal.FetchChild<C03_SubContinentColl>(parent_Continent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C03_SubContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C03_SubContinentColl()
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
        /// Loads a <see cref="C03_SubContinentColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent Continent ID.</param>
        protected void Child_Fetch(int parent_Continent_ID)
        {
            var args = new DataPortalHookArgs(parent_Continent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<IC03_SubContinentCollDal>();
                var data = dal.Fetch(parent_Continent_ID);
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
        /// Loads all <see cref="C03_SubContinentColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(C04_SubContinent.GetC04_SubContinent(dr));
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
