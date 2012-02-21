using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E08_Region (read only object).<br/>
    /// This is a generated base class of <see cref="E08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E09_CityObjects"/> of type <see cref="E09_CityColl"/> (1:M relation to <see cref="E10_City"/>)<br/>
    /// This class is an item of <see cref="E07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E08_Region : ReadOnlyBase<E08_Region>
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
        public static readonly PropertyInfo<int> Region_IDProperty = RegisterProperty<int>(p => p.Region_ID, "4_Regions ID", -1);
        /// <summary>
        /// Gets the 4_Regions ID.
        /// </summary>
        /// <value>The 4_Regions ID.</value>
        public int Region_ID
        {
            get { return GetProperty(Region_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Region_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_NameProperty = RegisterProperty<string>(p => p.Region_Name, "4_Regions Name");
        /// <summary>
        /// Gets the 4_Regions Name.
        /// </summary>
        /// <value>The 4_Regions Name.</value>
        public string Region_Name
        {
            get { return GetProperty(Region_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E09_Region_Child> E09_Region_SingleObjectProperty = RegisterProperty<E09_Region_Child>(p => p.E09_Region_SingleObject, "E09 Region Single Object");
        /// <summary>
        /// Gets the E09 Region Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E09 Region Single Object.</value>
        public E09_Region_Child E09_Region_SingleObject
        {
            get { return GetProperty(E09_Region_SingleObjectProperty); }
            private set { LoadProperty(E09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E09_Region_ReChild> E09_Region_ASingleObjectProperty = RegisterProperty<E09_Region_ReChild>(p => p.E09_Region_ASingleObject, "E09 Region ASingle Object");
        /// <summary>
        /// Gets the E09 Region ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E09 Region ASingle Object.</value>
        public E09_Region_ReChild E09_Region_ASingleObject
        {
            get { return GetProperty(E09_Region_ASingleObjectProperty); }
            private set { LoadProperty(E09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E09_CityColl> E09_CityObjectsProperty = RegisterProperty<E09_CityColl>(p => p.E09_CityObjects, "E09 City Objects");
        /// <summary>
        /// Gets the E09 City Objects ("parent load" child property).
        /// </summary>
        /// <value>The E09 City Objects.</value>
        public E09_CityColl E09_CityObjects
        {
            get { return GetProperty(E09_CityObjectsProperty); }
            private set { LoadProperty(E09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E08_Region"/> object.</returns>
        internal static E08_Region GetE08_Region(SafeDataReader dr)
        {
            E08_Region obj = new E08_Region();
            obj.Fetch(dr);
            obj.LoadProperty(E09_CityObjectsProperty, new E09_CityColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E08_Region()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Region_IDProperty, dr.GetInt32("Region_ID"));
            LoadProperty(Region_NameProperty, dr.GetString("Region_Name"));
            parent_Country_ID = dr.GetInt32("Parent_Country_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="E09_Region_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E09_Region_Child child)
        {
            LoadProperty(E09_Region_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="E09_Region_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E09_Region_ReChild child)
        {
            LoadProperty(E09_Region_ASingleObjectProperty, child);
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
