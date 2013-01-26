using System;
using Csla;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

namespace ParentLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E02_Continent (editable root object).<br/>
    /// This is a generated base class of <see cref="E02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E03_SubContinentObjects"/> of type <see cref="E03_SubContinentColl"/> (1:M relation to <see cref="E04_SubContinent"/>)
    /// </remarks>
    [Serializable]
    public partial class E02_Continent : BusinessBase<E02_Continent>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Continent_IDProperty = RegisterProperty<int>(p => p.Continent_ID, "1_Continents ID");
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
        /// Gets or sets the 1_Continents Name.
        /// </summary>
        /// <value>The 1_Continents Name.</value>
        public string Continent_Name
        {
            get { return GetProperty(Continent_NameProperty); }
            set { SetProperty(Continent_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E03_Continent_Child> E03_Continent_SingleObjectProperty = RegisterProperty<E03_Continent_Child>(p => p.E03_Continent_SingleObject, "E03 Continent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the E03 Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E03 Continent Single Object.</value>
        public E03_Continent_Child E03_Continent_SingleObject
        {
            get { return GetProperty(E03_Continent_SingleObjectProperty); }
            private set { LoadProperty(E03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E03_Continent_ReChild> E03_Continent_ASingleObjectProperty = RegisterProperty<E03_Continent_ReChild>(p => p.E03_Continent_ASingleObject, "E03 Continent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the E03 Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E03 Continent ASingle Object.</value>
        public E03_Continent_ReChild E03_Continent_ASingleObject
        {
            get { return GetProperty(E03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(E03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E03_SubContinentColl> E03_SubContinentObjectsProperty = RegisterProperty<E03_SubContinentColl>(p => p.E03_SubContinentObjects, "E03 SubContinent Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the E03 Sub Continent Objects ("parent load" child property).
        /// </summary>
        /// <value>The E03 Sub Continent Objects.</value>
        public E03_SubContinentColl E03_SubContinentObjects
        {
            get { return GetProperty(E03_SubContinentObjectsProperty); }
            private set { LoadProperty(E03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="E02_Continent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="E02_Continent"/> object.</returns>
        public static E02_Continent NewE02_Continent()
        {
            return DataPortal.Create<E02_Continent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="E02_Continent"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID parameter of the E02_Continent to fetch.</param>
        /// <returns>A reference to the fetched <see cref="E02_Continent"/> object.</returns>
        public static E02_Continent GetE02_Continent(int continent_ID)
        {
            return DataPortal.Fetch<E02_Continent>(continent_ID);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="E02_Continent"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the E02_Continent to delete.</param>
        public static void DeleteE02_Continent(int continent_ID)
        {
            DataPortal.Delete<E02_Continent>(continent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E02_Continent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="E02_Continent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(Continent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(E03_Continent_SingleObjectProperty, DataPortal.CreateChild<E03_Continent_Child>());
            LoadProperty(E03_Continent_ASingleObjectProperty, DataPortal.CreateChild<E03_Continent_ReChild>());
            LoadProperty(E03_SubContinentObjectsProperty, DataPortal.CreateChild<E03_SubContinentColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="E02_Continent"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        protected void DataPortal_Fetch(int continent_ID)
        {
            var args = new DataPortalHookArgs(continent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IE02_ContinentDal>();
                var data = dal.Fetch(continent_ID);
                Fetch(data);
                FetchChildren(dal);
            }
            OnFetchPost(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Loads a <see cref="E02_Continent"/> object from the given <see cref="E02_ContinentDto"/>.
        /// </summary>
        /// <param name="data">The E02_ContinentDto to use.</param>
        private void Fetch(E02_ContinentDto data)
        {
            // Value properties
            LoadProperty(Continent_IDProperty, data.Continent_ID);
            LoadProperty(Continent_NameProperty, data.Continent_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects from the given DAL provider.
        /// </summary>
        /// <param name="dal">The DAL provider to use.</param>
        private void FetchChildren(IE02_ContinentDal dal)
        {
            LoadProperty(E03_Continent_SingleObjectProperty, E03_Continent_Child.GetE03_Continent_Child(dal.E03_Continent_Child));
            LoadProperty(E03_Continent_ASingleObjectProperty, E03_Continent_ReChild.GetE03_Continent_ReChild(dal.E03_Continent_ReChild));
            LoadProperty(E03_SubContinentObjectsProperty, E03_SubContinentColl.GetE03_SubContinentColl(dal.E03_SubContinentColl));
            foreach (var item in dal.E05_SubContinent_Child)
            {
                var child = E05_SubContinent_Child.GetE05_SubContinent_Child(item);
                var obj = E03_SubContinentObjects.FindE04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.E05_SubContinent_ReChild)
            {
                var child = E05_SubContinent_ReChild.GetE05_SubContinent_ReChild(item);
                var obj = E03_SubContinentObjects.FindE04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            var e05_CountryColl = E05_CountryColl.GetE05_CountryColl(dal.E05_CountryColl);
            e05_CountryColl.LoadItems(E03_SubContinentObjects);
            foreach (var item in dal.E07_Country_Child)
            {
                var child = E07_Country_Child.GetE07_Country_Child(item);
                var obj = e05_CountryColl.FindE06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.E07_Country_ReChild)
            {
                var child = E07_Country_ReChild.GetE07_Country_ReChild(item);
                var obj = e05_CountryColl.FindE06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            var e07_RegionColl = E07_RegionColl.GetE07_RegionColl(dal.E07_RegionColl);
            e07_RegionColl.LoadItems(e05_CountryColl);
            foreach (var item in dal.E09_Region_Child)
            {
                var child = E09_Region_Child.GetE09_Region_Child(item);
                var obj = e07_RegionColl.FindE08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.E09_Region_ReChild)
            {
                var child = E09_Region_ReChild.GetE09_Region_ReChild(item);
                var obj = e07_RegionColl.FindE08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            var e09_CityColl = E09_CityColl.GetE09_CityColl(dal.E09_CityColl);
            e09_CityColl.LoadItems(e07_RegionColl);
            foreach (var item in dal.E11_City_Child)
            {
                var child = E11_City_Child.GetE11_City_Child(item);
                var obj = e09_CityColl.FindE10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.E11_City_ReChild)
            {
                var child = E11_City_ReChild.GetE11_City_ReChild(item);
                var obj = e09_CityColl.FindE10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            var e11_CityRoadColl = E11_CityRoadColl.GetE11_CityRoadColl(dal.E11_CityRoadColl);
            e11_CityRoadColl.LoadItems(e09_CityColl);
        }

        /// <summary>
        /// Inserts a new <see cref="E02_Continent"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            var dto = new E02_ContinentDto();
            dto.Continent_Name = Continent_Name;
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IE02_ContinentDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(Continent_IDProperty, resultDto.Continent_ID);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="E02_Continent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            var dto = new E02_ContinentDto();
            dto.Continent_ID = Continent_ID;
            dto.Continent_Name = Continent_Name;
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IE02_ContinentDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="E02_Continent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(Continent_ID);
        }

        /// <summary>
        /// Deletes the <see cref="E02_Continent"/> object from database.
        /// </summary>
        /// <param name="continent_ID">The delete criteria.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(int continent_ID)
        {
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IE02_ContinentDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(continent_ID);
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
