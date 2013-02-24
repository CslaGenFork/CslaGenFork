using System;
using System.Data;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C08_Region (read only object).<br/>
    /// This is a generated base class of <see cref="C08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C09_CityObjects"/> of type <see cref="C09_CityColl"/> (1:M relation to <see cref="C10_City"/>)<br/>
    /// This class is an item of <see cref="C07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C08_Region : ReadOnlyBase<C08_Region>
    {

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
        /// Maintains metadata about child <see cref="C09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C09_Region_Child> C09_Region_SingleObjectProperty = RegisterProperty<C09_Region_Child>(p => p.C09_Region_SingleObject, "C09 Region Single Object");
        /// <summary>
        /// Gets the C09 Region Single Object ("self load" child property).
        /// </summary>
        /// <value>The C09 Region Single Object.</value>
        public C09_Region_Child C09_Region_SingleObject
        {
            get { return GetProperty(C09_Region_SingleObjectProperty); }
            private set { LoadProperty(C09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C09_Region_ReChild> C09_Region_ASingleObjectProperty = RegisterProperty<C09_Region_ReChild>(p => p.C09_Region_ASingleObject, "C09 Region ASingle Object");
        /// <summary>
        /// Gets the C09 Region ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C09 Region ASingle Object.</value>
        public C09_Region_ReChild C09_Region_ASingleObject
        {
            get { return GetProperty(C09_Region_ASingleObjectProperty); }
            private set { LoadProperty(C09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C09_CityColl> C09_CityObjectsProperty = RegisterProperty<C09_CityColl>(p => p.C09_CityObjects, "C09 City Objects");
        /// <summary>
        /// Gets the C09 City Objects ("self load" child property).
        /// </summary>
        /// <value>The C09 City Objects.</value>
        public C09_CityColl C09_CityObjects
        {
            get { return GetProperty(C09_CityObjectsProperty); }
            private set { LoadProperty(C09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="C08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="C08_Region"/> object.</returns>
        internal static C08_Region GetC08_Region(SafeDataReader dr)
        {
            C08_Region obj = new C08_Region();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C08_Region()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Region_IDProperty, dr.GetInt32("Region_ID"));
            LoadProperty(Region_NameProperty, dr.GetString("Region_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(C09_Region_SingleObjectProperty, C09_Region_Child.GetC09_Region_Child(Region_ID));
            LoadProperty(C09_Region_ASingleObjectProperty, C09_Region_ReChild.GetC09_Region_ReChild(Region_ID));
            LoadProperty(C09_CityObjectsProperty, C09_CityColl.GetC09_CityColl(Region_ID));
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
