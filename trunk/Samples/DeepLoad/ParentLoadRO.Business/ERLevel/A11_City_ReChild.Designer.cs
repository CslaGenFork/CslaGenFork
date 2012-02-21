using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A11_City_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="A11_City_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="A10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A11_City_ReChild : ReadOnlyBase<A11_City_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int city_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets or sets the 6_CityRoads Child Name.
        /// </summary>
        /// <value>The 6_CityRoads Child Name.</value>
        public string City_Child_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A11_City_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A11_City_ReChild"/> object.</returns>
        internal static A11_City_ReChild GetA11_City_ReChild(SafeDataReader dr)
        {
            A11_City_ReChild obj = new A11_City_ReChild();
            obj.Fetch(dr);
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A11_City_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A11_City_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A11_City_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            City_Child_Name = dr.GetString("City_Child_Name");
            city_ID2 = dr.GetInt32("City_ID2");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
