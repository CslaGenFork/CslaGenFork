using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A10_City (read only object).<br/>
    /// This is a generated base class of <see cref="A10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="A11_CityRoadObjects"/> of type <see cref="A11_CityRoadColl"/> (1:M relation to <see cref="A12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="A09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A10_City : ReadOnlyBase<A10_City>
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
        /// Maintains metadata about child <see cref="A11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A11_City_Child> A11_City_SingleObjectProperty = RegisterProperty<A11_City_Child>(p => p.A11_City_SingleObject, "A11 City Single Object");
        /// <summary>
        /// Gets the A11 City Single Object ("parent load" child property).
        /// </summary>
        /// <value>The A11 City Single Object.</value>
        public A11_City_Child A11_City_SingleObject
        {
            get { return GetProperty(A11_City_SingleObjectProperty); }
            private set { LoadProperty(A11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A11_City_ReChild> A11_City_ASingleObjectProperty = RegisterProperty<A11_City_ReChild>(p => p.A11_City_ASingleObject, "A11 City ASingle Object");
        /// <summary>
        /// Gets the A11 City ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The A11 City ASingle Object.</value>
        public A11_City_ReChild A11_City_ASingleObject
        {
            get { return GetProperty(A11_City_ASingleObjectProperty); }
            private set { LoadProperty(A11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<A11_CityRoadColl> A11_CityRoadObjectsProperty = RegisterProperty<A11_CityRoadColl>(p => p.A11_CityRoadObjects, "A11 CityRoad Objects");
        /// <summary>
        /// Gets the A11 City Road Objects ("parent load" child property).
        /// </summary>
        /// <value>The A11 City Road Objects.</value>
        public A11_CityRoadColl A11_CityRoadObjects
        {
            get { return GetProperty(A11_CityRoadObjectsProperty); }
            private set { LoadProperty(A11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A10_City"/> object.</returns>
        internal static A10_City GetA10_City(SafeDataReader dr)
        {
            A10_City obj = new A10_City();
            obj.Fetch(dr);
            obj.LoadProperty(A11_CityRoadObjectsProperty, new A11_CityRoadColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A10_City()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A10_City"/> object from the given SafeDataReader.
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
        /// Loads child <see cref="A11_City_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A11_City_Child child)
        {
            LoadProperty(A11_City_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="A11_City_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A11_City_ReChild child)
        {
            LoadProperty(A11_City_ASingleObjectProperty, child);
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
