using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H02Level1 (read only object).<br/>
    /// This is a generated base class of <see cref="H02Level1"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H03Level11Objects"/> of type <see cref="H03Level11Coll"/> (1:M relation to <see cref="H04Level11"/>)<br/>
    /// This class is an item of <see cref="H01Level1Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H02Level1 : ReadOnlyBase<H02Level1>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_IDProperty = RegisterProperty<int>(p => p.Level_1_ID, "Level_1 ID", -1);
        /// <summary>
        /// Gets the Level_1 ID.
        /// </summary>
        /// <value>The Level_1 ID.</value>
        public int Level_1_ID
        {
            get { return GetProperty(Level_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_NameProperty = RegisterProperty<string>(p => p.Level_1_Name, "Level_1 Name");
        /// <summary>
        /// Gets the Level_1 Name.
        /// </summary>
        /// <value>The Level_1 Name.</value>
        public string Level_1_Name
        {
            get { return GetProperty(Level_1_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H03Level11SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H03Level11Child> H03Level11SingleObjectProperty = RegisterProperty<H03Level11Child>(p => p.H03Level11SingleObject, "B3 Level11 Single Object");
        /// <summary>
        /// Gets the H03 Level11 Single Object ("self load" child property).
        /// </summary>
        /// <value>The H03 Level11 Single Object.</value>
        public H03Level11Child H03Level11SingleObject
        {
            get { return GetProperty(H03Level11SingleObjectProperty); }
            private set { LoadProperty(H03Level11SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H03Level11ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H03Level11ReChild> H03Level11ASingleObjectProperty = RegisterProperty<H03Level11ReChild>(p => p.H03Level11ASingleObject, "B3 Level11 ASingle Object");
        /// <summary>
        /// Gets the H03 Level11 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H03 Level11 ASingle Object.</value>
        public H03Level11ReChild H03Level11ASingleObject
        {
            get { return GetProperty(H03Level11ASingleObjectProperty); }
            private set { LoadProperty(H03Level11ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H03Level11Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H03Level11Coll> H03Level11ObjectsProperty = RegisterProperty<H03Level11Coll>(p => p.H03Level11Objects, "B3 Level11 Objects");
        /// <summary>
        /// Gets the H03 Level11 Objects ("self load" child property).
        /// </summary>
        /// <value>The H03 Level11 Objects.</value>
        public H03Level11Coll H03Level11Objects
        {
            get { return GetProperty(H03Level11ObjectsProperty); }
            private set { LoadProperty(H03Level11ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H02Level1"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H02Level1"/> object.</returns>
        internal static H02Level1 GetH02Level1(SafeDataReader dr)
        {
            H02Level1 obj = new H02Level1();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H02Level1"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H02Level1()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H02Level1"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_IDProperty, dr.GetInt32("Level_1_ID"));
            LoadProperty(Level_1_NameProperty, dr.GetString("Level_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(H03Level11SingleObjectProperty, H03Level11Child.GetH03Level11Child(Level_1_ID));
            LoadProperty(H03Level11ASingleObjectProperty, H03Level11ReChild.GetH03Level11ReChild(Level_1_ID));
            LoadProperty(H03Level11ObjectsProperty, H03Level11Coll.GetH03Level11Coll(Level_1_ID));
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
