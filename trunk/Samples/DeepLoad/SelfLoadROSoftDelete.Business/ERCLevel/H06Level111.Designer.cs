using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H06Level111 (read only object).<br/>
    /// This is a generated base class of <see cref="H06Level111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H07Level1111Objects"/> of type <see cref="H07Level1111Coll"/> (1:M relation to <see cref="H08Level1111"/>)<br/>
    /// This class is an item of <see cref="H05Level111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H06Level111 : ReadOnlyBase<H06Level111>
    {

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
        /// Maintains metadata about child <see cref="H07Level1111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H07Level1111Child> H07Level1111SingleObjectProperty = RegisterProperty<H07Level1111Child>(p => p.H07Level1111SingleObject, "B7 Level1111 Single Object");
        /// <summary>
        /// Gets the H07 Level1111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The H07 Level1111 Single Object.</value>
        public H07Level1111Child H07Level1111SingleObject
        {
            get { return GetProperty(H07Level1111SingleObjectProperty); }
            private set { LoadProperty(H07Level1111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H07Level1111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H07Level1111ReChild> H07Level1111ASingleObjectProperty = RegisterProperty<H07Level1111ReChild>(p => p.H07Level1111ASingleObject, "B7 Level1111 ASingle Object");
        /// <summary>
        /// Gets the H07 Level1111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H07 Level1111 ASingle Object.</value>
        public H07Level1111ReChild H07Level1111ASingleObject
        {
            get { return GetProperty(H07Level1111ASingleObjectProperty); }
            private set { LoadProperty(H07Level1111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H07Level1111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H07Level1111Coll> H07Level1111ObjectsProperty = RegisterProperty<H07Level1111Coll>(p => p.H07Level1111Objects, "B7 Level1111 Objects");
        /// <summary>
        /// Gets the H07 Level1111 Objects ("self load" child property).
        /// </summary>
        /// <value>The H07 Level1111 Objects.</value>
        public H07Level1111Coll H07Level1111Objects
        {
            get { return GetProperty(H07Level1111ObjectsProperty); }
            private set { LoadProperty(H07Level1111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H06Level111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H06Level111"/> object.</returns>
        internal static H06Level111 GetH06Level111(SafeDataReader dr)
        {
            H06Level111 obj = new H06Level111();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H06Level111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H06Level111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H06Level111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_IDProperty, dr.GetInt32("Level_1_1_1_ID"));
            LoadProperty(Level_1_1_1_NameProperty, dr.GetString("Level_1_1_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(H07Level1111SingleObjectProperty, H07Level1111Child.GetH07Level1111Child(Level_1_1_1_ID));
            LoadProperty(H07Level1111ASingleObjectProperty, H07Level1111ReChild.GetH07Level1111ReChild(Level_1_1_1_ID));
            LoadProperty(H07Level1111ObjectsProperty, H07Level1111Coll.GetH07Level1111Coll(Level_1_1_1_ID));
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
