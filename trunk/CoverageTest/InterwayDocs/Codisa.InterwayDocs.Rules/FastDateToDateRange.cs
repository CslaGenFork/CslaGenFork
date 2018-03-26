using System;
using System.Collections.Generic;
using Csla;
using Csla.Core;
using Csla.Rules;

namespace Codisa.InterwayDocs.Rules
{
    /// <summary>
    /// Converts a fast date option setting into a pair of start date / end date.
    /// </summary>
    public class FastDateToDateRange : PropertyRule
    {
        private DateTime _todayDate = DateTime.Today;

        /// <summary>
        /// Initializes a new instance of the <see cref="FastDateToDateRange" /> class.
        /// </summary>
        /// <param name="primaryProperty">The primary property.</param>
        public FastDateToDateRange(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
        }

        /// <summary>
        /// Takes the fast date option InputProperty and changes the target's start date and end date properties.
        /// </summary>
        /// <param name="context">Rule context object.</param>
        protected override void Execute(RuleContext context)
        {
            var selectedFastDateIndex = (int) context.InputPropertyValues[PrimaryProperty];

            var iCriteriaDates = context.Target as ICriteriaDates;
            if (iCriteriaDates != null)
            {
                var newStartDate = new SmartDate();
                var newEndDate = new SmartDate();

                if (selectedFastDateIndex != 6)
                {
                    switch (selectedFastDateIndex)
                    {
                        case 0:
                            newStartDate = _todayDate.Date;
                            break;
                        case 1:
                            newStartDate = _todayDate.AddDays(-1).Date;
                            newEndDate = _todayDate.AddDays(-1).Date;
                            break;
                        case 2:
                            newStartDate = _todayDate.AddDays(-7).Date;
                            break;
                        case 3:
                            newStartDate = _todayDate.AddDays(-15).Date;
                            break;
                        case 4:
                            newStartDate = _todayDate.AddDays(-30).Date;
                            break;
                        case 5:
                            newStartDate = _todayDate.AddDays(-91).Date;
                            break;
                    }

                    iCriteriaDates.CriteriaStartDate = newStartDate;

                    // reset startup defaults
                    iCriteriaDates.CriteriaEndDate = newEndDate;
                    iCriteriaDates.SelectedDateTypeIndex = 0;
                    iCriteriaDates.FullText = string.Empty;

                    var iHaveArchiveLocation = context.Target as IHaveArchiveLocation;
                    if (iHaveArchiveLocation != null)
                        iHaveArchiveLocation.ArchiveLocation = string.Empty;
                }
            }
        }
    }
}