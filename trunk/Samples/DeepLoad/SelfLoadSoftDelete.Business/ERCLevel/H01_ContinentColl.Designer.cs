using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H01_ContinentColl (editable root list).<br/>
    /// This is a generated base class of <see cref="H01_ContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="H02_Continent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class H01_ContinentColl : BusinessListBase<H01_ContinentColl, H02_Continent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="H02_Continent"/> item from the collection.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to be removed.</param>
        public void Remove(int continent_ID)
        {
            foreach (var h02_Continent in this)
            {
                if (h02_Continent.Continent_ID == continent_ID)
                {
                    Remove(h02_Continent);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="H02_Continent"/> item is in the collection.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the H02_Continent is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int continent_ID)
        {
            foreach (var h02_Continent in this)
            {
                if (h02_Continent.Continent_ID == continent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="H02_Continent"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the H02_Continent is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int continent_ID)
        {
            foreach (var h02_Continent in this.DeletedList)
            {
                if (h02_Continent.Continent_ID == continent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="H02_Continent"/> item of the <see cref="H01_ContinentColl"/> collection, based on a given Continent_ID.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID.</param>
        /// <returns>A <see cref="H02_Continent"/> object.</returns>
        public H02_Continent FindH02_ContinentByContinent_ID(int continent_ID)
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
        /// Factory method. Creates a new <see cref="H01_ContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="H01_ContinentColl"/> collection.</returns>
        public static H01_ContinentColl NewH01_ContinentColl()
        {
            return DataPortal.Create<H01_ContinentColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="H01_ContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="H01_ContinentColl"/> collection.</returns>
        public static H01_ContinentColl GetH01_ContinentColl()
        {
            return DataPortal.Fetch<H01_ContinentColl>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H01_ContinentColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H01_ContinentColl()
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
        /// Loads a <see cref="H01_ContinentColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH01_ContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="H01_ContinentColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(H02_Continent.GetH02_Continent(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="H01_ContinentColl"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
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
