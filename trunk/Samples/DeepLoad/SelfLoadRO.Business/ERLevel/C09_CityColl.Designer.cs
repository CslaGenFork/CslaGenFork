using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C09_CityColl (read only list).<br/>
    /// This is a generated base class of <see cref="C09_CityColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="C08_Region"/> read only object.<br/>
    /// The items of the collection are <see cref="C10_City"/> objects.
    /// </remarks>
    [Serializable]
    public partial class C09_CityColl : ReadOnlyListBase<C09_CityColl, C10_City>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="C10_City"/> item is in the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C10_City is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int city_ID)
        {
            foreach (var c10_City in this)
            {
                if (c10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="C10_City"/> item of the <see cref="C09_CityColl"/> collection, based on a given City_ID.
        /// </summary>
        /// <param name="city_ID">The City_ID.</param>
        /// <returns>A <see cref="C10_City"/> object.</returns>
        public C10_City FindC10_CityByCity_ID(int city_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].City_ID.Equals(city_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="C09_CityColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent_Region_ID parameter of the C09_CityColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C09_CityColl"/> collection.</returns>
        internal static C09_CityColl GetC09_CityColl(int parent_Region_ID)
        {
            return DataPortal.FetchChild<C09_CityColl>(parent_Region_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C09_CityColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C09_CityColl()
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
        /// Loads a <see cref="C09_CityColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent Region ID.</param>
        protected void Child_Fetch(int parent_Region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC09_CityColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Region_ID", parent_Region_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, parent_Region_ID);
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
        /// Loads all <see cref="C09_CityColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(C10_City.GetC10_City(dr));
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
