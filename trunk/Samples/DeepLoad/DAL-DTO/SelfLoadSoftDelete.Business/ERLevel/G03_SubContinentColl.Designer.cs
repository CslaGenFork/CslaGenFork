using System;
using System.Collections.Generic;
using Csla;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERLevel;

namespace SelfLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G03_SubContinentColl (editable child list).<br/>
    /// This is a generated base class of <see cref="G03_SubContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="G02_Continent"/> editable root object.<br/>
    /// The items of the collection are <see cref="G04_SubContinent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class G03_SubContinentColl : BusinessListBase<G03_SubContinentColl, G04_SubContinent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="G04_SubContinent"/> item from the collection.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to be removed.</param>
        public void Remove(int subContinent_ID)
        {
            foreach (var g04_SubContinent in this)
            {
                if (g04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    Remove(g04_SubContinent);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="G04_SubContinent"/> item is in the collection.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the G04_SubContinent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int subContinent_ID)
        {
            foreach (var g04_SubContinent in this)
            {
                if (g04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="G04_SubContinent"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the G04_SubContinent is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int subContinent_ID)
        {
            foreach (var g04_SubContinent in DeletedList)
            {
                if (g04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="G04_SubContinent"/> item of the <see cref="G03_SubContinentColl"/> collection, based on a given SubContinent_ID.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID.</param>
        /// <returns>A <see cref="G04_SubContinent"/> object.</returns>
        public G04_SubContinent FindG04_SubContinentBySubContinent_ID(int subContinent_ID)
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
        /// Factory method. Creates a new <see cref="G03_SubContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="G03_SubContinentColl"/> collection.</returns>
        internal static G03_SubContinentColl NewG03_SubContinentColl()
        {
            return DataPortal.CreateChild<G03_SubContinentColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="G03_SubContinentColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent_Continent_ID parameter of the G03_SubContinentColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G03_SubContinentColl"/> collection.</returns>
        internal static G03_SubContinentColl GetG03_SubContinentColl(int parent_Continent_ID)
        {
            return DataPortal.FetchChild<G03_SubContinentColl>(parent_Continent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G03_SubContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public G03_SubContinentColl()
        {
            // Use factory methods and do not use direct creation.

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
        /// Loads a <see cref="G03_SubContinentColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent Continent ID.</param>
        protected void Child_Fetch(int parent_Continent_ID)
        {
            var args = new DataPortalHookArgs(parent_Continent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG03_SubContinentCollDal>();
                var data = dal.Fetch(parent_Continent_ID);
                Fetch(data);
            }
            OnFetchPost(args);
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        }

        /// <summary>
        /// Loads all <see cref="G03_SubContinentColl"/> collection items from the given list of G04_SubContinentDto.
        /// </summary>
        /// <param name="data">The list of <see cref="G04_SubContinentDto"/>.</param>
        private void Fetch(List<G04_SubContinentDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(G04_SubContinent.GetG04_SubContinent(dto));
            }
            RaiseListChangedEvents = rlce;
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
