using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F10_City (read only object).<br/>
    /// This is a generated base class of <see cref="F10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="F11_CityRoadObjects"/> of type <see cref="F11_CityRoadColl"/> (1:M relation to <see cref="F12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="F09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F10_City : ReadOnlyBase<F10_City>
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
        /// Maintains metadata about child <see cref="F11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F11_City_Child> F11_City_SingleObjectProperty = RegisterProperty<F11_City_Child>(p => p.F11_City_SingleObject, "F11 City Single Object");
        /// <summary>
        /// Gets the F11 City Single Object ("parent load" child property).
        /// </summary>
        /// <value>The F11 City Single Object.</value>
        public F11_City_Child F11_City_SingleObject
        {
            get { return GetProperty(F11_City_SingleObjectProperty); }
            private set { LoadProperty(F11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F11_City_ReChild> F11_City_ASingleObjectProperty = RegisterProperty<F11_City_ReChild>(p => p.F11_City_ASingleObject, "F11 City ASingle Object");
        /// <summary>
        /// Gets the F11 City ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The F11 City ASingle Object.</value>
        public F11_City_ReChild F11_City_ASingleObject
        {
            get { return GetProperty(F11_City_ASingleObjectProperty); }
            private set { LoadProperty(F11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<F11_CityRoadColl> F11_CityRoadObjectsProperty = RegisterProperty<F11_CityRoadColl>(p => p.F11_CityRoadObjects, "F11 CityRoad Objects");
        /// <summary>
        /// Gets the F11 City Road Objects ("parent load" child property).
        /// </summary>
        /// <value>The F11 City Road Objects.</value>
        public F11_CityRoadColl F11_CityRoadObjects
        {
            get { return GetProperty(F11_CityRoadObjectsProperty); }
            private set { LoadProperty(F11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F10_City"/> object from the given F10_CityDto.
        /// </summary>
        /// <param name="data">The <see cref="F10_CityDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="F10_City"/> object.</returns>
        internal static F10_City GetF10_City(F10_CityDto data)
        {
            F10_City obj = new F10_City();
            obj.Fetch(data);
            obj.LoadProperty(F11_CityRoadObjectsProperty, new F11_CityRoadColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F10_City()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F10_City"/> object from the given <see cref="F10_CityDto"/>.
        /// </summary>
        /// <param name="data">The F10_CityDto to use.</param>
        private void Fetch(F10_CityDto data)
        {
            // Value properties
            LoadProperty(City_IDProperty, data.City_ID);
            LoadProperty(City_NameProperty, data.City_Name);
            // parent properties
            parent_Region_ID = data.Parent_Region_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="F11_City_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F11_City_Child child)
        {
            LoadProperty(F11_City_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="F11_City_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F11_City_ReChild child)
        {
            LoadProperty(F11_City_ASingleObjectProperty, child);
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
