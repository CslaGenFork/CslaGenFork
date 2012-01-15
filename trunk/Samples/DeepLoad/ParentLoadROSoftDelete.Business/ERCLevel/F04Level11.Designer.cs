using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F04Level11 (read only object).<br/>
    /// This is a generated base class of <see cref="F04Level11"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="F05Level111Objects"/> of type <see cref="F05Level111Coll"/> (1:M relation to <see cref="F06Level111"/>)<br/>
    /// This class is an item of <see cref="F03Level11Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F04Level11 : ReadOnlyBase<F04Level11>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parentID1 = 0;

        #endregion

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
        /// Maintains metadata about child <see cref="F05Level111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F05Level111ReChild> F05Level111ASingleObjectProperty = RegisterProperty<F05Level111ReChild>(p => p.F05Level111ASingleObject, "B5 Level111 ASingle Object");
        /// <summary>
        /// Gets the F05 Level111 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The F05 Level111 ASingle Object.</value>
        public F05Level111ReChild F05Level111ASingleObject
        {
            get { return GetProperty(F05Level111ASingleObjectProperty); }
            private set { LoadProperty(F05Level111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F05Level111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F05Level111Child> F05Level111SingleObjectProperty = RegisterProperty<F05Level111Child>(p => p.F05Level111SingleObject, "B5 Level111 Single Object");
        /// <summary>
        /// Gets the F05 Level111 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The F05 Level111 Single Object.</value>
        public F05Level111Child F05Level111SingleObject
        {
            get { return GetProperty(F05Level111SingleObjectProperty); }
            private set { LoadProperty(F05Level111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F05Level111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<F05Level111Coll> F05Level111ObjectsProperty = RegisterProperty<F05Level111Coll>(p => p.F05Level111Objects, "B5 Level111 Objects");
        /// <summary>
        /// Gets the F05 Level111 Objects ("parent load" child property).
        /// </summary>
        /// <value>The F05 Level111 Objects.</value>
        public F05Level111Coll F05Level111Objects
        {
            get { return GetProperty(F05Level111ObjectsProperty); }
            private set { LoadProperty(F05Level111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F04Level11"/> object.</returns>
        internal static F04Level11 GetF04Level11(SafeDataReader dr)
        {
            F04Level11 obj = new F04Level11();
            obj.Fetch(dr);
            obj.LoadProperty(F05Level111ObjectsProperty, new F05Level111Coll());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F04Level11"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F04Level11()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_IDProperty, dr.GetInt32("Level_1_1_ID"));
            LoadProperty(Level_1_1_NameProperty, dr.GetString("Level_1_1_Name"));
            parentID1 = dr.GetInt32("ParentID1");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="F05Level111ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F05Level111ReChild child)
        {
            LoadProperty(F05Level111ASingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="F05Level111Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F05Level111Child child)
        {
            LoadProperty(F05Level111SingleObjectProperty, child);
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
