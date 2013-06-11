
namespace SelfLoad.Business.ERCLevel
{
    public partial class D04_SubContinent
    {

        #region OnDeserialized actions

        /*/// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        /// <param name="context">Serialization context object.</param>
        protected override void OnDeserialized(System.Runtime.Serialization.StreamingContext context)
        {
            base.OnDeserialized(context);
            // add your custom OnDeserialized actions here.
        }*/

        #endregion

        #region ChildChanged Event Handler

        /*/// <summary>
        /// Raises the ChildChanged event, indicating that a child object has been changed.
        /// </summary>
        /// <param name="e">ChildChangedEventArgs object.</param>
        protected override void OnChildChanged(Csla.Core.ChildChangedEventArgs e)
        {
            base.OnChildChanged(e);

            // uncomment the lines for child with properties relevant to business rules
            //PropertyHasChanged(D05_SubContinent_SingleObjectProperty);
            //PropertyHasChanged(D05_SubContinent_ASingleObjectProperty);
            //PropertyHasChanged(D05_CountryObjectsProperty);
            // uncomment if there is an object level business rule (introduced in Csla 4.2.0)
            //CheckObjectRules();
        }*/

        #endregion

        #region Pseudo Event Handlers

        //partial void OnCreate(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        //partial void OnDeletePre(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        //partial void OnDeletePost(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        //partial void OnFetchPre(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        //partial void OnFetchPost(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        //partial void OnFetchRead(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        //partial void OnUpdatePre(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        //partial void OnUpdatePost(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        //partial void OnInsertPre(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        //partial void OnInsertPost(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        #endregion

    }
}
