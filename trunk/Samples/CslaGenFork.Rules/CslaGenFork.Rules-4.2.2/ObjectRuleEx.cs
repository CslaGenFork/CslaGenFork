// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectRuleEx.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Adapted from ObjectRule.cs and PropertyRule.cs that are part of Csla 4.2.0
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using Csla.Core;
using Csla.Properties;
using Csla.Rules;

namespace CslaGenFork.Rules
{
    /// <summary>
    /// Base class for an object rule 
    /// </summary>
    public abstract class ObjectRuleEx : BusinessRule
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
        /// Initializes a new instance of the <see cref="ObjectRuleEx"/> class.
        /// </summary>
        protected ObjectRuleEx()
        {
            CanRunOnServer = true;
            CanRunInCheckRules = true;
        }

        /// <summary>
        /// Gets or sets the primary property affected by this rule.
        /// Will always return null.
        /// Will throw ArgumentException if set to anything but null.
        /// </summary>
        /// <value>The primary property.</value>
        public override IPropertyInfo PrimaryProperty
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    throw new ArgumentException(Resources.ObjectRulesCannotSetPrimaryProperty, "PrimaryProperty");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can run in logical serverside data portal.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can run logical serverside data portal; otherwise, <c>false</c>.
        /// </value>
        public bool CanRunOnServer
        {
            get { return (RunMode & RunModes.DenyOnServerSidePortal) == 0; }
            set
            {
                if (value && !CanRunOnServer)
                {
                    RunMode = RunMode ^ RunModes.DenyOnServerSidePortal;
                }
                else if (!value && CanRunOnServer)
                {
                    RunMode = RunMode | RunModes.DenyOnServerSidePortal;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can run when CheckRules is called on BO.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can run when CheckRules is called; otherwise, <c>false</c>.
        /// </value>
        public bool CanRunInCheckRules
        {
            get { return (RunMode & RunModes.DenyCheckRules) == 0; }
            set
            {
                if (value && !CanRunInCheckRules)
                {
                    RunMode = RunMode ^ RunModes.DenyCheckRules;
                }
                else if (!value && CanRunInCheckRules)
                {
                    RunMode = RunMode | RunModes.DenyCheckRules;
                }
            }
        }
    }
}
