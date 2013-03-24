// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonObjectRule.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Adapted from CommonRules.cs that is part of Csla 4.2.0
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using Csla.Rules;

namespace CslaGenFork.Rules
{
    /// <summary>
    /// Base class used to create common object rules.
    /// </summary>
    public abstract class CommonObjectRule : ObjectRuleEx
    {
        /// <summary>
        /// Gets or sets the severity for this rule.
        /// </summary>
        /// <value>The rule severity.</value>
        public RuleSeverity Severity { get; set; }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        protected CommonObjectRule()
        {
            Severity = RuleSeverity.Error;
        }
    }
}
