using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeEdit (editable root object).<br/>
    /// This is a generated base class of <see cref="ProductTypeEdit"/> business object.
    /// </summary>
    [Serializable]
    public partial class ProductTypeEdit : BusinessBase<ProductTypeEdit>
    {

        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="ProductTypeId"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> ProductTypeIdProperty = RegisterProperty<int>(p => p.ProductTypeId, "Product Type Id");
        /// <summary>
        /// Gets the Product Type Id.
        /// </summary>
        /// <value>The Product Type Id.</value>
        public int ProductTypeId
        {
            get { return GetProperty(ProductTypeIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(p => p.Name, "Name");
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="ProductTypeEdit"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="ProductTypeEdit"/> object.</returns>
        public static ProductTypeEdit NewProductTypeEdit()
        {
            return DataPortal.Create<ProductTypeEdit>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="ProductTypeEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId parameter of the ProductTypeEdit to fetch.</param>
        /// <returns>A reference to the fetched <see cref="ProductTypeEdit"/> object.</returns>
        public static ProductTypeEdit GetProductTypeEdit(int productTypeId)
        {
            return DataPortal.Fetch<ProductTypeEdit>(productTypeId);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="ProductTypeEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId of the ProductTypeEdit to delete.</param>
        public static void DeleteProductTypeEdit(int productTypeId)
        {
            DataPortal.Delete<ProductTypeEdit>(productTypeId);
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="ProductTypeEdit"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewProductTypeEdit(EventHandler<DataPortalResult<ProductTypeEdit>> callback)
        {
            DataPortal.BeginCreate<ProductTypeEdit>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductTypeEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId parameter of the ProductTypeEdit to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductTypeEdit(int productTypeId, EventHandler<DataPortalResult<ProductTypeEdit>> callback)
        {
            DataPortal.BeginFetch<ProductTypeEdit>(productTypeId, callback);
        }

        /// <summary>
        /// Factory method. Asynchronously deletes a <see cref="ProductTypeEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId of the ProductTypeEdit to delete.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void DeleteProductTypeEdit(int productTypeId, EventHandler<DataPortalResult<ProductTypeEdit>> callback)
        {
            DataPortal.BeginDelete<ProductTypeEdit>(productTypeId, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeEdit"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeEdit()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnProductTypeEditSaved;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="ProductTypeEdit"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(ProductTypeIdProperty, System.Threading.Interlocked.Decrement(ref _lastId));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="ProductTypeEdit"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        protected void DataPortal_Fetch(int productTypeId)
        {
            var args = new DataPortalHookArgs(productTypeId);
            OnFetchPre(args);
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var dal = dalManager.GetProvider<IProductTypeEditDal>();
                var data = dal.Fetch(productTypeId);
                Fetch(data);
            }
            OnFetchPost(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="ProductTypeEdit"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(ProductTypeIdProperty, dr.GetInt32("ProductTypeId"));
            LoadProperty(NameProperty, dr.GetString("Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="ProductTypeEdit"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IProductTypeEditDal>();
                using (BypassPropertyChecks)
                {
                    int productTypeId = -1;
                    dal.Insert(
                        out productTypeId,
                        Name
                        );
                    LoadProperty(ProductTypeIdProperty, productTypeId);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="ProductTypeEdit"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IProductTypeEditDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        ProductTypeId,
                        Name
                        );
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="ProductTypeEdit"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(ProductTypeId);
        }

        /// <summary>
        /// Deletes the <see cref="ProductTypeEdit"/> object from database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(int productTypeId)
        {
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IProductTypeEditDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(productTypeId);
                }
                OnDeletePost(args);
            }
        }

        #endregion

        #region Saved Event

        // TODO: edit "ProductTypeEdit.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     Saved += OnProductTypeEditSaved;

        private void OnProductTypeEditSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (ProductTypeEditSaved != null)
                ProductTypeEditSaved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="ProductTypeEdit"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> ProductTypeEditSaved;

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
