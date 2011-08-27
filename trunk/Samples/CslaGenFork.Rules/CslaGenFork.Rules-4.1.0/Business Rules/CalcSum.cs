// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CalcSum.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   CalcSum rule will set PrimaryProperty to the sum of all supplied properties.
//   Rule should run on client when a property is changed or when CheckRules is called.
//   For use under Csla 4.0.1 or previous versions, 
//   code must also add Dependency rules from each additional properties to PrimaryProperty
//   in order to rerun calculation whenever one of the inputs is changed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;
using System.Linq;
using Csla.Core;
using Csla.Rules;

namespace CslaGenFork.Rules.TransformationRules
{
    /// <summary>
    /// CalcSum rule will set PrimaryProperty to the sum of all supplied properties.<br/>
    /// Rule should run on client when a property is changed or when CheckRules is called.<br/>
    /// For use under Csla 4.0.1 or previous versions, 
    /// code must also add Dependency rules from each additional properties to PrimaryProperty
    /// in order to rerun calculation whenever one of the inputs is changed.
    /// </summary>
    public class CalcSum : CommonRuleWithMessage
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
