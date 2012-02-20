using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C06Level111 (read only object).<br/>
    /// This is a generated base class of <see cref="C06Level111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C07Level1111Objects"/> of type <see cref="C07Level1111Coll"/> (1:M relation to <see cref="C08Level1111"/>)<br/>
    /// This class is an item of <see cref="C05Level111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C06Level111 : ReadOnlyBase<C06Level111>
    {

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

        #endregion

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
        /// Maintains metadata about <see cref="MarentID1"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> MarentID1Property = RegisterProperty<int>(p => p.MarentID1, "Marent ID1");
        /// <summary>
        /// Gets the Marent ID1.
        /// </summary>
        /// <value>The Marent ID1.</value>
        public int MarentID1
        {
            get { return GetProperty(MarentID1Property); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C07Level1111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C07Level1111Child> C07Level1111SingleObjectProperty = RegisterProperty<C07Level1111Child>(p => p.C07Level1111SingleObject, "A7 Level1111 Single Object");
        /// <summary>
        /// Gets the C07 Level1111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The C07 Level1111 Single Object.</value>
        public C07Level1111Child C07Level1111SingleObject
        {
            get { return GetProperty(C07Level1111SingleObjectProperty); }
            private set { LoadProperty(C07Level1111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C07Level1111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C07Level1111ReChild> C07Level1111ASingleObjectProperty = RegisterProperty<C07Level1111ReChild>(p => p.C07Level1111ASingleObject, "A7 Level1111 ASimple Object");
        /// <summary>
        /// Gets the C07 Level1111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C07 Level1111 ASingle Object.</value>
        public C07Level1111ReChild C07Level1111ASingleObject
        {
            get { return GetProperty(C07Level1111ASingleObjectProperty); }
            private set { LoadProperty(C07Level1111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C07Level1111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C07Level1111Coll> C07Level1111ObjectsProperty = RegisterProperty<C07Level1111Coll>(p => p.C07Level1111Objects, "A7 Level1111 Objects");
        /// <summary>
        /// Gets the C07 Level1111 Objects ("self load" child property).
        /// </summary>
        /// <value>The C07 Level1111 Objects.</value>
        public C07Level1111Coll C07Level1111Objects
        {
            get { return GetProperty(C07Level1111ObjectsProperty); }
            private set { LoadProperty(C07Level1111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="C06Level111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="C06Level111"/> object.</returns>
        internal static C06Level111 GetC06Level111(SafeDataReader dr)
        {
            C06Level111 obj = new C06Level111();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C06Level111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C06Level111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C06Level111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_IDProperty, dr.GetInt32("Level_1_1_1_ID"));
            LoadProperty(Level_1_1_1_NameProperty, dr.GetString("Level_1_1_1_Name"));
            LoadProperty(MarentID1Property, dr.GetInt32("MarentID1"));
            _rowVersion = (dr.GetValue("RowVersion")) as byte[];
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(C07Level1111SingleObjectProperty, C07Level1111Child.GetC07Level1111Child(Level_1_1_1_ID));
            LoadProperty(C07Level1111ASingleObjectProperty, C07Level1111ReChild.GetC07Level1111ReChild(Level_1_1_1_ID));
            LoadProperty(C07Level1111ObjectsProperty, C07Level1111Coll.GetC07Level1111Coll(Level_1_1_1_ID));
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
