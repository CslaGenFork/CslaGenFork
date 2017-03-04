using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// AddressEntity (base class).<br/>
    /// This is a generated base class of <see cref="AddressEntity"/> business object.
    /// </summary>
    [Serializable]
    public abstract partial class AddressEntity<T> : BusinessBase<T>
        where T : AddressEntity<T>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="AddressLine1"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> AddressLine1Property = RegisterProperty<string>(p => p.AddressLine1, "Address Line1", null);
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
        public static readonly PropertyInfo<string> AddressLine2Property = RegisterProperty<string>(p => p.AddressLine2, "Address Line2", null);
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
        public static readonly PropertyInfo<string> ZipCodeProperty = RegisterProperty<string>(p => p.ZipCode, "Zip Code", null);
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
        public static readonly PropertyInfo<string> StateProperty = RegisterProperty<string>(p => p.State, "State", null);
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
        public static readonly PropertyInfo<byte?> CountryProperty = RegisterProperty<byte?>(p => p.Country, "Country", null);
        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>The Country.</value>
        public byte? Country
        {
            get { return GetProperty(CountryProperty); }
            set { SetProperty(CountryProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressEntity"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public AddressEntity()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

    }
}
