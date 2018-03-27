using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeItem (editable child object).<br/>
    /// This is a generated <see cref="ProductTypeItem"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="ProductTypeColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class ProductTypeItem : BusinessBase<ProductTypeItem>
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

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeItem"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeItem()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnProductTypeItemSaved;

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="ProductTypeItem"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(ProductTypeIdProperty, System.Threading.Interlocked.Decrement(ref _lastId));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="ProductTypeItem"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(ProductTypeIdProperty, dr.GetInt32("ProductTypeId"));
            LoadProperty(NameProperty, dr.GetString("Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Inserts a new <see cref="ProductTypeItem"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert()
        {
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IProductTypeItemDal>();
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
        /// Updates in the database all changes made to the <see cref="ProductTypeItem"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IProductTypeItemDal>();
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
        /// Self deletes the <see cref="ProductTypeItem"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IProductTypeItemDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(ProductTypeIdProperty));
                }
                OnDeletePost(args);
            }
        }

        #endregion

        #region Saved Event

        // TODO: edit "ProductTypeItem.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     Saved += OnProductTypeItemSaved;

        private void OnProductTypeItemSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (ProductTypeItemSaved != null)
                ProductTypeItemSaved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="ProductTypeItem"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> ProductTypeItemSaved;

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
