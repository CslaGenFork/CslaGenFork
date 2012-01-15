using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D02Level1 (read only object).<br/>
    /// This is a generated base class of <see cref="D02Level1"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D03Level11Objects"/> of type <see cref="D03Level11Coll"/> (1:M relation to <see cref="D04Level11"/>)<br/>
    /// This class is an item of <see cref="D01Level1Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D02Level1 : ReadOnlyBase<D02Level1>
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
        /// Maintains metadata about child <see cref="D03Level11SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D03Level11Child> D03Level11SingleObjectProperty = RegisterProperty<D03Level11Child>(p => p.D03Level11SingleObject, "B3 Level11 Single Object");
        /// <summary>
        /// Gets the D03 Level11 Single Object ("self load" child property).
        /// </summary>
        /// <value>The D03 Level11 Single Object.</value>
        public D03Level11Child D03Level11SingleObject
        {
            get { return GetProperty(D03Level11SingleObjectProperty); }
            private set { LoadProperty(D03Level11SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D03Level11ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D03Level11ReChild> D03Level11ASingleObjectProperty = RegisterProperty<D03Level11ReChild>(p => p.D03Level11ASingleObject, "B3 Level11 ASingle Object");
        /// <summary>
        /// Gets the D03 Level11 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D03 Level11 ASingle Object.</value>
        public D03Level11ReChild D03Level11ASingleObject
        {
            get { return GetProperty(D03Level11ASingleObjectProperty); }
            private set { LoadProperty(D03Level11ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D03Level11Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D03Level11Coll> D03Level11ObjectsProperty = RegisterProperty<D03Level11Coll>(p => p.D03Level11Objects, "B3 Level11 Objects");
        /// <summary>
        /// Gets the D03 Level11 Objects ("self load" child property).
        /// </summary>
        /// <value>The D03 Level11 Objects.</value>
        public D03Level11Coll D03Level11Objects
        {
            get { return GetProperty(D03Level11ObjectsProperty); }
            private set { LoadProperty(D03Level11ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D02Level1"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D02Level1"/> object.</returns>
        internal static D02Level1 GetD02Level1(SafeDataReader dr)
        {
            D02Level1 obj = new D02Level1();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D02Level1"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D02Level1()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D02Level1"/> object from the given SafeDataReader.
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
            LoadProperty(D03Level11SingleObjectProperty, D03Level11Child.GetD03Level11Child(Level_1_ID));
            LoadProperty(D03Level11ASingleObjectProperty, D03Level11ReChild.GetD03Level11ReChild(Level_1_ID));
            LoadProperty(D03Level11ObjectsProperty, D03Level11Coll.GetD03Level11Coll(Level_1_ID));
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
