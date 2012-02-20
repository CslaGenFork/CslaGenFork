using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F08Level1111 (read only object).<br/>
    /// This is a generated base class of <see cref="F08Level1111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="F09Level11111Objects"/> of type <see cref="F09Level11111Coll"/> (1:M relation to <see cref="F10Level11111"/>)<br/>
    /// This class is an item of <see cref="F07Level1111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F08Level1111 : ReadOnlyBase<F08Level1111>
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
        /// Maintains metadata about child <see cref="F09Level11111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F09Level11111Child> F09Level11111SingleObjectProperty = RegisterProperty<F09Level11111Child>(p => p.F09Level11111SingleObject, "F09 Level11111 Single Object");
        /// <summary>
        /// Gets the F09 Level11111 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The F09 Level11111 Single Object.</value>
        public F09Level11111Child F09Level11111SingleObject
        {
            get { return GetProperty(F09Level11111SingleObjectProperty); }
            private set { LoadProperty(F09Level11111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F09Level11111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F09Level11111ReChild> F09Level11111ASingleObjectProperty = RegisterProperty<F09Level11111ReChild>(p => p.F09Level11111ASingleObject, "F09 Level11111 ASingle Object");
        /// <summary>
        /// Gets the F09 Level11111 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The F09 Level11111 ASingle Object.</value>
        public F09Level11111ReChild F09Level11111ASingleObject
        {
            get { return GetProperty(F09Level11111ASingleObjectProperty); }
            private set { LoadProperty(F09Level11111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F09Level11111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<F09Level11111Coll> F09Level11111ObjectsProperty = RegisterProperty<F09Level11111Coll>(p => p.F09Level11111Objects, "F09 Level11111 Objects");
        /// <summary>
        /// Gets the F09 Level11111 Objects ("parent load" child property).
        /// </summary>
        /// <value>The F09 Level11111 Objects.</value>
        public F09Level11111Coll F09Level11111Objects
        {
            get { return GetProperty(F09Level11111ObjectsProperty); }
            private set { LoadProperty(F09Level11111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F08Level1111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F08Level1111"/> object.</returns>
        internal static F08Level1111 GetF08Level1111(SafeDataReader dr)
        {
            F08Level1111 obj = new F08Level1111();
            obj.Fetch(dr);
            obj.LoadProperty(F09Level11111ObjectsProperty, new F09Level11111Coll());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F08Level1111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F08Level1111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F08Level1111"/> object from the given SafeDataReader.
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
        /// Loads child <see cref="F09Level11111Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F09Level11111Child child)
        {
            LoadProperty(F09Level11111SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="F09Level11111ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F09Level11111ReChild child)
        {
            LoadProperty(F09Level11111ASingleObjectProperty, child);
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
