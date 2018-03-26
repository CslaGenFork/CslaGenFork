using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace Codisa.InterwayDocs.Rules
{
    /// <summary>
    /// Business rule for checking a Document Class property is valid.
    /// </summary>
    public class ClassificationFormat : CommonBusinessRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationFormat"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        public ClassificationFormat(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationFormat"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        /// <param name="message">The error message text.</param>
        public ClassificationFormat(IPropertyInfo primaryProperty, string message)
            : this(primaryProperty)
        {
            MessageText = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationFormat"/> class.
        /// </summary>
        /// <param name="primaryProperty">Primary property for this rule.</param>
        /// <param name="messageDelegate">The error message function.</param>
        public ClassificationFormat(IPropertyInfo primaryProperty, Func<string> messageDelegate)
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
            return HasMessageDelegate ? base.GetMessage() : "{0} está no formato errado.\r\nO formato deve ser \"AAA.AAA\".";
        }

        /// <summary>
        /// Business rule implementation.
        /// </summary>
        /// <param name="context">Rule context object.</param>
        protected override void Execute(RuleContext context)
        {
            object value = context.InputPropertyValues[PrimaryProperty];

            var newValue = Convert.ToString(value);
            if (!string.IsNullOrEmpty(newValue))
            {
                newValue = newValue.Replace(" ", string.Empty);
                newValue = newValue.ToUpper();

                if (!CheckFormat(newValue))
                {
                    var message = string.Format(GetMessage(), PrimaryProperty.FriendlyName);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }

                context.AddOutValue(newValue);
            }
        }

        private static bool CheckFormat(string value)
        {
            if (value.Length != 7)
                return false;

            if (!Regex.IsMatch(value, @"^[A-Z]{3}.[A-Z]{3}$", RegexOptions.Compiled))
                return false;

            return true;
        }
    }
}