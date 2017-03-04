using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// InvoiceLineCollection (editable child list).<br/>
    /// This is a generated base class of <see cref="InvoiceLineCollection"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="InvoiceEdit"/> editable root object.<br/>
    /// The items of the collection are <see cref="InvoiceLineItem"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class InvoiceLineCollection : BusinessBindingListBase<InvoiceLineCollection, InvoiceLineItem>
#else
    public partial class InvoiceLineCollection : BusinessListBase<InvoiceLineCollection, InvoiceLineItem>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="InvoiceLineItem"/> item from the collection.
        /// </summary>
        /// <param name="invoiceLineId">The InvoiceLineId of the item to be removed.</param>
        public void Remove(Guid invoiceLineId)
        {
            foreach (var invoiceLineItem in this)
            {
                if (invoiceLineItem.InvoiceLineId == invoiceLineId)
                {
                    Remove(invoiceLineItem);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="InvoiceLineItem"/> item is in the collection.
        /// </summary>
        /// <param name="invoiceLineId">The InvoiceLineId of the item to search for.</param>
        /// <returns><c>true</c> if the InvoiceLineItem is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(Guid invoiceLineId)
        {
            foreach (var invoiceLineItem in this)
            {
                if (invoiceLineItem.InvoiceLineId == invoiceLineId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="InvoiceLineItem"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="invoiceLineId">The InvoiceLineId of the item to search for.</param>
        /// <returns><c>true</c> if the InvoiceLineItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(Guid invoiceLineId)
        {
            foreach (var invoiceLineItem in DeletedList)
            {
                if (invoiceLineItem.InvoiceLineId == invoiceLineId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceLineCollection"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public InvoiceLineCollection()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();

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
        /// Loads all <see cref="InvoiceLineCollection"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<InvoiceLineItem>(dr));
            }
            OnFetchPost(args);
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
