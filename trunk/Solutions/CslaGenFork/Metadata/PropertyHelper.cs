using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CslaGenerator.Metadata
{
    public static class PropertyHelper
    {
        public static string TidyAllowSpaces(string prop)
        {
            prop = prop.Trim().Replace("\r", "").Replace("\n", "");
            while (prop.Contains("  "))
            {
                prop = prop.Replace("  ", " ");
            }
            return prop;
        }

        public static string[] TidyAllowSpaces(string[] propArray)
        {
            for (var item = 0; item < propArray.Length; item++)
            {
                propArray[item] = TidyAllowSpaces(propArray[item]);
            }
            return propArray;
        }

        public static string Tidy(string prop)
        {
            prop = TidyAllowSpaces(prop);
            return prop.Replace(" ", "_");
        }

        public static string[] Tidy(string[] propArray)
        {
            for (var item = 0; item < propArray.Length; item++)
            {
                propArray[item] = Tidy(propArray[item]);
            }
            return propArray;
        }

        public static string TidyFilename(string prop)
        {
            prop = Tidy(prop);
            Regex rx = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars())) + "]");
            prop = rx.Replace(prop, ".");
            return prop.Replace(" ", "_");
        }

        public static string[] TidyFilename(string[] propArray)
        {
            for (var item = 0; item < propArray.Length; item++)
            {
                propArray[item] = TidyFilename(propArray[item]);
            }
            return propArray;
        }

        public static string TidyXML(string prop)
        {
            return prop.Trim().Replace("  ", " ").Replace("\n\n", "\n").Replace("\n", "\r\n");
        }

        public static string TidyInteger(string prop)
        {
            return Regex.Replace(prop, @"\D+", "", RegexOptions.Singleline);
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
