using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F07_Country_Child (editable child object).<br/>
    /// This is a generated base class of <see cref="F07_Country_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F06_Country"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F07_Country_Child : BusinessBase<F07_Country_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int country_ID1 = 0;

        #endregion

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
        /// Factory method. Creates a new <see cref="F07_Country_Child"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="F07_Country_Child"/> object.</returns>
        internal static F07_Country_Child NewF07_Country_Child()
        {
            return DataPortal.CreateChild<F07_Country_Child>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="F07_Country_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F07_Country_Child"/> object.</returns>
        internal static F07_Country_Child GetF07_Country_Child(SafeDataReader dr)
        {
            F07_Country_Child obj = new F07_Country_Child();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F07_Country_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F07_Country_Child()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="F07_Country_Child"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="F07_Country_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_Child_NameProperty, dr.GetString("Country_Child_Name"));
            // parent properties
            country_ID1 = dr.GetInt32("Country_ID1");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="F07_Country_Child"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(F06_Country parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", parent.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", ReadProperty(Country_Child_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="F07_Country_Child"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(F06_Country parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", parent.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", ReadProperty(Country_Child_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
            }
        }

        /// <summary>
        /// Self deletes the <see cref="F07_Country_Child"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(F06_Country parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", parent.Country_ID).DbType = DbType.Int32;
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
