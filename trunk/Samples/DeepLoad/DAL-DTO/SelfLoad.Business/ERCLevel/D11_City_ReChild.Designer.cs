using System;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D11_City_ReChild (editable child object).<br/>
    /// This is a generated base class of <see cref="D11_City_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="D10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D11_City_ReChild : BusinessBase<D11_City_ReChild>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="City_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> City_Child_NameProperty = RegisterProperty<string>(p => p.City_Child_Name, "CityRoads Child Name");
        /// <summary>
        /// Gets or sets the CityRoads Child Name.
        /// </summary>
        /// <value>The CityRoads Child Name.</value>
        public string City_Child_Name
        {
            get { return GetProperty(City_Child_NameProperty); }
            set { SetProperty(City_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D11_City_ReChild"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="D11_City_ReChild"/> object.</returns>
        internal static D11_City_ReChild NewD11_City_ReChild()
        {
            return DataPortal.CreateChild<D11_City_ReChild>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D11_City_ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="city_ID2">The City_ID2 parameter of the D11_City_ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D11_City_ReChild"/> object.</returns>
        internal static D11_City_ReChild GetD11_City_ReChild(int city_ID2)
        {
            return DataPortal.FetchChild<D11_City_ReChild>(city_ID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D11_City_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public D11_City_ReChild()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="D11_City_ReChild"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="D11_City_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="city_ID2">The City ID2.</param>
        protected void Child_Fetch(int city_ID2)
        {
            var args = new DataPortalHookArgs(city_ID2);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<ID11_City_ReChildDal>();
                var data = dal.Fetch(city_ID2);
                Fetch(data);
            }
            OnFetchPost(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Loads a <see cref="D11_City_ReChild"/> object from the given <see cref="D11_City_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The D11_City_ReChildDto to use.</param>
        private void Fetch(D11_City_ReChildDto data)
        {
            // Value properties
            LoadProperty(City_Child_NameProperty, data.City_Child_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="D11_City_ReChild"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(D10_City parent)
        {
            var dto = new D11_City_ReChildDto();
            dto.Parent_City_ID = parent.City_ID;
            dto.City_Child_Name = City_Child_Name;
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<ID11_City_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="D11_City_ReChild"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(D10_City parent)
        {
            if (!IsDirty)
                return;

            var dto = new D11_City_ReChildDto();
            dto.Parent_City_ID = parent.City_ID;
            dto.City_Child_Name = City_Child_Name;
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<ID11_City_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="D11_City_ReChild"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(D10_City parent)
        {
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<ID11_City_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.City_ID);
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
