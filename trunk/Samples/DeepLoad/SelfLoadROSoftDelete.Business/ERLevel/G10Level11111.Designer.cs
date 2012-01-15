using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G10Level11111 (read only object).<br/>
    /// This is a generated base class of <see cref="G10Level11111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="G11Level111111Objects"/> of type <see cref="G11Level111111Coll"/> (1:M relation to <see cref="G12Level111111"/>)<br/>
    /// This class is an item of <see cref="G09Level11111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G10Level11111 : ReadOnlyBase<G10Level11111>
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
        /// Maintains metadata about child <see cref="G11Level111111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G11Level111111Child> G11Level111111SingleObjectProperty = RegisterProperty<G11Level111111Child>(p => p.G11Level111111SingleObject, "G11 Level111111 Single Object");
        /// <summary>
        /// Gets the G11 Level111111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The G11 Level111111 Single Object.</value>
        public G11Level111111Child G11Level111111SingleObject
        {
            get { return GetProperty(G11Level111111SingleObjectProperty); }
            private set { LoadProperty(G11Level111111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G11Level111111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G11Level111111ReChild> G11Level111111ASingleObjectProperty = RegisterProperty<G11Level111111ReChild>(p => p.G11Level111111ASingleObject, "G11 Level111111 ASingle Object");
        /// <summary>
        /// Gets the G11 Level111111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The G11 Level111111 ASingle Object.</value>
        public G11Level111111ReChild G11Level111111ASingleObject
        {
            get { return GetProperty(G11Level111111ASingleObjectProperty); }
            private set { LoadProperty(G11Level111111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G11Level111111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<G11Level111111Coll> G11Level111111ObjectsProperty = RegisterProperty<G11Level111111Coll>(p => p.G11Level111111Objects, "G11 Level111111 Objects");
        /// <summary>
        /// Gets the G11 Level111111 Objects ("self load" child property).
        /// </summary>
        /// <value>The G11 Level111111 Objects.</value>
        public G11Level111111Coll G11Level111111Objects
        {
            get { return GetProperty(G11Level111111ObjectsProperty); }
            private set { LoadProperty(G11Level111111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G10Level11111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="G10Level11111"/> object.</returns>
        internal static G10Level11111 GetG10Level11111(SafeDataReader dr)
        {
            G10Level11111 obj = new G10Level11111();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G10Level11111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G10Level11111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G10Level11111"/> object from the given SafeDataReader.
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
            LoadProperty(G11Level111111SingleObjectProperty, G11Level111111Child.GetG11Level111111Child(Level_1_1_1_1_1_ID));
            LoadProperty(G11Level111111ASingleObjectProperty, G11Level111111ReChild.GetG11Level111111ReChild(Level_1_1_1_1_1_ID));
            LoadProperty(G11Level111111ObjectsProperty, G11Level111111Coll.GetG11Level111111Coll(Level_1_1_1_1_1_ID));
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
