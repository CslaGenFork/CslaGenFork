using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B01Level1Coll (editable root list).<br/>
    /// This is a generated base class of <see cref="B01Level1Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="B02Level1"/> objects.
    /// </remarks>
    [Serializable]
    public partial class B01Level1Coll : BusinessListBase<B01Level1Coll, B02Level1>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="B02Level1"/> item from the collection.
        /// </summary>
        /// <param name="level_1_ID">The Level_1_ID of the item to be removed.</param>
        public void Remove(int level_1_ID)
        {
            foreach (B02Level1 b02Level1 in this)
            {
                if (b02Level1.Level_1_ID == level_1_ID)
                {
                      Remove(b02Level1);
                      break;
                }
            }
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="B02Level1"/> item of the <see cref="B01Level1Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_ID">The Level_1_ID.</param>
        /// <returns>A <see cref="B02Level1"/> object.</returns>
        public B02Level1 FindB02Level1ByParentProperties(int level_1_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Level_1_ID.Equals(level_1_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B01Level1Coll"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="B01Level1Coll"/> collection.</returns>
        public static B01Level1Coll NewB01Level1Coll()
        {
            return DataPortal.Create<B01Level1Coll>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B01Level1Coll"/> object.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="B01Level1Coll"/> object.</returns>
        public static B01Level1Coll GetB01Level1Coll()
        {
            return DataPortal.Fetch<B01Level1Coll>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B01Level1Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B01Level1Coll()
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
        /// Loads a <see cref="B01Level1Coll"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetB01Level1Coll", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
                if (this.Count > 0)
                    this[0].FetchChildren(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="B01Level1Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(B02Level1.GetB02Level1(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="B01Level1Coll"/> object.
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
