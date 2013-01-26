using System;
using Csla;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G08_Region (read only object).<br/>
    /// This is a generated base class of <see cref="G08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="G09_CityObjects"/> of type <see cref="G09_CityColl"/> (1:M relation to <see cref="G10_City"/>)<br/>
    /// This class is an item of <see cref="G07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G08_Region : ReadOnlyBase<G08_Region>
    {

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
        /// Maintains metadata about child <see cref="G09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G09_Region_Child> G09_Region_SingleObjectProperty = RegisterProperty<G09_Region_Child>(p => p.G09_Region_SingleObject, "G09 Region Single Object");
        /// <summary>
        /// Gets the G09 Region Single Object ("self load" child property).
        /// </summary>
        /// <value>The G09 Region Single Object.</value>
        public G09_Region_Child G09_Region_SingleObject
        {
            get { return GetProperty(G09_Region_SingleObjectProperty); }
            private set { LoadProperty(G09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G09_Region_ReChild> G09_Region_ASingleObjectProperty = RegisterProperty<G09_Region_ReChild>(p => p.G09_Region_ASingleObject, "G09 Region ASingle Object");
        /// <summary>
        /// Gets the G09 Region ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The G09 Region ASingle Object.</value>
        public G09_Region_ReChild G09_Region_ASingleObject
        {
            get { return GetProperty(G09_Region_ASingleObjectProperty); }
            private set { LoadProperty(G09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<G09_CityColl> G09_CityObjectsProperty = RegisterProperty<G09_CityColl>(p => p.G09_CityObjects, "G09 City Objects");
        /// <summary>
        /// Gets the G09 City Objects ("self load" child property).
        /// </summary>
        /// <value>The G09 City Objects.</value>
        public G09_CityColl G09_CityObjects
        {
            get { return GetProperty(G09_CityObjectsProperty); }
            private set { LoadProperty(G09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G08_Region"/> object from the given G08_RegionDto.
        /// </summary>
        /// <param name="data">The <see cref="G08_RegionDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="G08_Region"/> object.</returns>
        internal static G08_Region GetG08_Region(G08_RegionDto data)
        {
            G08_Region obj = new G08_Region();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G08_Region()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G08_Region"/> object from the given <see cref="G08_RegionDto"/>.
        /// </summary>
        /// <param name="data">The G08_RegionDto to use.</param>
        private void Fetch(G08_RegionDto data)
        {
            // Value properties
            LoadProperty(Region_IDProperty, data.Region_ID);
            LoadProperty(Region_NameProperty, data.Region_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(G09_Region_SingleObjectProperty, G09_Region_Child.GetG09_Region_Child(Region_ID));
            LoadProperty(G09_Region_ASingleObjectProperty, G09_Region_ReChild.GetG09_Region_ReChild(Region_ID));
            LoadProperty(G09_CityObjectsProperty, G09_CityColl.GetG09_CityColl(Region_ID));
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
