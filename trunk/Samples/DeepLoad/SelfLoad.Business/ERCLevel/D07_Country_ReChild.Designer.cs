using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D07_Country_ReChild (editable child object).<br/>
    /// This is a generated base class of <see cref="D07_Country_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="D06_Country"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D07_Country_ReChild : BusinessBase<D07_Country_ReChild>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Country_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Country_Child_NameProperty = RegisterProperty<string>(p => p.Country_Child_Name, "Regions Child Name");
        /// <summary>
        /// Gets or sets the Regions Child Name.
        /// </summary>
        /// <value>The Regions Child Name.</value>
        public string Country_Child_Name
        {
            get { return GetProperty(Country_Child_NameProperty); }
            set { SetProperty(Country_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D07_Country_ReChild"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="D07_Country_ReChild"/> object.</returns>
        internal static D07_Country_ReChild NewD07_Country_ReChild()
        {
            return DataPortal.CreateChild<D07_Country_ReChild>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D07_Country_ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="country_ID2">The Country_ID2 parameter of the D07_Country_ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D07_Country_ReChild"/> object.</returns>
        internal static D07_Country_ReChild GetD07_Country_ReChild(int country_ID2)
        {
            return DataPortal.FetchChild<D07_Country_ReChild>(country_ID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D07_Country_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D07_Country_ReChild()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="D07_Country_ReChild"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="D07_Country_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="country_ID2">The Country ID2.</param>
        protected void Child_Fetch(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, country_ID2);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="D07_Country_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_Child_NameProperty, dr.GetString("Country_Child_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="D07_Country_ReChild"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(D06_Country parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", parent.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", ReadProperty(Country_Child_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="D07_Country_ReChild"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(D06_Country parent)
        {
            if (!IsDirty)
                return;

            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", parent.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", ReadProperty(Country_Child_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
            }
        }

        /// <summary>
        /// Self deletes the <see cref="D07_Country_ReChild"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(D06_Country parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", parent.Country_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}
