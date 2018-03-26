using System;
using System.Collections.Generic;
using Csla;
using Codisa.InterwayDocs.Rules;
using Codisa.InterwayDocs.DataAccess;
using Codisa.InterwayDocs.DataAccess.SearchObjects;

namespace Codisa.InterwayDocs.Business.SearchObjects
{

    /// <summary>
    /// Search criteria that includes archive location (base class).<br/>
    /// This is a generated <see cref="SearchLocatableCriteriaBase{T}"/> base classe.
    /// </summary>
    [Serializable]
    public abstract partial class SearchLocatableCriteriaBase<T> : SearchCriteriaBase<T>
        where T : SearchLocatableCriteriaBase<T>, IGenericCriteriaInformation, IHaveArchiveLocation
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="ArchiveLocation"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ArchiveLocationProperty = RegisterProperty<string>(p => p.ArchiveLocation, "Archive Location");
        /// <summary>
        /// Gets or sets the Archive Location.
        /// </summary>
        /// <value>The Archive Location.</value>
        public string ArchiveLocation
        {
            get { return GetProperty(ArchiveLocationProperty); }
            set { SetProperty(ArchiveLocationProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchLocatableCriteriaBase{T}"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SearchLocatableCriteriaBase()
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

            // ArchiveLocation
            BusinessRules.AddRule(new CollapseWhiteSpace(ArchiveLocationProperty));

            AddBusinessRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom shared business rules.
        /// </summary>
        partial void AddBusinessRulesExtend();

        #endregion

    }
}
