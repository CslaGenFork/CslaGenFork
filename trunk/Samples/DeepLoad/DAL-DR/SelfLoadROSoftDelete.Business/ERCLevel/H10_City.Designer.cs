using System;
using System.Data;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H10_City (read only object).<br/>
    /// This is a generated base class of <see cref="H10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H11_CityRoadObjects"/> of type <see cref="H11_CityRoadColl"/> (1:M relation to <see cref="H12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="H09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H10_City : ReadOnlyBase<H10_City>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="City_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> City_IDProperty = RegisterProperty<int>(p => p.City_ID, "Cities ID", -1);
        /// <summary>
        /// Gets the Cities ID.
        /// </summary>
        /// <value>The Cities ID.</value>
        public int City_ID
        {
            get { return GetProperty(City_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="City_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> City_NameProperty = RegisterProperty<string>(p => p.City_Name, "Cities Name");
        /// <summary>
        /// Gets the Cities Name.
        /// </summary>
        /// <value>The Cities Name.</value>
        public string City_Name
        {
            get { return GetProperty(City_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H11_City_Child> H11_City_SingleObjectProperty = RegisterProperty<H11_City_Child>(p => p.H11_City_SingleObject, "H11 City Single Object");
        /// <summary>
        /// Gets the H11 City Single Object ("self load" child property).
        /// </summary>
        /// <value>The H11 City Single Object.</value>
        public H11_City_Child H11_City_SingleObject
        {
            get { return GetProperty(H11_City_SingleObjectProperty); }
            private set { LoadProperty(H11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H11_City_ReChild> H11_City_ASingleObjectProperty = RegisterProperty<H11_City_ReChild>(p => p.H11_City_ASingleObject, "H11 City ASingle Object");
        /// <summary>
        /// Gets the H11 City ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H11 City ASingle Object.</value>
        public H11_City_ReChild H11_City_ASingleObject
        {
            get { return GetProperty(H11_City_ASingleObjectProperty); }
            private set { LoadProperty(H11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H11_CityRoadColl> H11_CityRoadObjectsProperty = RegisterProperty<H11_CityRoadColl>(p => p.H11_CityRoadObjects, "H11 CityRoad Objects");
        /// <summary>
        /// Gets the H11 City Road Objects ("self load" child property).
        /// </summary>
        /// <value>The H11 City Road Objects.</value>
        public H11_CityRoadColl H11_CityRoadObjects
        {
            get { return GetProperty(H11_CityRoadObjectsProperty); }
            private set { LoadProperty(H11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H10_City"/> object.</returns>
        internal static H10_City GetH10_City(SafeDataReader dr)
        {
            H10_City obj = new H10_City();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H10_City()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(City_IDProperty, dr.GetInt32("City_ID"));
            LoadProperty(City_NameProperty, dr.GetString("City_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(H11_City_SingleObjectProperty, H11_City_Child.GetH11_City_Child(City_ID));
            LoadProperty(H11_City_ASingleObjectProperty, H11_City_ReChild.GetH11_City_ReChild(City_ID));
            LoadProperty(H11_CityRoadObjectsProperty, H11_CityRoadColl.GetH11_CityRoadColl(City_ID));
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
