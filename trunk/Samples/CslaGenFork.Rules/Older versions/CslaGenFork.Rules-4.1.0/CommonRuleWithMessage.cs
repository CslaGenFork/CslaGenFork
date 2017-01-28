// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonRuleWithMessage.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Adapted from PropertyRule.cs that is part of Csla 4.2.0
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using Csla.Core;
using Csla.Rules.CommonRules;

namespace CslaGenFork.Rules
{
    /// <summary>
    /// Base class.Adapted from PropertyRule.cs that is part of Csla 4.2.0
    /// </summary>
    public abstract class CommonRuleWithMessage : CommonBusinessRule
    {
        /// <summary>
        /// Gets or sets the error message (constant).
        /// </summary>
        /// <value>The error message text.</value>
        public string MessageText
        {
            get { return MessageDelegate.Invoke(); }
            set { MessageDelegate = () => value; }
        }

        /// <summary>
        /// Gets or sets the error message function for this rule.
        /// Use this for localizable messages from a resource file.
        /// </summary>
        /// <value>The error message function.</value>
        public Func<string> MessageDelegate { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has message delegate.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has message delegate; otherwise, <c>false</c>.
        /// </value>
        protected bool HasMessageDelegate
        {
            get { return MessageDelegate != null; }
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>
        /// The error message.
        /// </returns>
        protected virtual string GetMessage()
        {
            return MessageText;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonRuleWithMessage"/> class.
        /// </summary>
        protected CommonRuleWithMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonRuleWithMessage"/> class.
        /// </summary>
        /// <param name="propertyInfo">The property info.</param>
        protected CommonRuleWithMessage(IPropertyInfo propertyInfo)
            : base(propertyInfo)
        {
        }

    }
}

