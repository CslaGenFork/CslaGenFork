using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D10Level11111 (read only object).<br/>
    /// This is a generated base class of <see cref="D10Level11111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D11Level111111Objects"/> of type <see cref="D11Level111111Coll"/> (1:M relation to <see cref="D12Level111111"/>)<br/>
    /// This class is an item of <see cref="D09Level11111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D10Level11111 : ReadOnlyBase<D10Level11111>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_1_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_1_1_1_ID, "Level_1_1_1_1_1 ID", -1);
        /// <summary>
        /// Gets the Level_1_1_1_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1_1_1_1 ID.</value>
        public int Level_1_1_1_1_1_ID
        {
            get { return GetProperty(Level_1_1_1_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_1_1_Name, "Level_1_1_1_1_1 Name");
        /// <summary>
        /// Gets the Level_1_1_1_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1_1_1_1 Name.</value>
        public string Level_1_1_1_1_1_Name
        {
            get { return GetProperty(Level_1_1_1_1_1_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D11Level111111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D11Level111111Child> D11Level111111SingleObjectProperty = RegisterProperty<D11Level111111Child>(p => p.D11Level111111SingleObject, "D11 Level111111 Single Object");
        /// <summary>
        /// Gets the D11 Level111111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The D11 Level111111 Single Object.</value>
        public D11Level111111Child D11Level111111SingleObject
        {
            get { return GetProperty(D11Level111111SingleObjectProperty); }
            private set { LoadProperty(D11Level111111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D11Level111111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D11Level111111ReChild> D11Level111111ASingleObjectProperty = RegisterProperty<D11Level111111ReChild>(p => p.D11Level111111ASingleObject, "D11 Level111111 ASingle Object");
        /// <summary>
        /// Gets the D11 Level111111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D11 Level111111 ASingle Object.</value>
        public D11Level111111ReChild D11Level111111ASingleObject
        {
            get { return GetProperty(D11Level111111ASingleObjectProperty); }
            private set { LoadProperty(D11Level111111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D11Level111111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D11Level111111Coll> D11Level111111ObjectsProperty = RegisterProperty<D11Level111111Coll>(p => p.D11Level111111Objects, "D11 Level111111 Objects");
        /// <summary>
        /// Gets the D11 Level111111 Objects ("self load" child property).
        /// </summary>
        /// <value>The D11 Level111111 Objects.</value>
        public D11Level111111Coll D11Level111111Objects
        {
            get { return GetProperty(D11Level111111ObjectsProperty); }
            private set { LoadProperty(D11Level111111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D10Level11111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D10Level11111"/> object.</returns>
        internal static D10Level11111 GetD10Level11111(SafeDataReader dr)
        {
            D10Level11111 obj = new D10Level11111();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D10Level11111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D10Level11111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D10Level11111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_1_1_IDProperty, dr.GetInt32("Level_1_1_1_1_1_ID"));
            LoadProperty(Level_1_1_1_1_1_NameProperty, dr.GetString("Level_1_1_1_1_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(D11Level111111SingleObjectProperty, D11Level111111Child.GetD11Level111111Child(Level_1_1_1_1_1_ID));
            LoadProperty(D11Level111111ASingleObjectProperty, D11Level111111ReChild.GetD11Level111111ReChild(Level_1_1_1_1_1_ID));
            LoadProperty(D11Level111111ObjectsProperty, D11Level111111Coll.GetD11Level111111Coll(Level_1_1_1_1_1_ID));
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
