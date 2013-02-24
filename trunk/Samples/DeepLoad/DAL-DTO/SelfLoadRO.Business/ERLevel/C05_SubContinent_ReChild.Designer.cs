using System;
using Csla;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERLevel;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C05_SubContinent_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="C05_SubContinent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="C04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C05_SubContinent_ReChild : ReadOnlyBase<C05_SubContinent_ReChild>
    {

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "Countries Child Name");
        /// <summary>
        /// Gets the Countries Child Name.
        /// </summary>
        /// <value>The Countries Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="C05_SubContinent_ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="subContinent_ID2">The SubContinent_ID2 parameter of the C05_SubContinent_ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C05_SubContinent_ReChild"/> object.</returns>
        internal static C05_SubContinent_ReChild GetC05_SubContinent_ReChild(int subContinent_ID2)
        {
            return DataPortal.FetchChild<C05_SubContinent_ReChild>(subContinent_ID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C05_SubContinent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C05_SubContinent_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C05_SubContinent_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="subContinent_ID2">The Sub Continent ID2.</param>
        protected void Child_Fetch(int subContinent_ID2)
        {
            var args = new DataPortalHookArgs(subContinent_ID2);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadRO.GetManager())
            {
                var dal = dalManager.GetProvider<IC05_SubContinent_ReChildDal>();
                var data = dal.Fetch(subContinent_ID2);
                Fetch(data);
            }
            OnFetchPost(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Loads a <see cref="C05_SubContinent_ReChild"/> object from the given <see cref="C05_SubContinent_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The C05_SubContinent_ReChildDto to use.</param>
        private void Fetch(C05_SubContinent_ReChildDto data)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, data.SubContinent_Child_Name);
            _rowVersion = data.RowVersion;
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
