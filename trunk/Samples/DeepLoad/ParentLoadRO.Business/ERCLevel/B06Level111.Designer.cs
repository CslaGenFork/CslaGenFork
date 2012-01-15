using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B06Level111 (read only object).<br/>
    /// This is a generated base class of <see cref="B06Level111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B07Level1111Objects"/> of type <see cref="B07Level1111Coll"/> (1:M relation to <see cref="B08Level1111"/>)<br/>
    /// This class is an item of <see cref="B05Level111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B06Level111 : ReadOnlyBase<B06Level111>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int marentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_1_ID, "Level_1_1_1 ID", -1);
        /// <summary>
        /// Gets the Level_1_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1_1 ID.</value>
        public int Level_1_1_1_ID
        {
            get { return GetProperty(Level_1_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_Name, "Level_1_1_1 Name");
        /// <summary>
        /// Gets the Level_1_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1_1 Name.</value>
        public string Level_1_1_1_Name
        {
            get { return GetProperty(Level_1_1_1_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B07Level1111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B07Level1111Child> B07Level1111SingleObjectProperty = RegisterProperty<B07Level1111Child>(p => p.B07Level1111SingleObject, "B7 Level1111 Single Object");
        /// <summary>
        /// Gets the B07 Level1111 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B07 Level1111 Single Object.</value>
        public B07Level1111Child B07Level1111SingleObject
        {
            get { return GetProperty(B07Level1111SingleObjectProperty); }
            private set { LoadProperty(B07Level1111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B07Level1111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B07Level1111ReChild> B07Level1111ASingleObjectProperty = RegisterProperty<B07Level1111ReChild>(p => p.B07Level1111ASingleObject, "B7 Level1111 ASingle Object");
        /// <summary>
        /// Gets the B07 Level1111 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B07 Level1111 ASingle Object.</value>
        public B07Level1111ReChild B07Level1111ASingleObject
        {
            get { return GetProperty(B07Level1111ASingleObjectProperty); }
            private set { LoadProperty(B07Level1111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B07Level1111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B07Level1111Coll> B07Level1111ObjectsProperty = RegisterProperty<B07Level1111Coll>(p => p.B07Level1111Objects, "B7 Level1111 Objects");
        /// <summary>
        /// Gets the B07 Level1111 Objects ("parent load" child property).
        /// </summary>
        /// <value>The B07 Level1111 Objects.</value>
        public B07Level1111Coll B07Level1111Objects
        {
            get { return GetProperty(B07Level1111ObjectsProperty); }
            private set { LoadProperty(B07Level1111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B06Level111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B06Level111"/> object.</returns>
        internal static B06Level111 GetB06Level111(SafeDataReader dr)
        {
            B06Level111 obj = new B06Level111();
            obj.Fetch(dr);
            obj.LoadProperty(B07Level1111ObjectsProperty, new B07Level1111Coll());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B06Level111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B06Level111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B06Level111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_IDProperty, dr.GetInt32("Level_1_1_1_ID"));
            LoadProperty(Level_1_1_1_NameProperty, dr.GetString("Level_1_1_1_Name"));
            marentID1 = dr.GetInt32("MarentID1");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B07Level1111Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B07Level1111Child child)
        {
            LoadProperty(B07Level1111SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B07Level1111ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B07Level1111ReChild child)
        {
            LoadProperty(B07Level1111ASingleObjectProperty, child);
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
