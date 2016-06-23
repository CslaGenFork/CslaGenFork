using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for CslaObjectType.
    /// </summary>
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum CslaObjectType
    {
        EditableRoot = 1,
        EditableChild,
        EditableSwitchable,
        DynamicEditableRoot,
        EditableRootCollection,
        DynamicEditableRootCollection,
        EditableChildCollection,
        ReadOnlyObject,
        ReadOnlyCollection,
        NameValueList,
        UnitOfWork,
        CriteriaClass,
        BaseClass,
        PlaceHolder
    }
}