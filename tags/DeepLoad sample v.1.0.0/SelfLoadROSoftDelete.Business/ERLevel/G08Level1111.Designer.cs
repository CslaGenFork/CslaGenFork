using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G08Level1111 (read only object).<br/>
    /// This is a generated base class of <see cref="G08Level1111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="G09Level11111Objects"/> of type <see cref="G09Level11111Coll"/> (1:M relation to <see cref="G10Level11111"/>)<br/>
    /// This class is an item of <see cref="G07Level1111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G08Level1111 : ReadOnlyBase<G08Level1111>
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
        /// Maintains metadata about child <see cref="G09Level11111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G09Level11111Child> G09Level11111SingleObjectProperty = RegisterProperty<G09Level11111Child>(p => p.G09Level11111SingleObject, "G09 Level11111 Single Object");
        /// <summary>
        /// Gets the G09 Level11111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The G09 Level11111 Single Object.</value>
        public G09Level11111Child G09Level11111SingleObject
        {
            get { return GetProperty(G09Level11111SingleObjectProperty); }
            private set { LoadProperty(G09Level11111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G09Level11111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G09Level11111ReChild> G09Level11111ASingleObjectProperty = RegisterProperty<G09Level11111ReChild>(p => p.G09Level11111ASingleObject, "G09 Level11111 ASingle Object");
        /// <summary>
        /// Gets the G09 Level11111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The G09 Level11111 ASingle Object.</value>
        public G09Level11111ReChild G09Level11111ASingleObject
        {
            get { return GetProperty(G09Level11111ASingleObjectProperty); }
            private set { LoadProperty(G09Level11111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G09Level11111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<G09Level11111Coll> G09Level11111ObjectsProperty = RegisterProperty<G09Level11111Coll>(p => p.G09Level11111Objects, "G09 Level11111 Objects");
        /// <summary>
        /// Gets the G09 Level11111 Objects ("self load" child property).
        /// </summary>
        /// <value>The G09 Level11111 Objects.</value>
        public G09Level11111Coll G09Level11111Objects
        {
            get { return GetProperty(G09Level11111ObjectsProperty); }
            private set { LoadProperty(G09Level11111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G08Level1111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="G08Level1111"/> object.</returns>
        internal static G08Level1111 GetG08Level1111(SafeDataReader dr)
        {
            G08Level1111 obj = new G08Level1111();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G08Level1111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G08Level1111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G08Level1111"/> object from the given SafeDataReader.
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
            LoadProperty(G09Level11111SingleObjectProperty, G09Level11111Child.GetG09Level11111Child(Level_1_1_1_1_ID));
            LoadProperty(G09Level11111ASingleObjectProperty, G09Level11111ReChild.GetG09Level11111ReChild(Level_1_1_1_1_ID));
            LoadProperty(G09Level11111ObjectsProperty, G09Level11111Coll.GetG09Level11111Coll(Level_1_1_1_1_ID));
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
