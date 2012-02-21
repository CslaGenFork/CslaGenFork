using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D03_SubContinentColl (editable child list).<br/>
    /// This is a generated base class of <see cref="D03_SubContinentColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="D02_Continent"/> editable child object.<br/>
    /// The items of the collection are <see cref="D04_SubContinent"/> objects.
    /// </remarks>
    [Serializable]
    public partial class D03_SubContinentColl : BusinessListBase<D03_SubContinentColl, D04_SubContinent>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="D04_SubContinent"/> item from the collection.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to be removed.</param>
        public void Remove(int subContinent_ID)
        {
            foreach (var d04_SubContinent in this)
            {
                if (d04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    Remove(d04_SubContinent);
                    break;
                }
            }
        }

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

        /// <summary>
        /// Determines whether a <see cref="D04_SubContinent"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="subContinent_ID">The SubContinent_ID of the item to search for.</param>
        /// <returns><c>true</c> if the D04_SubContinent is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int subContinent_ID)
        {
            foreach (var d04_SubContinent in this.DeletedList)
            {
                if (d04_SubContinent.SubContinent_ID == subContinent_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D03_SubContinentColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="D03_SubContinentColl"/> collection.</returns>
        internal static D03_SubContinentColl NewD03_SubContinentColl()
        {
            return DataPortal.CreateChild<D03_SubContinentColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D03_SubContinentColl"/> object, based on given parameters.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent_Continent_ID parameter of the D03_SubContinentColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D03_SubContinentColl"/> object.</returns>
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
        private D03_SubContinentColl()
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
        /// Loads a <see cref="D03_SubContinentColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent Continent ID.</param>
        protected void Child_Fetch(int parent_Continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD03_SubContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Continent_ID", parent_Continent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, parent_Continent_ID);
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
        /// Loads all <see cref="D03_SubContinentColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(D04_SubContinent.GetD04_SubContinent(dr));
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
