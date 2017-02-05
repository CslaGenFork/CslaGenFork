using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeCachedNVL (name value list).<br/>
    /// This is a generated base class of <see cref="ProductTypeCachedNVL"/> business object.
    /// </summary>
    [Serializable]
    public partial class ProductTypeCachedNVL : NameValueListBase<int, string>
    {

        #region Private Fields

        private static ProductTypeCachedNVL _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory ProductTypeCachedNVL cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(ProductTypeCachedNVL list)
        {
            _list = list;
        }

        internal static bool IsCached
        {
            get { return _list != null; }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="ProductTypeCachedNVL"/> object.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="ProductTypeCachedNVL"/> object.</returns>
        public static ProductTypeCachedNVL GetProductTypeCachedNVL()
        {
            if (_list == null)
                _list = DataPortal.Fetch<ProductTypeCachedNVL>();

            return _list;
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductTypeCachedNVL"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductTypeCachedNVL(EventHandler<DataPortalResult<ProductTypeCachedNVL>> callback)
        {
            if (_list == null)
                DataPortal.BeginFetch<ProductTypeCachedNVL>((o, e) =>
                    {
                        _list = e.Object;
                        callback(o, e);
                    });
            else
                callback(null, new DataPortalResult<ProductTypeCachedNVL>(_list, null, null));
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeCachedNVL"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeCachedNVL()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="ProductTypeCachedNVL"/> collection from the database or from the cache.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InvoicesDatabase"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeCachedNVL", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            _list = this;
        }

        private void LoadCachedList()
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AddRange(_list);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
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
                        dr.GetString("Name")));
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
