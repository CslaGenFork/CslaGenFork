using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E04Level11 (read only object).<br/>
    /// This is a generated base class of <see cref="E04Level11"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E05Level111Objects"/> of type <see cref="E05Level111Coll"/> (1:M relation to <see cref="E06Level111"/>)<br/>
    /// This class is an item of <see cref="E03Level11Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E04Level11 : ReadOnlyBase<E04Level11>
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
        /// Maintains metadata about child <see cref="E05Level111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E05Level111Child> E05Level111SingleObjectProperty = RegisterProperty<E05Level111Child>(p => p.E05Level111SingleObject, "A5 Level111 Single Object");
        /// <summary>
        /// Gets the E05 Level111 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E05 Level111 Single Object.</value>
        public E05Level111Child E05Level111SingleObject
        {
            get { return GetProperty(E05Level111SingleObjectProperty); }
            private set { LoadProperty(E05Level111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E05Level111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E05Level111ReChild> E05Level111ASingleObjectProperty = RegisterProperty<E05Level111ReChild>(p => p.E05Level111ASingleObject, "A5 Level111 ASingle Object");
        /// <summary>
        /// Gets the E05 Level111 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E05 Level111 ASingle Object.</value>
        public E05Level111ReChild E05Level111ASingleObject
        {
            get { return GetProperty(E05Level111ASingleObjectProperty); }
            private set { LoadProperty(E05Level111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E05Level111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E05Level111Coll> E05Level111ObjectsProperty = RegisterProperty<E05Level111Coll>(p => p.E05Level111Objects, "A5 Level111 Objects");
        /// <summary>
        /// Gets the E05 Level111 Objects ("parent load" child property).
        /// </summary>
        /// <value>The E05 Level111 Objects.</value>
        public E05Level111Coll E05Level111Objects
        {
            get { return GetProperty(E05Level111ObjectsProperty); }
            private set { LoadProperty(E05Level111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E04Level11"/> object.</returns>
        internal static E04Level11 GetE04Level11(SafeDataReader dr)
        {
            E04Level11 obj = new E04Level11();
            obj.Fetch(dr);
            obj.LoadProperty(E05Level111ObjectsProperty, new E05Level111Coll());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E04Level11"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E04Level11()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E04Level11"/> object from the given SafeDataReader.
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
        /// Loads child <see cref="E05Level111Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E05Level111Child child)
        {
            LoadProperty(E05Level111SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="E05Level111ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E05Level111ReChild child)
        {
            LoadProperty(E05Level111ASingleObjectProperty, child);
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
