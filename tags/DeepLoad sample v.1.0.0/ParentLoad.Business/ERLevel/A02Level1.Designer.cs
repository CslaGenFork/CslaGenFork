using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A02Level1 (editable root object).<br/>
    /// This is a generated base class of <see cref="A02Level1"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="A03Level11Objects"/> of type <see cref="A03Level11Coll"/> (1:M relation to <see cref="A04Level11"/>)
    /// </remarks>
    [Serializable]
    public partial class A02Level1 : BusinessBase<A02Level1>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_IDProperty = RegisterProperty<int>(p => p.Level_1_ID, "Level_1 ID");
        /// <summary>
        /// Gets the Level_1 ID.
        /// </summary>
        /// <value>The Level_1 ID.</value>
        public int Level_1_ID
        {
            get { return GetProperty(Level_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_NameProperty = RegisterProperty<string>(p => p.Level_1_Name, "Level_1 Name");
        /// <summary>
        /// Gets or sets the Level_1 Name.
        /// </summary>
        /// <value>The Level_1 Name.</value>
        public string Level_1_Name
        {
            get { return GetProperty(Level_1_NameProperty); }
            set { SetProperty(Level_1_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A03Level11SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A03Level11Child> A03Level11SingleObjectProperty = RegisterProperty<A03Level11Child>(p => p.A03Level11SingleObject, "A3 Level11 Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A03 Level11 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The A03 Level11 Single Object.</value>
        public A03Level11Child A03Level11SingleObject
        {
            get { return GetProperty(A03Level11SingleObjectProperty); }
            private set { LoadProperty(A03Level11SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A03Level11ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A03Level11ReChild> A03Level11ASingleObjectProperty = RegisterProperty<A03Level11ReChild>(p => p.A03Level11ASingleObject, "A3 Level11 ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A03 Level11 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The A03 Level11 ASingle Object.</value>
        public A03Level11ReChild A03Level11ASingleObject
        {
            get { return GetProperty(A03Level11ASingleObjectProperty); }
            private set { LoadProperty(A03Level11ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A03Level11Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<A03Level11Coll> A03Level11ObjectsProperty = RegisterProperty<A03Level11Coll>(p => p.A03Level11Objects, "A3 Level11 Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A03 Level11 Objects ("parent load" child property).
        /// </summary>
        /// <value>The A03 Level11 Objects.</value>
        public A03Level11Coll A03Level11Objects
        {
            get { return GetProperty(A03Level11ObjectsProperty); }
            private set { LoadProperty(A03Level11ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="A02Level1"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="A02Level1"/> object.</returns>
        public static A02Level1 NewA02Level1()
        {
            return DataPortal.Create<A02Level1>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A02Level1"/> object, based on given parameters.
        /// </summary>
        /// <param name="level_1_ID">The Level_1_ID parameter of the A02Level1 to fetch.</param>
        /// <returns>A reference to the fetched <see cref="A02Level1"/> object.</returns>
        public static A02Level1 GetA02Level1(int level_1_ID)
        {
            return DataPortal.Fetch<A02Level1>(level_1_ID);
        }

        /// <summary>
        /// Factory method. Marks the <see cref="A02Level1"/> object for deletion.
        /// The object will be deleted as part of the next save operation.
        /// </summary>
        /// <param name="level_1_ID">The Level_1_ID of the A02Level1 to delete.</param>
        public static void DeleteA02Level1(int level_1_ID)
        {
            DataPortal.Delete<A02Level1>(level_1_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A02Level1"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A02Level1()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="A02Level1"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(Level_1_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(A03Level11SingleObjectProperty, DataPortal.CreateChild<A03Level11Child>());
            LoadProperty(A03Level11ASingleObjectProperty, DataPortal.CreateChild<A03Level11ReChild>());
            LoadProperty(A03Level11ObjectsProperty, DataPortal.CreateChild<A03Level11Coll>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="A02Level1"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="level_1_ID">The Level_1 ID.</param>
        protected void DataPortal_Fetch(int level_1_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetA02Level1", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", level_1_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, level_1_ID);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                    FetchChildren(dr);
                }
                BusinessRules.CheckRules();
            }
        }

        /// <summary>
        /// Loads a <see cref="A02Level1"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_IDProperty, dr.GetInt32("Level_1_ID"));
            LoadProperty(Level_1_NameProperty, dr.GetString("Level_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            if (dr.Read())
                LoadProperty(A03Level11SingleObjectProperty, A03Level11Child.GetA03Level11Child(dr));
            dr.NextResult();
            if (dr.Read())
                LoadProperty(A03Level11ASingleObjectProperty, A03Level11ReChild.GetA03Level11ReChild(dr));
            dr.NextResult();
            LoadProperty(A03Level11ObjectsProperty, A03Level11Coll.GetA03Level11Coll(dr));
            dr.NextResult();
            while (dr.Read())
            {
                var child = A05Level111Child.GetA05Level111Child(dr);
                var obj = A03Level11Objects.FindA04Level11ByParentProperties(child.cMarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A05Level111ReChild.GetA05Level111ReChild(dr);
                var obj = A03Level11Objects.FindA04Level11ByParentProperties(child.cMarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a05Level111Coll = A05Level111Coll.GetA05Level111Coll(dr);
            a05Level111Coll.LoadItems(A03Level11Objects);
            dr.NextResult();
            while (dr.Read())
            {
                var child = A07Level1111Child.GetA07Level1111Child(dr);
                var obj = a05Level111Coll.FindA06Level111ByParentProperties(child.cLarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A07Level1111ReChild.GetA07Level1111ReChild(dr);
                var obj = a05Level111Coll.FindA06Level111ByParentProperties(child.cLarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a07Level1111Coll = A07Level1111Coll.GetA07Level1111Coll(dr);
            a07Level1111Coll.LoadItems(a05Level111Coll);
            dr.NextResult();
            while (dr.Read())
            {
                var child = A09Level11111Child.GetA09Level11111Child(dr);
                var obj = a07Level1111Coll.FindA08Level1111ByParentProperties(child.cNarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A09Level11111ReChild.GetA09Level11111ReChild(dr);
                var obj = a07Level1111Coll.FindA08Level1111ByParentProperties(child.cNarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a09Level11111Coll = A09Level11111Coll.GetA09Level11111Coll(dr);
            a09Level11111Coll.LoadItems(a07Level1111Coll);
            dr.NextResult();
            while (dr.Read())
            {
                var child = A11Level111111Child.GetA11Level111111Child(dr);
                var obj = a09Level11111Coll.FindA10Level11111ByParentProperties(child.cQarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A11Level111111ReChild.GetA11Level111111ReChild(dr);
                var obj = a09Level11111Coll.FindA10Level11111ByParentProperties(child.cQarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a11Level111111Coll = A11Level111111Coll.GetA11Level111111Coll(dr);
            a11Level111111Coll.LoadItems(a09Level11111Coll);
        }

        /// <summary>
        /// Inserts a new <see cref="A02Level1"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA02Level1", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", ReadProperty(Level_1_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Level_1_Name", ReadProperty(Level_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Level_1_IDProperty, (int) cmd.Parameters["@Level_1_ID"].Value);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="A02Level1"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA02Level1", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", ReadProperty(Level_1_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_Name", ReadProperty(Level_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="A02Level1"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(Level_1_ID);
        }

        /// <summary>
        /// Deletes the <see cref="A02Level1"/> object from database.
        /// </summary>
        /// <param name="level_1_ID">The delete criteria.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(int level_1_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteA02Level1", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", level_1_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, level_1_ID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(A03Level11SingleObjectProperty, DataPortal.CreateChild<A03Level11Child>());
            LoadProperty(A03Level11ASingleObjectProperty, DataPortal.CreateChild<A03Level11ReChild>());
            LoadProperty(A03Level11ObjectsProperty, DataPortal.CreateChild<A03Level11Coll>());
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
