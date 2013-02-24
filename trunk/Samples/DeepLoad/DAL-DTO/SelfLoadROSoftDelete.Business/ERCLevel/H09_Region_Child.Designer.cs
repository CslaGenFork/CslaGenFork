using System;
using Csla;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H09_Region_Child (read only object).<br/>
    /// This is a generated base class of <see cref="H09_Region_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="H08_Region"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H09_Region_Child : ReadOnlyBase<H09_Region_Child>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_Child_NameProperty = RegisterProperty<string>(p => p.Region_Child_Name, "Cities Child Name");
        /// <summary>
        /// Gets the Cities Child Name.
        /// </summary>
        /// <value>The Cities Child Name.</value>
        public string Region_Child_Name
        {
            get { return GetProperty(Region_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H09_Region_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="region_ID1">The Region_ID1 parameter of the H09_Region_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="H09_Region_Child"/> object.</returns>
        internal static H09_Region_Child GetH09_Region_Child(int region_ID1)
        {
            return DataPortal.FetchChild<H09_Region_Child>(region_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H09_Region_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H09_Region_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H09_Region_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="region_ID1">The Region ID1.</param>
        protected void Child_Fetch(int region_ID1)
        {
            var args = new DataPortalHookArgs(region_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IH09_Region_ChildDal>();
                var data = dal.Fetch(region_ID1);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        /// <summary>
        /// Loads a <see cref="H09_Region_Child"/> object from the given <see cref="H09_Region_ChildDto"/>.
        /// </summary>
        /// <param name="data">The H09_Region_ChildDto to use.</param>
        private void Fetch(H09_Region_ChildDto data)
        {
            // Value properties
            LoadProperty(Region_Child_NameProperty, data.Region_Child_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
