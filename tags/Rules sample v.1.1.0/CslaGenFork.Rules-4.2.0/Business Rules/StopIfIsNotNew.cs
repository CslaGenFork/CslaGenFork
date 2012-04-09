// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StopIfIsNotNew.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Shorcircuits rule processing if object is not new.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using Csla.Core;
using Csla.Rules;

namespace CslaGenFork.Rules.ShortCircuitingRules
{
    /// <summary>
    /// Shorcircuits rule processing if object is not new.
    /// </summary>
    public class StopIfIsNotNew : PropertyRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StopIfIsNotNew"/> class.
        /// </summary>
        /// <param name="primaryProperty">
        /// The primary property.
        /// </param>
        public StopIfIsNotNew(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Execute(RuleContext context)
        {
            var target = (ITrackStatus) context.Target;
            if (!target.IsNew)
            {
                context.AddSuccessResult(true);
            }
        }
    }
}
