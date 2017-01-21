using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using UsingClass;

namespace TestProject.Business
{

    /// <summary>
    /// DocTypeDynamicCollection (dynamic root list).<br/>
    /// This is a generated base class of <see cref="DocTypeDynamicCollection"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="DocTypeDynamic"/> objects.
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class DocTypeDynamicCollection : DynamicBindingListBase<DocTypeDynamic>, IHaveInterface
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="DocTypeDynamic"/> item is in the collection.
        /// </summary>
        /// <param name="docTypeID">The DocTypeID of the item to search for.</param>
        /// <returns><c>true</c> if the DocTypeDynamic is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int docTypeID)
        {
            foreach (var docTypeDynamic in this)
            {
                if (docTypeDynamic.DocTypeID == docTypeID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocTypeDynamicCollection"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocTypeDynamicCollection"/> collection.</returns>
        public static DocTypeDynamicCollection NewDocTypeDynamicCollection()
        {
            return DataPortal.Create<DocTypeDynamicCollection>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocTypeDynamicCollection"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="DocTypeDynamicCollection"/> collection.</returns>
        public static DocTypeDynamicCollection GetDocTypeDynamicCollection()
        {
            return DataPortal.Fetch<DocTypeDynamicCollection>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocTypeDynamicCollection"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocTypeDynamicCollection()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocTypeDynamicCollection"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("GetDocTypeDynamicCollection", ctx.Connection))
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
        /// Loads all <see cref="DocTypeDynamicCollection"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.Fetch<DocTypeDynamic>(dr));
            }
            RaiseListChangedEvents = rlce;
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
