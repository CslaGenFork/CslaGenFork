using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F03_Continent_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="F03_Continent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F02_Continent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F03_Continent_ReChild : ReadOnlyBase<F03_Continent_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int continent_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_Child_NameProperty = RegisterProperty<string>(p => p.Continent_Child_Name, "2_SubContinents Child Name");
        /// <summary>
        /// Gets the 2_SubContinents Child Name.
        /// </summary>
        /// <value>The 2_SubContinents Child Name.</value>
        public string Continent_Child_Name
        {
            get { return GetProperty(Continent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F03_Continent_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F03_Continent_ReChild"/> object.</returns>
        internal static F03_Continent_ReChild GetF03_Continent_ReChild(SafeDataReader dr)
        {
            F03_Continent_ReChild obj = new F03_Continent_ReChild();
            obj.Fetch(dr);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F03_Continent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F03_Continent_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F03_Continent_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Continent_Child_NameProperty, dr.GetString("Continent_Child_Name"));
            // parent properties
            continent_ID2 = dr.GetInt32("Continent_ID2");
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
