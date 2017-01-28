// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyFrom.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Establishes a dependency from properties to PrimaryProperty, raising NotifyPropertyChanged and re-running the 
//   rules for PrimaryProperty whenever one of the dependencyProperties is changed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;

namespace CslaGenFork.Rules.ShortCircuitingRules
{
    /// <summary>
    /// A rule that establishes a dependency from properties to PrimaryProperty.
    /// The rules for PrimaryProperty will be rerun whenever one of the dependencyProperties is changed.
    /// NotifyPropertyChanged will also be raised for PrimaryProperty when any of input properties is changed. 
    /// </summary>
    public class DependencyFrom : BusinessRule
    {
        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Primary property for the rule.</param>
        /// <param name="dependencyProperties">Dependent properties.</param>
        /// <remarks>
        /// When rules are run for one of the dependency properties the rules for primary property i rerun.
        /// </remarks>
        public DependencyFrom(IPropertyInfo primaryProperty, params IPropertyInfo[] dependencyProperties)
            : base(primaryProperty)
        {
            if (InputProperties == null)
                InputProperties = new List<IPropertyInfo>();
            InputProperties.AddRange(dependencyProperties);
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Primary property for the rule.</param>
        /// <param name="dependencyProperty">The dependency property.</param>
        /// <param name="isBiDirectional">if set to <c>true</c> [is bi directional].</param>
        /// <remarks>
        /// When rules are run for one of the dependency properties the rules for primary property i rerun.
        /// </remarks>
        public DependencyFrom(IPropertyInfo primaryProperty, IPropertyInfo dependencyProperty, bool isBiDirectional)
            : base(primaryProperty)
        {
            if (InputProperties == null)
                InputProperties = new List<IPropertyInfo>();
            InputProperties.Add(dependencyProperty);
            if (isBiDirectional)
                AffectedProperties.Add(dependencyProperty);
        }
    }
}
