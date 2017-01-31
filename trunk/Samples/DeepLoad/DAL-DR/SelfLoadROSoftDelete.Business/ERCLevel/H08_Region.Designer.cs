using System;
using System.Data;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H08_Region (read only object).<br/>
    /// This is a generated base class of <see cref="H08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H09_CityObjects"/> of type <see cref="H09_CityColl"/> (1:M relation to <see cref="H10_City"/>)<br/>
    /// This class is an item of <see cref="H07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H08_Region : ReadOnlyBase<H08_Region>
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
        /// Maintains metadata about child <see cref="H09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H09_Region_Child> H09_Region_SingleObjectProperty = RegisterProperty<H09_Region_Child>(p => p.H09_Region_SingleObject, "H09 Region Single Object");
        /// <summary>
        /// Gets the H09 Region Single Object ("self load" child property).
        /// </summary>
        /// <value>The H09 Region Single Object.</value>
        public H09_Region_Child H09_Region_SingleObject
        {
            get { return GetProperty(H09_Region_SingleObjectProperty); }
            private set { LoadProperty(H09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H09_Region_ReChild> H09_Region_ASingleObjectProperty = RegisterProperty<H09_Region_ReChild>(p => p.H09_Region_ASingleObject, "H09 Region ASingle Object");
        /// <summary>
        /// Gets the H09 Region ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H09 Region ASingle Object.</value>
        public H09_Region_ReChild H09_Region_ASingleObject
        {
            get { return GetProperty(H09_Region_ASingleObjectProperty); }
            private set { LoadProperty(H09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H09_CityColl> H09_CityObjectsProperty = RegisterProperty<H09_CityColl>(p => p.H09_CityObjects, "H09 City Objects");
        /// <summary>
        /// Gets the H09 City Objects ("self load" child property).
        /// </summary>
        /// <value>The H09 City Objects.</value>
        public H09_CityColl H09_CityObjects
        {
            get { return GetProperty(H09_CityObjectsProperty); }
            private set { LoadProperty(H09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H08_Region"/> object.</returns>
        internal static H08_Region GetH08_Region(SafeDataReader dr)
        {
            H08_Region obj = new H08_Region();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public H08_Region()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H08_Region"/> object from the given SafeDataReader.
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
            LoadProperty(H09_Region_SingleObjectProperty, H09_Region_Child.GetH09_Region_Child(Region_ID));
            LoadProperty(H09_Region_ASingleObjectProperty, H09_Region_ReChild.GetH09_Region_ReChild(Region_ID));
            LoadProperty(H09_CityObjectsProperty, H09_CityColl.GetH09_CityColl(Region_ID));
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
