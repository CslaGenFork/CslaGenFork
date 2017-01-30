using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B08_Region (read only object).<br/>
    /// This is a generated base class of <see cref="B08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B09_CityObjects"/> of type <see cref="B09_CityColl"/> (1:M relation to <see cref="B10_City"/>)<br/>
    /// This class is an item of <see cref="B07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B08_Region : ReadOnlyBase<B08_Region>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_Country_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Region_IDProperty = RegisterProperty<int>(p => p.Region_ID, "Region ID", -1);
        /// <summary>
        /// Gets the Region ID.
        /// </summary>
        /// <value>The Region ID.</value>
        public int Region_ID
        {
            get { return GetProperty(Region_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Region_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_NameProperty = RegisterProperty<string>(p => p.Region_Name, "Region Name");
        /// <summary>
        /// Gets the Region Name.
        /// </summary>
        /// <value>The Region Name.</value>
        public string Region_Name
        {
            get { return GetProperty(Region_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B09_Region_Child> B09_Region_SingleObjectProperty = RegisterProperty<B09_Region_Child>(p => p.B09_Region_SingleObject, "B09 Region Single Object");
        /// <summary>
        /// Gets the B09 Region Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B09 Region Single Object.</value>
        public B09_Region_Child B09_Region_SingleObject
        {
            get { return GetProperty(B09_Region_SingleObjectProperty); }
            private set { LoadProperty(B09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B09_Region_ReChild> B09_Region_ASingleObjectProperty = RegisterProperty<B09_Region_ReChild>(p => p.B09_Region_ASingleObject, "B09 Region ASingle Object");
        /// <summary>
        /// Gets the B09 Region ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B09 Region ASingle Object.</value>
        public B09_Region_ReChild B09_Region_ASingleObject
        {
            get { return GetProperty(B09_Region_ASingleObjectProperty); }
            private set { LoadProperty(B09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B09_CityColl> B09_CityObjectsProperty = RegisterProperty<B09_CityColl>(p => p.B09_CityObjects, "B09 City Objects");
        /// <summary>
        /// Gets the B09 City Objects ("parent load" child property).
        /// </summary>
        /// <value>The B09 City Objects.</value>
        public B09_CityColl B09_CityObjects
        {
            get { return GetProperty(B09_CityObjectsProperty); }
            private set { LoadProperty(B09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B08_Region"/> object.</returns>
        internal static B08_Region GetB08_Region(SafeDataReader dr)
        {
            B08_Region obj = new B08_Region();
            obj.Fetch(dr);
            obj.LoadProperty(B09_CityObjectsProperty, new B09_CityColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public B08_Region()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Region_IDProperty, dr.GetInt32("Region_ID"));
            LoadProperty(Region_NameProperty, dr.GetString("Region_Name"));
            // parent properties
            parent_Country_ID = dr.GetInt32("Parent_Country_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B09_Region_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B09_Region_Child child)
        {
            LoadProperty(B09_Region_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B09_Region_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B09_Region_ReChild child)
        {
            LoadProperty(B09_Region_ASingleObjectProperty, child);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
