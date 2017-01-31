using System;
using System.Collections.Generic;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D01_ContinentColl (editable root list).<br/>
    /// This is a generated base class of <see cref="D01_ContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="D02_Continent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class D01_ContinentColl : BusinessListBase<D01_ContinentColl, D02_Continent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="D02_Continent"/> item from the collection.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to be removed.</param>
        public void Remove(int continent_ID)
        {
            foreach (var d02_Continent in this)
            {
                if (d02_Continent.Continent_ID == continent_ID)
                {
                    Remove(d02_Continent);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="D02_Continent"/> item is in the collection.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D02_Continent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int continent_ID)
        {
            foreach (var d02_Continent in this)
            {
                if (d02_Continent.Continent_ID == continent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="D02_Continent"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D02_Continent is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int continent_ID)
        {
            foreach (var d02_Continent in DeletedList)
            {
                if (d02_Continent.Continent_ID == continent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="D02_Continent"/> item of the <see cref="D01_ContinentColl"/> collection, based on a given Continent_ID.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID.</param>
        /// <returns>A <see cref="D02_Continent"/> object.</returns>
        public D02_Continent FindD02_ContinentByContinent_ID(int continent_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Continent_ID.Equals(continent_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D01_ContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="D01_ContinentColl"/> collection.</returns>
        public static D01_ContinentColl NewD01_ContinentColl()
        {
            return DataPortal.Create<D01_ContinentColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D01_ContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="D01_ContinentColl"/> collection.</returns>
        public static D01_ContinentColl GetD01_ContinentColl()
        {
            return DataPortal.Fetch<D01_ContinentColl>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D01_ContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public D01_ContinentColl()
        {
            // Use factory methods and do not use direct creation.

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
        /// Loads a <see cref="D01_ContinentColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            var args = new DataPortalHookArgs();
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<ID01_ContinentCollDal>();
                var data = dal.Fetch();
                Fetch(data);
            }
            OnFetchPost(args);
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        }

        /// <summary>
        /// Loads all <see cref="D01_ContinentColl"/> collection items from the given list of D02_ContinentDto.
        /// </summary>
        /// <param name="data">The list of <see cref="D02_ContinentDto"/>.</param>
        private void Fetch(List<D02_ContinentDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(D02_Continent.GetD02_Continent(dto));
            }
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="D01_ContinentColl"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                base.Child_Update();
            }
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
