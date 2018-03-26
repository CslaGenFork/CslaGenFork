// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GreaterThanOrEqual.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Validates that PrimaryProperty is greater than or equal compareToProperty
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace Codisa.InterwayDocs.Rules
{
    /// <summary>
    /// Validates that PrimaryProperty is greater than or equal compareToProperty,
    /// but only when the PrimaryProperty has a value.
    /// </summary>
    public class GreaterThanOrEqual : CommonBusinessRule
    {
        /// <summary>
        /// Gets or sets CompareTo.
        /// </summary>
        private IPropertyInfo CompareTo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GreaterThanOrEqual"/> class.
        /// </summary>
        /// <param name="primaryProperty">
        /// The primary property.
        /// </param>
        /// <param name="compareToProperty">
        /// The compare to property.
        /// </param>
        public GreaterThanOrEqual(IPropertyInfo primaryProperty, IPropertyInfo compareToProperty)
            : base(primaryProperty)
        {
            CompareTo = compareToProperty;
            InputProperties = new List<IPropertyInfo> {primaryProperty, compareToProperty};
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>
        /// The error message.
        /// </returns>
        protected override string GetMessage()
        {
            return HasMessageDelegate ? base.GetMessage() : "{0} must be greater than or equal to {1}";
        }

        /// <summary>
        /// Does the check for primary propert less than or equal to the compareTo property
        /// </summary>
        /// <param name="context">
        /// Rule context object.
        /// </param>
        protected override void Execute(RuleContext context)
        {
            var value1 = (IComparable) context.InputPropertyValues[PrimaryProperty];
            var value2 = (IComparable) context.InputPropertyValues[CompareTo];

            if (!string.IsNullOrEmpty(Convert.ToString(value1)) && value1.CompareTo(value2) < 0)
            {
                context.Results.Add(new RuleResult(RuleName, PrimaryProperty,
                    string.Format(GetMessage(), PrimaryProperty.FriendlyName, CompareTo.FriendlyName, value2))
                {
                    Severity = Severity
                });
            }
        }
    }
}