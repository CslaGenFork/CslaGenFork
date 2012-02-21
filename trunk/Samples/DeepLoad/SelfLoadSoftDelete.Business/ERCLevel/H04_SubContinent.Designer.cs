using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H04_SubContinent (editable child object).<br/>
    /// This is a generated base class of <see cref="H04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H05_CountryObjects"/> of type <see cref="H05_CountryColl"/> (1:M relation to <see cref="H06_Country"/>)<br/>
    /// This class is an item of <see cref="H03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H04_SubContinent : BusinessBase<H04_SubContinent>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SubContinent_IDProperty = RegisterProperty<int>(p => p.SubContinent_ID, "2_SubContinents ID");
        /// <summary>
        /// Gets the 2_SubContinents ID.
        /// </summary>
        /// <value>The 2_SubContinents ID.</value>
        public int SubContinent_ID
        {
            get { return GetProperty(SubContinent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_NameProperty = RegisterProperty<string>(p => p.SubContinent_Name, "2_SubContinents Name");
        /// <summary>
        /// Gets or sets the 2_SubContinents Name.
        /// </summary>
        /// <value>The 2_SubContinents Name.</value>
        public string SubContinent_Name
        {
            get { return GetProperty(SubContinent_NameProperty); }
            set { SetProperty(SubContinent_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H05_SubContinent_Child> H05_SubContinent_SingleObjectProperty = RegisterProperty<H05_SubContinent_Child>(p => p.H05_SubContinent_SingleObject, "H05 SubContinent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H05 Sub Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The H05 Sub Continent Single Object.</value>
        public H05_SubContinent_Child H05_SubContinent_SingleObject
        {
            get { return GetProperty(H05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(H05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H05_SubContinent_ReChild> H05_SubContinent_ASingleObjectProperty = RegisterProperty<H05_SubContinent_ReChild>(p => p.H05_SubContinent_ASingleObject, "H05 SubContinent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H05 Sub Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H05 Sub Continent ASingle Object.</value>
        public H05_SubContinent_ReChild H05_SubContinent_ASingleObject
        {
            get { return GetProperty(H05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(H05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H05_CountryColl> H05_CountryObjectsProperty = RegisterProperty<H05_CountryColl>(p => p.H05_CountryObjects, "H05 Country Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H05 Country Objects ("self load" child property).
        /// </summary>
        /// <value>The H05 Country Objects.</value>
        public H05_CountryColl H05_CountryObjects
        {
            get { return GetProperty(H05_CountryObjectsProperty); }
            private set { LoadProperty(H05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="H04_SubContinent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="H04_SubContinent"/> object.</returns>
        internal static H04_SubContinent NewH04_SubContinent()
        {
            return DataPortal.CreateChild<H04_SubContinent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="H04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H04_SubContinent"/> object.</returns>
        internal static H04_SubContinent GetH04_SubContinent(SafeDataReader dr)
        {
            H04_SubContinent obj = new H04_SubContinent();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H04_SubContinent()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="H04_SubContinent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(SubContinent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(H05_SubContinent_SingleObjectProperty, DataPortal.CreateChild<H05_SubContinent_Child>());
            LoadProperty(H05_SubContinent_ASingleObjectProperty, DataPortal.CreateChild<H05_SubContinent_ReChild>());
            LoadProperty(H05_CountryObjectsProperty, DataPortal.CreateChild<H05_CountryColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="H04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(SubContinent_IDProperty, dr.GetInt32("SubContinent_ID"));
            LoadProperty(SubContinent_NameProperty, dr.GetString("SubContinent_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(H05_SubContinent_SingleObjectProperty, H05_SubContinent_Child.GetH05_SubContinent_Child(SubContinent_ID));
            LoadProperty(H05_SubContinent_ASingleObjectProperty, H05_SubContinent_ReChild.GetH05_SubContinent_ReChild(SubContinent_ID));
            LoadProperty(H05_CountryObjectsProperty, H05_CountryColl.GetH05_CountryColl(SubContinent_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="H04_SubContinent"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(H02_Continent parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", parent.Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", ReadProperty(SubContinent_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", ReadProperty(SubContinent_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(SubContinent_IDProperty, (int) cmd.Parameters["@SubContinent_ID"].Value);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="H04_SubContinent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", ReadProperty(SubContinent_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", ReadProperty(SubContinent_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="H04_SubContinent"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteH04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", ReadProperty(SubContinent_IDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(H05_SubContinent_SingleObjectProperty, DataPortal.CreateChild<H05_SubContinent_Child>());
            LoadProperty(H05_SubContinent_ASingleObjectProperty, DataPortal.CreateChild<H05_SubContinent_ReChild>());
            LoadProperty(H05_CountryObjectsProperty, DataPortal.CreateChild<H05_CountryColl>());
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
