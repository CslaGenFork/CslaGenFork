using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C07Level1111ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="C07Level1111ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="C06Level111"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C07Level1111ReChild : ReadOnlyBase<C07Level1111ReChild>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_1_Child_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_1_Child_Name, "Level_1_1_1_1 Child Name");
        /// <summary>
        /// Gets the Level_1_1_1_1 Child Name.
        /// </summary>
        /// <value>The Level_1_1_1_1 Child Name.</value>
        public string Level_1_1_1_1_Child_Name
        {
            get { return GetProperty(Level_1_1_1_1_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="C07Level1111ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="cLarentID2">The CLarentID2 parameter of the C07Level1111ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C07Level1111ReChild"/> object.</returns>
        internal static C07Level1111ReChild GetC07Level1111ReChild(int cLarentID2)
        {
            return DataPortal.FetchChild<C07Level1111ReChild>(cLarentID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C07Level1111ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C07Level1111ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C07Level1111ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="cLarentID2">The CLarent ID2.</param>
        protected void Child_Fetch(int cLarentID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC07Level1111ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CLarentID2", cLarentID2).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, cLarentID2);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
                BusinessRules.CheckRules();
            }
        }

        /// <summary>
        /// Loads a <see cref="C07Level1111ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_1_Child_NameProperty, dr.GetString("Level_1_1_1_1_Child_Name"));
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
