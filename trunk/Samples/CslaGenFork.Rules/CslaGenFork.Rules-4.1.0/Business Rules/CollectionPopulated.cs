/*
License: The MIT License (MIT) 
Copyright (c) 2011 CslaGenFork project.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, 
modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.  
*/

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionPopulated.cs" company="">
//   Copyright (c) 2011 CslaGenFork project. Website: http://cslagenfork.codeplex.com/
// </copyright>
// <summary>
//   Business rule for checking a child collection has a least one item.
// </summary>
// <remarks>
//   If no child collections are specified, will check every child collection.
//   Rule should run on client when a property is changed or when CheckRules is called.
// </remarks>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Csla;
using Csla.Core;
using Csla.Rules;

namespace CslaGenFork.Rules.ObjectRules
{
    /// <summary>
    /// Business rule for checking a child collection has a least one item.<br/>
    /// Rule should run on client when a property is changed or when CheckRules is called.
    /// </summary>
    /// <remarks>
    /// If no child collections are specified, will check every child collection.
    /// </remarks>
    public class CollectionPopulated : CommonObjectRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionPopulated"/> class.
        /// </summary>
        /// <param name="message">The error message text.</param>
        public CollectionPopulated(string message)
        {
            MessageText = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionPopulated"/> class.
        /// </summary>
        /// <param name="messageDelegate">The error message function.</param>
        public CollectionPopulated(Func<string> messageDelegate)
        {
            MessageDelegate = messageDelegate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionPopulated"/> class.
        /// </summary>
        /// <param name="chilCollectionProperties">The child collections properties to check.</param>
        public CollectionPopulated(params IPropertyInfo[] chilCollectionProperties)
        {
            if (InputProperties == null)
                InputProperties = new List<IPropertyInfo>();
            InputProperties.AddRange(chilCollectionProperties);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionPopulated"/> class.
        /// </summary>
        /// <param name="message">The error message text.</param>
        /// <param name="chilCollectionProperties">The child collections properties to check.</param>
        public CollectionPopulated(string message, params IPropertyInfo[] chilCollectionProperties)
            : this(chilCollectionProperties)
        {
            MessageText = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionPopulated"/> class.
        /// </summary>
        /// <param name="messageDelegate">The error message function.</param>
        /// <param name="chilCollectionProperties">The child collections properties to check.</param>
        public CollectionPopulated(Func<string> messageDelegate, params IPropertyInfo[] chilCollectionProperties)
            : this(chilCollectionProperties)
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
            return HasMessageDelegate ? base.GetMessage() : "The collection(s) - {0} - must have a at least one item.";
        }

        /// <summary>
        /// Business rule implementation.
        /// </summary>
        /// <param name="context">Rule context object.</param>
        protected override void Execute(RuleContext context)
        {
            var emptyCollections = new List<string>();

            if (context.InputPropertyValues.Count == 0)
            {
                var target = (BusinessBase)context.Target;
                foreach (var field in target.GetType().GetFields(
                    BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.NonPublic))
                {
                    var value = field.GetValue(target) as IPropertyInfo;
                    if (value != null)
                    {
                        if ((value.RelationshipType & RelationshipTypes.Child) == RelationshipTypes.Child)
                            emptyCollections.Add(value.FriendlyName);
                    }
                }
            }
            else
            {
                foreach (var field in context.InputPropertyValues)
                {
                    if (field.Value != null)
                    {
                        var childCollection = (IList)field.Value;
                        if (childCollection.Count == 0)
                            emptyCollections.Add(field.Key.FriendlyName);
                    }
                    else
                        emptyCollections.Add(field.Key.FriendlyName);
                }
            }

            var unpopulatedNames = String.Join(", ", emptyCollections);
            var errorMessage = string.Format(GetMessage(), unpopulatedNames);
            context.Results.Add(new RuleResult(RuleName, PrimaryProperty, errorMessage) { Severity = Severity });
        }
    }
}
