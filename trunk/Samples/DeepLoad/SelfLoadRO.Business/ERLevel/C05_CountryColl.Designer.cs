using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C05_CountryColl (read only list).<br/>
    /// This is a generated base class of <see cref="C05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="C04_SubContinent"/> read only object.<br/>
    /// The items of the collection are <see cref="C06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class C05_CountryColl : ReadOnlyListBase<C05_CountryColl, C06_Country>
    {

        #region Collection Business Methods

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

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="C06_Country"/> item of the <see cref="C05_CountryColl"/> collection, based on a given Country_ID.
        /// </summary>
        /// <param name="country_ID">The Country_ID.</param>
        /// <returns>A <see cref="C06_Country"/> object.</returns>
        public C06_Country FindC06_CountryByCountry_ID(int country_ID)
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
        /// Factory method. Loads a <see cref="C05_CountryColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent_SubContinent_ID parameter of the C05_CountryColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C05_CountryColl"/> collection.</returns>
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
        /// Loads a <see cref="C05_CountryColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        protected void Child_Fetch(int parent_SubContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC05_CountryColl", ctx.Connection))
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
        /// Loads all <see cref="C05_CountryColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(C06_Country.GetC06_Country(dr));
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
