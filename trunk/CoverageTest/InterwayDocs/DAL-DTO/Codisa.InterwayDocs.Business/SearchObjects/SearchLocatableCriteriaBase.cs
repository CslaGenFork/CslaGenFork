
namespace Codisa.InterwayDocs.Business.SearchObjects
{
    public abstract partial class SearchLocatableCriteriaBase<T> : SearchCriteriaBase<T>
        where T : SearchLocatableCriteriaBase<T>, IGenericCriteriaInformation, IHaveArchiveLocation
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
