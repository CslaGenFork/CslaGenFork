using System;
using System.Data;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// SupplierInfo (read only object).<br/>
    /// This is a generated base class of <see cref="SupplierInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="SupplierList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class SupplierInfo : ReadOnlyBase<SupplierInfo>
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

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SupplierInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Update properties on saved object event

        /// <summary>
        /// Existing <see cref="SupplierInfo"/> object is updated by <see cref="SupplierEdit"/> Saved event.
        /// </summary>
        internal static SupplierInfo LoadInfo(SupplierEdit supplierEdit)
        {
            var info = new SupplierInfo();
            info.UpdatePropertiesOnSaved(supplierEdit);
            return info;
        }

        /// <summary>
        /// Properties on <see cref="SupplierInfo"/> object are updated by <see cref="SupplierEdit"/> Saved event.
        /// </summary>
        internal void UpdatePropertiesOnSaved(SupplierEdit supplierEdit)
        {
            LoadProperty(NameProperty, supplierEdit.Name);
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="SupplierInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(SupplierIdProperty, dr.GetInt32("SupplierId"));
            LoadProperty(NameProperty, dr.GetString("Name"));
            var args = new DataPortalHookArgs(dr);
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
