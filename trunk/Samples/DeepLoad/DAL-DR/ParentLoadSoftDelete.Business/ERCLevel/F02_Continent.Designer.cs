using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess.ERCLevel;
using ParentLoadSoftDelete.DataAccess;

namespace ParentLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F02_Continent (editable child object).<br/>
    /// This is a generated base class of <see cref="F02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="F03_SubContinentObjects"/> of type <see cref="F03_SubContinentColl"/> (1:M relation to <see cref="F04_SubContinent"/>)<br/>
    /// This class is an item of <see cref="F01_ContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F02_Continent : BusinessBase<F02_Continent>
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
        /// Maintains metadata about child <see cref="F03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F03_Continent_Child> F03_Continent_SingleObjectProperty = RegisterProperty<F03_Continent_Child>(p => p.F03_Continent_SingleObject, "F03 Continent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the F03 Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The F03 Continent Single Object.</value>
        public F03_Continent_Child F03_Continent_SingleObject
        {
            get { return GetProperty(F03_Continent_SingleObjectProperty); }
            private set { LoadProperty(F03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F03_Continent_ReChild> F03_Continent_ASingleObjectProperty = RegisterProperty<F03_Continent_ReChild>(p => p.F03_Continent_ASingleObject, "F03 Continent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the F03 Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The F03 Continent ASingle Object.</value>
        public F03_Continent_ReChild F03_Continent_ASingleObject
        {
            get { return GetProperty(F03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(F03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<F03_SubContinentColl> F03_SubContinentObjectsProperty = RegisterProperty<F03_SubContinentColl>(p => p.F03_SubContinentObjects, "F03 SubContinent Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the F03 Sub Continent Objects ("parent load" child property).
        /// </summary>
        /// <value>The F03 Sub Continent Objects.</value>
        public F03_SubContinentColl F03_SubContinentObjects
        {
            get { return GetProperty(F03_SubContinentObjectsProperty); }
            private set { LoadProperty(F03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="F02_Continent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="F02_Continent"/> object.</returns>
        internal static F02_Continent NewF02_Continent()
        {
            return DataPortal.CreateChild<F02_Continent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="F02_Continent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F02_Continent"/> object.</returns>
        internal static F02_Continent GetF02_Continent(SafeDataReader dr)
        {
            F02_Continent obj = new F02_Continent();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.LoadProperty(F03_SubContinentObjectsProperty, F03_SubContinentColl.NewF03_SubContinentColl());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F02_Continent()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="F02_Continent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Continent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(F03_Continent_SingleObjectProperty, DataPortal.CreateChild<F03_Continent_Child>());
            LoadProperty(F03_Continent_ASingleObjectProperty, DataPortal.CreateChild<F03_Continent_ReChild>());
            LoadProperty(F03_SubContinentObjectsProperty, DataPortal.CreateChild<F03_SubContinentColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="F02_Continent"/> object from the given SafeDataReader.
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
                var child = F03_Continent_Child.GetF03_Continent_Child(dr);
                var obj = ((F01_ContinentColl)Parent).FindF02_ContinentByParentProperties(child.continent_ID1);
                obj.LoadProperty(F03_Continent_SingleObjectProperty, child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F03_Continent_ReChild.GetF03_Continent_ReChild(dr);
                var obj = ((F01_ContinentColl)Parent).FindF02_ContinentByParentProperties(child.continent_ID2);
                obj.LoadProperty(F03_Continent_ASingleObjectProperty, child);
            }
            dr.NextResult();
            var f03_SubContinentColl = F03_SubContinentColl.GetF03_SubContinentColl(dr);
            f03_SubContinentColl.LoadItems((F01_ContinentColl)Parent);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F05_SubContinent_Child.GetF05_SubContinent_Child(dr);
                var obj = f03_SubContinentColl.FindF04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F05_SubContinent_ReChild.GetF05_SubContinent_ReChild(dr);
                var obj = f03_SubContinentColl.FindF04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f05_CountryColl = F05_CountryColl.GetF05_CountryColl(dr);
            f05_CountryColl.LoadItems(f03_SubContinentColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F07_Country_Child.GetF07_Country_Child(dr);
                var obj = f05_CountryColl.FindF06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F07_Country_ReChild.GetF07_Country_ReChild(dr);
                var obj = f05_CountryColl.FindF06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f07_RegionColl = F07_RegionColl.GetF07_RegionColl(dr);
            f07_RegionColl.LoadItems(f05_CountryColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F09_Region_Child.GetF09_Region_Child(dr);
                var obj = f07_RegionColl.FindF08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F09_Region_ReChild.GetF09_Region_ReChild(dr);
                var obj = f07_RegionColl.FindF08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f09_CityColl = F09_CityColl.GetF09_CityColl(dr);
            f09_CityColl.LoadItems(f07_RegionColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F11_City_Child.GetF11_City_Child(dr);
                var obj = f09_CityColl.FindF10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F11_City_ReChild.GetF11_City_ReChild(dr);
                var obj = f09_CityColl.FindF10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f11_CityRoadColl = F11_CityRoadColl.GetF11_CityRoadColl(dr);
            f11_CityRoadColl.LoadItems(f09_CityColl);
        }

        /// <summary>
        /// Inserts a new <see cref="F02_Continent"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert()
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IF02_ContinentDal>();
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
        /// Updates in the database all changes made to the <see cref="F02_Continent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IF02_ContinentDal>();
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
        /// Self deletes the <see cref="F02_Continent"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IF02_ContinentDal>();
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
