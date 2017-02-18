using System;
using Csla;

namespace Invoices.Business
{
    public partial class SupplierList
    {

        #region OnDeserialized actions

        /// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            SupplierEditSaved.Register(this);
            // add your custom OnDeserialized actions here.
        }

        #endregion

        #region Inline queries

        //partial void GetQueryGetSupplierList()
        //{
        //    getSupplierListInlineQuery = "";
        //}

        //partial void GetQueryGetSupplierListByName(string name)
        //{
        //    getSupplierListByNameInlineQuery = "";
        //}

        #endregion

        #region Implementation of DataPortal Hooks

        //partial void OnFetchPre(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnFetchPost(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

    }
}
