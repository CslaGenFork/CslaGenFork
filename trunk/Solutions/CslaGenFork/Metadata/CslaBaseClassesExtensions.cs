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
                /*case CslaBaseClasses.CommandBaseT:
                    return "T";*/
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
                /*case CslaBaseClasses.CommandBaseT:
                    return false;*/
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
                /*case CslaBaseClasses.CommandBaseT:
                    return true;*/
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
    }
}