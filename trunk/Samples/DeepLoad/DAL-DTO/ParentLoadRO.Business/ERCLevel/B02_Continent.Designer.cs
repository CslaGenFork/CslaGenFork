using System;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B02_Continent (read only object).<br/>
    /// This is a generated base class of <see cref="B02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B03_SubContinentObjects"/> of type <see cref="B03_SubContinentColl"/> (1:M relation to <see cref="B04_SubContinent"/>)<br/>
    /// This class is an item of <see cref="B01_ContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B02_Continent : ReadOnlyBase<B02_Continent>
    {

        #region ParentList Property

        /// <summary>
        /// Maintains metadata about <see cref="ParentList"/> property.
        /// </summary>
        [NotUndoable]
        [NonSerialized]
        public static readonly PropertyInfo<B01_ContinentColl> ParentListProperty = RegisterProperty<B01_ContinentColl>(p => p.ParentList);
        /// <summary>
        /// Provide access to the parent list reference for use in child object code.
        /// </summary>
        /// <value>The parent list reference.</value>
        public B01_ContinentColl ParentList
        {
            get { return ReadProperty(ParentListProperty); }
            internal set { LoadProperty(ParentListProperty, value); }
        }

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Continent_IDProperty = RegisterProperty<int>(p => p.Continent_ID, "Continent ID", -1);
        /// <summary>
        /// Gets the Continent ID.
        /// </summary>
        /// <value>The Continent ID.</value>
        public int Continent_ID
        {
            get { return GetProperty(Continent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_NameProperty = RegisterProperty<string>(p => p.Continent_Name, "Continent Name");
        /// <summary>
        /// Gets the Continent Name.
        /// </summary>
        /// <value>The Continent Name.</value>
        public string Continent_Name
        {
            get { return GetProperty(Continent_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B03_Continent_Child> B03_Continent_SingleObjectProperty = RegisterProperty<B03_Continent_Child>(p => p.B03_Continent_SingleObject, "B03 Continent Single Object");
        /// <summary>
        /// Gets the B03 Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B03 Continent Single Object.</value>
        public B03_Continent_Child B03_Continent_SingleObject
        {
            get { return GetProperty(B03_Continent_SingleObjectProperty); }
            private set { LoadProperty(B03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B03_Continent_ReChild> B03_Continent_ASingleObjectProperty = RegisterProperty<B03_Continent_ReChild>(p => p.B03_Continent_ASingleObject, "B03 Continent ASingle Object");
        /// <summary>
        /// Gets the B03 Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B03 Continent ASingle Object.</value>
        public B03_Continent_ReChild B03_Continent_ASingleObject
        {
            get { return GetProperty(B03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(B03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B03_SubContinentColl> B03_SubContinentObjectsProperty = RegisterProperty<B03_SubContinentColl>(p => p.B03_SubContinentObjects, "B03 SubContinent Objects");
        /// <summary>
        /// Gets the B03 Sub Continent Objects ("parent load" child property).
        /// </summary>
        /// <value>The B03 Sub Continent Objects.</value>
        public B03_SubContinentColl B03_SubContinentObjects
        {
            get { return GetProperty(B03_SubContinentObjectsProperty); }
            private set { LoadProperty(B03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B02_Continent"/> object from the given B02_ContinentDto.
        /// </summary>
        /// <param name="data">The <see cref="B02_ContinentDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B02_Continent"/> object.</returns>
        internal static B02_Continent GetB02_Continent(B02_ContinentDto data)
        {
            B02_Continent obj = new B02_Continent();
            obj.Fetch(data);
            obj.LoadProperty(B03_SubContinentObjectsProperty, new B03_SubContinentColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public B02_Continent()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B02_Continent"/> object from the given <see cref="B02_ContinentDto"/>.
        /// </summary>
        /// <param name="data">The B02_ContinentDto to use.</param>
        private void Fetch(B02_ContinentDto data)
        {
            // Value properties
            LoadProperty(Continent_IDProperty, data.Continent_ID);
            LoadProperty(Continent_NameProperty, data.Continent_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects from the given DAL provider.
        /// </summary>
        /// <param name="dal">The DAL provider to use.</param>
        internal void FetchChildren(IB01_ContinentCollDal dal)
        {
            foreach (var item in dal.B03_Continent_Child)
            {
                var child = B03_Continent_Child.GetB03_Continent_Child(item);
                var obj = ParentList.FindB02_ContinentByParentProperties(child.continent_ID1);
                obj.LoadProperty(B03_Continent_SingleObjectProperty, child);
            }
            foreach (var item in dal.B03_Continent_ReChild)
            {
                var child = B03_Continent_ReChild.GetB03_Continent_ReChild(item);
                var obj = ParentList.FindB02_ContinentByParentProperties(child.continent_ID2);
                obj.LoadProperty(B03_Continent_ASingleObjectProperty, child);
            }
            var b03_SubContinentColl = B03_SubContinentColl.GetB03_SubContinentColl(dal.B03_SubContinentColl);
            b03_SubContinentColl.LoadItems(ParentList);
            foreach (var item in dal.B05_SubContinent_Child)
            {
                var child = B05_SubContinent_Child.GetB05_SubContinent_Child(item);
                var obj = b03_SubContinentColl.FindB04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.B05_SubContinent_ReChild)
            {
                var child = B05_SubContinent_ReChild.GetB05_SubContinent_ReChild(item);
                var obj = b03_SubContinentColl.FindB04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            var b05_CountryColl = B05_CountryColl.GetB05_CountryColl(dal.B05_CountryColl);
            b05_CountryColl.LoadItems(b03_SubContinentColl);
            foreach (var item in dal.B07_Country_Child)
            {
                var child = B07_Country_Child.GetB07_Country_Child(item);
                var obj = b05_CountryColl.FindB06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.B07_Country_ReChild)
            {
                var child = B07_Country_ReChild.GetB07_Country_ReChild(item);
                var obj = b05_CountryColl.FindB06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            var b07_RegionColl = B07_RegionColl.GetB07_RegionColl(dal.B07_RegionColl);
            b07_RegionColl.LoadItems(b05_CountryColl);
            foreach (var item in dal.B09_Region_Child)
            {
                var child = B09_Region_Child.GetB09_Region_Child(item);
                var obj = b07_RegionColl.FindB08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.B09_Region_ReChild)
            {
                var child = B09_Region_ReChild.GetB09_Region_ReChild(item);
                var obj = b07_RegionColl.FindB08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            var b09_CityColl = B09_CityColl.GetB09_CityColl(dal.B09_CityColl);
            b09_CityColl.LoadItems(b07_RegionColl);
            foreach (var item in dal.B11_City_Child)
            {
                var child = B11_City_Child.GetB11_City_Child(item);
                var obj = b09_CityColl.FindB10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.B11_City_ReChild)
            {
                var child = B11_City_ReChild.GetB11_City_ReChild(item);
                var obj = b09_CityColl.FindB10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            var b11_CityRoadColl = B11_CityRoadColl.GetB11_CityRoadColl(dal.B11_CityRoadColl);
            b11_CityRoadColl.LoadItems(b09_CityColl);
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
