using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G05_CountryColl (editable child list).<br/>
    /// This is a generated base class of <see cref="G05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="G04_SubContinent"/> editable child object.<br/>
    /// The items of the collection are <see cref="G06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class G05_CountryColl : BusinessListBase<G05_CountryColl, G06_Country>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="G06_Country"/> item from the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to be removed.</param>
        public void Remove(int country_ID)
        {
            foreach (var g06_Country in this)
            {
                if (g06_Country.Country_ID == country_ID)
                {
                    Remove(g06_Country);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="G06_Country"/> item is in the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the G06_Country is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int country_ID)
        {
            foreach (var g06_Country in this)
            {
                if (g06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="G06_Country"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the G06_Country is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int country_ID)
        {
            foreach (var g06_Country in DeletedList)
            {
                if (g06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="G06_Country"/> item of the <see cref="G05_CountryColl"/> collection, based on a given Country_ID.
        /// </summary>
        /// <param name="country_ID">The Country_ID.</param>
        /// <returns>A <see cref="G06_Country"/> object.</returns>
        public G06_Country FindG06_CountryByCountry_ID(int country_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Country_ID.Equals(country_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="G05_CountryColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="G05_CountryColl"/> collection.</returns>
        internal static G05_CountryColl NewG05_CountryColl()
        {
            return DataPortal.CreateChild<G05_CountryColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="G05_CountryColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent_SubContinent_ID parameter of the G05_CountryColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G05_CountryColl"/> collection.</returns>
        internal static G05_CountryColl GetG05_CountryColl(int parent_SubContinent_ID)
        {
            return DataPortal.FetchChild<G05_CountryColl>(parent_SubContinent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G05_CountryColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public G05_CountryColl()
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
        /// Loads a <see cref="G05_CountryColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        protected void Child_Fetch(int parent_SubContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG05_CountryColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", parent_SubContinent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, parent_SubContinent_ID);
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
        /// Loads all <see cref="G05_CountryColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(G06_Country.GetG06_Country(dr));
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
