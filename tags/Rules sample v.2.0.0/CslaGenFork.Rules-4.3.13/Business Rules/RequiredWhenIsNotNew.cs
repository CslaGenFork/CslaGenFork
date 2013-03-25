// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequiredWhenIsNotNew.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Business rule for for making a Field required when NOT Target.IsNew
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using Csla.Core;
using Csla.Rules.CommonRules;

namespace CslaGenFork.Rules.ConditionalRequired
{
    /// <summary>
    /// Business rule for for making a Field required when NOT Target.IsNew
    /// </summary>
    public class RequiredWhenIsNotNew : Required
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredWhenIsNotNew"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        public RequiredWhenIsNotNew(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredWhenIsNotNew"/> class.
        /// </summary>
        /// <param name="primaryProperty">The primary property.</param>
        /// <param name="message">The message.</param>
        public RequiredWhenIsNotNew(IPropertyInfo primaryProperty, string message)
            : base(primaryProperty, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredWhenIsNotNew"/> class.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        /// <param name="messageDelegate">The localizable message.</param>
        public RequiredWhenIsNotNew(IPropertyInfo primaryProperty, Func<string> messageDelegate)
            : base(primaryProperty, messageDelegate)
        {
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(Csla.Rules.RuleContext context)
        {
            var bb = (BusinessBase) context.Target;
            if (!bb.IsNew)
                base.Execute(context);
        }
    }
}
