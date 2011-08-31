// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Range.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Business rule for checking a value is between a minimum and a maximum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using CslaGenFork.Rules.Properties;

namespace CslaGenFork.Rules.CompareFieldsRules
{
    /// <summary>
    /// Business rule for checking a value is between a minimum and a maximum.
    /// </summary>
    public class Range : CommonBusinessRule
    {
        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        public IComparable Min { get; private set; }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public IComparable Max { get; private set; }

        /// <summary>
        /// Gets or sets the format string used
        /// to format the minimum and maximum values.
        /// </summary>
        /// <value>
        /// The format string used
        /// to format the minimum and maximum values.
        /// </value>
        public string Format { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> class.
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">
        /// Property to which the rule applies.
        /// </param>
        /// <param name="min">
        /// Min value.
        /// </param>
        /// <param name="max">
        /// Max value.
        /// </param>
        public Range(IPropertyInfo primaryProperty, IComparable min, IComparable max)
            : base(primaryProperty)
        {
            Max = max;
            Min = min;
            RuleUri.AddQueryParameter("max", max.ToString());
            RuleUri.AddQueryParameter("min", min.ToString());
            InputProperties = new List<IPropertyInfo> {primaryProperty};
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> class.
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">
        /// Property to which the rule applies.
        /// </param>
        /// <param name="min">
        /// Min value.
        /// </param>
        /// <param name="max">
        /// Max value.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public Range(IPropertyInfo primaryProperty, IComparable min, IComparable max, string message)
            : this(primaryProperty, min, max)
        {
            MessageText = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> class.
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">
        /// Property to which the rule applies.
        /// </param>
        /// <param name="min">
        /// Min value.
        /// </param>
        /// <param name="max">
        /// Max value.
        /// </param>
        /// <param name="messageDelegate">
        /// The message delegate.
        /// </param>
        public Range(IPropertyInfo primaryProperty, IComparable min, IComparable max, Func<string> messageDelegate)
            : this(primaryProperty, min, max)
        {
            MessageDelegate = messageDelegate;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>
        /// The error message.
        /// </returns>
        protected override string GetMessage()
        {
            return HasMessageDelegate ? base.GetMessage() : Resources.RangeRule;
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">
        /// Rule context.
        /// </param>
        protected override void Execute(RuleContext context)
        {
            var value = (IComparable) context.InputPropertyValues[PrimaryProperty];
            var minResult = value.CompareTo(Min);
            var maxResult = value.CompareTo(Max);

            if ((minResult <= -1) || (maxResult >= 1))
            {
                var minOutValue = string.IsNullOrEmpty(Format)
                                      ? Min.ToString()
                                      : string.Format(string.Format("{{0:{0}}}", Format), Min);
                var maxOutValue = string.IsNullOrEmpty(Format)
                                      ? Max.ToString()
                                      : string.Format(string.Format("{{0:{0}}}", Format), Max);

                var message = string.Format(GetMessage(), PrimaryProperty.FriendlyName, minOutValue, maxOutValue);
                context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
            }
        }
    }
}
