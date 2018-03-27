using System;
using Csla;
using UsingLibrary;

namespace TestProject.Business
{
    public abstract partial class MyBusinessListBase<T, C> : BusinessListBase<T, C>, IHaveInterface
        where T : MyBusinessListBase<T, C>, IHaveInterface
        where C : BusinessBase<C>
    {

        #region OnDeserialized actions

        /*/// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            // add your custom OnDeserialized actions here.
        }*/

        #endregion

    }
}
