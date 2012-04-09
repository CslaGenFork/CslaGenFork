// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequiredWhenCanWrite.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Business rule for for making a Field required when the user can write.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using Csla.Core;
using Csla.Rules.CommonRules;

namespace CslaGenFork.Rules.ConditionalRequired
{
    /// <summary>
    /// Business rule for for making a Field required when the user can write.
    /// </summary>
    public class RequiredWhenCanWrite : Required
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredWhenCanWrite"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        public RequiredWhenCanWrite(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredWhenCanWrite"/> class.
        /// </summary>
        /// <param name="primaryProperty">The primary property.</param>
        /// <param name="message">The message.</param>
        public RequiredWhenCanWrite(IPropertyInfo primaryProperty, string message)
            : base(primaryProperty, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredWhenCanWrite"/> class.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        /// <param name="messageDelegate">The localizable message.</param>
        public RequiredWhenCanWrite(IPropertyInfo primaryProperty, Func<string> messageDelegate)
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
            if (bb.CanWriteProperty(PrimaryProperty))
                base.Execute(context);
        }
    }
}
