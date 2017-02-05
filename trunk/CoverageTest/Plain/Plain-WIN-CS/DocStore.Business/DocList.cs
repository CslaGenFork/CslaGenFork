//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocList
// ObjectType:  DocList
// CSLAType:    ReadOnlyCollection

using System;
using Csla;
using DocStore.Business.Util;

namespace DocStore.Business
{
    public partial class DocList
    {

        #region OnDeserialized actions

        /// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            DocSaved.Register(this);
            // add your custom OnDeserialized actions here.
        }

        #endregion

        #region Inlines queries

        private string GetDocListInlineQuery()
        {
            return "";
        }

        private string GetDocListInlineQuery(DocListFilteredCriteria crit)
        {
            return "";
        }

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