using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// CustomerList (read only list).<br/>
    /// This is a generated <see cref="CustomerList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="CustomerInfo"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class CustomerList : ReadOnlyBindingListBase<CustomerList, CustomerInfo>
#else
    public partial class CustomerList : ReadOnlyListBase<CustomerList, CustomerInfo>
#endif
    {

        #region Event handler properties

        [NotUndoable]
        private static bool _singleInstanceSavedHandler = true;

        /// <summary>
        /// Gets or sets a value indicating whether only a single instance should handle the Saved event.
        /// </summary>
        /// <value>
        /// <c>true</c> if only a single instance should handle the Saved event; otherwise, <c>false</c>.
        /// </value>
        public static bool SingleInstanceSavedHandler
        {
            get { return _singleInstanceSavedHandler; }
            set { _singleInstanceSavedHandler = value; }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="CustomerList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="CustomerList"/> collection.</returns>
        public static CustomerList GetCustomerList()
        {
            return DataPortal.Fetch<CustomerList>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="CustomerList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="name">The Name parameter of the CustomerList to fetch.</param>
        /// <returns>A reference to the fetched <see cref="CustomerList"/> collection.</returns>
        public static CustomerList GetCustomerList(string name)
        {
            return DataPortal.Fetch<CustomerList>(name);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="CustomerList"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetCustomerList(EventHandler<DataPortalResult<CustomerList>> callback)
        {
            DataPortal.BeginFetch<CustomerList>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="CustomerList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="name">The Name parameter of the CustomerList to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetCustomerList(string name, EventHandler<DataPortalResult<CustomerList>> callback)
        {
            DataPortal.BeginFetch<CustomerList>(name, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CustomerList()
        {
            // Use factory methods and do not use direct creation.
            CustomerEditSaved.Register(this);

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Saved Event Handler

        /// <summary>
        /// Handle Saved events of <see cref="CustomerEdit"/> to update the list of <see cref="CustomerInfo"/> objects.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        internal void CustomerEditSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            var obj = (CustomerEdit)e.NewObject;
            if (((CustomerEdit)sender).IsNew)
            {
                IsReadOnly = false;
                var rlce = RaiseListChangedEvents;
                RaiseListChangedEvents = true;
                Add(CustomerInfo.LoadInfo(obj));
                RaiseListChangedEvents = rlce;
                IsReadOnly = true;
            }
            else if (((CustomerEdit)sender).IsDeleted)
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.CustomerId == obj.CustomerId)
                    {
                        IsReadOnly = false;
                        var rlce = RaiseListChangedEvents;
                        RaiseListChangedEvents = true;
                        this.RemoveItem(index);
                        RaiseListChangedEvents = rlce;
                        IsReadOnly = true;
                        break;
                    }
                }
            }
            else
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.CustomerId == obj.CustomerId)
                    {
                        child.UpdatePropertiesOnSaved(obj);
#if !WINFORMS
                        var notifyCollectionChangedEventArgs =
                            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, child, child, index);
                        OnCollectionChanged(notifyCollectionChangedEventArgs);
#else
                        var listChangedEventArgs = new ListChangedEventArgs(ListChangedType.ItemChanged, index);
                        OnListChanged(listChangedEventArgs);
#endif
                        break;
                    }
                }
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="CustomerList"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                GetQueryGetCustomerList();
                using (var cmd = new SqlCommand(getCustomerListInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="CustomerList"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="name">The Name.</param>
        protected void DataPortal_Fetch(string name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                GetQueryGetCustomerList(name);
                using (var cmd = new SqlCommand(getCustomerListInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", name).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd, name);
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
        /// Loads all <see cref="CustomerList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<CustomerInfo>(dr));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion

        #region Inline queries fields and partial methods

        [NotUndoable, NonSerialized]
        private string getCustomerListInlineQuery;

        partial void GetQueryGetCustomerList();

        partial void GetQueryGetCustomerList(string name);

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

        #region CustomerEditSaved nested class

        // TODO: edit "CustomerList.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     CustomerEditSaved.Register(this);

        /// <summary>
        /// Nested class to manage the Saved events of <see cref="CustomerEdit"/>
        /// to update the list of <see cref="CustomerInfo"/> objects.
        /// </summary>
        private static class CustomerEditSaved
        {
            private static List<WeakReference> _references;

            private static bool Found(object obj)
            {
                return _references.Any(reference => Equals(reference.Target, obj));
            }

            /// <summary>
            /// Registers a CustomerList instance to handle Saved events.
            /// to update the list of <see cref="CustomerInfo"/> objects.
            /// </summary>
            /// <param name="obj">The CustomerList instance.</param>
            public static void Register(CustomerList obj)
            {
                var mustRegister = _references == null;

                if (mustRegister)
                    _references = new List<WeakReference>();

                if (CustomerList.SingleInstanceSavedHandler)
                    _references.Clear();

                if (!Found(obj))
                    _references.Add(new WeakReference(obj));

                if (mustRegister)
                    CustomerEdit.CustomerEditSaved += CustomerEditSavedHandler;
            }

            /// <summary>
            /// Handles Saved events of <see cref="CustomerEdit"/>.
            /// </summary>
            /// <param name="sender">The sender of the event.</param>
            /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            public static void CustomerEditSavedHandler(object sender, Csla.Core.SavedEventArgs e)
            {
                foreach (var reference in _references)
                {
                    if (reference.IsAlive)
                        ((CustomerList) reference.Target).CustomerEditSavedHandler(sender, e);
                }
            }

            /// <summary>
            /// Removes event handling and clears all registered CustomerList instances.
            /// </summary>
            public static void Unregister()
            {
                CustomerEdit.CustomerEditSaved -= CustomerEditSavedHandler;
                _references = null;
            }
        }

        #endregion

    }
}
