// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToUpper.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Converts the property to uppercase string.
//   Rule should run on client when a property is changed or when CheckRules is called.
//   Rule must run before any validation rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;

namespace CslaGenFork.Rules.TransformationRules
{
    /// <summary>
    /// Converts the property to uppercase string.<br/>
    /// Rule should run on client when a property is changed or when CheckRules is called.
    /// Rule must run before any validation rules.
    /// </summary>
    public class ToUpper : PropertyRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToUpper"/> class.
        /// </summary>
        /// <param name="primaryProperty">
        /// The primary property.
        /// </param>
        public ToUpper(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            AffectedProperties.Add(primaryProperty);

            CanRunOnServer = false;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Execute(RuleContext context)
        {
            var value = (string) context.InputPropertyValues[PrimaryProperty];
            context.AddOutValue(PrimaryProperty, value.ToUpper());
        }
    }
}
