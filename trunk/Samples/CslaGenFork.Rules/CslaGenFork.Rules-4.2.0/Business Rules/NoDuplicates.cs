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
// <copyright file="NoDuplicates.cs" company="">
//   Copyright (c) 2011 CslaGenFork project. Website: http://cslagenfork.codeplex.com/
// </copyright>
// <summary>
//   Business rule for checking a name property is unique at the parent collection level.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace CslaGenFork.Rules.CollectionRules
{
    /// <summary>
    /// Business rule for checking a name property is unique at the parent collection level.
    /// </summary>
    public class NoDuplicates : CommonBusinessRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoDuplicates"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        public NoDuplicates(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoDuplicates"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        /// <param name="message">The error message text.</param>
        public NoDuplicates(IPropertyInfo primaryProperty, string message)
            : this(primaryProperty)
        {
            MessageText = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoDuplicates"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        /// <param name="messageDelegate">The error message function.</param>
        public NoDuplicates(IPropertyInfo primaryProperty, Func<string> messageDelegate)
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
            return HasMessageDelegate ? base.GetMessage() : "{0} must be unique";
        }

        /// <summary>
        /// Business rule implementation.
        /// </summary>
        /// <param name="context">Rule context object.</param>
        protected override void Execute(RuleContext context)
        {
            var value = context.InputPropertyValues[PrimaryProperty] as string;
            if (value == null)
                return;

            dynamic target = context.Target;
            var parent = target.Parent;
            if (parent != null)
            {
                foreach (var item in parent)
                {
                    System.Reflection.PropertyInfo compare = item.GetType().GetProperty(PrimaryProperty.Name);
                    if (value.ToUpperInvariant() == compare.GetValue(item, null).ToUpperInvariant() &&
                        !(ReferenceEquals(item, target)))
                    {
                        var message = string.Format(GetMessage(), PrimaryProperty.FriendlyName);
                        context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                    }
                }
            }
        }
    }
}
