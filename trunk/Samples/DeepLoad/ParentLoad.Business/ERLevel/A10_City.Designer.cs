using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A10_City (editable child object).<br/>
    /// This is a generated base class of <see cref="A10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="A11_CityRoadObjects"/> of type <see cref="A11_CityRoadColl"/> (1:M relation to <see cref="A12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="A09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A10_City : BusinessBase<A10_City>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_Region_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="City_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> City_IDProperty = RegisterProperty<int>(p => p.City_ID, "City ID");
        /// <summary>
        /// Gets the City ID.
        /// </summary>
        /// <value>The City ID.</value>
        public int City_ID
        {
            get { return GetProperty(City_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="City_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> City_NameProperty = RegisterProperty<string>(p => p.City_Name, "City Name");
        /// <summary>
        /// Gets or sets the City Name.
        /// </summary>
        /// <value>The City Name.</value>
        public string City_Name
        {
            get { return GetProperty(City_NameProperty); }
            set { SetProperty(City_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A11_City_Child> A11_City_SingleObjectProperty = RegisterProperty<A11_City_Child>(p => p.A11_City_SingleObject, "A11 City Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A11 City Single Object ("parent load" child property).
        /// </summary>
        /// <value>The A11 City Single Object.</value>
        public A11_City_Child A11_City_SingleObject
        {
            get { return GetProperty(A11_City_SingleObjectProperty); }
            private set { LoadProperty(A11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A11_City_ReChild> A11_City_ASingleObjectProperty = RegisterProperty<A11_City_ReChild>(p => p.A11_City_ASingleObject, "A11 City ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A11 City ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The A11 City ASingle Object.</value>
        public A11_City_ReChild A11_City_ASingleObject
        {
            get { return GetProperty(A11_City_ASingleObjectProperty); }
            private set { LoadProperty(A11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<A11_CityRoadColl> A11_CityRoadObjectsProperty = RegisterProperty<A11_CityRoadColl>(p => p.A11_CityRoadObjects, "A11 CityRoad Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A11 City Road Objects ("parent load" child property).
        /// </summary>
        /// <value>The A11 City Road Objects.</value>
        public A11_CityRoadColl A11_CityRoadObjects
        {
            get { return GetProperty(A11_CityRoadObjectsProperty); }
            private set { LoadProperty(A11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="A10_City"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="A10_City"/> object.</returns>
        internal static A10_City NewA10_City()
        {
            return DataPortal.CreateChild<A10_City>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A10_City"/> object.</returns>
        internal static A10_City GetA10_City(SafeDataReader dr)
        {
            A10_City obj = new A10_City();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.LoadProperty(A11_CityRoadObjectsProperty, A11_CityRoadColl.NewA11_CityRoadColl());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A10_City()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="A10_City"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(City_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(A11_City_SingleObjectProperty, DataPortal.CreateChild<A11_City_Child>());
            LoadProperty(A11_City_ASingleObjectProperty, DataPortal.CreateChild<A11_City_ReChild>());
            LoadProperty(A11_CityRoadObjectsProperty, DataPortal.CreateChild<A11_CityRoadColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="A10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(City_IDProperty, dr.GetInt32("City_ID"));
            LoadProperty(City_NameProperty, dr.GetString("City_Name"));
            // parent properties
            parent_Region_ID = dr.GetInt32("Parent_Region_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="A11_City_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A11_City_Child child)
        {
            LoadProperty(A11_City_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="A11_City_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A11_City_ReChild child)
        {
            LoadProperty(A11_City_ASingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="A10_City"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(A08_Region parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", parent.Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_ID", ReadProperty(City_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@City_Name", ReadProperty(City_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(City_IDProperty, (int) cmd.Parameters["@City_ID"].Value);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="A10_City"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", ReadProperty(City_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Name", ReadProperty(City_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="A10_City"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteA10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", ReadProperty(City_IDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(A11_City_SingleObjectProperty, DataPortal.CreateChild<A11_City_Child>());
            LoadProperty(A11_City_ASingleObjectProperty, DataPortal.CreateChild<A11_City_ReChild>());
            LoadProperty(A11_CityRoadObjectsProperty, DataPortal.CreateChild<A11_CityRoadColl>());
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
