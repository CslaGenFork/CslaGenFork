using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeNVL (name value list).<br/>
    /// This is a generated base class of <see cref="ProductTypeNVL"/> business object.
    /// </summary>
    [Serializable]
    public partial class ProductTypeNVL : NameValueListBase<int, string>
    {

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="ProductTypeNVL"/> object.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="ProductTypeNVL"/> object.</returns>
        public static ProductTypeNVL GetProductTypeNVL()
        {
            return DataPortal.Fetch<ProductTypeNVL>();
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductTypeNVL"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductTypeNVL(EventHandler<DataPortalResult<ProductTypeNVL>> callback)
        {
            DataPortal.BeginFetch<ProductTypeNVL>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeNVL"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeNVL()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="ProductTypeNVL"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InvoicesDatabase"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeNVL", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                while (dr.Read())
                {
                    Add(new NameValuePair(
                        dr.GetInt32("ProductTypeId"),
                        dr.GetString("Description")));
                }
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
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

        #endregion

    }
}
