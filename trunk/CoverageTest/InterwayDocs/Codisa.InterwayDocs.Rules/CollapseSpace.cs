// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollapseSpace.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Removes leading, trailing and duplicate spaces.
//   Rule should run on client when a property is changed or when CheckRules is called.
//   Rule must run before any validation rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Text.RegularExpressions;
using Csla.Core;
using Csla.Rules;

namespace Codisa.InterwayDocs.Rules
{
    /// <summary>
    /// Removes leading, trailing and duplicate spaces.<br/>
    /// Rule should run on client when a property is changed or when CheckRules is called.
    /// Rule must run before any validation rules.
    /// </summary>
    public class CollapseSpace : PropertyRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollapseSpace"/> class.
        /// </summary>
        /// <param name="primaryProperty">
        /// The primary property.
        /// </param>
        public CollapseSpace(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};

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
            var value = (string) context.InputPropertyValues[PrimaryProperty];
            if (string.IsNullOrEmpty(value)) return;

            var newValue = value.Trim(' ');
            var r = new Regex(@" +");
            newValue = r.Replace(newValue, @" ");
            context.AddOutValue(newValue);
        }
    }
}