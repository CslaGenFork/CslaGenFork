using System;
using System.Collections.Generic;
using System.Text;
using CslaGenerator.Metadata;

namespace UnitTests
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine(RelationRulesCsla30.IsNoParentAllowed(CslaObjectType.EditableRoot));
        }
    }
}
