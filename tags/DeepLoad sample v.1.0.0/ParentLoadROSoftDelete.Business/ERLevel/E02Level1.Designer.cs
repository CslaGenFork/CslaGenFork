using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E02Level1 (read only object).<br/>
    /// This is a generated base class of <see cref="E02Level1"/> business object.
    /// This class is a root object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E03Level11Objects"/> of type <see cref="E03Level11Coll"/> (1:M relation to <see cref="E04Level11"/>)
    /// </remarks>
    [Serializable]
    public partial class E02Level1 : ReadOnlyBase<E02Level1>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_IDProperty = RegisterProperty<int>(p => p.Level_1_ID, "Level_1 ID", -1);
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
        /// Gets the Level_1 Name.
        /// </summary>
        /// <value>The Level_1 Name.</value>
        public string Level_1_Name
        {
            get { return GetProperty(Level_1_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E03Level11SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E03Level11Child> E03Level11SingleObjectProperty = RegisterProperty<E03Level11Child>(p => p.E03Level11SingleObject, "A3 Level11 Single Object");
        /// <summary>
        /// Gets the E03 Level11 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E03 Level11 Single Object.</value>
        public E03Level11Child E03Level11SingleObject
        {
            get { return GetProperty(E03Level11SingleObjectProperty); }
            private set { LoadProperty(E03Level11SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E03Level11ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E03Level11ReChild> E03Level11ASingleObjectProperty = RegisterProperty<E03Level11ReChild>(p => p.E03Level11ASingleObject, "A3 Level11 ASingle Object");
        /// <summary>
        /// Gets the E03 Level11 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E03 Level11 ASingle Object.</value>
        public E03Level11ReChild E03Level11ASingleObject
        {
            get { return GetProperty(E03Level11ASingleObjectProperty); }
            private set { LoadProperty(E03Level11ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E03Level11Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E03Level11Coll> E03Level11ObjectsProperty = RegisterProperty<E03Level11Coll>(p => p.E03Level11Objects, "A3 Level11 Objects");
        /// <summary>
        /// Gets the E03 Level11 Objects ("parent load" child property).
        /// </summary>
        /// <value>The E03 Level11 Objects.</value>
        public E03Level11Coll E03Level11Objects
        {
            get { return GetProperty(E03Level11ObjectsProperty); }
            private set { LoadProperty(E03Level11ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E02Level1"/> object, based on given parameters.
        /// </summary>
        /// <param name="level_1_ID">The Level_1_ID parameter of the E02Level1 to fetch.</param>
        /// <returns>A reference to the fetched <see cref="E02Level1"/> object.</returns>
        public static E02Level1 GetE02Level1(int level_1_ID)
        {
            return DataPortal.Fetch<E02Level1>(level_1_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E02Level1"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E02Level1()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E02Level1"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="level_1_ID">The Level_1 ID.</param>
        protected void DataPortal_Fetch(int level_1_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetE02Level1", ctx.Connection))
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
        /// Loads a <see cref="E02Level1"/> object from the given SafeDataReader.
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
                LoadProperty(E03Level11SingleObjectProperty, E03Level11Child.GetE03Level11Child(dr));
            dr.NextResult();
            if (dr.Read())
                LoadProperty(E03Level11ASingleObjectProperty, E03Level11ReChild.GetE03Level11ReChild(dr));
            dr.NextResult();
            LoadProperty(E03Level11ObjectsProperty, E03Level11Coll.GetE03Level11Coll(dr));
            dr.NextResult();
            while (dr.Read())
            {
                var child = E05Level111Child.GetE05Level111Child(dr);
                var obj = E03Level11Objects.FindE04Level11ByParentProperties(child.cMarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E05Level111ReChild.GetE05Level111ReChild(dr);
                var obj = E03Level11Objects.FindE04Level11ByParentProperties(child.cMarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e05Level111Coll = E05Level111Coll.GetE05Level111Coll(dr);
            e05Level111Coll.LoadItems(E03Level11Objects);
            dr.NextResult();
            while (dr.Read())
            {
                var child = E07Level1111Child.GetE07Level1111Child(dr);
                var obj = e05Level111Coll.FindE06Level111ByParentProperties(child.cLarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E07Level1111ReChild.GetE07Level1111ReChild(dr);
                var obj = e05Level111Coll.FindE06Level111ByParentProperties(child.cLarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e07Level1111Coll = E07Level1111Coll.GetE07Level1111Coll(dr);
            e07Level1111Coll.LoadItems(e05Level111Coll);
            dr.NextResult();
            while (dr.Read())
            {
                var child = E09Level11111Child.GetE09Level11111Child(dr);
                var obj = e07Level1111Coll.FindE08Level1111ByParentProperties(child.cNarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E09Level11111ReChild.GetE09Level11111ReChild(dr);
                var obj = e07Level1111Coll.FindE08Level1111ByParentProperties(child.cNarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e09Level11111Coll = E09Level11111Coll.GetE09Level11111Coll(dr);
            e09Level11111Coll.LoadItems(e07Level1111Coll);
            dr.NextResult();
            while (dr.Read())
            {
                var child = E11Level111111Child.GetE11Level111111Child(dr);
                var obj = e09Level11111Coll.FindE10Level11111ByParentProperties(child.cQarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E11Level111111ReChild.GetE11Level111111ReChild(dr);
                var obj = e09Level11111Coll.FindE10Level11111ByParentProperties(child.cQarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e11Level111111Coll = E11Level111111Coll.GetE11Level111111Coll(dr);
            e11Level111111Coll.LoadItems(e09Level11111Coll);
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

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
