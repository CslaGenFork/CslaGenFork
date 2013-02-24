using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E09_Region_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="E09_Region_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="E08_Region"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E09_Region_ReChild : ReadOnlyBase<E09_Region_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int region_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_Child_NameProperty = RegisterProperty<string>(p => p.Region_Child_Name, "Cities Child Name");
        /// <summary>
        /// Gets the Cities Child Name.
        /// </summary>
        /// <value>The Cities Child Name.</value>
        public string Region_Child_Name
        {
            get { return GetProperty(Region_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E09_Region_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E09_Region_ReChild"/> object.</returns>
        internal static E09_Region_ReChild GetE09_Region_ReChild(SafeDataReader dr)
        {
            E09_Region_ReChild obj = new E09_Region_ReChild();
            obj.Fetch(dr);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E09_Region_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E09_Region_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E09_Region_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Region_Child_NameProperty, dr.GetString("Region_Child_Name"));
            // parent properties
            region_ID2 = dr.GetInt32("Region_ID2");
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
