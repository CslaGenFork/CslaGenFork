using System;
using Csla;
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
        /// Factory method. Loads a <see cref="B02_Continent"/> object from the given B02_ContinentDto.
        /// </summary>
        /// <param name="data">The <see cref="B02_ContinentDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B02_Continent"/> object.</returns>
        internal static B02_Continent GetB02_Continent(B02_ContinentDto data)
        {
            B02_Continent obj = new B02_Continent();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
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
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public B02_Continent()
        {
            // Use factory methods and do not use direct creation.

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
        /// Loads a <see cref="B02_Continent"/> object from the given <see cref="B02_ContinentDto"/>.
        /// </summary>
        /// <param name="data">The B02_ContinentDto to use.</param>
        private void Fetch(B02_ContinentDto data)
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
        internal void FetchChildren(IB01_ContinentCollDal dal)
        {
            foreach (var item in dal.B03_Continent_Child)
            {
                var child = B03_Continent_Child.GetB03_Continent_Child(item);
                var obj = ((B01_ContinentColl)Parent).FindB02_ContinentByParentProperties(child.continent_ID1);
                obj.LoadProperty(B03_Continent_SingleObjectProperty, child);
            }
            foreach (var item in dal.B03_Continent_ReChild)
            {
                var child = B03_Continent_ReChild.GetB03_Continent_ReChild(item);
                var obj = ((B01_ContinentColl)Parent).FindB02_ContinentByParentProperties(child.continent_ID2);
                obj.LoadProperty(B03_Continent_ASingleObjectProperty, child);
            }
            var b03_SubContinentColl = B03_SubContinentColl.GetB03_SubContinentColl(dal.B03_SubContinentColl);
            b03_SubContinentColl.LoadItems((B01_ContinentColl)Parent);
            foreach (var item in dal.B05_SubContinent_Child)
            {
                var child = B05_SubContinent_Child.GetB05_SubContinent_Child(item);
                var obj = b03_SubContinentColl.FindB04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.B05_SubContinent_ReChild)
            {
                var child = B05_SubContinent_ReChild.GetB05_SubContinent_ReChild(item);
                var obj = b03_SubContinentColl.FindB04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            var b05_CountryColl = B05_CountryColl.GetB05_CountryColl(dal.B05_CountryColl);
            b05_CountryColl.LoadItems(b03_SubContinentColl);
            foreach (var item in dal.B07_Country_Child)
            {
                var child = B07_Country_Child.GetB07_Country_Child(item);
                var obj = b05_CountryColl.FindB06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.B07_Country_ReChild)
            {
                var child = B07_Country_ReChild.GetB07_Country_ReChild(item);
                var obj = b05_CountryColl.FindB06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            var b07_RegionColl = B07_RegionColl.GetB07_RegionColl(dal.B07_RegionColl);
            b07_RegionColl.LoadItems(b05_CountryColl);
            foreach (var item in dal.B09_Region_Child)
            {
                var child = B09_Region_Child.GetB09_Region_Child(item);
                var obj = b07_RegionColl.FindB08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.B09_Region_ReChild)
            {
                var child = B09_Region_ReChild.GetB09_Region_ReChild(item);
                var obj = b07_RegionColl.FindB08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            var b09_CityColl = B09_CityColl.GetB09_CityColl(dal.B09_CityColl);
            b09_CityColl.LoadItems(b07_RegionColl);
            foreach (var item in dal.B11_City_Child)
            {
                var child = B11_City_Child.GetB11_City_Child(item);
                var obj = b09_CityColl.FindB10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.B11_City_ReChild)
            {
                var child = B11_City_ReChild.GetB11_City_ReChild(item);
                var obj = b09_CityColl.FindB10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            var b11_CityRoadColl = B11_CityRoadColl.GetB11_CityRoadColl(dal.B11_CityRoadColl);
            b11_CityRoadColl.LoadItems(b09_CityColl);
        }

        /// <summary>
        /// Inserts a new <see cref="B02_Continent"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert()
        {
            var dto = new B02_ContinentDto();
            dto.Continent_Name = Continent_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IB02_ContinentDal>();
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
        /// Updates in the database all changes made to the <see cref="B02_Continent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            var dto = new B02_ContinentDto();
            dto.Continent_ID = Continent_ID;
            dto.Continent_Name = Continent_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IB02_ContinentDal>();
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

        #region DataPortal Hooks

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
