using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for TypeCodeEx.
    /// </summary>
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum TypeCodeEx
    {
        Empty,
        [Description("Custom Type")]
        CustomType,
        Boolean,
        Byte,
        ByteArray,
        Char,
        DateTime,
        DateTimeOffset,
        DBNull,
        Decimal,
        Double,
        Guid,
        Int16,
        Int32,
        Int64,
        Object,
        SByte,
        Single,
        SmartDate,
        String,
        TimeSpan,
        UInt16,
        UInt32,
        UInt64
    }
}