
namespace Codisa.InterwayDocs.Business
{
    public abstract partial class EditOnDemandBase<T> : BusinessBase<T>
        where T : EditOnDemandBase<T>
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
