using System;
using Csla;
using SelfLoadRO.DataAccess.ERLevel;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C10_City (read only object).<br/>
    /// This is a generated base class of <see cref="C10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C11_CityRoadObjects"/> of type <see cref="C11_CityRoadColl"/> (1:M relation to <see cref="C12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="C09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C10_City : ReadOnlyBase<C10_City>
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
        /// Maintains metadata about child <see cref="C11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C11_City_Child> C11_City_SingleObjectProperty = RegisterProperty<C11_City_Child>(p => p.C11_City_SingleObject, "C11 City Single Object");
        /// <summary>
        /// Gets the C11 City Single Object ("self load" child property).
        /// </summary>
        /// <value>The C11 City Single Object.</value>
        public C11_City_Child C11_City_SingleObject
        {
            get { return GetProperty(C11_City_SingleObjectProperty); }
            private set { LoadProperty(C11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C11_City_ReChild> C11_City_ASingleObjectProperty = RegisterProperty<C11_City_ReChild>(p => p.C11_City_ASingleObject, "C11 City ASingle Object");
        /// <summary>
        /// Gets the C11 City ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C11 City ASingle Object.</value>
        public C11_City_ReChild C11_City_ASingleObject
        {
            get { return GetProperty(C11_City_ASingleObjectProperty); }
            private set { LoadProperty(C11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C11_CityRoadColl> C11_CityRoadObjectsProperty = RegisterProperty<C11_CityRoadColl>(p => p.C11_CityRoadObjects, "C11 CityRoad Objects");
        /// <summary>
        /// Gets the C11 City Road Objects ("self load" child property).
        /// </summary>
        /// <value>The C11 City Road Objects.</value>
        public C11_CityRoadColl C11_CityRoadObjects
        {
            get { return GetProperty(C11_CityRoadObjectsProperty); }
            private set { LoadProperty(C11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="C10_City"/> object from the given C10_CityDto.
        /// </summary>
        /// <param name="data">The <see cref="C10_CityDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="C10_City"/> object.</returns>
        internal static C10_City GetC10_City(C10_CityDto data)
        {
            C10_City obj = new C10_City();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C10_City()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C10_City"/> object from the given <see cref="C10_CityDto"/>.
        /// </summary>
        /// <param name="data">The C10_CityDto to use.</param>
        private void Fetch(C10_CityDto data)
        {
            // Value properties
            LoadProperty(City_IDProperty, data.City_ID);
            LoadProperty(City_NameProperty, data.City_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(C11_City_SingleObjectProperty, C11_City_Child.GetC11_City_Child(City_ID));
            LoadProperty(C11_City_ASingleObjectProperty, C11_City_ReChild.GetC11_City_ReChild(City_ID));
            LoadProperty(C11_CityRoadObjectsProperty, C11_CityRoadColl.GetC11_CityRoadColl(City_ID));
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
