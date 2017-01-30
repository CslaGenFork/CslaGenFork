using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D08_Region (read only object).<br/>
    /// This is a generated base class of <see cref="D08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D09_CityObjects"/> of type <see cref="D09_CityColl"/> (1:M relation to <see cref="D10_City"/>)<br/>
    /// This class is an item of <see cref="D07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D08_Region : ReadOnlyBase<D08_Region>
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
        /// Maintains metadata about child <see cref="D09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D09_Region_Child> D09_Region_SingleObjectProperty = RegisterProperty<D09_Region_Child>(p => p.D09_Region_SingleObject, "D09 Region Single Object");
        /// <summary>
        /// Gets the D09 Region Single Object ("self load" child property).
        /// </summary>
        /// <value>The D09 Region Single Object.</value>
        public D09_Region_Child D09_Region_SingleObject
        {
            get { return GetProperty(D09_Region_SingleObjectProperty); }
            private set { LoadProperty(D09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D09_Region_ReChild> D09_Region_ASingleObjectProperty = RegisterProperty<D09_Region_ReChild>(p => p.D09_Region_ASingleObject, "D09 Region ASingle Object");
        /// <summary>
        /// Gets the D09 Region ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D09 Region ASingle Object.</value>
        public D09_Region_ReChild D09_Region_ASingleObject
        {
            get { return GetProperty(D09_Region_ASingleObjectProperty); }
            private set { LoadProperty(D09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D09_CityColl> D09_CityObjectsProperty = RegisterProperty<D09_CityColl>(p => p.D09_CityObjects, "D09 City Objects");
        /// <summary>
        /// Gets the D09 City Objects ("self load" child property).
        /// </summary>
        /// <value>The D09 City Objects.</value>
        public D09_CityColl D09_CityObjects
        {
            get { return GetProperty(D09_CityObjectsProperty); }
            private set { LoadProperty(D09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D08_Region"/> object.</returns>
        internal static D08_Region GetD08_Region(SafeDataReader dr)
        {
            D08_Region obj = new D08_Region();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public D08_Region()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D08_Region"/> object from the given SafeDataReader.
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
            LoadProperty(D09_Region_SingleObjectProperty, D09_Region_Child.GetD09_Region_Child(Region_ID));
            LoadProperty(D09_Region_ASingleObjectProperty, D09_Region_ReChild.GetD09_Region_ReChild(Region_ID));
            LoadProperty(D09_CityObjectsProperty, D09_CityColl.GetD09_CityColl(Region_ID));
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
