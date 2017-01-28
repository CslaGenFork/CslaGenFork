// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StopIfAnyAdditionalHasValue.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   If any of the additional properties has a value stop rule processing
//   for this field and make field valid
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;
using System.Linq;
using Csla.Core;
using Csla.Rules;

namespace CslaGenFork.Rules.ShortCircuitingRules
{
    /// <summary>
    /// If any of the additional properties has a value stop rule processing
    /// for this field and make field valid.
    /// </summary>
    public class StopIfAnyAdditionalHasValue : BusinessRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StopIfAnyAdditionalHasValue"/> class.
        /// </summary>
        /// <param name="primaryProperty">The primary property.</param>
        /// <param name="additionalProperties">The additional properties.</param>
        public StopIfAnyAdditionalHasValue(IPropertyInfo primaryProperty, params IPropertyInfo[] additionalProperties)
            : base(primaryProperty)
        {
            if (InputProperties == null) InputProperties = new List<IPropertyInfo> {primaryProperty};
            InputProperties.AddRange(additionalProperties);
        }

        /// <summary>
        /// Executes the rule in specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Execute(RuleContext context)
        {
            var hasValue = false;
            // excludes PrimaryProperty
            foreach (var field in context.InputPropertyValues.Where(p => p.Key != PrimaryProperty))
            {
                // smartfields have their own implementation of IsEmpty
                var smartField = field.Value as ISmartField;

                if (smartField != null)
                {
                    hasValue = !smartField.IsEmpty;
                }
                else if (field.Value != null && !field.Value.Equals(field.Key.DefaultValue))
                {
                    hasValue = true;
                }
            }

            // if hasValue then shortcut rule processing
            if (hasValue) context.AddSuccessResult(true);
        }
    }
}
