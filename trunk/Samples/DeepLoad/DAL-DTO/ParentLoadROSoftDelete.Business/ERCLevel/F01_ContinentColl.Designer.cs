using System;
using System.Collections.Generic;
using Csla;
using ParentLoadROSoftDelete.DataAccess;
using ParentLoadROSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F01_ContinentColl (read only list).<br/>
    /// This is a generated base class of <see cref="F01_ContinentColl"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="F02_Continent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F01_ContinentColl : ReadOnlyListBase<F01_ContinentColl, F02_Continent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Adds a new <see cref="F02_Continent"/> item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>
        /// There is no valid Parent property (inexistant or null).
        /// The Add method is redefined so it takes care of filling the ParentList property.
        /// </remarks>
        public new void Add(F02_Continent item)
        {
            item.ParentList = this;
            base.Add(item);
        }

        /// <summary>
        /// Determines whether a <see cref="F02_Continent"/> item is in the collection.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F02_Continent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int continent_ID)
        {
            foreach (var f02_Continent in this)
            {
                if (f02_Continent.Continent_ID == continent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="F02_Continent"/> item of the <see cref="F01_ContinentColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID.</param>
        /// <returns>A <see cref="F02_Continent"/> object.</returns>
        public F02_Continent FindF02_ContinentByParentProperties(int continent_ID)
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
        /// Factory method. Loads a <see cref="F01_ContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="F01_ContinentColl"/> collection.</returns>
        public static F01_ContinentColl GetF01_ContinentColl()
        {
            return DataPortal.Fetch<F01_ContinentColl>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F01_ContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F01_ContinentColl()
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
        /// Loads a <see cref="F01_ContinentColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            var args = new DataPortalHookArgs();
            OnFetchPre(args);
            using (var dalManager = DalFactoryParentLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IF01_ContinentCollDal>();
                var data = dal.Fetch();
                Fetch(data);
                LoadCollection(dal);
            }
            OnFetchPost(args);
        }

        private void LoadCollection(IF01_ContinentCollDal dal)
        {
            if (this.Count > 0)
                this[0].FetchChildren(dal);
        }

        /// <summary>
        /// Loads all <see cref="F01_ContinentColl"/> collection items from the given list of F02_ContinentDto.
        /// </summary>
        /// <param name="data">The list of <see cref="F02_ContinentDto"/>.</param>
        private void Fetch(List<F02_ContinentDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(F02_Continent.GetF02_Continent(dto));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
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
