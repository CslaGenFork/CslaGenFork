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

    public static class Access
    {
        public static string Convert(PropertyAccess propAccess)
        {
            switch (propAccess)
            {
                case PropertyAccess.IsProtected:
                    return "protected";
                case PropertyAccess.IsInternal:
                    return "internal";
                case PropertyAccess.IsProtectedInternal:
                    return "protected internal";
                case PropertyAccess.IsPrivate:
                    return "private";
                default:
                    return "public";
            }
        }
    }
}