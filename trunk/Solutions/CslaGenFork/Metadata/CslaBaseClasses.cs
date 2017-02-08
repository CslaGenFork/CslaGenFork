using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Summary description for CslaBaseClasses.
    /// </summary>
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum CslaBaseClasses
    {
        [Description("None")] None = 0,
        [Description("BusinessBase<T>")] BusinessBaseT = 1,
        [Description("BusinessBindingListBase<T,C>")] BusinessBindingListBaseTC = 2,
        [Description("BusinessListBase<T,C>")] BusinessListBaseTC = 3,
        /*[Description("CommandBase<T>")]
        CommandBaseT = 4,*/
        [Description("DynamicBindingListBase<T>")] DynamicBindingListBaseT = 5,
        [Description("DynamicListBase<T>")] DynamicListBaseT = 6,
        [Description("NameValueListBase<K,V>")] NameValueListBaseKV = 7,
        [Description("ReadOnlyBase<T>")] ReadOnlyBaseT = 8,
        [Description("ReadOnlyBindingListBase<T,C>")] ReadOnlyBindingListBaseTC = 9,
        [Description("ReadOnlyListBase<T,C>")] ReadOnlyListBaseTC = 10
    }
}