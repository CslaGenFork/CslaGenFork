using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H10Level11111 (read only object).<br/>
    /// This is a generated base class of <see cref="H10Level11111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H11Level111111Objects"/> of type <see cref="H11Level111111Coll"/> (1:M relation to <see cref="H12Level111111"/>)<br/>
    /// This class is an item of <see cref="H09Level11111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H10Level11111 : ReadOnlyBase<H10Level11111>
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
        /// Maintains metadata about child <see cref="H11Level111111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H11Level111111Child> H11Level111111SingleObjectProperty = RegisterProperty<H11Level111111Child>(p => p.H11Level111111SingleObject, "H11 Level111111 Single Object");
        /// <summary>
        /// Gets the H11 Level111111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The H11 Level111111 Single Object.</value>
        public H11Level111111Child H11Level111111SingleObject
        {
            get { return GetProperty(H11Level111111SingleObjectProperty); }
            private set { LoadProperty(H11Level111111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H11Level111111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H11Level111111ReChild> H11Level111111ASingleObjectProperty = RegisterProperty<H11Level111111ReChild>(p => p.H11Level111111ASingleObject, "H11 Level111111 ASingle Object");
        /// <summary>
        /// Gets the H11 Level111111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H11 Level111111 ASingle Object.</value>
        public H11Level111111ReChild H11Level111111ASingleObject
        {
            get { return GetProperty(H11Level111111ASingleObjectProperty); }
            private set { LoadProperty(H11Level111111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H11Level111111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H11Level111111Coll> H11Level111111ObjectsProperty = RegisterProperty<H11Level111111Coll>(p => p.H11Level111111Objects, "H11 Level111111 Objects");
        /// <summary>
        /// Gets the H11 Level111111 Objects ("self load" child property).
        /// </summary>
        /// <value>The H11 Level111111 Objects.</value>
        public H11Level111111Coll H11Level111111Objects
        {
            get { return GetProperty(H11Level111111ObjectsProperty); }
            private set { LoadProperty(H11Level111111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H10Level11111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H10Level11111"/> object.</returns>
        internal static H10Level11111 GetH10Level11111(SafeDataReader dr)
        {
            H10Level11111 obj = new H10Level11111();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H10Level11111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H10Level11111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H10Level11111"/> object from the given SafeDataReader.
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
            LoadProperty(H11Level111111SingleObjectProperty, H11Level111111Child.GetH11Level111111Child(Level_1_1_1_1_1_ID));
            LoadProperty(H11Level111111ASingleObjectProperty, H11Level111111ReChild.GetH11Level111111ReChild(Level_1_1_1_1_1_ID));
            LoadProperty(H11Level111111ObjectsProperty, H11Level111111Coll.GetH11Level111111Coll(Level_1_1_1_1_1_ID));
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
