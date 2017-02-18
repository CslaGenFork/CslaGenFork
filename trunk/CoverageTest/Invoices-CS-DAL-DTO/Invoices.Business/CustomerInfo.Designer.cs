using System;
using Csla;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// CustomerInfo (read only object).<br/>
    /// This is a generated base class of <see cref="CustomerInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="CustomerList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class CustomerInfo : ReadOnlyBase<CustomerInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="CustomerId"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> CustomerIdProperty = RegisterProperty<string>(p => p.CustomerId, "Customer Id");
        /// <summary>
        /// Gets the Customer Id.
        /// </summary>
        /// <value>The Customer Id.</value>
        public string CustomerId
        {
            get { return GetProperty(CustomerIdProperty); }
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
        /// Maintains metadata about <see cref="FiscalNumber"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FiscalNumberProperty = RegisterProperty<string>(p => p.FiscalNumber, "Fiscal Number", null);
        /// <summary>
        /// Gets the Fiscal Number.
        /// </summary>
        /// <value>The Fiscal Number.</value>
        public string FiscalNumber
        {
            get { return GetProperty(FiscalNumberProperty); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CustomerInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Update properties on saved object event

        /// <summary>
        /// Existing <see cref="CustomerInfo"/> object is updated by <see cref="CustomerEdit"/> Saved event.
        /// </summary>
        internal static CustomerInfo LoadInfo(CustomerEdit customerEdit)
        {
            var info = new CustomerInfo();
            info.UpdatePropertiesOnSaved(customerEdit);
            return info;
        }

        /// <summary>
        /// Properties on <see cref="CustomerInfo"/> object are updated by <see cref="CustomerEdit"/> Saved event.
        /// </summary>
        internal void UpdatePropertiesOnSaved(CustomerEdit customerEdit)
        {
            LoadProperty(NameProperty, customerEdit.Name);
            LoadProperty(FiscalNumberProperty, customerEdit.FiscalNumber);
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="CustomerInfo"/> object from the given <see cref="CustomerInfoDto"/>.
        /// </summary>
        /// <param name="data">The CustomerInfoDto to use.</param>
        private void Child_Fetch(CustomerInfoDto data)
        {
            // Value properties
            LoadProperty(CustomerIdProperty, data.CustomerId);
            LoadProperty(NameProperty, data.Name);
            LoadProperty(FiscalNumberProperty, data.FiscalNumber);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
