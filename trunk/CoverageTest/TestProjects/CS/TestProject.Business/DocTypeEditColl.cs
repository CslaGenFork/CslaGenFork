using System;
using Csla;

namespace TestProject.Business
{
    public partial class DocTypeEditColl
    {

        #region OnDeserialized actions

        /// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            Saved += OnDocTypeEditCollSaved;
            // add your custom OnDeserialized actions here.
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
