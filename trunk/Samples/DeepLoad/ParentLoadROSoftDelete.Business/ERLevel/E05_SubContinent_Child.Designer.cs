using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E05_SubContinent_Child (read only object).<br/>
    /// This is a generated base class of <see cref="E05_SubContinent_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="E04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E05_SubContinent_Child : ReadOnlyBase<E05_SubContinent_Child>
    {

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

        [NotUndoable]
        [NonSerialized]
        internal int subContinent_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "3_Countries Child Name");
        /// <summary>
        /// Gets the 3_Countries Child Name.
        /// </summary>
        /// <value>The 3_Countries Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_ID1"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SubContinent_ID1Property = RegisterProperty<int>(p => p.SubContinent_ID1, "CMarent ID1");
        /// <summary>
        /// Gets the CMarent ID1.
        /// </summary>
        /// <value>The CMarent ID1.</value>
        public int SubContinent_ID1
        {
            get { return GetProperty(SubContinent_ID1Property); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E05_SubContinent_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E05_SubContinent_Child"/> object.</returns>
        internal static E05_SubContinent_Child GetE05_SubContinent_Child(SafeDataReader dr)
        {
            E05_SubContinent_Child obj = new E05_SubContinent_Child();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E05_SubContinent_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E05_SubContinent_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E05_SubContinent_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, dr.GetString("SubContinent_Child_Name"));
            LoadProperty(SubContinent_ID1Property, dr.GetInt32("SubContinent_ID1"));
            _rowVersion = (dr.GetValue("RowVersion")) as byte[];
            subContinent_ID1 = dr.GetInt32("SubContinent_ID1");
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
