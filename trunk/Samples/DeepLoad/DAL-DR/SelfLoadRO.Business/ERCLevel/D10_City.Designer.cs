using System;
using System.Data;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D10_City (read only object).<br/>
    /// This is a generated base class of <see cref="D10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D11_CityRoadObjects"/> of type <see cref="D11_CityRoadColl"/> (1:M relation to <see cref="D12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="D09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D10_City : ReadOnlyBase<D10_City>
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
        /// Maintains metadata about child <see cref="D11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D11_City_Child> D11_City_SingleObjectProperty = RegisterProperty<D11_City_Child>(p => p.D11_City_SingleObject, "D11 City Single Object");
        /// <summary>
        /// Gets the D11 City Single Object ("self load" child property).
        /// </summary>
        /// <value>The D11 City Single Object.</value>
        public D11_City_Child D11_City_SingleObject
        {
            get { return GetProperty(D11_City_SingleObjectProperty); }
            private set { LoadProperty(D11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D11_City_ReChild> D11_City_ASingleObjectProperty = RegisterProperty<D11_City_ReChild>(p => p.D11_City_ASingleObject, "D11 City ASingle Object");
        /// <summary>
        /// Gets the D11 City ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D11 City ASingle Object.</value>
        public D11_City_ReChild D11_City_ASingleObject
        {
            get { return GetProperty(D11_City_ASingleObjectProperty); }
            private set { LoadProperty(D11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D11_CityRoadColl> D11_CityRoadObjectsProperty = RegisterProperty<D11_CityRoadColl>(p => p.D11_CityRoadObjects, "D11 CityRoad Objects");
        /// <summary>
        /// Gets the D11 City Road Objects ("self load" child property).
        /// </summary>
        /// <value>The D11 City Road Objects.</value>
        public D11_CityRoadColl D11_CityRoadObjects
        {
            get { return GetProperty(D11_CityRoadObjectsProperty); }
            private set { LoadProperty(D11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D10_City"/> object.</returns>
        internal static D10_City GetD10_City(SafeDataReader dr)
        {
            D10_City obj = new D10_City();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D10_City()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D10_City"/> object from the given SafeDataReader.
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
            LoadProperty(D11_City_SingleObjectProperty, D11_City_Child.GetD11_City_Child(City_ID));
            LoadProperty(D11_City_ASingleObjectProperty, D11_City_ReChild.GetD11_City_ReChild(City_ID));
            LoadProperty(D11_CityRoadObjectsProperty, D11_CityRoadColl.GetD11_CityRoadColl(City_ID));
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
