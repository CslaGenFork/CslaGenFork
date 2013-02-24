using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G09_Region_Child (read only object).<br/>
    /// This is a generated base class of <see cref="G09_Region_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="G08_Region"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G09_Region_Child : ReadOnlyBase<G09_Region_Child>
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
        /// Factory method. Loads a <see cref="G09_Region_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="region_ID1">The Region_ID1 parameter of the G09_Region_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G09_Region_Child"/> object.</returns>
        internal static G09_Region_Child GetG09_Region_Child(int region_ID1)
        {
            return DataPortal.FetchChild<G09_Region_Child>(region_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G09_Region_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G09_Region_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G09_Region_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="region_ID1">The Region ID1.</param>
        protected void Child_Fetch(int region_ID1)
        {
            var args = new DataPortalHookArgs(region_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG09_Region_ChildDal>();
                var data = dal.Fetch(region_ID1);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        private void Fetch(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="G09_Region_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Region_Child_NameProperty, dr.GetString("Region_Child_Name"));
            var args = new DataPortalHookArgs(dr);
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
