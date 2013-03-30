using System;

namespace CslaGenerator.Metadata
{
    [Flags]
    public enum CriteriaMergeType
    {
        None = 0,
        Create = 1,
        Get = 2,
        Delete = 4
    }
}
