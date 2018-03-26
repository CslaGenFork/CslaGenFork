using System;
using Csla;
using Codisa.InterwayDocs.Rules;

namespace Codisa.InterwayDocs.Business.SearchObjects
{
    public abstract partial class SearchCriteriaBase<T> : BusinessBase<T>
        where T : SearchCriteriaBase<T>, IGenericCriteriaInformation
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

        #region Business Properties

        /// <summary>
        /// Gets or sets the Start Date Criteria.
        /// </summary>
        /// <value>The Start Date Criteria.</value>
        public SmartDate CriteriaStartDate
        {
            get { return GetProperty(StartDateProperty); }
            set { SetProperty(StartDateProperty, value); }
        }

                /// <summary>
        /// Gets or sets the End Date Criteria.
        /// </summary>
        /// <value>The End Date Criteria.</value>
        public SmartDate CriteriaEndDate
        {
            get { return GetProperty(EndDateProperty); }
            set { SetProperty(EndDateProperty, value); }
        }

        /// <summary>
        /// Gets or sets the selected date type name.
        /// </summary>
        /// <value>The selected date type name.</value>
        public string SelectedDateTypeName
        {
            get { return GetNameOfDateType(); }
            set { SeIndexOftDateType(value); }
        }

        #endregion

        #region DataType name helpers

        private string GetNameOfDateType()
        {
            var result = string.Empty;
            var index = 0;
            foreach (var dateType in DateTypeList)
            {
                if (index == SelectedDateTypeIndex)
                {
                    result = dateType.DateTypeName;
                    break;
                }

                index++;
            }

            return result;
        }

        private void SeIndexOftDateType(string name)
        {
            var index = 0;
            foreach (var dateType in DateTypeList)
            {
                if (name == dateType.DateTypeName)
                {
                    SelectedDateTypeIndex = index;
                    break;
                }

                index++;
            }
        }

        #endregion

        #region Common criteria methods

        /// <summary>
        /// Gets the common criteria.
        /// </summary>
        /// <param name="fastDateOptions">The fast date options class to use.</param>
        /// <param name="commonBookCriteria">The common book criteria.</param>
        public void GetCommonCriteria(FastDateOptions fastDateOptions, CommonBookCriteria commonBookCriteria)
        {
            SelectedDateTypeIndex = commonBookCriteria.SelectedDateTypeIndex;
            SelectedFastDateIndex = commonBookCriteria.SelectedFastDateIndex;

            if (SelectedFastDateIndex == fastDateOptions.GetIndex("FreeSearch"))
            {
                if (!string.IsNullOrEmpty(commonBookCriteria.StartDate))
                    StartDate = commonBookCriteria.StartDate;

                if (!string.IsNullOrEmpty(commonBookCriteria.EndDate))
                    EndDate = commonBookCriteria.EndDate;
            }

            if (!string.IsNullOrEmpty(commonBookCriteria.FullText))
                FullText = commonBookCriteria.FullText;

            var iHaveArchiveLocation = this as IHaveArchiveLocation;
            if (iHaveArchiveLocation != null && !string.IsNullOrEmpty(commonBookCriteria.ArchiveLocation))
                iHaveArchiveLocation.ArchiveLocation = commonBookCriteria.ArchiveLocation;
        }

        /// <summary>
        /// Stores the common criteria.
        /// </summary>
        /// <param name="commonBookCriteria">The common book criteria.</param>
        public void StoreCommonCriteria(CommonBookCriteria commonBookCriteria)
        {
            commonBookCriteria.SelectedFastDateIndex = SelectedFastDateIndex;
            commonBookCriteria.SelectedDateTypeIndex = SelectedDateTypeIndex;
            commonBookCriteria.StartDate = ReadProperty(StartDateProperty);
            commonBookCriteria.EndDate = ReadProperty(EndDateProperty);
            commonBookCriteria.FullText = FullText;

            var iHaveArchiveLocation = this as IHaveArchiveLocation;
            if (iHaveArchiveLocation != null)
                commonBookCriteria.ArchiveLocation = iHaveArchiveLocation.ArchiveLocation;
        }

        #endregion
    }
}
