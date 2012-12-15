using System;

namespace CslaGenerator.Metadata
{
    [Flags]
    public enum CriteriaMergeType
    {
        Create = 0,
        Get = 1,
        Delete = 2,
        All = 4
    }
}
