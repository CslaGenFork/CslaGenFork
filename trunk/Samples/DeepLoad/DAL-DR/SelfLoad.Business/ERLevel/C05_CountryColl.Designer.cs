using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess.ERLevel;
using SelfLoad.DataAccess;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C05_CountryColl (editable child list).<br/>
    /// This is a generated base class of <see cref="C05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="C04_SubContinent"/> editable child object.<br/>
    /// The items of the collection are <see cref="C06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class C05_CountryColl : BusinessListBase<C05_CountryColl, C06_Country>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="C06_Country"/> item from the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to be removed.</param>
        public void Remove(int country_ID)
        {
            foreach (var c06_Country in this)
            {
                if (c06_Country.Country_ID == country_ID)
                {
                    Remove(c06_Country);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="C06_Country"/> item is in the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C06_Country is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int country_ID)
        {
            foreach (var c06_Country in this)
            {
                if (c06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="C06_Country"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C06_Country is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int country_ID)
        {
            foreach (var c06_Country in this.DeletedList)
            {
                if (c06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C05_CountryColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="C05_CountryColl"/> collection.</returns>
        internal static C05_CountryColl NewC05_CountryColl()
        {
            return DataPortal.CreateChild<C05_CountryColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C05_CountryColl"/> object, based on given parameters.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent_SubContinent_ID parameter of the C05_CountryColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C05_CountryColl"/> object.</returns>
        internal static C05_CountryColl GetC05_CountryColl(int parent_SubContinent_ID)
        {
            return DataPortal.FetchChild<C05_CountryColl>(parent_SubContinent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C05_CountryColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C05_CountryColl()
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
        /// Loads a <see cref="C05_CountryColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        protected void Child_Fetch(int parent_SubContinent_ID)
        {
            var args = new DataPortalHookArgs(parent_SubContinent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<IC05_CountryCollDal>();
                var data = dal.Fetch(parent_SubContinent_ID);
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
        /// Loads all <see cref="C05_CountryColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(C06_Country.GetC06_Country(dr));
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
