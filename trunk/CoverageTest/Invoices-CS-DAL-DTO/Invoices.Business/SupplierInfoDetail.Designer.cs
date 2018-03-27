using System;
using Csla;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// SupplierInfoDetail (read only object).<br/>
    /// This is a generated <see cref="SupplierInfoDetail"/> business object.
    /// This class is a root object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="Products"/> of type <see cref="SupplierProductList"/> (1:M relation to <see cref="SupplierProductInfo"/>)
    /// </remarks>
    [Serializable]
    public partial class SupplierInfoDetail : ReadOnlyBase<SupplierInfoDetail>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SupplierId"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SupplierIdProperty = RegisterProperty<int>(p => p.SupplierId, "Supplier Id");
        /// <summary>
        /// For simplicity sake, use the VAT number (no auto increment here).
        /// </summary>
        /// <value>The Supplier Id.</value>
        public int SupplierId
        {
            get { return GetProperty(SupplierIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(p => p.Name, "Name");
        /// <summary>
        /// Gets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name
        {
            get { return GetProperty(NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="AddressLine1"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> AddressLine1Property = RegisterProperty<string>(p => p.AddressLine1, "Address Line1");
        /// <summary>
        /// Gets the Address Line1.
        /// </summary>
        /// <value>The Address Line1.</value>
        public string AddressLine1
        {
            get { return GetProperty(AddressLine1Property); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="AddressLine2"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> AddressLine2Property = RegisterProperty<string>(p => p.AddressLine2, "Address Line2");
        /// <summary>
        /// Gets the Address Line2.
        /// </summary>
        /// <value>The Address Line2.</value>
        public string AddressLine2
        {
            get { return GetProperty(AddressLine2Property); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ZipCode"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ZipCodeProperty = RegisterProperty<string>(p => p.ZipCode, "Zip Code");
        /// <summary>
        /// Gets the Zip Code.
        /// </summary>
        /// <value>The Zip Code.</value>
        public string ZipCode
        {
            get { return GetProperty(ZipCodeProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="State"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> StateProperty = RegisterProperty<string>(p => p.State, "State");
        /// <summary>
        /// Gets the State.
        /// </summary>
        /// <value>The State.</value>
        public string State
        {
            get { return GetProperty(StateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Country"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte?> CountryProperty = RegisterProperty<byte?>(p => p.Country, "Country");
        /// <summary>
        /// Gets the Country.
        /// </summary>
        /// <value>The Country.</value>
        public byte? Country
        {
            get { return GetProperty(CountryProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="Products"/> property.
        /// </summary>
        public static readonly PropertyInfo<SupplierProductList> ProductsProperty = RegisterProperty<SupplierProductList>(p => p.Products, "Products");
        /// <summary>
        /// Gets the Products ("lazy load" child property).
        /// </summary>
        /// <value>The Products.</value>
        public SupplierProductList Products
        {
            get
            {
#if ASYNC
                if (!FieldManager.FieldExists(ProductsProperty))
                {
                    LoadProperty(ProductsProperty, null);
                    DataPortal.BeginFetch<SupplierProductList>(ReadProperty(SupplierIdProperty), (o, e) =>
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
                    return GetProperty(ProductsProperty);
                }
#else
                if (!FieldManager.FieldExists(ProductsProperty))
                    Products = DataPortal.Fetch<SupplierProductList>(ReadProperty(SupplierIdProperty));

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
        /// Factory method. Loads a <see cref="SupplierInfoDetail"/> object, based on given parameters.
        /// </summary>
        /// <param name="supplierId">The SupplierId parameter of the SupplierInfoDetail to fetch.</param>
        /// <returns>A reference to the fetched <see cref="SupplierInfoDetail"/> object.</returns>
        public static SupplierInfoDetail GetSupplierInfoDetail(int supplierId)
        {
            return DataPortal.Fetch<SupplierInfoDetail>(supplierId);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="SupplierInfoDetail"/> object, based on given parameters.
        /// </summary>
        /// <param name="supplierId">The SupplierId parameter of the SupplierInfoDetail to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetSupplierInfoDetail(int supplierId, EventHandler<DataPortalResult<SupplierInfoDetail>> callback)
        {
            DataPortal.BeginFetch<SupplierInfoDetail>(supplierId, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierInfoDetail"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SupplierInfoDetail()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="SupplierInfoDetail"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        protected void DataPortal_Fetch(int supplierId)
        {
            var args = new DataPortalHookArgs(supplierId);
            OnFetchPre(args);
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var dal = dalManager.GetProvider<ISupplierInfoDetailDal>();
                var data = dal.Fetch(supplierId);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        /// <summary>
        /// Loads a <see cref="SupplierInfoDetail"/> object from the given <see cref="SupplierInfoDetailDto"/>.
        /// </summary>
        /// <param name="data">The SupplierInfoDetailDto to use.</param>
        private void Fetch(SupplierInfoDetailDto data)
        {
            // Value properties
            LoadProperty(SupplierIdProperty, data.SupplierId);
            LoadProperty(NameProperty, data.Name);
            LoadProperty(AddressLine1Property, data.AddressLine1);
            LoadProperty(AddressLine2Property, data.AddressLine2);
            LoadProperty(ZipCodeProperty, data.ZipCode);
            LoadProperty(StateProperty, data.State);
            LoadProperty(CountryProperty, data.Country);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

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
