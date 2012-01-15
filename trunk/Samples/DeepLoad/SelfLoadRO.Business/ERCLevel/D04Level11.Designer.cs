using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D04Level11 (read only object).<br/>
    /// This is a generated base class of <see cref="D04Level11"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D05Level111Objects"/> of type <see cref="D05Level111Coll"/> (1:M relation to <see cref="D06Level111"/>)<br/>
    /// This class is an item of <see cref="D03Level11Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D04Level11 : ReadOnlyBase<D04Level11>
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
        /// Maintains metadata about child <see cref="D05Level111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D05Level111ReChild> D05Level111ASingleObjectProperty = RegisterProperty<D05Level111ReChild>(p => p.D05Level111ASingleObject, "B5 Level111 ASingle Object");
        /// <summary>
        /// Gets the D05 Level111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D05 Level111 ASingle Object.</value>
        public D05Level111ReChild D05Level111ASingleObject
        {
            get { return GetProperty(D05Level111ASingleObjectProperty); }
            private set { LoadProperty(D05Level111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D05Level111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D05Level111Child> D05Level111SingleObjectProperty = RegisterProperty<D05Level111Child>(p => p.D05Level111SingleObject, "B5 Level111 Single Object");
        /// <summary>
        /// Gets the D05 Level111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The D05 Level111 Single Object.</value>
        public D05Level111Child D05Level111SingleObject
        {
            get { return GetProperty(D05Level111SingleObjectProperty); }
            private set { LoadProperty(D05Level111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D05Level111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D05Level111Coll> D05Level111ObjectsProperty = RegisterProperty<D05Level111Coll>(p => p.D05Level111Objects, "B5 Level111 Objects");
        /// <summary>
        /// Gets the D05 Level111 Objects ("self load" child property).
        /// </summary>
        /// <value>The D05 Level111 Objects.</value>
        public D05Level111Coll D05Level111Objects
        {
            get { return GetProperty(D05Level111ObjectsProperty); }
            private set { LoadProperty(D05Level111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D04Level11"/> object.</returns>
        internal static D04Level11 GetD04Level11(SafeDataReader dr)
        {
            D04Level11 obj = new D04Level11();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D04Level11"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D04Level11()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D04Level11"/> object from the given SafeDataReader.
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
            LoadProperty(D05Level111ASingleObjectProperty, D05Level111ReChild.GetD05Level111ReChild(Level_1_1_ID));
            LoadProperty(D05Level111SingleObjectProperty, D05Level111Child.GetD05Level111Child(Level_1_1_ID));
            LoadProperty(D05Level111ObjectsProperty, D05Level111Coll.GetD05Level111Coll(Level_1_1_ID));
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
