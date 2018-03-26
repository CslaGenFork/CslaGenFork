using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace Codisa.InterwayDocs.Rules
{
    /// <summary>
    /// Business rule for checking the FullText property has no more than three parts.
    /// </summary>
    public class ThreePartsFullText : CommonBusinessRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThreePartsFullText"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        public ThreePartsFullText(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreePartsFullText"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        /// <param name="message">The error message text.</param>
        public ThreePartsFullText(IPropertyInfo primaryProperty, string message)
            : this(primaryProperty)
        {
            MessageText = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreePartsFullText"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        /// <param name="messageDelegate">The error message function.</param>
        public ThreePartsFullText(IPropertyInfo primaryProperty, Func<string> messageDelegate)
            : this(primaryProperty)
        {
            MessageDelegate = messageDelegate;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>
        /// The error message.
        /// </returns>
        protected override string GetMessage()
        {
            return HasMessageDelegate ? base.GetMessage() : "Não pode usar mais de 3 palavras.";
        }

        /// <summary>
        /// Business rule implementation.
        /// </summary>
        /// <param name="context">Rule context object.</param>
        protected override void Execute(RuleContext context)
        {
            object value = context.InputPropertyValues[PrimaryProperty];
            var message = string.Format(GetMessage(), PrimaryProperty.FriendlyName);

            var newValue = Convert.ToString(value);

            var words = newValue.Split(' ');
            if (words.Length > 3)
            {
                context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message)
                {
                    Severity = RuleSeverity.Error
                });
            }
            else
            {
                context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message)
                {
                    Severity = RuleSeverity.Information
                });
            }

            context.AddOutValue(newValue);
        }
    }
}