using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B02_Continent (editable child object).<br/>
    /// This is a generated base class of <see cref="B02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B03_SubContinentObjects"/> of type <see cref="B03_SubContinentColl"/> (1:M relation to <see cref="B04_SubContinent"/>)<br/>
    /// This class is an item of <see cref="B01_ContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B02_Continent : BusinessBase<B02_Continent>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Continent_IDProperty = RegisterProperty<int>(p => p.Continent_ID, "Continent ID");
        /// <summary>
        /// Gets the Continent ID.
        /// </summary>
        /// <value>The Continent ID.</value>
        public int Continent_ID
        {
            get { return GetProperty(Continent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_NameProperty = RegisterProperty<string>(p => p.Continent_Name, "Continent Name");
        /// <summary>
        /// Gets or sets the Continent Name.
        /// </summary>
        /// <value>The Continent Name.</value>
        public string Continent_Name
        {
            get { return GetProperty(Continent_NameProperty); }
            set { SetProperty(Continent_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B03_Continent_Child> B03_Continent_SingleObjectProperty = RegisterProperty<B03_Continent_Child>(p => p.B03_Continent_SingleObject, "B03 Continent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B03 Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B03 Continent Single Object.</value>
        public B03_Continent_Child B03_Continent_SingleObject
        {
            get { return GetProperty(B03_Continent_SingleObjectProperty); }
            private set { LoadProperty(B03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B03_Continent_ReChild> B03_Continent_ASingleObjectProperty = RegisterProperty<B03_Continent_ReChild>(p => p.B03_Continent_ASingleObject, "B03 Continent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B03 Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B03 Continent ASingle Object.</value>
        public B03_Continent_ReChild B03_Continent_ASingleObject
        {
            get { return GetProperty(B03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(B03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B03_SubContinentColl> B03_SubContinentObjectsProperty = RegisterProperty<B03_SubContinentColl>(p => p.B03_SubContinentObjects, "B03 SubContinent Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B03 Sub Continent Objects ("parent load" child property).
        /// </summary>
        /// <value>The B03 Sub Continent Objects.</value>
        public B03_SubContinentColl B03_SubContinentObjects
        {
            get { return GetProperty(B03_SubContinentObjectsProperty); }
            private set { LoadProperty(B03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B02_Continent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="B02_Continent"/> object.</returns>
        internal static B02_Continent NewB02_Continent()
        {
            return DataPortal.CreateChild<B02_Continent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B02_Continent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B02_Continent"/> object.</returns>
        internal static B02_Continent GetB02_Continent(SafeDataReader dr)
        {
            B02_Continent obj = new B02_Continent();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.LoadProperty(B03_SubContinentObjectsProperty, B03_SubContinentColl.NewB03_SubContinentColl());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B02_Continent()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="B02_Continent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Continent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(B03_Continent_SingleObjectProperty, DataPortal.CreateChild<B03_Continent_Child>());
            LoadProperty(B03_Continent_ASingleObjectProperty, DataPortal.CreateChild<B03_Continent_ReChild>());
            LoadProperty(B03_SubContinentObjectsProperty, DataPortal.CreateChild<B03_SubContinentColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="B02_Continent"/> object from the given SafeDataReader.
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
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        internal void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            while (dr.Read())
            {
                var child = B03_Continent_Child.GetB03_Continent_Child(dr);
                var obj = ((B01_ContinentColl)Parent).FindB02_ContinentByParentProperties(child.continent_ID1);
                obj.LoadProperty(B03_Continent_SingleObjectProperty, child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = B03_Continent_ReChild.GetB03_Continent_ReChild(dr);
                var obj = ((B01_ContinentColl)Parent).FindB02_ContinentByParentProperties(child.continent_ID2);
                obj.LoadProperty(B03_Continent_ASingleObjectProperty, child);
            }
            dr.NextResult();
            var b03_SubContinentColl = B03_SubContinentColl.GetB03_SubContinentColl(dr);
            b03_SubContinentColl.LoadItems((B01_ContinentColl)Parent);
            dr.NextResult();
            while (dr.Read())
            {
                var child = B05_SubContinent_Child.GetB05_SubContinent_Child(dr);
                var obj = b03_SubContinentColl.FindB04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = B05_SubContinent_ReChild.GetB05_SubContinent_ReChild(dr);
                var obj = b03_SubContinentColl.FindB04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var b05_CountryColl = B05_CountryColl.GetB05_CountryColl(dr);
            b05_CountryColl.LoadItems(b03_SubContinentColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = B07_Country_Child.GetB07_Country_Child(dr);
                var obj = b05_CountryColl.FindB06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = B07_Country_ReChild.GetB07_Country_ReChild(dr);
                var obj = b05_CountryColl.FindB06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var b07_RegionColl = B07_RegionColl.GetB07_RegionColl(dr);
            b07_RegionColl.LoadItems(b05_CountryColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = B09_Region_Child.GetB09_Region_Child(dr);
                var obj = b07_RegionColl.FindB08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = B09_Region_ReChild.GetB09_Region_ReChild(dr);
                var obj = b07_RegionColl.FindB08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var b09_CityColl = B09_CityColl.GetB09_CityColl(dr);
            b09_CityColl.LoadItems(b07_RegionColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = B11_City_Child.GetB11_City_Child(dr);
                var obj = b09_CityColl.FindB10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = B11_City_ReChild.GetB11_City_ReChild(dr);
                var obj = b09_CityColl.FindB10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var b11_CityRoadColl = B11_CityRoadColl.GetB11_CityRoadColl(dr);
            b11_CityRoadColl.LoadItems(b09_CityColl);
        }

        /// <summary>
        /// Inserts a new <see cref="B02_Continent"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert()
        {
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IB02_ContinentDal>();
                using (BypassPropertyChecks)
                {
                    int continent_ID = -1;
                    dal.Insert(
                        out continent_ID,
                        Continent_Name
                        );
                    LoadProperty(Continent_IDProperty, continent_ID);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="B02_Continent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IB02_ContinentDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        Continent_ID,
                        Continent_Name
                        );
                }
                OnUpdatePost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="B02_Continent"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IB02_ContinentDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(Continent_IDProperty));
                }
                OnDeletePost(args);
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
