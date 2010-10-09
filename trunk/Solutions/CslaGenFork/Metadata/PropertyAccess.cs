using System;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Access visibility of the property.
    /// </summary>
    public enum PropertyAccess
    {
        IsPublic,
        IsProtected,
        IsInternal,
        IsProtectedInternal,
        IsPrivate
    }
}
