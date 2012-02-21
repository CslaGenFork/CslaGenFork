using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess.ERCLevel;
using ParentLoadSoftDelete.DataAccess;

namespace ParentLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F01_ContinentColl (editable root list).<br/>
    /// This is a generated base class of <see cref="F01_ContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="F02_Continent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class F01_ContinentColl : BusinessListBase<F01_ContinentColl, F02_Continent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="F02_Continent"/> item from the collection.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to be removed.</param>
        public void Remove(int continent_ID)
        {
            foreach (var f02_Continent in this)
            {
                if (f02_Continent.Continent_ID == continent_ID)
                {
                    Remove(f02_Continent);
                    break;
                }
            }
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

        /// <summary>
        /// Determines whether a <see cref="F02_Continent"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the F02_Continent is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int continent_ID)
        {
            foreach (var f02_Continent in this.DeletedList)
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
        /// Factory method. Creates a new <see cref="F01_ContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="F01_ContinentColl"/> collection.</returns>
        public static F01_ContinentColl NewF01_ContinentColl()
        {
            return DataPortal.Create<F01_ContinentColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="F01_ContinentColl"/> object.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="F01_ContinentColl"/> object.</returns>
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
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
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
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IF01_ContinentCollDal>();
                var data = dal.Fetch();
                LoadCollection(data);
            }
            OnFetchPost(args);
        }

        private void LoadCollection(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                Fetch(dr);
                if (this.Count > 0)
                    this[0].FetchChildren(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="F01_ContinentColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(F02_Continent.GetF02_Continent(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="F01_ContinentColl"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                base.Child_Update();
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
