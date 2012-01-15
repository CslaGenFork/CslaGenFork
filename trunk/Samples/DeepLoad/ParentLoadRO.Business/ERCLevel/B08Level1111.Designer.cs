using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B08Level1111 (read only object).<br/>
    /// This is a generated base class of <see cref="B08Level1111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B09Level11111Objects"/> of type <see cref="B09Level11111Coll"/> (1:M relation to <see cref="B10Level11111"/>)<br/>
    /// This class is an item of <see cref="B07Level1111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B08Level1111 : ReadOnlyBase<B08Level1111>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int larentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_1_1_ID, "Level_1_1_1_1 ID", -1);
        /// <summary>
        /// Gets the Level_1_1_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1_1_1 ID.</value>
        public int Level_1_1_1_1_ID
        {
            get { return GetProperty(Level_1_1_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_1_Name, "Level_1_1_1_1 Name");
        /// <summary>
        /// Gets the Level_1_1_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1_1_1 Name.</value>
        public string Level_1_1_1_1_Name
        {
            get { return GetProperty(Level_1_1_1_1_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B09Level11111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B09Level11111Child> B09Level11111SingleObjectProperty = RegisterProperty<B09Level11111Child>(p => p.B09Level11111SingleObject, "B09 Level11111 Single Object");
        /// <summary>
        /// Gets the B09 Level11111 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B09 Level11111 Single Object.</value>
        public B09Level11111Child B09Level11111SingleObject
        {
            get { return GetProperty(B09Level11111SingleObjectProperty); }
            private set { LoadProperty(B09Level11111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B09Level11111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B09Level11111ReChild> B09Level11111ASingleObjectProperty = RegisterProperty<B09Level11111ReChild>(p => p.B09Level11111ASingleObject, "B09 Level11111 ASingle Object");
        /// <summary>
        /// Gets the B09 Level11111 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B09 Level11111 ASingle Object.</value>
        public B09Level11111ReChild B09Level11111ASingleObject
        {
            get { return GetProperty(B09Level11111ASingleObjectProperty); }
            private set { LoadProperty(B09Level11111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B09Level11111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B09Level11111Coll> B09Level11111ObjectsProperty = RegisterProperty<B09Level11111Coll>(p => p.B09Level11111Objects, "B09 Level11111 Objects");
        /// <summary>
        /// Gets the B09 Level11111 Objects ("parent load" child property).
        /// </summary>
        /// <value>The B09 Level11111 Objects.</value>
        public B09Level11111Coll B09Level11111Objects
        {
            get { return GetProperty(B09Level11111ObjectsProperty); }
            private set { LoadProperty(B09Level11111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B08Level1111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B08Level1111"/> object.</returns>
        internal static B08Level1111 GetB08Level1111(SafeDataReader dr)
        {
            B08Level1111 obj = new B08Level1111();
            obj.Fetch(dr);
            obj.LoadProperty(B09Level11111ObjectsProperty, new B09Level11111Coll());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B08Level1111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B08Level1111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B08Level1111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_1_IDProperty, dr.GetInt32("Level_1_1_1_1_ID"));
            LoadProperty(Level_1_1_1_1_NameProperty, dr.GetString("Level_1_1_1_1_Name"));
            larentID1 = dr.GetInt32("LarentID1");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B09Level11111Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B09Level11111Child child)
        {
            LoadProperty(B09Level11111SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B09Level11111ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B09Level11111ReChild child)
        {
            LoadProperty(B09Level11111ASingleObjectProperty, child);
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
