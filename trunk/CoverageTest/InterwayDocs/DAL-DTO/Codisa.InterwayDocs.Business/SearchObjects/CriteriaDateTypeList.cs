using System;
using Codisa.InterwayDocs.Business.Properties;
using Csla;

namespace Codisa.InterwayDocs.Business.SearchObjects
{

    /// <summary>
    /// CriteriaDateTypeList (read only list).<br/>
    /// This is a generated base class of <see cref="CriteriaDateTypeList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="CriteriaDateTypeInfo"/> objects.
    /// </remarks>
    [Serializable]
    public class CriteriaDateTypeList : ReadOnlyBindingListBase<CriteriaDateTypeList, CriteriaDateTypeInfo>
    {

        #region Collection Business Methods

        /// <summary>
        /// Gets the description of a <see cref="CriteriaDateTypeInfo"/> item is in the collection, given the DateTypeName.
        /// </summary>
        /// <param name="dateTypeName">The DateTypeName of the item to search for.</param>
        /// <returns><c>DateTypeDescription</c> if the CriteriaDateTypeInfo is a collection item; otherwise, <c>DateTypeName</c>.</returns>
        public string GetDescription(string dateTypeName)
        {
            foreach (var criteriaDateTypeInfo in this)
            {
                if (criteriaDateTypeInfo.DateTypeName == dateTypeName)
                {
                    return criteriaDateTypeInfo.DateTypeDescription;
                }
            }
            return dateTypeName;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="CriteriaDateTypeList"/> collection.
        /// </summary>
        /// <param name="useSendDate">if set to <c>true</c> use SendDate.</param>
        /// <returns>A reference to the fetched <see cref="CriteriaDateTypeList"/> collection.</returns>
        public static CriteriaDateTypeList GetCriteriaDateTypeList(bool useSendDate)
        {
            return DataPortal.Fetch<CriteriaDateTypeList>(useSendDate);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CriteriaDateTypeList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CriteriaDateTypeList()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="CriteriaDateTypeList" /> collection from the database.
        /// </summary>
        /// <param name="useSendDate">if set to <c>true</c> use SendDate.</param>
        protected void DataPortal_Fetch(bool useSendDate)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            AddNameValuePair("RegisterDate", Resources.RegisterDate);
            AddNameValuePair("DocumentDate", Resources.DocumentDate);

            if (useSendDate)
                AddNameValuePair("SendDate", Resources.SendDate);
            else
                AddNameValuePair("ReceptionDate", Resources.ReceptionDate);

            AddNameValuePair("CreateDate", Resources.CreateDate);
            AddNameValuePair("ChangeDate", Resources.ChangeDate);
            AddNameValuePair("AllDates", Resources.AllDates);

            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        private void AddNameValuePair(string dateTypeName, string dateTypeDescription)
        {
            Add(CriteriaDateTypeInfo.GetCriteriaDateTypeInfo(dateTypeName, dateTypeDescription));
        }

        #endregion

    }
}