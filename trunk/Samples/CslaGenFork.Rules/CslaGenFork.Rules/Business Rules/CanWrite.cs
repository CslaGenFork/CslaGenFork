﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CanWrite.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Gateway rule that will only call inner rule when uuser can edit property
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using Csla.Core;
using Csla.Rules;

namespace CslaGenFork.Rules.GatewayRules
{
    /// <summary>
    /// Gateway rule that will only call inner rule when uuser can edit property
    /// </summary>
    public class CanWrite : PropertyRule
    {
        /// <summary>
        /// Gets the inner rule.
        /// </summary>
        /// <value>The inner rule.</value>
        public IBusinessRule InnerRule { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanWrite"/> class.
        /// </summary>
        /// <param name="primaryProperty">
        /// The primary property.
        /// </param>
        /// <param name="innerRule">
        /// The inner rule.
        /// </param>
        public CanWrite(IPropertyInfo primaryProperty, IBusinessRule innerRule)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            InnerRule = innerRule;
            RuleUri.AddQueryParameter("rule", Uri.EscapeUriString(InnerRule.RuleName));

            // merge InnerRule input property list into this rule's list
            if (InnerRule.InputProperties != null)
            {
                InputProperties.AddRange(InnerRule.InputProperties);
            }

            // remove any duplicates
            InputProperties = new List<IPropertyInfo>(InputProperties.Distinct());
            AffectedProperties.AddRange(innerRule.AffectedProperties);
        }

        /// <summary>
        /// Executes the rule
        /// </summary>
        /// <param name="context">
        /// The rule context.
        /// </param>
        protected override void Execute(RuleContext context)
        {
            var target = (BusinessBase) context.Target;

            if (target.CanWriteProperty(PrimaryProperty))
            {
                var chainedContext = context.GetChainedContext(InnerRule);
                InnerRule.Execute(chainedContext);
            }
        }
    }
}
