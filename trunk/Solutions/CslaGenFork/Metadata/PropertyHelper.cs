using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CslaGenerator.Metadata
{
    public static class PropertyHelper
    {
        public static string Tidy(string prop)
        {
            return prop.Trim().Replace("  ", " ").Replace("\r", "").Replace("\n", "").Replace(" ", "_");
        }

        public static string[] Tidy(string[] propArray)
        {
            for (var item = 0; item < propArray.Length; item++)
            {
                propArray[item] = propArray[item].Trim().Replace("  ", " ").Replace("\r", "").Replace("\n", "").Replace(" ", "_");
                
            }
            return propArray;
        }

        public static string TidyAllowSpaces(string prop)
        {
            return prop.Trim().Replace("  ", " ").Replace("\r", "").Replace("\n", "");
        }

        public static string[] TidyAllowSpaces(string[] propArray)
        {
            for (var item = 0; item < propArray.Length; item++)
            {
                propArray[item] = propArray[item].Trim().Replace("  ", " ").Replace("\r", "").Replace("\n", "");

            }
            return propArray;
        }

        public static string TidyXML(string prop)
        {
            return prop.Trim().Replace("  ", " ").Replace("\n\n", "\n").Replace("\n", "\r\n");
        }

        public static string TidyInteger(string prop)
        {
            return Regex.Replace(prop, @"\D+","",RegexOptions.Singleline);
        }

        public static string SplitOnCaps(string name)
        {
            var mc = Regex.Matches(name, @"(\P{Lu}+)|(\p{Lu}+\P{Lu}*)");
            var parts = new string[mc.Count];
            for (var i = 0; i < mc.Count; i++)
            {
                parts[i] = mc[i].ToString();
            }
            return string.Join(" ", parts).Replace("_ ", " ");
        }

    }
}
