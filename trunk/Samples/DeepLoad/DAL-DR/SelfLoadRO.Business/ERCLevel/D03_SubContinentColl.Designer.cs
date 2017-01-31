using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERCLevel;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D03_SubContinentColl (read only list).<br/>
    /// This is a generated base class of <see cref="D03_SubContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="D02_Continent"/> read only object.<br/>
    /// The items of the collection are <see cref="D04_SubContinent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class D03_SubContinentColl : ReadOnlyListBase<D03_SubContinentColl, D04_SubContinent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="D04_SubContinent"/> item is in the collection.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D04_SubContinent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int subContinent_ID)
        {
            foreach (var d04_SubContinent in this)
            {
                if (d04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="D04_SubContinent"/> item of the <see cref="D03_SubContinentColl"/> collection, based on a given SubContinent_ID.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID.</param>
        /// <returns>A <see cref="D04_SubContinent"/> object.</returns>
        public D04_SubContinent FindD04_SubContinentBySubContinent_ID(int subContinent_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].SubContinent_ID.Equals(subContinent_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D03_SubContinentColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent_Continent_ID parameter of the D03_SubContinentColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D03_SubContinentColl"/> collection.</returns>
        internal static D03_SubContinentColl GetD03_SubContinentColl(int parent_Continent_ID)
        {
            return DataPortal.FetchChild<D03_SubContinentColl>(parent_Continent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D03_SubContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public D03_SubContinentColl()
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
        /// Loads a <see cref="D03_SubContinentColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent Continent ID.</param>
        protected void Child_Fetch(int parent_Continent_ID)
        {
            var args = new DataPortalHookArgs(parent_Continent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadRO.GetManager())
            {
                var dal = dalManager.GetProvider<ID03_SubContinentCollDal>();
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
        /// Loads all <see cref="D03_SubContinentColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(D04_SubContinent.GetD04_SubContinent(dr));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
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
