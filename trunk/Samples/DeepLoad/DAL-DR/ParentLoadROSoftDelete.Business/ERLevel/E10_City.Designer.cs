using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E10_City (read only object).<br/>
    /// This is a generated base class of <see cref="E10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E11_CityRoadObjects"/> of type <see cref="E11_CityRoadColl"/> (1:M relation to <see cref="E12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="E09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E10_City : ReadOnlyBase<E10_City>
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
        /// Maintains metadata about child <see cref="E11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E11_City_Child> E11_City_SingleObjectProperty = RegisterProperty<E11_City_Child>(p => p.E11_City_SingleObject, "E11 City Single Object");
        /// <summary>
        /// Gets the E11 City Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E11 City Single Object.</value>
        public E11_City_Child E11_City_SingleObject
        {
            get { return GetProperty(E11_City_SingleObjectProperty); }
            private set { LoadProperty(E11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E11_City_ReChild> E11_City_ASingleObjectProperty = RegisterProperty<E11_City_ReChild>(p => p.E11_City_ASingleObject, "E11 City ASingle Object");
        /// <summary>
        /// Gets the E11 City ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E11 City ASingle Object.</value>
        public E11_City_ReChild E11_City_ASingleObject
        {
            get { return GetProperty(E11_City_ASingleObjectProperty); }
            private set { LoadProperty(E11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E11_CityRoadColl> E11_CityRoadObjectsProperty = RegisterProperty<E11_CityRoadColl>(p => p.E11_CityRoadObjects, "E11 CityRoad Objects");
        /// <summary>
        /// Gets the E11 City Road Objects ("parent load" child property).
        /// </summary>
        /// <value>The E11 City Road Objects.</value>
        public E11_CityRoadColl E11_CityRoadObjects
        {
            get { return GetProperty(E11_CityRoadObjectsProperty); }
            private set { LoadProperty(E11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E10_City"/> object.</returns>
        internal static E10_City GetE10_City(SafeDataReader dr)
        {
            E10_City obj = new E10_City();
            obj.Fetch(dr);
            obj.LoadProperty(E11_CityRoadObjectsProperty, new E11_CityRoadColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E10_City()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E10_City"/> object from the given SafeDataReader.
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
        /// Loads child <see cref="E11_City_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E11_City_Child child)
        {
            LoadProperty(E11_City_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="E11_City_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E11_City_ReChild child)
        {
            LoadProperty(E11_City_ASingleObjectProperty, child);
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
