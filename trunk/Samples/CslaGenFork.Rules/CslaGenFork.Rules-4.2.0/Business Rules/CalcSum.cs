﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CalcSum.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   CalcSum rule will set primary property to the sum of all supplied properties.
//   Rule should run on client when a property is changed or when CheckRules is called.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;
using System.Linq;
using Csla.Core;
using Csla.Rules;

namespace CslaGenFork.Rules.TransformationRules
{
    /// <summary>
    /// CalcSum rule will set primary property to the sum of all supplied properties.
    ///
    /// Rule should run on client when a property is changed or when CheckRules is called.
    /// </summary>
    /// <remarks>
    /// As InputProperties is now regarded as Dependency you will not need to add a Dependency
    /// rule to each input field in order to rerun calculation whenever on of the inputs is changed.
    /// </remarks>
    public class CalcSum : PropertyRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalcSum"/> class.
        /// </summary>
        /// <param name="primaryProperty">
        /// The primary property.
        /// </param>
        /// <param name="inputProperties">
        /// The input properties.
        /// </param>
        public CalcSum(IPropertyInfo primaryProperty, params IPropertyInfo[] inputProperties)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo>();
            InputProperties.AddRange(inputProperties);

            CanRunOnServer = false;
        }

        /// <summary>
        /// Business rule implementation.
        /// </summary>
        /// <param name="context">
        /// Rule context object.
        /// </param>
        protected override void Execute(RuleContext context)
        {
            // Use linq Sum to calculate the sum value
            var sum = context.InputPropertyValues.Sum(property => (dynamic) property.Value);

            // add calculated value to OutValues
            // When rule is completed the RuleEngine will update businessobject
            context.AddOutValue(PrimaryProperty, sum);
        }
    }
}
