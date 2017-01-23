using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeList (read only list).<br/>
    /// This is a generated base class of <see cref="ProductTypeList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="ProductTypeInfo"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class ProductTypeList : ReadOnlyBindingListBase<ProductTypeList, ProductTypeInfo>
#else
    public partial class ProductTypeList : ReadOnlyListBase<ProductTypeList, ProductTypeInfo>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="ProductTypeInfo"/> item is in the collection.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        /// <returns><c>true</c> if the ProductTypeInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int productTypeId)
        {
            foreach (var productTypeInfo in this)
            {
                if (productTypeInfo.ProductTypeId == productTypeId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="ProductTypeList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="ProductTypeList"/> collection.</returns>
        public static ProductTypeList GetProductTypeList()
        {
            return DataPortal.Fetch<ProductTypeList>();
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductTypeList"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductTypeList(EventHandler<DataPortalResult<ProductTypeList>> callback)
        {
            DataPortal.BeginFetch<ProductTypeList>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeList()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="ProductTypeList"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InvoicesDatabase"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeList", ctx.Connection))
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
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="ProductTypeList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<ProductTypeInfo>(dr));
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
