using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D04Level11 (editable child object).<br/>
    /// This is a generated base class of <see cref="D04Level11"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D05Level111Objects"/> of type <see cref="D05Level111Coll"/> (1:M relation to <see cref="D06Level111"/>)<br/>
    /// This class is an item of <see cref="D03Level11Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D04Level11 : BusinessBase<D04Level11>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_ID, "Level_1_1 ID");
        /// <summary>
        /// Gets the Level_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1 ID.</value>
        public int Level_1_1_ID
        {
            get { return GetProperty(Level_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_Name, "Level_1_1 Name");
        /// <summary>
        /// Gets or sets the Level_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1 Name.</value>
        public string Level_1_1_Name
        {
            get { return GetProperty(Level_1_1_NameProperty); }
            set { SetProperty(Level_1_1_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D05Level111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D05Level111ReChild> D05Level111ASingleObjectProperty = RegisterProperty<D05Level111ReChild>(p => p.D05Level111ASingleObject, "B5 Level111 ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D05 Level111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D05 Level111 ASingle Object.</value>
        public D05Level111ReChild D05Level111ASingleObject
        {
            get { return GetProperty(D05Level111ASingleObjectProperty); }
            private set { LoadProperty(D05Level111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D05Level111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D05Level111Child> D05Level111SingleObjectProperty = RegisterProperty<D05Level111Child>(p => p.D05Level111SingleObject, "B5 Level111 Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D05 Level111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The D05 Level111 Single Object.</value>
        public D05Level111Child D05Level111SingleObject
        {
            get { return GetProperty(D05Level111SingleObjectProperty); }
            private set { LoadProperty(D05Level111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D05Level111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D05Level111Coll> D05Level111ObjectsProperty = RegisterProperty<D05Level111Coll>(p => p.D05Level111Objects, "B5 Level111 Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D05 Level111 Objects ("self load" child property).
        /// </summary>
        /// <value>The D05 Level111 Objects.</value>
        public D05Level111Coll D05Level111Objects
        {
            get { return GetProperty(D05Level111ObjectsProperty); }
            private set { LoadProperty(D05Level111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D04Level11"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="D04Level11"/> object.</returns>
        internal static D04Level11 NewD04Level11()
        {
            return DataPortal.CreateChild<D04Level11>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D04Level11"/> object.</returns>
        internal static D04Level11 GetD04Level11(SafeDataReader dr)
        {
            D04Level11 obj = new D04Level11();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D04Level11"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D04Level11()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="D04Level11"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Level_1_1_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(D05Level111ASingleObjectProperty, DataPortal.CreateChild<D05Level111ReChild>());
            LoadProperty(D05Level111SingleObjectProperty, DataPortal.CreateChild<D05Level111Child>());
            LoadProperty(D05Level111ObjectsProperty, DataPortal.CreateChild<D05Level111Coll>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="D04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_IDProperty, dr.GetInt32("Level_1_1_ID"));
            LoadProperty(Level_1_1_NameProperty, dr.GetString("Level_1_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(D05Level111ASingleObjectProperty, D05Level111ReChild.GetD05Level111ReChild(Level_1_1_ID));
            LoadProperty(D05Level111SingleObjectProperty, D05Level111Child.GetD05Level111Child(Level_1_1_ID));
            LoadProperty(D05Level111ObjectsProperty, D05Level111Coll.GetD05Level111Coll(Level_1_1_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="D04Level11"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(D02Level1 parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD04Level11", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", parent.Level_1_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_ID", ReadProperty(Level_1_1_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Level_1_1_Name", ReadProperty(Level_1_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Level_1_1_IDProperty, (int) cmd.Parameters["@Level_1_1_ID"].Value);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="D04Level11"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD04Level11", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_ID", ReadProperty(Level_1_1_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_Name", ReadProperty(Level_1_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="D04Level11"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteD04Level11", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_ID", ReadProperty(Level_1_1_IDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(D05Level111ASingleObjectProperty, DataPortal.CreateChild<D05Level111ReChild>());
            LoadProperty(D05Level111SingleObjectProperty, DataPortal.CreateChild<D05Level111Child>());
            LoadProperty(D05Level111ObjectsProperty, DataPortal.CreateChild<D05Level111Coll>());
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
