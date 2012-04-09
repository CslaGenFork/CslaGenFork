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
// <copyright file="DateNotInFuture.cs" company="">
//   Copyright (c) 2011 CslaGenFork project. Website: http://cslagenfork.codeplex.com/
// </copyright>
// <summary>
//   Business rule for checking a date property is valid and not in the future.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace CslaGenFork.Rules.DateRules
{
    /// <summary>
    /// Business rule for checking a date property is valid and not in the future.
    /// </summary>
    public class DateNotInFuture : CommonBusinessRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateNotInFuture"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        public DateNotInFuture(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateNotInFuture"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        /// <param name="message">The error message text.</param>
        public DateNotInFuture(IPropertyInfo primaryProperty, string message)
            : this(primaryProperty)
        {
            MessageText = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateNotInFuture"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        /// <param name="messageDelegate">The error message function.</param>
        public DateNotInFuture(IPropertyInfo primaryProperty, Func<string> messageDelegate)
            : this(primaryProperty)
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
            return HasMessageDelegate ? base.GetMessage() : "{0} can't be in the future.";
        }

        /// <summary>
        /// Business rule implementation.
        /// </summary>
        /// <param name="context">Rule context object.</param>
        protected override void Execute(RuleContext context)
        {
            object value = context.InputPropertyValues[PrimaryProperty];
            if (Convert.ToDateTime(value) > DateTime.Now)
            {
                var message = string.Format(GetMessage(), PrimaryProperty.FriendlyName);
                context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                return;
            }

            try
            {
                if (Convert.ToDateTime(value) >= DateTime.MinValue)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                context.AddErrorResult(string.Format("{0}{1} isn't valid.",
                                                     ex.Message + Environment.NewLine,
                                                     PrimaryProperty.FriendlyName));
            }
        }
    }
}