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
// <copyright file="IsEmptyOrIsInRole.cs" company="">
//   Copyright (c) 2011 CslaGenFork project. Website: http://cslagenfork.codeplex.com/
// </copyright>
// <summary>
//   Authorization rule for checking a Property can be accessed only it was empty
//   (at the time the edit started) or the user has any of the specified roles.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Core;
using Csla.Reflection;
using Csla.Rules;

namespace CslaGenFork.Rules.AuthorizationRules
{
    /// <summary>
    /// Authorization rule for checking a Property can be accessed only it was empty
    /// (at the time the edit started) or the user has any of the specified roles.
    /// </summary>
    public class IsEmptyOrIsInRole : AuthorizationRule
    {
        private readonly List<string> _roles;
        private static object _target;
        private static Dictionary<string, bool> _elements;

        /// <summary>
        /// Gets a value indicating whether the results
        /// of this rule can be cached at the business
        /// object level.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the result of this rule can be cached by the calling code; otherwise, <c>false</c>.
        /// </value>
        public override bool CacheResult
        {
            get { return false; }
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="action">Action this rule will enforce.</param>
        /// <param name="element">Member to be authorized.</param>
        /// <param name="roles">List of allowed roles.</param>
        public IsEmptyOrIsInRole(AuthorizationActions action, IMemberInfo element, List<string> roles)
            : base(action, element)
        {
            _roles = roles;
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="action">Action this rule will enforce.</param>
        /// <param name="element">Member to be authorized.</param>
        /// <param name="roles">List of allowed roles.</param>
        public IsEmptyOrIsInRole(AuthorizationActions action, IMemberInfo element, params string[] roles)
            : base(action, element)
        {
            _roles = new List<string>(roles);
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Authorization context.</param>
        protected override void Execute(AuthorizationContext context)
        {
            if (_target != context.Target)
                _elements = new Dictionary<string, bool>();

            if (!_elements.ContainsKey(Element.Name))
            {
                _target = context.Target;
                var isEmpty = string.IsNullOrEmpty(MethodCaller.CallPropertyGetter(context.Target, Element.Name).ToString());
                _elements.Add(Element.Name, isEmpty);
            }

            if (_elements[Element.Name])
                context.HasPermission = true;
            else
            {
                if (_roles.Count > 0)
                {
                    if (_roles.Any(item => ApplicationContext.User.IsInRole(item)))
                    {
                        context.HasPermission = true;
                    }
                }
                else
                {
                    // if no role specified, allow all roles
                    context.HasPermission = true;
                }
            }
        }
    }
}
