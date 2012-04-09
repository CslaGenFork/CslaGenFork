/*
License: The MIT License (MIT) 
Copyright (c) 2011 CslaGenFork project.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, 
modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.  
*/

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RangeMM.cs" company="">
//   Copyright (c) 2011 CslaGenFork project. Website: http://cslagenfork.codeplex.com/
// </copyright>
// <summary>
//   Business rule for checking a value is between a minimum and a maximum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using CslaGenFork.Rules.Properties;

namespace CslaGenFork.Rules.CompareFieldsRules
{
    /// <summary>
    /// Business rule for checking a value is between a minimum and a maximum.
    /// </summary>
    /// <typeparam name="MIN">The type of the minimum value.</typeparam>
    /// <typeparam name="MAX">The type of the maximum value.</typeparam>
    public class Range<MIN, MAX> : CommonRuleWithMessage
        where MIN : IComparable
        where MAX : IComparable
    {
        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        public MIN Min { get; private set; }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public MAX Max { get; private set; }

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
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        public Range(IPropertyInfo primaryProperty, MIN min, MAX max)
            : base(primaryProperty)
        {
            Max = max;
            Min = min;
            RuleUri.AddQueryParameter("max", max.ToString());
            RuleUri.AddQueryParameter("min", min.ToString());
            InputProperties = new List<IPropertyInfo> {primaryProperty};
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <param name="message">The minimum error message text.</param>
        public Range(IPropertyInfo primaryProperty, MIN min, MAX max, string message)
            : this(primaryProperty, min, max)
        {
            MessageText = message;
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <param name="messageDelegate">The minimum error message function.</param>
        public Range(IPropertyInfo primaryProperty, MIN min, MAX max, Func<string> messageDelegate)
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
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            var value = (IComparable) context.InputPropertyValues[PrimaryProperty];
            int minResult = value.CompareTo(Min);
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
