using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C04Level11 (read only object).<br/>
    /// This is a generated base class of <see cref="C04Level11"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C05Level111Objects"/> of type <see cref="C05Level111Coll"/> (1:M relation to <see cref="C06Level111"/>)<br/>
    /// This class is an item of <see cref="C03Level11Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C04Level11 : ReadOnlyBase<C04Level11>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_ID, "Level_1_1 ID", -1);
        /// <summary>
        /// Gets the Level_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1 ID.</value>
        public int Level_1_1_ID
        {
            get { return GetProperty(Level_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_Name, "Level_1_1 Name");
        /// <summary>
        /// Gets the Level_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1 Name.</value>
        public string Level_1_1_Name
        {
            get { return GetProperty(Level_1_1_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C05Level111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C05Level111Child> C05Level111SingleObjectProperty = RegisterProperty<C05Level111Child>(p => p.C05Level111SingleObject, "A5 Level111 Single Object");
        /// <summary>
        /// Gets the C05 Level111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The C05 Level111 Single Object.</value>
        public C05Level111Child C05Level111SingleObject
        {
            get { return GetProperty(C05Level111SingleObjectProperty); }
            private set { LoadProperty(C05Level111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C05Level111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C05Level111ReChild> C05Level111ASingleObjectProperty = RegisterProperty<C05Level111ReChild>(p => p.C05Level111ASingleObject, "A5 Level111 ASingle Object");
        /// <summary>
        /// Gets the C05 Level111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C05 Level111 ASingle Object.</value>
        public C05Level111ReChild C05Level111ASingleObject
        {
            get { return GetProperty(C05Level111ASingleObjectProperty); }
            private set { LoadProperty(C05Level111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C05Level111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C05Level111Coll> C05Level111ObjectsProperty = RegisterProperty<C05Level111Coll>(p => p.C05Level111Objects, "A5 Level111 Objects");
        /// <summary>
        /// Gets the C05 Level111 Objects ("self load" child property).
        /// </summary>
        /// <value>The C05 Level111 Objects.</value>
        public C05Level111Coll C05Level111Objects
        {
            get { return GetProperty(C05Level111ObjectsProperty); }
            private set { LoadProperty(C05Level111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="C04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="C04Level11"/> object.</returns>
        internal static C04Level11 GetC04Level11(SafeDataReader dr)
        {
            C04Level11 obj = new C04Level11();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C04Level11"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C04Level11()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_IDProperty, dr.GetInt32("Level_1_1_ID"));
            LoadProperty(Level_1_1_NameProperty, dr.GetString("Level_1_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(C05Level111SingleObjectProperty, C05Level111Child.GetC05Level111Child(Level_1_1_ID));
            LoadProperty(C05Level111ASingleObjectProperty, C05Level111ReChild.GetC05Level111ReChild(Level_1_1_ID));
            LoadProperty(C05Level111ObjectsProperty, C05Level111Coll.GetC05Level111Coll(Level_1_1_ID));
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
