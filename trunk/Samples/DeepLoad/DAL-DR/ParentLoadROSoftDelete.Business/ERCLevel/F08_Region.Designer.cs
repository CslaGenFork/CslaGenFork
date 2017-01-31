using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F08_Region (read only object).<br/>
    /// This is a generated base class of <see cref="F08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="F09_CityObjects"/> of type <see cref="F09_CityColl"/> (1:M relation to <see cref="F10_City"/>)<br/>
    /// This class is an item of <see cref="F07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F08_Region : ReadOnlyBase<F08_Region>
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
        public static readonly PropertyInfo<int> Region_IDProperty = RegisterProperty<int>(p => p.Region_ID, "Regions ID", -1);
        /// <summary>
        /// Gets the Regions ID.
        /// </summary>
        /// <value>The Regions ID.</value>
        public int Region_ID
        {
            get { return GetProperty(Region_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Region_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_NameProperty = RegisterProperty<string>(p => p.Region_Name, "Regions Name");
        /// <summary>
        /// Gets the Regions Name.
        /// </summary>
        /// <value>The Regions Name.</value>
        public string Region_Name
        {
            get { return GetProperty(Region_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F09_Region_Child> F09_Region_SingleObjectProperty = RegisterProperty<F09_Region_Child>(p => p.F09_Region_SingleObject, "F09 Region Single Object");
        /// <summary>
        /// Gets the F09 Region Single Object ("parent load" child property).
        /// </summary>
        /// <value>The F09 Region Single Object.</value>
        public F09_Region_Child F09_Region_SingleObject
        {
            get { return GetProperty(F09_Region_SingleObjectProperty); }
            private set { LoadProperty(F09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F09_Region_ReChild> F09_Region_ASingleObjectProperty = RegisterProperty<F09_Region_ReChild>(p => p.F09_Region_ASingleObject, "F09 Region ASingle Object");
        /// <summary>
        /// Gets the F09 Region ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The F09 Region ASingle Object.</value>
        public F09_Region_ReChild F09_Region_ASingleObject
        {
            get { return GetProperty(F09_Region_ASingleObjectProperty); }
            private set { LoadProperty(F09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<F09_CityColl> F09_CityObjectsProperty = RegisterProperty<F09_CityColl>(p => p.F09_CityObjects, "F09 City Objects");
        /// <summary>
        /// Gets the F09 City Objects ("parent load" child property).
        /// </summary>
        /// <value>The F09 City Objects.</value>
        public F09_CityColl F09_CityObjects
        {
            get { return GetProperty(F09_CityObjectsProperty); }
            private set { LoadProperty(F09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F08_Region"/> object.</returns>
        internal static F08_Region GetF08_Region(SafeDataReader dr)
        {
            F08_Region obj = new F08_Region();
            obj.Fetch(dr);
            obj.LoadProperty(F09_CityObjectsProperty, new F09_CityColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public F08_Region()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F08_Region"/> object from the given SafeDataReader.
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
        /// Loads child <see cref="F09_Region_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F09_Region_Child child)
        {
            LoadProperty(F09_Region_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="F09_Region_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F09_Region_ReChild child)
        {
            LoadProperty(F09_Region_ASingleObjectProperty, child);
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
