using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G10_City (read only object).<br/>
    /// This is a generated base class of <see cref="G10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="G11_CityRoadObjects"/> of type <see cref="G11_CityRoadColl"/> (1:M relation to <see cref="G12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="G09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G10_City : ReadOnlyBase<G10_City>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="City_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> City_IDProperty = RegisterProperty<int>(p => p.City_ID, "5_Cities ID", -1);
        /// <summary>
        /// Gets the 5_Cities ID.
        /// </summary>
        /// <value>The 5_Cities ID.</value>
        public int City_ID
        {
            get { return GetProperty(City_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="City_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> City_NameProperty = RegisterProperty<string>(p => p.City_Name, "5_Cities Name");
        /// <summary>
        /// Gets the 5_Cities Name.
        /// </summary>
        /// <value>The 5_Cities Name.</value>
        public string City_Name
        {
            get { return GetProperty(City_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G11_City_Child> G11_City_SingleObjectProperty = RegisterProperty<G11_City_Child>(p => p.G11_City_SingleObject, "G11 City Single Object");
        /// <summary>
        /// Gets the G11 City Single Object ("self load" child property).
        /// </summary>
        /// <value>The G11 City Single Object.</value>
        public G11_City_Child G11_City_SingleObject
        {
            get { return GetProperty(G11_City_SingleObjectProperty); }
            private set { LoadProperty(G11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G11_City_ReChild> G11_City_ASingleObjectProperty = RegisterProperty<G11_City_ReChild>(p => p.G11_City_ASingleObject, "G11 City ASingle Object");
        /// <summary>
        /// Gets the G11 City ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The G11 City ASingle Object.</value>
        public G11_City_ReChild G11_City_ASingleObject
        {
            get { return GetProperty(G11_City_ASingleObjectProperty); }
            private set { LoadProperty(G11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<G11_CityRoadColl> G11_CityRoadObjectsProperty = RegisterProperty<G11_CityRoadColl>(p => p.G11_CityRoadObjects, "G11 CityRoad Objects");
        /// <summary>
        /// Gets the G11 City Road Objects ("self load" child property).
        /// </summary>
        /// <value>The G11 City Road Objects.</value>
        public G11_CityRoadColl G11_CityRoadObjects
        {
            get { return GetProperty(G11_CityRoadObjectsProperty); }
            private set { LoadProperty(G11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="G10_City"/> object.</returns>
        internal static G10_City GetG10_City(SafeDataReader dr)
        {
            G10_City obj = new G10_City();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G10_City()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G10_City"/> object from the given SafeDataReader.
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
            LoadProperty(G11_City_SingleObjectProperty, G11_City_Child.GetG11_City_Child(City_ID));
            LoadProperty(G11_City_ASingleObjectProperty, G11_City_ReChild.GetG11_City_ReChild(City_ID));
            LoadProperty(G11_CityRoadObjectsProperty, G11_CityRoadColl.GetG11_CityRoadColl(City_ID));
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
