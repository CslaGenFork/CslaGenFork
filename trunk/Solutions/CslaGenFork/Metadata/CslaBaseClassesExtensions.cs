using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    // ReSharper disable InconsistentNaming

    public static class CslaBaseClassesExtensions
    {
        public static string GetGenericArguments(this CslaBaseClasses cslaBaseClass)
        {
            switch (cslaBaseClass)
            {
                case CslaBaseClasses.BusinessBaseT:
                    return "T";
                case CslaBaseClasses.BusinessBindingListBaseTC:
                    return "T,C";
                case CslaBaseClasses.BusinessListBaseTC:
                    return "T,C";
                case CslaBaseClasses.CommandBaseT:
                    return "T";
                case CslaBaseClasses.DynamicBindingListBaseT:
                    return "T";
                case CslaBaseClasses.DynamicListBaseT:
                    return "T";
                case CslaBaseClasses.NameValueListBaseKV:
                    return "K,V";
                case CslaBaseClasses.ReadOnlyBaseT:
                    return "T";
                case CslaBaseClasses.ReadOnlyBindingListBaseTC:
                    return "T,C";
                case CslaBaseClasses.ReadOnlyListBaseTC:
                    return "T,C";
                default:
                    return string.Empty;
            }
        }

        public static string[][] GetWhereClause(this CslaObjectInfo info)
        {
            var cslaBaseClass = info.CslaBaseClass;

            var firstType = string.Empty;
            var firstClass = string.Empty;
            var firstClassInterfaces = string.Empty;
            var secondType = string.Empty;
            var secondClass = string.Empty;
            var secondClassInterfaces = string.Empty;

            if (cslaBaseClass == CslaBaseClasses.BusinessBindingListBaseTC ||
                cslaBaseClass == CslaBaseClasses.BusinessListBaseTC)
            {
                firstType = "T";
                secondType = "C";
                if (info.ItemType != string.Empty)
                {
                    secondClass = info.ItemType;
                }
                else
                    secondClass = new EnumDescriptionOrCaseConverter(typeof(CslaBaseClasses)).
                        ConvertToInvariantString(CslaBaseClasses.BusinessBaseT);
            }
            else if (cslaBaseClass == CslaBaseClasses.ReadOnlyBindingListBaseTC ||
                     cslaBaseClass == CslaBaseClasses.ReadOnlyListBaseTC)
            {
                firstType = "T";
                secondType = "C";
                if (info.ItemType != string.Empty)
                {
                    secondClass = info.ItemType;
                }
                else
                    secondClass = new EnumDescriptionOrCaseConverter(typeof(CslaBaseClasses)).
                        ConvertToInvariantString(CslaBaseClasses.ReadOnlyBaseT);
            }
            else if (cslaBaseClass == CslaBaseClasses.DynamicBindingListBaseT ||
                     cslaBaseClass == CslaBaseClasses.DynamicListBaseT)
            {
                firstType = "T";
                if (info.ItemType != string.Empty)
                {
                    firstClass = info.ItemType;
                }
                else
                    firstClass = new EnumDescriptionOrCaseConverter(typeof(CslaBaseClasses)).
                        ConvertToInvariantString(CslaBaseClasses.BusinessBaseT);

                if (!firstClass.EndsWith("<T>"))
                    firstClass = string.Format("{0}<T>", firstClass);
            }
            else if (cslaBaseClass == CslaBaseClasses.NameValueListBaseKV)
            {
                // return empty arrays
                return new[] {new string[] {}};
            }

            if (firstClass == string.Empty)
            {
                firstType = "T";
                firstClass = info.GenericName;
                firstClassInterfaces = info.GetObjectInterfaces();
            }

            firstClass = firstClass.Replace(",", ", ");

            if (secondClass == string.Empty)
                return new[] {new[] {firstType, firstClass, firstClassInterfaces}};

            secondClass = secondClass.Replace("<T>", "<C>");
            if (!secondClass.EndsWith("<C>"))
                secondClass = string.Format("{0}<C>", secondClass);

            return new[]
            {
                new[] {firstType, firstClass, firstClassInterfaces},
                new[] {secondType, secondClass, secondClassInterfaces}
            };
        }

        public static string NonGenericBaseClass(this CslaBaseClasses cslaBaseClass)
        {
            var result = new EnumDescriptionOrCaseConverter(typeof(CslaBaseClasses)).
                ConvertToInvariantString(cslaBaseClass);

            return result.Replace(string.Format("<{0}>", GetGenericArguments(cslaBaseClass)), string.Empty);
        }

        public static bool IsListBaseClass(this CslaBaseClasses cslaBaseClass)
        {
            switch (cslaBaseClass)
            {
                case CslaBaseClasses.BusinessBaseT:
                    return false;
                case CslaBaseClasses.BusinessBindingListBaseTC:
                    return true;
                case CslaBaseClasses.BusinessListBaseTC:
                    return true;
                case CslaBaseClasses.CommandBaseT:
                    return false;
                case CslaBaseClasses.DynamicBindingListBaseT:
                    return true;
                case CslaBaseClasses.DynamicListBaseT:
                    return true;
                case CslaBaseClasses.NameValueListBaseKV:
                    return false;
                case CslaBaseClasses.ReadOnlyBaseT:
                    return false;
                case CslaBaseClasses.ReadOnlyBindingListBaseTC:
                    return true;
                case CslaBaseClasses.ReadOnlyListBaseTC:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsNotListBaseClass(this CslaBaseClasses cslaBaseClass)
        {
            return !cslaBaseClass.IsListBaseClass();
        }

        public static bool IsObjectBaseClass(this CslaBaseClasses cslaBaseClass)
        {
            switch (cslaBaseClass)
            {
                case CslaBaseClasses.BusinessBaseT:
                    return true;
                case CslaBaseClasses.BusinessBindingListBaseTC:
                    return false;
                case CslaBaseClasses.BusinessListBaseTC:
                    return false;
                case CslaBaseClasses.CommandBaseT:
                    return true;
                case CslaBaseClasses.DynamicBindingListBaseT:
                    return false;
                case CslaBaseClasses.DynamicListBaseT:
                    return false;
                case CslaBaseClasses.NameValueListBaseKV:
                    return false;
                case CslaBaseClasses.ReadOnlyBaseT:
                    return true;
                case CslaBaseClasses.ReadOnlyBindingListBaseTC:
                    return false;
                case CslaBaseClasses.ReadOnlyListBaseTC:
                    return false;
                default:
                    return true;
            }
        }

        public static bool IsNotObjectBaseClass(this CslaBaseClasses cslaBaseClass)
        {
            return !cslaBaseClass.IsObjectBaseClass();
        }

        public static bool IsDynamicEditableRootCollection(this CslaBaseClasses cslaBaseClass)
        {
            if (cslaBaseClass == CslaBaseClasses.DynamicBindingListBaseT ||
                cslaBaseClass == CslaBaseClasses.DynamicListBaseT)
                return true;

            return false;
        }

        public static bool IsNotDynamicEditableRootCollection(this CslaBaseClasses cslaBaseClass)
        {
            return !cslaBaseClass.IsDynamicEditableRootCollection();
        }
    }
}