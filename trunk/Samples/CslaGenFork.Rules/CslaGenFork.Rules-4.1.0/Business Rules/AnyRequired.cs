// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnyRequired.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Check that at least one of the fields of type string or smartvalue field has a value.
//   Code must also add Dependency rules from each additional properties to primary property.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using Csla.Core;
using Csla.Rules;

namespace CslaGenFork.Rules.ShortCircuitingRules
{
    /// <summary>
    /// Check that at least one of the fields of type string or smartvalue field has a value.
    /// Code must also add Dependency rules from each additional properties to primary property.
    /// </summary>
    public class AnyRequired : CommonRuleWithMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnyRequired"/> class.
        /// </summary>
        /// <param name="primaryProperty">The primary property.</param>
        /// <param name="additionalProperties">The additional properties.</param>
        public AnyRequired(IPropertyInfo primaryProperty, params IPropertyInfo[] additionalProperties)
            : base(primaryProperty)
        {
            if (InputProperties == null)
                InputProperties = new List<IPropertyInfo>();
            InputProperties.AddRange(additionalProperties);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyRequired"/> class.
        /// </summary>
        /// <param name="primaryProperty">The primary property.</param>
        /// <param name="message">The error message text.</param>
        /// <param name="additionalProperties">The additional properties.</param>
        public AnyRequired(IPropertyInfo primaryProperty, string message, params IPropertyInfo[] additionalProperties)
            : this(primaryProperty, additionalProperties)
        {
            MessageText = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyRequired"/> class.
        /// </summary>
        /// <param name="primaryProperty">The primary property.</param>
        /// <param name="messageDelegate">The error message function.</param>
        /// <param name="additionalProperties">The additional properties.</param>
        public AnyRequired(IPropertyInfo primaryProperty, Func<string> messageDelegate,
                           params IPropertyInfo[] additionalProperties)
            : this(primaryProperty, additionalProperties)
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
            return HasMessageDelegate ? base.GetMessage() : "At least one of the fields {0} must have a value";
        }

        /// <summary>
        /// Executes the rule in specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Execute(RuleContext context)
        {
            foreach (var field in context.InputPropertyValues)
            {
                // smartfields have their own implementation of IsEmpty
                var smartField = field.Value as ISmartField;

                if (smartField != null)
                {
                    if (!smartField.IsEmpty) return;
                }
                else if (field.Value != null && !field.Value.Equals(field.Key.DefaultValue)) return;
            }

            var fields = context.InputPropertyValues.Select(p => p.Key.FriendlyName).ToArray();
            var fieldNames = String.Join(", ", fields);
            context.AddErrorResult(string.Format(GetMessage(), fieldNames));
        }
    }
}
