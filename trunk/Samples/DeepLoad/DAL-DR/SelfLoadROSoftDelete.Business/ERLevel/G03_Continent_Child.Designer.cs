using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G03_Continent_Child (read only object).<br/>
    /// This is a generated base class of <see cref="G03_Continent_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="G02_Continent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G03_Continent_Child : ReadOnlyBase<G03_Continent_Child>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_Child_NameProperty = RegisterProperty<string>(p => p.Continent_Child_Name, "SubContinents Child Name");
        /// <summary>
        /// Gets the SubContinents Child Name.
        /// </summary>
        /// <value>The SubContinents Child Name.</value>
        public string Continent_Child_Name
        {
            get { return GetProperty(Continent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G03_Continent_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID1">The Continent_ID1 parameter of the G03_Continent_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G03_Continent_Child"/> object.</returns>
        internal static G03_Continent_Child GetG03_Continent_Child(int continent_ID1)
        {
            return DataPortal.FetchChild<G03_Continent_Child>(continent_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G03_Continent_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G03_Continent_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G03_Continent_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID1">The Continent ID1.</param>
        protected void Child_Fetch(int continent_ID1)
        {
            var args = new DataPortalHookArgs(continent_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG03_Continent_ChildDal>();
                var data = dal.Fetch(continent_ID1);
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
        /// Loads a <see cref="G03_Continent_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Continent_Child_NameProperty, dr.GetString("Continent_Child_Name"));
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
