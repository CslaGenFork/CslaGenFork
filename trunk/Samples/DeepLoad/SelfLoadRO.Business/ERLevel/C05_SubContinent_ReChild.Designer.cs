using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

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
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C05_SubContinent_ReChild()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C05_SubContinent_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="subContinent_ID2">The Sub Continent ID2.</param>
        protected void Child_Fetch(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, subContinent_ID2);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="C05_SubContinent_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, dr.GetString("SubContinent_Child_Name"));
            _rowVersion = dr.GetValue("RowVersion") as byte[];
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

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
