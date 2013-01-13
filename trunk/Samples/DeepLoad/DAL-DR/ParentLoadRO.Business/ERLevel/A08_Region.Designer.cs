using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A08_Region (read only object).<br/>
    /// This is a generated base class of <see cref="A08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="A09_CityObjects"/> of type <see cref="A09_CityColl"/> (1:M relation to <see cref="A10_City"/>)<br/>
    /// This class is an item of <see cref="A07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A08_Region : ReadOnlyBase<A08_Region>
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
        /// Maintains metadata about child <see cref="A09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A09_Region_Child> A09_Region_SingleObjectProperty = RegisterProperty<A09_Region_Child>(p => p.A09_Region_SingleObject, "A09 Region Single Object");
        /// <summary>
        /// Gets the A09 Region Single Object ("parent load" child property).
        /// </summary>
        /// <value>The A09 Region Single Object.</value>
        public A09_Region_Child A09_Region_SingleObject
        {
            get { return GetProperty(A09_Region_SingleObjectProperty); }
            private set { LoadProperty(A09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A09_Region_ReChild> A09_Region_ASingleObjectProperty = RegisterProperty<A09_Region_ReChild>(p => p.A09_Region_ASingleObject, "A09 Region ASingle Object");
        /// <summary>
        /// Gets the A09 Region ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The A09 Region ASingle Object.</value>
        public A09_Region_ReChild A09_Region_ASingleObject
        {
            get { return GetProperty(A09_Region_ASingleObjectProperty); }
            private set { LoadProperty(A09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<A09_CityColl> A09_CityObjectsProperty = RegisterProperty<A09_CityColl>(p => p.A09_CityObjects, "A09 City Objects");
        /// <summary>
        /// Gets the A09 City Objects ("parent load" child property).
        /// </summary>
        /// <value>The A09 City Objects.</value>
        public A09_CityColl A09_CityObjects
        {
            get { return GetProperty(A09_CityObjectsProperty); }
            private set { LoadProperty(A09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A08_Region"/> object.</returns>
        internal static A08_Region GetA08_Region(SafeDataReader dr)
        {
            A08_Region obj = new A08_Region();
            obj.Fetch(dr);
            obj.LoadProperty(A09_CityObjectsProperty, new A09_CityColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A08_Region()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A08_Region"/> object from the given SafeDataReader.
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
        /// Loads child <see cref="A09_Region_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A09_Region_Child child)
        {
            LoadProperty(A09_Region_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="A09_Region_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A09_Region_ReChild child)
        {
            LoadProperty(A09_Region_ASingleObjectProperty, child);
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
