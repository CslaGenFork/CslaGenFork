using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C08Level1111 (read only object).<br/>
    /// This is a generated base class of <see cref="C08Level1111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C09Level11111Objects"/> of type <see cref="C09Level11111Coll"/> (1:M relation to <see cref="C10Level11111"/>)<br/>
    /// This class is an item of <see cref="C07Level1111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C08Level1111 : ReadOnlyBase<C08Level1111>
    {

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
        /// Maintains metadata about child <see cref="C09Level11111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C09Level11111Child> C09Level11111SingleObjectProperty = RegisterProperty<C09Level11111Child>(p => p.C09Level11111SingleObject, "C09 Level11111 Single Object");
        /// <summary>
        /// Gets the C09 Level11111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The C09 Level11111 Single Object.</value>
        public C09Level11111Child C09Level11111SingleObject
        {
            get { return GetProperty(C09Level11111SingleObjectProperty); }
            private set { LoadProperty(C09Level11111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C09Level11111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C09Level11111ReChild> C09Level11111ASingleObjectProperty = RegisterProperty<C09Level11111ReChild>(p => p.C09Level11111ASingleObject, "C09 Level11111 ASingle Object");
        /// <summary>
        /// Gets the C09 Level11111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C09 Level11111 ASingle Object.</value>
        public C09Level11111ReChild C09Level11111ASingleObject
        {
            get { return GetProperty(C09Level11111ASingleObjectProperty); }
            private set { LoadProperty(C09Level11111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C09Level11111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C09Level11111Coll> C09Level11111ObjectsProperty = RegisterProperty<C09Level11111Coll>(p => p.C09Level11111Objects, "C09 Level11111 Objects");
        /// <summary>
        /// Gets the C09 Level11111 Objects ("self load" child property).
        /// </summary>
        /// <value>The C09 Level11111 Objects.</value>
        public C09Level11111Coll C09Level11111Objects
        {
            get { return GetProperty(C09Level11111ObjectsProperty); }
            private set { LoadProperty(C09Level11111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="C08Level1111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="C08Level1111"/> object.</returns>
        internal static C08Level1111 GetC08Level1111(SafeDataReader dr)
        {
            C08Level1111 obj = new C08Level1111();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C08Level1111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C08Level1111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C08Level1111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_1_IDProperty, dr.GetInt32("Level_1_1_1_1_ID"));
            LoadProperty(Level_1_1_1_1_NameProperty, dr.GetString("Level_1_1_1_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(C09Level11111SingleObjectProperty, C09Level11111Child.GetC09Level11111Child(Level_1_1_1_1_ID));
            LoadProperty(C09Level11111ASingleObjectProperty, C09Level11111ReChild.GetC09Level11111ReChild(Level_1_1_1_1_ID));
            LoadProperty(C09Level11111ObjectsProperty, C09Level11111Coll.GetC09Level11111Coll(Level_1_1_1_1_ID));
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
