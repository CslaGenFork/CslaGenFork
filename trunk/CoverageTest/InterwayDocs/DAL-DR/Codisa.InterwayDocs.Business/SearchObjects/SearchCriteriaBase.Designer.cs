using System;
using System.Data;
using Csla;
using Csla.Data;
using Codisa.InterwayDocs.Business.Properties;
using Codisa.InterwayDocs.Rules;
using Codisa.InterwayDocs.DataAccess;

namespace Codisa.InterwayDocs.Business.SearchObjects
{

    /// <summary>
    /// Common search criteria (base class).<br/>
    /// This is a generated <see cref="SearchCriteriaBase{T}"/> base classe.
    /// </summary>
    [Serializable]
    public abstract partial class SearchCriteriaBase<T> : BusinessBase<T>
        where T : SearchCriteriaBase<T>, IGenericCriteriaInformation
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="StartDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> StartDateProperty = RegisterProperty<SmartDate>(p => p.StartDate, "Start Date");
        /// <summary>
        /// Gets or sets the Start Date.
        /// </summary>
        /// <value>The Start Date.</value>
        public string StartDate
        {
            get { return GetPropertyConvert<SmartDate, string>(StartDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(StartDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="EndDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> EndDateProperty = RegisterProperty<SmartDate>(p => p.EndDate, "End Date");
        /// <summary>
        /// Gets or sets the End Date.
        /// </summary>
        /// <value>The End Date.</value>
        public string EndDate
        {
            get { return GetPropertyConvert<SmartDate, string>(EndDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(EndDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FullText"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FullTextProperty = RegisterProperty<string>(p => p.FullText, "Full Text");
        /// <summary>
        /// Gets or sets the Full Text.
        /// </summary>
        /// <value>The Full Text.</value>
        public string FullText
        {
            get { return GetProperty(FullTextProperty); }
            set { SetProperty(FullTextProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DateTypeList"/> property.
        /// </summary>
        public static readonly PropertyInfo<CriteriaDateTypeList> DateTypeListProperty = RegisterProperty<CriteriaDateTypeList>(p => p.DateTypeList, "Date Type List");
        /// <summary>
        /// Gets or sets the Date Type List.
        /// </summary>
        /// <value>The Date Type List.</value>
        public CriteriaDateTypeList DateTypeList
        {
            get { return GetProperty(DateTypeListProperty); }
            set { SetProperty(DateTypeListProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SelectedDateTypeIndex"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SelectedDateTypeIndexProperty = RegisterProperty<int>(p => p.SelectedDateTypeIndex, "Selected Date Type Index");
        /// <summary>
        /// Gets or sets the Selected Date Type Index.
        /// </summary>
        /// <value>The Selected Date Type Index.</value>
        public int SelectedDateTypeIndex
        {
            get { return GetProperty(SelectedDateTypeIndexProperty); }
            set { SetProperty(SelectedDateTypeIndexProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SelectedFastDateIndex"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SelectedFastDateIndexProperty = RegisterProperty<int>(p => p.SelectedFastDateIndex, "Selected Fast Date Index", -1);
        /// <summary>
        /// Gets or sets the Selected Fast Date Index.
        /// </summary>
        /// <value>The Selected Fast Date Index.</value>
        public int SelectedFastDateIndex
        {
            get { return GetProperty(SelectedFastDateIndexProperty); }
            set { SetProperty(SelectedFastDateIndexProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCriteriaBase{T}"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SearchCriteriaBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Business Rules and Property Authorization

        /// <summary>
        /// Override this method in your business class to be notified when you need to set up shared business rules.
        /// </summary>
        /// <remarks>
        /// This method is automatically called by CSLA.NET when your object should associate
        /// per-type validation rules with its properties.
        /// </remarks>
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            // Property Business Rules

            // StartDate
            BusinessRules.AddRule(new DateNotInFuture(StartDateProperty) { MessageDelegate = () => Resources.DateNotInFuture });
            // EndDate
            BusinessRules.AddRule(new DateNotInFuture(EndDateProperty) { MessageDelegate = () => Resources.DateNotInFuture });
            BusinessRules.AddRule(new GreaterThanOrEqual(EndDateProperty, StartDateProperty) { MessageDelegate = () => Resources.EndDateGreaterThanOrEqualStartDate, Priority = 1 });
            // FullText
            BusinessRules.AddRule(new CollapseWhiteSpace(FullTextProperty));
            BusinessRules.AddRule(new ThreePartsFullText(FullTextProperty) { MessageDelegate = () => Resources.ThreePartsFullText, Priority = 1 });
            // SelectedFastDateIndex
            BusinessRules.AddRule(new FastDateToDateRange(SelectedFastDateIndexProperty));

            AddBusinessRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom shared business rules.
        /// </summary>
        partial void AddBusinessRulesExtend();

        #endregion

    }
}
