using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public enum PersistenceType
    {
        [Description("SQL Connection Manager")]
        SqlConnectionManager = 1,
        [Description("SQL Connection Unshared")]
        SqlConnectionUnshared = 2,
        LinqContext = 3,
        EFContext = 4
    }
}