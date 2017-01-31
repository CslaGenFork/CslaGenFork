using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B10_City (read only object).<br/>
    /// This is a generated base class of <see cref="B10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B11_CityRoadObjects"/> of type <see cref="B11_CityRoadColl"/> (1:M relation to <see cref="B12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="B09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B10_City : ReadOnlyBase<B10_City>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_Region_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="City_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> City_IDProperty = RegisterProperty<int>(p => p.City_ID, "City ID", -1);
        /// <summary>
        /// Gets the City ID.
        /// </summary>
        /// <value>The City ID.</value>
        public int City_ID
        {
            get { return GetProperty(City_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="City_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> City_NameProperty = RegisterProperty<string>(p => p.City_Name, "City Name");
        /// <summary>
        /// Gets the City Name.
        /// </summary>
        /// <value>The City Name.</value>
        public string City_Name
        {
            get { return GetProperty(City_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B11_City_Child> B11_City_SingleObjectProperty = RegisterProperty<B11_City_Child>(p => p.B11_City_SingleObject, "B11 City Single Object");
        /// <summary>
        /// Gets the B11 City Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B11 City Single Object.</value>
        public B11_City_Child B11_City_SingleObject
        {
            get { return GetProperty(B11_City_SingleObjectProperty); }
            private set { LoadProperty(B11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B11_City_ReChild> B11_City_ASingleObjectProperty = RegisterProperty<B11_City_ReChild>(p => p.B11_City_ASingleObject, "B11 City ASingle Object");
        /// <summary>
        /// Gets the B11 City ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B11 City ASingle Object.</value>
        public B11_City_ReChild B11_City_ASingleObject
        {
            get { return GetProperty(B11_City_ASingleObjectProperty); }
            private set { LoadProperty(B11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B11_CityRoadColl> B11_CityRoadObjectsProperty = RegisterProperty<B11_CityRoadColl>(p => p.B11_CityRoadObjects, "B11 CityRoad Objects");
        /// <summary>
        /// Gets the B11 City Road Objects ("parent load" child property).
        /// </summary>
        /// <value>The B11 City Road Objects.</value>
        public B11_CityRoadColl B11_CityRoadObjects
        {
            get { return GetProperty(B11_CityRoadObjectsProperty); }
            private set { LoadProperty(B11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B10_City"/> object.</returns>
        internal static B10_City GetB10_City(SafeDataReader dr)
        {
            B10_City obj = new B10_City();
            obj.Fetch(dr);
            obj.LoadProperty(B11_CityRoadObjectsProperty, new B11_CityRoadColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public B10_City()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(City_IDProperty, dr.GetInt32("City_ID"));
            LoadProperty(City_NameProperty, dr.GetString("City_Name"));
            // parent properties
            parent_Region_ID = dr.GetInt32("Parent_Region_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B11_City_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B11_City_Child child)
        {
            LoadProperty(B11_City_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B11_City_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B11_City_ReChild child)
        {
            LoadProperty(B11_City_ASingleObjectProperty, child);
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
