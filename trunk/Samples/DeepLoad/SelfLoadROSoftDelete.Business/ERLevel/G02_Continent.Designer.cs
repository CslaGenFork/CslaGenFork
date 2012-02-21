using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G02_Continent (read only object).<br/>
    /// This is a generated base class of <see cref="G02_Continent"/> business object.
    /// This class is a root object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="G03_SubContinentObjects"/> of type <see cref="G03_SubContinentColl"/> (1:M relation to <see cref="G04_SubContinent"/>)
    /// </remarks>
    [Serializable]
    public partial class G02_Continent : ReadOnlyBase<G02_Continent>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Continent_IDProperty = RegisterProperty<int>(p => p.Continent_ID, "1_Continents ID", -1);
        /// <summary>
        /// Gets the 1_Continents ID.
        /// </summary>
        /// <value>The 1_Continents ID.</value>
        public int Continent_ID
        {
            get { return GetProperty(Continent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_NameProperty = RegisterProperty<string>(p => p.Continent_Name, "1_Continents Name");
        /// <summary>
        /// Gets the 1_Continents Name.
        /// </summary>
        /// <value>The 1_Continents Name.</value>
        public string Continent_Name
        {
            get { return GetProperty(Continent_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G03_Continent_Child> G03_Continent_SingleObjectProperty = RegisterProperty<G03_Continent_Child>(p => p.G03_Continent_SingleObject, "G03 Continent Single Object");
        /// <summary>
        /// Gets the G03 Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The G03 Continent Single Object.</value>
        public G03_Continent_Child G03_Continent_SingleObject
        {
            get { return GetProperty(G03_Continent_SingleObjectProperty); }
            private set { LoadProperty(G03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G03_Continent_ReChild> G03_Continent_ASingleObjectProperty = RegisterProperty<G03_Continent_ReChild>(p => p.G03_Continent_ASingleObject, "G03 Continent ASingle Object");
        /// <summary>
        /// Gets the G03 Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The G03 Continent ASingle Object.</value>
        public G03_Continent_ReChild G03_Continent_ASingleObject
        {
            get { return GetProperty(G03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(G03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<G03_SubContinentColl> G03_SubContinentObjectsProperty = RegisterProperty<G03_SubContinentColl>(p => p.G03_SubContinentObjects, "G03 SubContinent Objects");
        /// <summary>
        /// Gets the G03 Sub Continent Objects ("self load" child property).
        /// </summary>
        /// <value>The G03 Sub Continent Objects.</value>
        public G03_SubContinentColl G03_SubContinentObjects
        {
            get { return GetProperty(G03_SubContinentObjectsProperty); }
            private set { LoadProperty(G03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G02_Continent"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID parameter of the G02_Continent to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G02_Continent"/> object.</returns>
        public static G02_Continent GetG02_Continent(int continent_ID)
        {
            return DataPortal.Fetch<G02_Continent>(continent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G02_Continent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G02_Continent"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        protected void DataPortal_Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, continent_ID);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            FetchChildren();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
                BusinessRules.CheckRules();
            }
        }

        /// <summary>
        /// Loads a <see cref="G02_Continent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Continent_IDProperty, dr.GetInt32("Continent_ID"));
            LoadProperty(Continent_NameProperty, dr.GetString("Continent_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        private void FetchChildren()
        {
            LoadProperty(G03_Continent_SingleObjectProperty, G03_Continent_Child.GetG03_Continent_Child(Continent_ID));
            LoadProperty(G03_Continent_ASingleObjectProperty, G03_Continent_ReChild.GetG03_Continent_ReChild(Continent_ID));
            LoadProperty(G03_SubContinentObjectsProperty, G03_SubContinentColl.GetG03_SubContinentColl(Continent_ID));
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
