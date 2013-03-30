namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Access visibility of the property.
    /// </summary>
    public enum PropertyAccess
    {
        IsPublic = 1,
        IsProtected = 2,
        IsInternal = 3,
        IsProtectedInternal = 4,
        IsPrivate = 5
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
