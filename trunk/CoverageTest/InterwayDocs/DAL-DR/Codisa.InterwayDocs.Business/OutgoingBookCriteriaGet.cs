using System;
using Csla;
using Codisa.InterwayDocs.Business.SearchObjects;

namespace Codisa.InterwayDocs.Business
{
    public partial class OutgoingBookCriteriaGet
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

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OutgoingBookCriteriaGet"/> class.
        /// </summary>
        /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public OutgoingBookCriteriaGet()
        {
            var dateTypeList = CriteriaDateTypeList.GetCriteriaDateTypeList(true);
            LoadProperty(DateTypeListProperty, dateTypeList);
            LoadProperty(SelectedDateTypeIndexProperty, 0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutgoingBookCriteriaGet"/> class.
        /// </summary>
        /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public OutgoingBookCriteriaGet(SmartDate criteriaStartDate, SmartDate criteriaEndDate, string archiveLocation, string fullText)
        {
            var dateTypeList = CriteriaDateTypeList.GetCriteriaDateTypeList(true);
            LoadProperty(DateTypeListProperty, dateTypeList);
            LoadProperty(SelectedDateTypeIndexProperty, 0);
        }

        #endregion

    }
}
