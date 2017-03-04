using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// SupplierEdit (editable root object).<br/>
    /// This is a generated base class of <see cref="SupplierEdit"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="Products"/> of type <see cref="SupplierProductColl"/> (1:M relation to <see cref="SupplierProductItem"/>)
    /// </remarks>
    [Serializable]
    public partial class SupplierEdit : BusinessBase<SupplierEdit>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SupplierId"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> SupplierIdProperty = RegisterProperty<int>(p => p.SupplierId, "Supplier Id");
        /// <summary>
        /// For simplicity sake, use the VAT number (no auto increment here).
        /// </summary>
        /// <value>The Supplier Id.</value>
        public int SupplierId
        {
            get { return GetProperty(SupplierIdProperty); }
            set { SetProperty(SupplierIdProperty, value); }
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

        /// <summary>
        /// Maintains metadata about <see cref="AddressLine1"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> AddressLine1Property = RegisterProperty<string>(p => p.AddressLine1, "Address Line1");
        /// <summary>
        /// Gets or sets the Address Line1.
        /// </summary>
        /// <value>The Address Line1.</value>
        public string AddressLine1
        {
            get { return GetProperty(AddressLine1Property); }
            set { SetProperty(AddressLine1Property, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="AddressLine2"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> AddressLine2Property = RegisterProperty<string>(p => p.AddressLine2, "Address Line2");
        /// <summary>
        /// Gets or sets the Address Line2.
        /// </summary>
        /// <value>The Address Line2.</value>
        public string AddressLine2
        {
            get { return GetProperty(AddressLine2Property); }
            set { SetProperty(AddressLine2Property, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ZipCode"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ZipCodeProperty = RegisterProperty<string>(p => p.ZipCode, "Zip Code");
        /// <summary>
        /// Gets or sets the Zip Code.
        /// </summary>
        /// <value>The Zip Code.</value>
        public string ZipCode
        {
            get { return GetProperty(ZipCodeProperty); }
            set { SetProperty(ZipCodeProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="State"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> StateProperty = RegisterProperty<string>(p => p.State, "State");
        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        /// <value>The State.</value>
        public string State
        {
            get { return GetProperty(StateProperty); }
            set { SetProperty(StateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Country"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte?> CountryProperty = RegisterProperty<byte?>(p => p.Country, "Country");
        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>The Country.</value>
        public byte? Country
        {
            get { return GetProperty(CountryProperty); }
            set { SetProperty(CountryProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="Products"/> property.
        /// </summary>
        public static readonly PropertyInfo<SupplierProductColl> ProductsProperty = RegisterProperty<SupplierProductColl>(p => p.Products, "Products", RelationshipTypes.Child | RelationshipTypes.LazyLoad);
        /// <summary>
        /// Gets the Products ("lazy load" child property).
        /// </summary>
        /// <value>The Products.</value>
        public SupplierProductColl Products
        {
            get
            {
#if ASYNC
                if (!FieldManager.FieldExists(ProductsProperty))
                {
                    LoadProperty(ProductsProperty, null);
                    if (this.IsNew)
                    {
                        DataPortal.BeginCreate<SupplierProductColl>((o, e) =>
                            {
                                if (e.Error != null)
                                    throw e.Error;
                                else
                                {
                                    // set the property so OnPropertyChanged is raised
                                    Products = e.Object;
                                }
                            });
                        return null;
                    }
                    else
                    {
                        DataPortal.BeginFetch<SupplierProductColl>(ReadProperty(SupplierIdProperty), (o, e) =>
                            {
                                if (e.Error != null)
                                    throw e.Error;
                                else
                                {
                                    // set the property so OnPropertyChanged is raised
                                    Products = e.Object;
                                }
                            });
                        return null;
                    }
                }
                else
                {
                    return GetProperty(ProductsProperty);
                }
#else
                if (!FieldManager.FieldExists(ProductsProperty))
                    if (this.IsNew)
                        Products = DataPortal.Create<SupplierProductColl>();
                    else
                        Products = DataPortal.Fetch<SupplierProductColl>(ReadProperty(SupplierIdProperty));

                return GetProperty(ProductsProperty);
#endif
            }
            private set
            {
                LoadProperty(ProductsProperty, value);
                OnPropertyChanged(ProductsProperty);
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="SupplierEdit"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="SupplierEdit"/> object.</returns>
        public static SupplierEdit NewSupplierEdit()
        {
            return DataPortal.Create<SupplierEdit>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="SupplierEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="supplierId">The SupplierId parameter of the SupplierEdit to fetch.</param>
        /// <returns>A reference to the fetched <see cref="SupplierEdit"/> object.</returns>
        public static SupplierEdit GetSupplierEdit(int supplierId)
        {
            return DataPortal.Fetch<SupplierEdit>(supplierId);
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="SupplierEdit"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewSupplierEdit(EventHandler<DataPortalResult<SupplierEdit>> callback)
        {
            DataPortal.BeginCreate<SupplierEdit>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="SupplierEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="supplierId">The SupplierId parameter of the SupplierEdit to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetSupplierEdit(int supplierId, EventHandler<DataPortalResult<SupplierEdit>> callback)
        {
            DataPortal.BeginFetch<SupplierEdit>(supplierId, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierEdit"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SupplierEdit()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnSupplierEditSaved;
            SupplierEditSaved += SupplierEditSavedHandler;
        }

        #endregion

        #region Cache Invalidation

        // TODO: edit "SupplierEdit.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     SupplierEditSaved += SupplierEditSavedHandler;

        private void SupplierEditSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client
            SupplierList.InvalidateCache();
        }

        /// <summary>
        /// Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        /// </summary>
        /// <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        protected override void DataPortal_OnDataPortalInvokeComplete(Csla.DataPortalEventArgs e)
        {
            if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server &&
                e.Operation == DataPortalOperations.Update)
            {
                // this runs on the server
                SupplierList.InvalidateCache();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="SupplierEdit"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(AddressLine1Property, null);
            LoadProperty(AddressLine2Property, null);
            LoadProperty(ZipCodeProperty, null);
            LoadProperty(StateProperty, null);
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="SupplierEdit"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        protected void DataPortal_Fetch(int supplierId)
        {
            var args = new DataPortalHookArgs(supplierId);
            OnFetchPre(args);
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var dal = dalManager.GetProvider<ISupplierEditDal>();
                var data = dal.Fetch(supplierId);
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
        /// Loads a <see cref="SupplierEdit"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(SupplierIdProperty, dr.GetInt32("SupplierId"));
            LoadProperty(NameProperty, dr.GetString("Name"));
            LoadProperty(AddressLine1Property, dr.IsDBNull("AddressLine1") ? null : dr.GetString("AddressLine1"));
            LoadProperty(AddressLine2Property, dr.IsDBNull("AddressLine2") ? null : dr.GetString("AddressLine2"));
            LoadProperty(ZipCodeProperty, dr.IsDBNull("ZipCode") ? null : dr.GetString("ZipCode"));
            LoadProperty(StateProperty, dr.IsDBNull("State") ? null : dr.GetString("State"));
            LoadProperty(CountryProperty, (byte?)dr.GetValue("Country"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="SupplierEdit"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<ISupplierEditDal>();
                using (BypassPropertyChecks)
                {
                    dal.Insert(
                        SupplierId,
                        Name,
                        AddressLine1,
                        AddressLine2,
                        ZipCode,
                        State,
                        Country
                        );
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="SupplierEdit"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<ISupplierEditDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        SupplierId,
                        Name,
                        AddressLine1,
                        AddressLine2,
                        ZipCode,
                        State,
                        Country
                        );
                }
                OnUpdatePost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        #endregion

        #region Saved Event

        // TODO: edit "SupplierEdit.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     Saved += OnSupplierEditSaved;

        private void OnSupplierEditSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (SupplierEditSaved != null)
                SupplierEditSaved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="SupplierEdit"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> SupplierEditSaved;

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

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
